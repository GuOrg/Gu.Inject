namespace Gu.Inject.Tests.Types
{
    public class Foo
    {
        public Foo(Bar bar)
        {
            this.Bar = bar;
        }

        public Bar Bar { get; }
    }
}
