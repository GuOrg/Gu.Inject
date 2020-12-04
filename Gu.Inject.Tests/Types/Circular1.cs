// ReSharper disable All
namespace Gu.Inject.Tests.Types
{
    public static class Circular1
    {
        public class A
        {
            public A(B b)
            {
                this.B = b;
            }

            public B B { get; }
        }

        public class B
        {
            public B(A a)
            {
                this.A = a;
            }

            public A A { get; }
        }
    }
}
