namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class GetGraph500 : Get<Graph500.Node1>
    {
        private static readonly Container<Graph500.Node1> Container = new Container<Graph500.Node1>().AutoBind();

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Container.Get<Graph500.Node1>();
        }
    }
}