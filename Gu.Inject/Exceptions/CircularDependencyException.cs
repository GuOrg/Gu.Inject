namespace Gu.Inject
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when resolution failed because a circular dependency was detected.
    /// </summary>
    [Serializable]
    public class CircularDependencyException : ResolveException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircularDependencyException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        public CircularDependencyException(Type type)
            : base(type, $"{type?.PrettyName()}(... Circular dependency detected.")
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CircularDependencyException" /> class with serialized data.</summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected CircularDependencyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}