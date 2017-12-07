namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Thrown when resolution failed.
    /// </summary>
    public abstract class BindingException : ResolveException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BindingException"/> class.
        /// </summary>
        /// <param name="type">The type that was resolved.</param>
        /// <param name="mapped">The mapped types.</param>
        /// <param name="message">The exception message.</param>
        protected BindingException(Type type, IEnumerable<Type> mapped, string message)
            : base(type, message)
        {
            this.Mapped = mapped;
        }

        /// <summary>
        /// Gets the candidate types to resolve.
        /// </summary>
        public IEnumerable<Type> Mapped { get; }
    }
}