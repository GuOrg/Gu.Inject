// ReSharper disable All
namespace Gu.Inject.Tests.Types
{
    public static class Circular2
    {
        public class A
        {
            public A(B b, E e)
            {
                this.B = b;
                this.E = e;
            }

            public B B { get; }

            public E E { get; }
        }

        public class B
        {
            public B(C c, D d)
            {
                this.C = c;
                this.D = d;
            }

            public C C { get; }

            public D D { get; }
        }

        public class C
        {
        }

        public class D
        {
        }

        public class E
        {
            public E(F f, G g)
            {
                this.F = f;
                this.G = g;
            }

            public F F { get; }

            public G G { get; }
        }

        public class F
        {
        }

        public class G
        {
            public G(A a)
            {
                this.A = a;
            }

            public A A { get; }
        }
    }
}
