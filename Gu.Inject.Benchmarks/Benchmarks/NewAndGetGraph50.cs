namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class NewAndGetGraph50 : NewAndGet<Graph50.Node1>
    {
    }
}