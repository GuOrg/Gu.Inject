// ReSharper disable RedundantTypeArgumentsOfMethod
#pragma warning disable IDE0001
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

            this.BindCore(from, Binding.Map(to));
            return this;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="T">The type to map.</typeparam>
        /// <returns>The same instance.</returns>
        public Kernel BindCircular<T>()
            where T : class
        {
            this.BindCore(typeof(T), Binding.Uninitialized<T>());
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
            this.BindCore(typeof(TInterface), Binding.Map<TConcrete>());
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
            this.BindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface2), Binding.Map<TConcrete>());
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
            this.BindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface3), Binding.Map<TConcrete>());
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

            if (typeof(T) == instance.GetType())
            {
                this.BindCore(typeof(T), Binding.Instance(instance));
            }
            else
            {
                this.BindCore(typeof(T), Binding.Mapped(instance));
                this.BindCore(instance.GetType(), Binding.Instance(instance));
            }

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

            this.Bind<TConcrete>(instance);
            this.BindCore(typeof(TInterface), Binding.Mapped(instance));
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

            this.Bind<TConcrete>(instance);
            this.BindCore(typeof(TInterface1), Binding.Mapped(instance));
            this.BindCore(typeof(TInterface2), Binding.Mapped(instance));
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

            this.Bind<TConcrete>(instance);
            this.BindCore(typeof(TInterface1), Binding.Mapped(instance));
            this.BindCore(typeof(TInterface2), Binding.Mapped(instance));
            this.BindCore(typeof(TInterface3), Binding.Mapped(instance));
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

            this.BindCore(typeof(T), Binding.Func(create));
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

            this.BindCore(typeof(TInterface), Binding.Map<TConcrete>());
            this.BindCore(typeof(TConcrete), Binding.Func(create));
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

            this.BindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            this.BindCore(typeof(TConcrete), Binding.Func(create));
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

            this.BindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface3), Binding.Map<TConcrete>());
            this.BindCore(typeof(TConcrete), Binding.Func(create));
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

            this.BindCore(typeof(T), Binding.Resolver(create));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface, TConcrete>(Func<IGetter, TConcrete> create)
            where TConcrete : class, TInterface
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.BindCore(typeof(TInterface), Binding.Map<TConcrete>());
            this.BindCore(typeof(TConcrete), Binding.Resolver(create));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TConcrete>(Func<IGetter, TConcrete> create)
            where TConcrete : class, TInterface1, TInterface2
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.BindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            this.BindCore(typeof(TConcrete), Binding.Resolver(create));
            return this;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public Kernel Bind<TInterface1, TInterface2, TInterface3, TConcrete>(Func<IGetter, TConcrete> create)
            where TConcrete : class, TInterface1, TInterface2
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            this.BindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            this.BindCore(typeof(TInterface3), Binding.Map<TConcrete>());
            this.BindCore(typeof(TConcrete), Binding.Resolver(create));
            return this;
        }
    }
}