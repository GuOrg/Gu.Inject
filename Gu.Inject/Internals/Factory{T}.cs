namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class Factory<T> : IFactory
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations
        // ReSharper disable once StaticMemberInGenericType
        private static readonly IReadOnlyList<Type> Empty = new Type[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations

        private readonly Func<T> creator;

        internal Factory(Func<T> creator)
        {
            this.creator = creator;
        }

        public IReadOnlyList<Type> ParameterTypes => Empty;

        public object Create(object?[]? args)
        {
            Debug.Assert((args?.Length ?? 0) == 0, "args?.Length ??0 ==0");
            return this.creator()!;
        }
    }
}