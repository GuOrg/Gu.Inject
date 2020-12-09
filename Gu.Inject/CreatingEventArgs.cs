namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Event arguments for <see cref="Kernel.Creating"/>.
    /// </summary>
    public sealed class CreatingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatingEventArgs"/> class.
        /// </summary>
        /// <param name="type">The type for which a type is about to be created.</param>
        public CreatingEventArgs(Type type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets the type for which a type is about to be created.
        /// </summary>
        public Type Type { get; }
    }
}
