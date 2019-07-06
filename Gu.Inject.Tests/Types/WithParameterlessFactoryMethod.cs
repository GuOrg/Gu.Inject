namespace Gu.Inject.Tests.Types
{

    public sealed class WithParameterlessFactoryMethod
    {
        public static WithParameterlessFactoryMethod Create() => new WithParameterlessFactoryMethod();

        private WithParameterlessFactoryMethod()
        {
        }
    }
}