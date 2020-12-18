namespace Gu.Inject
{
    using System;

    /// <summary>
    /// A get -only view of <see cref="Kernel"/>.
    /// Prefer <see cref="IReadOnlyKernel"/>.
    /// </summary>
    [Obsolete("Use IReadOnlyKernel")]
    public interface IGetter : IReadOnlyKernel
    {
    }
}
