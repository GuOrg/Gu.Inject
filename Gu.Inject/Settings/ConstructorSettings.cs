namespace Gu.Inject
{
    public class ConstructorSettings
    {
        public static readonly ConstructorSettings Default = new ConstructorSettings(Visibility.Public, Constructor.AllowOnlyOne);

        public ConstructorSettings(Visibility visibility, Constructor use)
        {
            this.Visibility = visibility;
            this.Use = use;
        }

        public Visibility Visibility { get; }

        public Constructor Use { get; }
    }
}