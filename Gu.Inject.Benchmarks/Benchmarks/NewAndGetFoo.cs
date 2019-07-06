namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class NewAndGetFoo : NewAndGet<Foo>
    {
        [Benchmark(Baseline = true)]
        public object GuInject() => new Container<Foo>().AutoBind().Get<Foo>();
    }
}