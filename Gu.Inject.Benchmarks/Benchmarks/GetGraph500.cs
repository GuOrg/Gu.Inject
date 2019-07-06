namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    [MemoryDiagnoser]
    public class GetGraph500
    {
        private static readonly Container<Graph500.Node1> Container = new Container<Graph500.Node1>().AutoBind();
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new ModuleGraph500());
        private static readonly SimpleInjector.Container SimpleInjectorContainer = new SimpleInjector.Container();

        [Benchmark(Baseline = true)]
        public Graph500.Node1 GuInject() => Container.Get<Graph500.Node1>();

        [Benchmark]
        public Graph500.Node1 Ninject() => StandardKernel.Get<Graph500.Node1>();

        [Benchmark]
        public Graph500.Node1 SimpleInjector() => SimpleInjectorContainer.GetInstance<Graph500.Node1>();
    }
}