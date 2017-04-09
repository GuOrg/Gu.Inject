namespace Gu.Inject
{
    public class DisposeSettings
    {
        public static readonly DisposeSettings Default = new DisposeSettings(true, false);

        public DisposeSettings(bool disposeCreatedByBoundFuncs, bool disposeBoundInstances)
        {
            this.DisposeCreatedByBoundFuncs = disposeCreatedByBoundFuncs;
            this.DisposeBoundInstances = disposeBoundInstances;
        }

        public bool DisposeCreatedByBoundFuncs { get; }

        public bool DisposeBoundInstances { get; }
    }
}