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
        /// <param name="message">The message that describes the error.</param>
        public CircularDependencyException(Type type, string message)
            : base(type, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularDependencyException"/> class.
        /// </summary>
        /// <param name="type">The type that has no binding.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public CircularDependencyException(Type type, string message, CircularDependencyException inner)
            : base(type, message, inner)
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
