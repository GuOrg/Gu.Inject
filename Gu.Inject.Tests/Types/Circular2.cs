// ReSharper disable UnusedParameter.Local
namespace Gu.Inject.Tests.Types
{
    public static class Circular2
    {
        public class A
        {
            public A(B b, E e)
            {
            }
        }

        public class B
        {
            public B(C c, D d)
            {
            }
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
            }
        }

        public class F
        {
        }

        public class G
        {
            public G(A a)
            {
            }
        }
    }
}
