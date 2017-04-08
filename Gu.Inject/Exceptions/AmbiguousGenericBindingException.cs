namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    public class AmbiguousGenericBindingException : BindingException
    {
        public AmbiguousGenericBindingException(Type type, IReadOnlyList<Type> mapped)
            : base(type, mapped, CreateMessage(type, mapped))
        {
        }

        private static string CreateMessage(Type type, IReadOnlyList<Type> mapped)
        {
            return $"Type {type.PrettyName()} has binding to a generic type: {mapped[0].PrettyName()}.\r\n" +
                   $"Add a binding specifying what type argument to use."; ;
        }
    }
}