namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class Factory<TArg, T> : IFactory
    {
        private readonly Func<TArg, T> creator;

        public Factory(Func<TArg, T> creator)
        {
            this.creator = creator;
        }

        public IReadOnlyList<Type> ParameterTypes { get; } = new[] { typeof(TArg) };

        public object Create(object[] args)
        {
            Debug.Assert(args.Length == 1, "args.Length ==1");
            return this.creator((TArg)args[0]);
        }
    }
}