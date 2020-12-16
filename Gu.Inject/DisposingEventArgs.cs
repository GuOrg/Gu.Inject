namespace Gu.Inject
{
    using System;

    /// <summary>
    /// Event arguments for <see cref="Kernel.Disposing"/>.
    /// </summary>
    public sealed class DisposingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisposingEventArgs"/> class.
        /// </summary>
        /// <param name="instance">The created instance.</param>
        public DisposingEventArgs(object? instance)
        {
            this.Instance = instance;
        }

        /// <summary>
        /// Gets the created instance.
        /// </summary>
        public object? Instance { get; }
    }
}
