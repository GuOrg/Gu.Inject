namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// A factory for resolving object graphs.
    /// </summary>
    /// <typeparam name="TRoot">The root type of the graph to resolve.</typeparam>
    public sealed class Container<TRoot> : IDisposable
    {
        private readonly Getter<TRoot> getter;
        private ConcurrentDictionary<Type, object> map = ConcurrentDictionaryPool<Type, object>.Borrow();

        /// <summary>
        /// Initializes a new instance of the <see cref="Container{TRoot}"/> class.
        /// </summary>
        public Container()
        {
            this.getter = new Getter<TRoot>(this);
        }

        /// <summary>
        /// This notifies before creating an instance of a type.
        /// </summary>
        public event EventHandler<Type> Creating;

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// The instance is owned by the container, that is, calling .Dispose() on the container disposes the instance, if its type implements IDisposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="create">The factory function used to create the instance.</param>
        public Container<TRoot> Bind<T>(Func<T> create)
            where T : class
        {
            if (create == null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.ThrowIfDisposed();
            _ = this.map.AddOrUpdate(
                 typeof(T),
                 _ => Add(),
                 (type, o) => UpdateBinding(type, o));
            return this;

            Func<T> Add() => create;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The container will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the container if disposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="create">The instance to bind.</param>
        public Container<TRoot> Bind<T>(Func<Getter<TRoot>, T> create)
            where T : class
        {
            if (create == null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.ThrowIfDisposed();
            _ = this.map.AddOrUpdate(
                typeof(T),
                _ => Add(),
                (type, o) => UpdateBinding(type, o));
            return this;

            Func<Getter<TRoot>, T> Add() => create;
        }

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        public T Get<T>()
            where T : class
        {
            this.ThrowIfDisposed();

            return (T)this.map.AddOrUpdate(
                typeof(T),
                _ => throw new NoBindingException(typeof(T), new[] { typeof(T) }),
                (t, v) => Create(t, v));

            object Create(Type type, object value)
            {
                switch (value)
                {
                    case T item:
                        return item;
                    case Func<T> func:
                        this.Creating?.Invoke(this, type);
                        return func();
                    case Func<Getter<TRoot>, T> get:
                        this.Creating?.Invoke(this, type);
                        return get(this.getter);
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // ReSharper disable once LocalVariableHidesMember
            var map = this.map;
            this.map = null;
            foreach (var kvp in map)
            {
                (kvp.Value as IDisposable)?.Dispose();
            }

            ConcurrentDictionaryPool<Type, object>.Return(map);
        }

        private static object UpdateBinding(Type type, object o)
        {
            if (type.IsInstanceOfType(o))
            {
                return new InvalidOperationException();
            }

            return new InvalidOperationException($"{type.PrettyName()} already has a binding to {(o as Type)?.PrettyName() ?? o}");
        }

        private void ThrowIfDisposed()
        {
            if (this.map == null)
            {
                throw new ObjectDisposedException(typeof(Container<TRoot>).PrettyName());
            }
        }
    }
}
