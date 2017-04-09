namespace Gu.Inject
{
    public class Settings
    {
        public static readonly Settings Default = new Settings(
            ConstructorSettings.Default,
            AssemblySettings.Default,
            DisposeSettings.Default);

        public Settings(ConstructorSettings constructors, AssemblySettings assembly, DisposeSettings dispose)
        {
            this.Constructors = constructors;
            this.Assembly = assembly;
            this.Dispose = dispose;
        }

        public ConstructorSettings Constructors { get; }

        public AssemblySettings Assembly { get; }

        public DisposeSettings Dispose { get; }
    }
}