// ReSharper disable UnusedParameter.Local
namespace Gu.Inject.Tests.Types
{
    internal class Circular
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
            public C()
            {
            }
        }

        public class D
        {
            public D()
            {
            }
        }

        public class E
        {
            public E(F f, G g)
            {
            }
        }

        public class F
        {
            public F()
            {
            }
        }

        public class G
        {
            public G(A a)
            {
            }
        }
    }
}
