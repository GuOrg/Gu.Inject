namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    [MemoryDiagnoser]
    public sealed class GetFoo
    {
        private static readonly Container<Foo> Container = new Container<Foo>().AutoBind();
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new ModuleFoo());
        private static readonly SimpleInjector.Container SimpleInjectorContainer = new SimpleInjector.Container();

        [Benchmark(Baseline = true)]
        public Foo GuInject() => Container.Get<Foo>();

        [Benchmark]
        public Foo Ninject() => StandardKernel.Get<Foo>();

        [Benchmark]
        public Foo SimpleInjector() => SimpleInjectorContainer.GetInstance<Foo>();
    }
}