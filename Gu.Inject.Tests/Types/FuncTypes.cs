// ReSharper disable All
namespace Gu.Inject.Tests.Types
{
    using System;

    public static class FuncTypes
    {
        public class A
        {
            private readonly Func<B> bFunc;

            public A(Func<B> bFunc)
            {
                this.bFunc = bFunc;
            }
        }

        public class B
        {
            private readonly Func<A> aFunc;

            public B(Func<A> aFunc)
            {
                this.aFunc = aFunc;
            }
        }
    }
}
