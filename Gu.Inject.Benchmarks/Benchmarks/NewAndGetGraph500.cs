namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class NewAndGetGraph500 : NewAndGet<Graph500.Node1>
    {
    }
}