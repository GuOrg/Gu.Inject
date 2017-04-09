namespace Gu.Inject.Benchmarks.Types
{
    using System.Collections.Generic;

    public interface INode
    {
        IReadOnlyList<INode> Children { get; }

        IEnumerable<INode> AllChildren { get; }
    }
}
