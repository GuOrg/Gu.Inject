// ReSharper disable All
namespace Gu.Inject.Tests.Types
{
    using System;

    public static class FuncTypes
    {
        public class A
        {
            private readonly Func<B> bFactory;

            public A(Func<B> bFactory)
            {
                this.bFactory = bFactory;
            }
        }

        public class B
        {
            private readonly Func<A> aFactory;

            public B(Func<A> aFactory)
            {
                this.aFactory = aFactory;
            }
        }
    }
}
