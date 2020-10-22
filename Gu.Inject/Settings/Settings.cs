namespace Gu.Inject
{
    public class Settings
    {
        public static readonly Settings Default = new Settings(
            ConstructorSettings.Default,
            DisposeSettings.Default);

        public Settings(ConstructorSettings constructors, DisposeSettings dispose)
        {
            this.Constructors = constructors;
            this.Dispose = dispose;
        }

        public ConstructorSettings Constructors { get; }

        public DisposeSettings Dispose { get; }
    }
}