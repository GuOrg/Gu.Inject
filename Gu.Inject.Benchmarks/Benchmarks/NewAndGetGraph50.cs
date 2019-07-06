namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class NewAndGetGraph50 : NewAndGet<Graph50.Node1>
    {
        [Benchmark(Baseline = true)]
        public object GuInject() => new Container<Graph50.Node1>().AutoBind().Get<Graph50.Node1>();
    }
}