// ReSharper disable UnusedParameter.Local
namespace Gu.Inject.Tests.Types
{
    public static class Circular1
    {
        public class A
        {
            public A(B b)
            {
            }
        }

        public class B
        {
            public B(A a)
            {
            }
        }
    }
}