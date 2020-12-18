#pragma warning disable CA1716 // Identifiers should not match keywords
namespace Gu.Inject
{
    using System;

    /// <summary>
    /// A get -only view of <see cref="Kernel"/>.
    /// </summary>
    public interface IReadOnlyKernel
    {
        /// <summary>
        /// This notifies before creating an instance of a type.
        /// </summary>
        event EventHandler<CreatingEventArgs>? Creating;

        /// <summary>
        /// This notifies after creating an instance of a type.
        /// </summary>
        event EventHandler<CreatedEventArgs>? Created;

        /// <summary>
        /// This notifies before an instance is removed when calling <see cref="Dispose"/>.
        /// Note that the event notifies for all instances not only types that implement <see cref="IDisposable"/>.
        /// It is called before the call to instance.Dispose() if it was created by the kernel.
        /// </summary>
        event EventHandler<DisposingEventArgs>? Disposing;

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        T Get<T>();

        /// <summary>
        /// Get the singleton instance of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>The singleton instance of <paramref name="type"/>.</returns>
        object? Get(Type type);
    }
}
