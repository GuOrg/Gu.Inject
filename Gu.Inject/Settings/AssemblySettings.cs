namespace Gu.Inject
{
    public class AssemblySettings
    {
        public static readonly AssemblySettings Default = new AssemblySettings(true, null);

        public AssemblySettings(bool addRecursive, string ignorePattern)
        {
            this.AddRecursive = addRecursive;
            this.IgnorePattern = ignorePattern;
        }

        public bool AddRecursive { get; }

        /// <summary>
        /// Regex pattern for assemblies to ignore.
        /// </summary>
        public string IgnorePattern { get; }
    }
}