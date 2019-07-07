namespace Gu.Inject.Tests.Types
{
    public sealed class SingletonFieldWithPublicCtor
    {
        public static readonly SingletonFieldWithPublicCtor Instance = new SingletonFieldWithPublicCtor();

        public SingletonFieldWithPublicCtor()
        {
        }
    }
}