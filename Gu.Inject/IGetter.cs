namespace Gu.Inject
{
    using System;

    [Obsolete("Use IReadOnlyKernel")]
    public interface IGetter : IReadOnlyKernel
    {
    }
}
