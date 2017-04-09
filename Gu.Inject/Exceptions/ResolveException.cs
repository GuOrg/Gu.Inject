namespace Gu.Inject
{
    using System;
    using System.Text;

    /// <summary>
    /// Thrown when resolution failed.
    /// </summary>
    public class ResolveException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <param name="inner">The inner exception.</param>
        public ResolveException(Type type, Exception inner)
            : base(CreateMessage(type, inner), inner)
        {
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveException"/> class.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <param name="message">The exception message.</param>
        public ResolveException(Type type, string message)
            : base(message, null)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets the type that could not be resolved.
        /// </summary>
        public Type Type { get; }

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
