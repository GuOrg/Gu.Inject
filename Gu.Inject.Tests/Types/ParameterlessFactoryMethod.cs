namespace Gu.Inject.Tests.Types
{

    public sealed class ParameterlessFactoryMethod
    {
        public static ParameterlessFactoryMethod Create() => new ParameterlessFactoryMethod();

        private ParameterlessFactoryMethod()
        {
        }
    }
}