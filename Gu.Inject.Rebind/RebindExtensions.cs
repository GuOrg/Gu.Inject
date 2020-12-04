// ReSharper disable RedundantTypeArgumentsOfMethod
#pragma warning disable IDE0001
namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Rebind extension methods for <see cref="Kernel"/>.
    /// </summary>
    public static class RebindExtensions
    {
        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="from">The type to map.</param>
        /// <param name="to">The mapped type.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind(this Kernel kernel, Type from, Type to)
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (from is null)
            {
                throw new ArgumentNullException(nameof(from));
            }

            if (to is null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            kernel.RebindCore(from, Binding.Map(to));
            return kernel;
        }

        /// <summary>
        /// Use this binding when there are circular dependencies.
        /// This binds an FormatterServices.GetUninitializedObject() that is used when creating the graph.
        /// </summary>
        /// <typeparam name="T">The type to map.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <returns>The same instance.</returns>
        public static Kernel RebindUninitialized<T>(this Kernel kernel)
            where T : class
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.RebindCore(typeof(T), Binding.Uninitialized<T>());
            return kernel;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface, TConcrete>(this Kernel kernel)
            where TConcrete : TInterface
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.RebindCore(typeof(TInterface), Binding.Map<TConcrete>());
            return kernel;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TConcrete>(this Kernel kernel)
            where TConcrete : TInterface1, TInterface2
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.RebindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            return kernel;
        }

        /// <summary>
        /// Provide an override to the automatic mapping.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TInterface3, TConcrete>(this Kernel kernel)
            where TConcrete : TInterface1, TInterface2, TInterface3
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            kernel.RebindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface3), Binding.Map<TConcrete>());
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<T>(this Kernel kernel, T instance)
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (typeof(T) == instance.GetType())
            {
                kernel.RebindCore(typeof(T), Binding.Instance(instance));
            }
            else
            {
                kernel.RebindCore(typeof(T), Binding.Mapped(instance));
                kernel.RebindCore(instance.GetType(), Binding.Instance(instance));
            }

            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface, TConcrete>(this Kernel kernel, TConcrete instance)
            where TConcrete : TInterface
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            kernel.Rebind<TConcrete>(instance);
            kernel.RebindCore(typeof(TInterface), Binding.Mapped(instance));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TConcrete>(this Kernel kernel, TConcrete instance)
            where TConcrete : TInterface1, TInterface2
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            kernel.Rebind<TConcrete>(instance);
            kernel.RebindCore(typeof(TInterface1), Binding.Mapped(instance));
            kernel.RebindCore(typeof(TInterface2), Binding.Mapped(instance));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// If the <paramref name="instance"/> implements IDisposable, the responsibility to dispose it remains the caller's, disposing the kernel doesn't do that.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="instance">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TInterface3, TConcrete>(this Kernel kernel, TConcrete instance)
            where TConcrete : TInterface1, TInterface2, TInterface3
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (instance is null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            kernel.Rebind<TConcrete>(instance);
            kernel.RebindCore(typeof(TInterface1), Binding.Mapped(instance));
            kernel.RebindCore(typeof(TInterface2), Binding.Mapped(instance));
            kernel.RebindCore(typeof(TInterface3), Binding.Mapped(instance));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// The instance is owned by the kernel, that is, calling .Dispose() on the kernel disposes the instance, if its type implements IDisposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<T>(this Kernel kernel, Func<T> create)
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(T), Binding.Func(create));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface, TConcrete>(this Kernel kernel, Func<TConcrete> create)
            where TConcrete : TInterface
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(TInterface), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TConcrete), Binding.Func(create));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TConcrete>(this Kernel kernel, Func<TConcrete> create)
            where TConcrete : TInterface1, TInterface2
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TConcrete), Binding.Func(create));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The instance is created lazily by <paramref name="create"/> and is cached for subsequent calls to .Get().
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TInterface3">The third type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The factory function used to create the instance.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TInterface3, TConcrete>(this Kernel kernel, Func<TConcrete> create)
            where TConcrete : TInterface1, TInterface2, TInterface3
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface3), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TConcrete), Binding.Func(create));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="T">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<T>(this Kernel kernel, Func<IGetter, T> create)
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(T), Binding.Resolver(create));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="TInterface">The type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface, TConcrete>(this Kernel kernel, Func<IGetter, TConcrete> create)
            where TConcrete : TInterface
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(TInterface), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TConcrete), Binding.Resolver(create));
            return kernel;
        }

        /// <summary>
        /// Provide an override for the automatic mapping.
        /// The kernel will keep <paramref name="create"/> alive until disposed.
        /// <paramref name="create"/> is disposed by the kernel if disposable.
        /// </summary>
        /// <typeparam name="TInterface1">The first type to map.</typeparam>
        /// <typeparam name="TInterface2">The second type to map.</typeparam>
        /// <typeparam name="TConcrete">The mapped type.</typeparam>
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TConcrete>(this Kernel kernel, Func<IGetter, TConcrete> create)
            where TConcrete : TInterface1, TInterface2
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TConcrete), Binding.Resolver(create));
            return kernel;
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
        /// <param name="kernel">The <see cref="Kernel"/>.</param>
        /// <param name="create">The instance to bind.</param>
        /// <returns>The same instance.</returns>
        public static Kernel Rebind<TInterface1, TInterface2, TInterface3, TConcrete>(this Kernel kernel, Func<IGetter, TConcrete> create)
            where TConcrete : TInterface1, TInterface2
        {
            if (kernel is null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            if (create is null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            kernel.RebindCore(typeof(TInterface1), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface2), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TInterface3), Binding.Map<TConcrete>());
            kernel.RebindCore(typeof(TConcrete), Binding.Resolver(create));
            return kernel;
        }
    }
}
