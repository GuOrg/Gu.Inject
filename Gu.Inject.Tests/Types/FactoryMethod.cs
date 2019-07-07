namespace Gu.Inject.Tests.Types
{
    public sealed class FactoryMethod
    {
        private FactoryMethod(Bar bar)
        {
            this.Bar = bar;
        }

        public Bar Bar { get; }

        public static FactoryMethod Create(Bar bar) => new FactoryMethod(bar);
    }
}