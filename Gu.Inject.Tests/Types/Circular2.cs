// ReSharper disable UnusedParameter.Local
#pragma warning disable CA1801 // Review unused parameters
#pragma warning disable IDE0060 // Remove unused parameter
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
