namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AmbiguousBindingException : BindingException
    {
        public AmbiguousBindingException(Type type, IReadOnlyList<Type> mapped)
            : base(type, mapped, CreateMessage(type, mapped))
        {
        }

        private static string CreateMessage(Type type, IReadOnlyList<Type> mapped)
        {
            return $"Type {type.PrettyName()} has more than one binding: {string.Join(", ", mapped.Select(t => TypeExt.PrettyName(t)))}.";
        }
    }
}