namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class Factory<T> : IFactory
    {
        private static readonly IReadOnlyList<Type> Empty = new Type[0];

        private readonly Func<T> creator;

        internal Factory(Func<T> creator)
        {
            this.creator = creator;
        }

        public IReadOnlyList<Type> ParameterTypes => Empty;

        public object Create(object[]? args)
        {
            Debug.Assert((args?.Length ?? 0) == 0, "args?.Length ??0 ==0");
            return this.creator();
        }
    }
}