namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    public class NoBindingException : BindingException
    {
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