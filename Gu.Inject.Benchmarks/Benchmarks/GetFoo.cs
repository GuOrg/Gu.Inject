namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class GetFoo : Get<Foo>
    {
        private static readonly Container<Foo> Container = new Container<Foo>().AutoBind();

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Container.Get<Foo>();
        }
    }
}