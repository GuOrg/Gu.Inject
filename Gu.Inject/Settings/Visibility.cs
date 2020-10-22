namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Allowed accessibility.
    /// </summary>
    [Serializable]
    [Flags]
    public enum Visibility
    {
        /// <summary>
        /// Public member.
        /// </summary>
        Public = 0,

        /// <summary>
        /// Internal member.
        /// </summary>
        Internal = 1 << 0,

        /// <summary>
        /// Private member.
        /// </summary>
        Private = 1 << 1,
    }
}