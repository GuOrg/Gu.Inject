namespace Gu.Inject.Tests.Types
{
    class B
    {
        public B(A a)
        {
            this.A = a;
        }

        public A A { get; }
    }
}