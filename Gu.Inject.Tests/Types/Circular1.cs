// ReSharper disable All
#pragma warning disable CA1801 // Review unused parameters
#pragma warning disable IDE0060 // Remove unused parameter
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
