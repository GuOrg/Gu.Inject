namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Bind overloads.
    /// </summary>
    public sealed partial class Kernel
    {
        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <param name="from">The type to map.</param>
        /// <param name="to">The mapped type.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind(Type from, Type to)
        {
            if (from is null)
            {
                throw new ArgumentNullException(nameof(from));
            }

            if (to is null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            this.BindCore(from, new Binding(to, BindingKind.Map));
            return this;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface, TConcrete>()
            where TConcrete : TInterface
        {
            this.Bind(typeof(TInterface), typeof(TConcrete));
            return this;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TConcrete>()
            where TConcrete : TInterface1, TInterface2
        {
            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
            return this;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TInterface3, TConcrete>()
            where TConcrete : TInterface1, TInterface2, TInterface3
        {
            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
            this.Bind(typeof(TInterface3), typeof(TConcrete));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<T>(T instance)
            where T : class
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.BindCore(typeof(T), new Binding(instance, BindingKind.Instance));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface, TConcrete>(TConcrete instance)
            where TConcrete : class, TInterface
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.Bind(typeof(TInterface), typeof(TConcrete));
            this.BindCore(typeof(TConcrete), new Binding(instance, BindingKind.Instance));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TConcrete>(TConcrete instance)
            where TConcrete : class, TInterface1, TInterface2
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
            this.BindCore(typeof(TConcrete), new Binding(instance, BindingKind.Instance));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TInterface3, TConcrete>(TConcrete instance)
            where TConcrete : class, TInterface1, TInterface2, TInterface3
        {
            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
            this.Bind(typeof(TInterface3), typeof(TConcrete));
            this.BindCore(typeof(TConcrete), new Binding(instance, BindingKind.Instance));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// The instance is owned by the kernel, that is, calling .Dispose() on the kernel disposes the instance, if its type implements IDisposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<T>(Func<T> create)
            where T : class
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.BindCore(typeof(T), new Binding(create, BindingKind.Func));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface, TConcrete>(Func<TConcrete> create)
            where TConcrete : class, TInterface
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.Bind(typeof(TInterface), typeof(TConcrete));
            this.BindCore(typeof(TConcrete), new Binding(create, BindingKind.Func));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TConcrete>(Func<TConcrete> create)
            where TConcrete : class, TInterface1, TInterface2
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
            this.BindCore(typeof(TConcrete), new Binding(create, BindingKind.Func));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TInterface3, TConcrete>(Func<TConcrete> create)
            where TConcrete : class, TInterface1, TInterface2, TInterface3
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.Bind(typeof(TInterface1), typeof(TConcrete));
            this.Bind(typeof(TInterface2), typeof(TConcrete));
            this.Bind(typeof(TInterface3), typeof(TConcrete));
            this.BindCore(typeof(TConcrete), new Binding(create, BindingKind.Func));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<T>(Func<IGetter, T> create)
            where T : class
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.BindCore(typeof(T), new Binding(create, BindingKind.ResolverFunc));
            return this;
        }
    }
}