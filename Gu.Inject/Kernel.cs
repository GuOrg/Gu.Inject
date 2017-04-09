namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// A factory for resolving object graphs.
    /// </summary>
    public sealed class Kernel : IDisposable
    {
        private ConcurrentDictionary<Type, object> created = ConcurrentDictionaryPool<Type, object>.Borrow();
        private ConcurrentDictionary<Type, object> bindings;

        /// <summary>
        /// This notifies before creating an instance of a type.
        /// </summary>
        public event EventHandler<Type> Resolving;

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        public void Bind<TInterface, TConcrete>()
            where TConcrete : TInterface
        {
            this.Bind(typeof(TInterface), typeof(TConcrete));
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        public void Bind<TInterface1, TInterface2, TConcrete>()
            where TConcrete : TInterface1, TInterface2
        {
            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <param name="from">The type to map.</param>
        /// <param name="to">The mapped type.</param>
        public void Bind(Type from, Type to)
        {
            if (from == null)
            {
                throw new ArgumentNullException(nameof(from));
            }

            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            this.ThrowIfDisposed();
            this.ThrowIfHasResolved();
            this.BindCore(from, to);
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="instance"/> alive until disposed.
        /// <paramref name="instance"/> is not disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="instance">The instance to bind.</param>
        public void Bind<T>(T instance)
            where T : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.ThrowIfDisposed();
            this.ThrowIfHasResolved();
            this.BindCore(typeof(T), instance);
        }

        /// <summary>
        /// Provide an override to a mapping.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type</typeparam>
        public void ReBind<TInterface, TConcrete>()
            where TConcrete : TInterface
        {
            this.ReBind(typeof(TInterface), typeof(TConcrete));
        }

        /// <summary>
        /// Provide an override to a mapping.
        /// </summary>
        /// <param name="from">The type to map.</param>
        /// <param name="to">The mapped type.</param>
        public void ReBind(Type from, Type to)
        {
            this.ThrowIfDisposed();
            this.ThrowIfHasResolved();
            if (this.bindings == null)
            {
                throw new InvalidOperationException($"{from.PrettyName()} does not have a binding.");
            }

            this.bindings.AddOrUpdate(
                from,
                t => throw new InvalidOperationException($"{t.PrettyName()} does not have a binding."),
                (t1, t2) => to);
        }

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/></returns>
        public T Get<T>()
            where T : class
        {
            if (!TypeMap.IsInitialized)
            {
                TypeMap.Initialize(Assembly.GetCallingAssembly());
            }

            return (T)this.Get(typeof(T));
        }

        /// <summary>
        /// Get the singleton instance of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>The singleton instance of <paramref name="type"/>.</returns>
        public object Get(Type type)
        {
            this.ThrowIfDisposed();
            if (!TypeMap.IsInitialized)
            {
                TypeMap.Initialize(Assembly.GetCallingAssembly());
            }

            return this.GetCore(type);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (this.created == null)
            {
                return;
            }

            var local = this.created;
            this.created = null;
            foreach (var kvp in local)
            {
                (kvp.Value as IDisposable)?.Dispose();
            }

            ConcurrentDictionaryPool<Type, object>.Return(local);
            ConcurrentDictionaryPool<Type, object>.Return(this.bindings);
        }

        private void BindCore(Type key, object value)
        {
            if (this.bindings == null)
            {
                lock (this.created)
                {
                    if (this.bindings == null)
                    {
                        this.bindings = ConcurrentDictionaryPool<Type, object>.Borrow();
                    }
                }
            }

            this.bindings.AddOrUpdate(
                key,
                t => value,
                (type, o) => throw new InvalidOperationException($"{type.PrettyName()} already has a binding to {(o as Type)?.PrettyName() ?? o}"));
        }

        private object GetCore(Type type, Node visited = null)
        {
            if (this.bindings != null &&
                this.bindings.TryGetValue(type, out object bound))
            {
                if (bound is Type boundType)
                {
                    return type == boundType
                               ? this.created.GetOrAdd(type, t => this.Create(t, visited))
                               : this.GetCore(boundType, visited);
                }

                return bound;
            }

            if (type.IsInterface || type.IsAbstract)
            {
                var mapped = TypeMap.GetMapped(type);
                if (mapped.Count == 0)
                {
                    throw new NoBindingException(type, mapped);
                }

                if (mapped.Count > 1)
                {
                    throw new AmbiguousBindingException(type, mapped);
                }

                if (mapped[0].IsGenericType && !type.IsGenericType)
                {
                    throw new AmbiguousGenericBindingException(type, mapped);
                }

                return this.GetCore(mapped[0], visited);
            }
            else
            {
                var mapped = TypeMap.GetMapped(type);
                if (mapped.Count != 0)
                {
                    throw new AmbiguousBindingException(type, mapped);
                }
            }

            return this.created.GetOrAdd(type, t => this.Create(t, visited));
        }

        private object Create(Type type, Node visited)
        {
            var info = Ctor.GetInfo(type);
            if (info.ParameterTypes.Any(p => p.IsArray))
            {
                var message = $"Type {type.PrettyName()} has params argument which is not supported.\r\n" +
                               "Add a binding specifying which how to create an instance.";
                throw new ResolveException(type, message);
            }

            this.Resolving?.Invoke(this, type);
            if (info.ParameterTypes.Count == 0)
            {
                return info.Create(null);
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
                var args = new object[info.ParameterTypes.Count];
                for (var i = 0; i < info.ParameterTypes.Count; i++)
                {
                    args[i] = this.GetCore(info.ParameterTypes[i], visited);
                }

                return info.Create(args);
            }
            catch (ResolveException e)
            {
                throw new ResolveException(type, e);
            }
        }

        private void ThrowIfHasResolved([CallerMemberName] string caller = null)
        {
            if (this.created.Count != 0)
            {
                throw new InvalidOperationException($"{caller} not allowed after Get.");
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.created == null)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

        private class Node
        {
            private readonly Type type;
            private readonly Node previous;

            public Node(Type type)
                : this(type, null)
            {
            }

            private Node(Type type, Node previous)
            {
                this.type = type;
                this.previous = previous;
            }

            public Node Next(Type type) => new Node(type, this);

            public bool Contains(Type type)
            {
                if (this.type == type)
                {
                    return true;
                }

                return this.previous?.Contains(type) == true;
            }
        }
    }
}
