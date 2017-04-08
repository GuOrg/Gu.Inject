namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Thrown when resolution failed because a circular dependency was detected.
    /// </summary>
    public class CircularDependencyException : ResolveException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircularDependencyException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        public CircularDependencyException(Type type)
            : base(type, $"{type.PrettyName()}( Circular dependency detected.")
        {
        }
    }
}