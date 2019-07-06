namespace Gu.Inject.Tests.Types
{
    public sealed class SingletonField
    {
        public static readonly SingletonField Instance = new SingletonField();

        private SingletonField()
        {
        }
    }
}