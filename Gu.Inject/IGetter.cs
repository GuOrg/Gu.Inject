#pragma warning disable CA1716 // Identifiers should not match keywords
namespace Gu.Inject
{
    using System;

    /// <summary>
    /// A get -only view of <see cref="Kernel"/>.
    /// </summary>
    public interface IGetter
    {
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
        object Get(Type type);
    }
}