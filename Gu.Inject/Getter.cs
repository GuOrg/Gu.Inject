namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Exposes <see cref="Container{TRoot}.Get{T}"/>.
    /// </summary>
    /// <typeparam name="TRoot">The root type of the graph to resolve.</typeparam>
    public readonly struct Getter<TRoot> : IEquatable<Getter<TRoot>>
    {
        private readonly Container<TRoot> container;

        /// <summary>
        /// Initializes a new instance of the <see cref="Getter{TRoot}"/> struct.
        /// </summary>
        /// <param name="container">The <see cref="Container{TRoot}"/>.</param>
        internal Getter(Container<TRoot> container)
        {
            this.container = container;
        }

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        public T Get<T>()
            where T : class
        {
            return this.container.Get<T>();
        }

        public static bool operator ==(Getter<TRoot> left, Getter<TRoot> right) => left.Equals(right);

        public static bool operator !=(Getter<TRoot> left, Getter<TRoot> right) => !left.Equals(right);

        /// <inheritdoc/>
        public bool Equals(Getter<TRoot> other) => ReferenceEquals(this.container, other.container);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Getter<TRoot> other && this.Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => this.container.GetHashCode();
    }
}