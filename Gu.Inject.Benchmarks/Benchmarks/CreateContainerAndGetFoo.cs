namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    [MemoryDiagnoser]
    public class CreateContainerAndGetFoo
    {
        [Benchmark(Baseline = true)]
        public Foo GuInject() => new Container<Foo>().AutoBind().Get<Foo>();

        [Benchmark]
        public Foo Ninject() => new Ninject.StandardKernel(new ModuleFoo()).Get<Foo>();

        [Benchmark]
        public Foo SimpleInjector() => new SimpleInjector.Container().GetInstance<Foo>();
    }
}