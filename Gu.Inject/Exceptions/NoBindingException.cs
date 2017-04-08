namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Thrown when resolution failed because there was no binding.
    /// </summary>
    public class NoBindingException : BindingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoBindingException"/> class.
        /// </summary>
        /// <param name="type">The type that has no binding.</param>
        /// <param name="mapped">Always empty.</param>
        public NoBindingException(Type type, IReadOnlyList<Type> mapped)
            : base(type, mapped, CreateMessage(type))
        {
        }

        private static string CreateMessage(Type type)
        {
            return $"Type {type.PrettyName()} has no bindings.";
        }
    }
}