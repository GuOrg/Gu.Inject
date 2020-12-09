namespace Gu.Inject
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Thrown when resolution failed.
    /// </summary>
    [Serializable]
    public class ResolveException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <param name="message">The exception message.</param>
        public ResolveException(Type type, string message)
            : this(type, message, null!)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <param name="inner">The inner exception.</param>
        public ResolveException(Type type, ResolveException inner)
            : this(type, CreateMessage(type, inner), inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public ResolveException(Type type, string message, ResolveException inner)
            : base(message, inner)
        {
            this.Type = type;
        }

        /// <summary>Initializes a new instance of the <see cref="ResolveException" /> class with serialized data.</summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ResolveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Type = (Type)info.GetValue(nameof(this.Type), typeof(Type))!;
        }

        /// <summary>
        /// Gets the type that could not be resolved.
        /// </summary>
#pragma warning disable CA1721 // Property names should not match get methods
        public Type Type { get; }
#pragma warning restore CA1721 // Property names should not match get methods

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(this.Type), this.Type, typeof(Type));
        }

        private static string CreateMessage(Type type, Exception inner)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{type.PrettyName()}(");
            foreach (var line in inner.Message.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                builder.AppendLine($"  {line}");
            }

            return builder.ToString();
        }
    }
}
