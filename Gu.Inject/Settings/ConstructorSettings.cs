namespace Gu.Inject
{
    /// <summary>
    /// Specify what constructors to use when resolving.
    /// </summary>
    public sealed class ConstructorSettings
    {
        /// <summary>
        /// The default instance.
        /// </summary>
        public static readonly ConstructorSettings Default = new ConstructorSettings(Inject.Accessibilities.Public);

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorSettings"/> class.
        /// </summary>
        /// <param name="accessibility">Specifies the accessibility.</param>
        public ConstructorSettings(Accessibilities accessibility)
        {
            this.Accessibility = accessibility;
        }

        /// <summary>
        /// Specifies the accessibility.
        /// </summary>
        public Accessibilities Accessibility { get; }
    }
}