namespace Gu.Inject
{
    public class ConstructorSettings
    {
        public static readonly ConstructorSettings Default = new ConstructorSettings(Visibility.Public);

        public ConstructorSettings(Visibility visibility)
        {
            this.Visibility = visibility;
        }

        public Visibility Visibility { get; }
    }
}