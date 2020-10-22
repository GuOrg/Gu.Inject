namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when resolution failed.
    /// </summary>
    [Serializable]
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

        /// <summary>Initializes a new instance of the <see cref="BindingException" /> class with serialized data.</summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected BindingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Mapped = (IEnumerable<Type>)info.GetValue(nameof(this.Mapped), typeof(IEnumerable<Type>))!;
        }

        /// <summary>
        /// Gets the candidate types to resolve.
        /// </summary>
        public IEnumerable<Type> Mapped { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(this.Mapped), this.Mapped, typeof(IEnumerable<Type>));
        }
    }
}