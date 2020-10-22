namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when resolution failed because there were more than one possible type to resolve.
    /// </summary>
    [Serializable]
    public class AmbiguousGenericBindingException : BindingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmbiguousGenericBindingException"/> class.
        /// </summary>
        /// <param name="type">The type that has no binding.</param>
        /// <param name="mapped">The bindings found by scanning the assemblies.</param>
        public AmbiguousGenericBindingException(Type type, IEnumerable<Type> mapped)
            : base(type, mapped, CreateMessage(type, mapped))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AmbiguousGenericBindingException" /> class with serialized data.</summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected AmbiguousGenericBindingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static string CreateMessage(Type type, IEnumerable<Type> mapped)
        {
            return $"Type {type.PrettyName()} has binding to a generic type: {mapped.First().PrettyName()}.\r\n" +
                   $"Add a binding specifying what type argument to use.";
        }
    }
}