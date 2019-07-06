namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class GetGraph50 : Get<Graph50.Node1>
    {
        private static readonly Container<Graph50.Node1> Container = new Container<Graph50.Node1>().AutoBind();

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Container.Get<Graph50.Node1>();
        }
    }
}