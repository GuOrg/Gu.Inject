namespace Gu.Inject
{
    public enum Constructor
    {
        /// <summary>
        /// This means that the kernel will throw when resolving a type that has more than one constructor.
        /// For types with more than one constructor explicit bindings must be provided.
        /// </summary>
        AllowOnlyOne,

        /// <summary>
        /// When a type has more than one constructor the one with most parameters is used.
        /// If two constructors have the same number of parameters an explicit binding must be provided.
        /// </summary>
        UseWithMostParameters,
    }
}