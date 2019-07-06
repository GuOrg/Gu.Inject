namespace Gu.Inject.Tests.Types
{
    public sealed class WithFactoryMethod
    {
        private WithFactoryMethod(Bar bar)
        {
            this.Bar = bar;
        }

        public Bar Bar { get; }

        public static WithFactoryMethod Create(Bar bar) => new WithFactoryMethod(bar);
    }
}