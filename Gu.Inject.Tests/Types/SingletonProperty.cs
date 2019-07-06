namespace Gu.Inject.Tests.Types
{
    public sealed class SingletonProperty
    {
        public static SingletonProperty Instance { get; } = new SingletonProperty();

        private SingletonProperty()
        {
        }
    }
}