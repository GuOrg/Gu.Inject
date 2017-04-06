namespace Gu.Inject.Tests.Types
{
    class A
    {
        public A(B b)
        {
            this.B = b;
        }

        public B B { get; }
    }
}