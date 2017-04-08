namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Thrown when resolution failed because there were more than one possible type to resolve.
    /// </summary>
    public class AmbiguousBindingException : BindingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmbiguousBindingException"/> class.
        /// </summary>
        /// <param name="type">The type that has no binding.</param>
        /// <param name="mapped">The bindings found by scanning the assemblies.</param>
        public AmbiguousBindingException(Type type, IReadOnlyList<Type> mapped)
            : base(type, mapped, CreateMessage(type, mapped))
        {
        }

        private static string CreateMessage(Type type, IReadOnlyList<Type> mapped)
        {
            return $"Type {type.PrettyName()} has more than one binding: {string.Join(", ", mapped.Select(TypeExt.PrettyName))}.";
        }
    }
}