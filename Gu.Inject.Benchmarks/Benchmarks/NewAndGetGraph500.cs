namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class NewAndGetGraph500 : NewAndGet<Graph500.Node1>
    {
        [Benchmark(Baseline = true)]
        public object GuInject() => new Container<Graph500.Node1>().AutoBind().Get<Graph500.Node1>();
    }
}