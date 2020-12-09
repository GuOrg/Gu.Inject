namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Event arguments for <see cref="Kernel.Created"/>.
    /// </summary>
    public sealed class CreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedEventArgs"/> class.
        /// </summary>
        /// <param name="instance">The created instance.</param>
        public CreatedEventArgs(object? instance)
        {
            this.Instance = instance;
        }

        /// <summary>
        /// Gets the created instance.
        /// </summary>
        public object? Instance { get; }
    }
}
