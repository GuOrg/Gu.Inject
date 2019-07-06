namespace Gu.Inject.Tests.Types
{
    public class TwoConstructors
    {
        public TwoConstructors()
        {
        }

        public TwoConstructors(Bar bar)
        {
            this.Bar = bar;
        }

        public Bar Bar { get; }
    }
}