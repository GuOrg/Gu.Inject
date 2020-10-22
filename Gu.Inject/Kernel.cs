namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A factory for resolving object graphs.
    /// </summary>
    public sealed partial class Kernel : IDisposable, IGetter
    {
        private ConcurrentDictionary<Type, object> created = ConcurrentDictionaryPool<Type, object>.Borrow();
        private ConcurrentDictionary<Type, object>? bindings;

        /// <summary>
        /// This notifies before creating an instance of a type.
        /// </summary>
        public event EventHandler<Type>? Creating;

        /// <summary>
        /// This notifies after creating an instance of a type.
        /// </summary>
        public event EventHandler<object>? Created;

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        public T Get<T>()
            where T : class
        {
            this.ThrowIfDisposed();
            return (T)this.GetCore(typeof(T));
        }

        /// <summary>
        /// Get the singleton instance of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>The singleton instance of <paramref name="type"/>.</returns>
        public object Get(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            this.ThrowIfDisposed();
            return this.GetCore(type);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (this.created is null)
            {
                return;
            }

            var local = this.created;
            this.created = null!;
            foreach (var kvp in local)
            {
                (kvp.Value as IDisposable)?.Dispose();
            }

            ConcurrentDictionaryPool<Type, object>.Return(local);
            ConcurrentDictionaryPool<Type, object>.Return(this.bindings);
        }

        private void BindCore(Type key, object value)
        {
            this.bindings ??= ConcurrentDictionaryPool<Type, object>.Borrow();
            _ = this.bindings.AddOrUpdate(
                key,
                t => value,
                (type, o) => throw new InvalidOperationException($"{type.PrettyName()} already has a binding to {(o as Type)?.PrettyName() ?? o}"));
        }

        private object GetCore(Type type, Node? visited = null)
        {
            if (this.bindings != null &&
                this.bindings.TryGetValue(type, out var bound))
            {
                if (bound is Type boundType)
                {
                    return type == boundType
                               ? this.created.GetOrAdd(type, t => this.Create(t, Ctor.GetFactory(type), visited))
                               : this.GetCore(boundType, visited);
                }

                if (bound is IFactory factory)
                {
                    return this.created.GetOrAdd(type, t => this.Create(t, factory, visited));
                }

                return bound;
            }

            if (type.IsInterface || type.IsAbstract || type.IsValueType)
            {
                throw new NoBindingException(type);
            }

            return this.created.GetOrAdd(type, t => this.Create(t, Ctor.GetFactory(type), visited));
        }

        private object Create(Type type, IFactory factory, Node? visited)
        {
            if (factory.ParameterTypes.Any(p => p.IsArray))
            {
                var message = $"Type {type.PrettyName()} has params argument which is not supported.\r\n" +
                               "Add a binding specifying which how to create an instance.";
                throw new ResolveException(type, message);
            }

            this.Creating?.Invoke(this, type);
            if (factory.ParameterTypes.Count == 0)
            {
                var item = factory.Create(null);
                this.Created?.Invoke(this, item);
                return item;
            }

            if (visited != null)
            {
                if (visited.Contains(type))
                {
                    throw new CircularDependencyException(type);
                }

                visited = visited.Next(type);
            }
            else
            {
                visited = new Node(type);
            }

            try
            {
                var args = new object[factory.ParameterTypes.Count];
                for (var i = 0; i < factory.ParameterTypes.Count; i++)
                {
                    args[i] = this.GetCore(factory.ParameterTypes[i], visited);
                }

                var item = factory.Create(args);
                this.Created?.Invoke(this, item);
                return item;
            }
            catch (ResolveException e)
            {
                throw new ResolveException(type, e);
            }
        }

        private void ThrowIfHasResolved([CallerMemberName] string? caller = null)
        {
            if (this.created.Count != 0)
            {
                throw new InvalidOperationException($"{caller} not allowed after Get.");
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.created is null)
            {
                throw new ObjectDisposedException(nameof(Kernel));
            }
        }

        private class Node
        {
            private readonly Type type;
            private readonly Node? previous;

            internal Node(Type type)
                : this(type, null)
            {
            }

            private Node(Type type, Node? previous)
            {
                this.type = type;
                this.previous = previous;
            }

            internal Node Next(Type next) => new Node(next, this);

            internal bool Contains(Type next)
            {
                if (this.type == next)
                {
                    return true;
                }

                return this.previous?.Contains(next) == true;
            }
        }
    }
}
