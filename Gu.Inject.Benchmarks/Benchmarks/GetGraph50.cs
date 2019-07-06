namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    [MemoryDiagnoser]
    public sealed class GetGraph50
    {
        private static readonly Container<Graph50.Node1> Container = new Container<Graph50.Node1>().AutoBind();
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new ModuleGraph50());
        private static readonly SimpleInjector.Container SimpleInjectorContainer = new SimpleInjector.Container();

        [Benchmark(Baseline = true)]
        public Graph50.Node1 GuInject() => Container.Get<Graph50.Node1>();

        [Benchmark]
        public Graph50.Node1 Ninject() => StandardKernel.Get<Graph50.Node1>();

        [Benchmark]
        public Graph50.Node1 SimpleInjector() => SimpleInjectorContainer.GetInstance<Graph50.Node1>();
    }
}