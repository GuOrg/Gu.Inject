namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when resolution failed because there was no binding.
    /// </summary>
    [Serializable]
    public class NoBindingException : BindingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoBindingException"/> class.
        /// </summary>
        /// <param name="type">The type that has no binding.</param>
        /// <param name="mapped">Always empty.</param>
        public NoBindingException(Type type, IEnumerable<Type> mapped)
            : base(type, mapped, CreateMessage(type))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NoBindingException" /> class with serialized data.</summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected NoBindingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static string CreateMessage(Type type)
        {
            return $"Type {type.PrettyName()} has no bindings.";
        }
    }
}