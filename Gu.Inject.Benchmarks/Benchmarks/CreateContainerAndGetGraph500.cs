namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    [MemoryDiagnoser]
    public class CreateContainerAndGetGraph500
    {
        [Benchmark(Baseline = true)]
        public Graph500.Node1 GuInject() => new Container<Graph500.Node1>().AutoBind().Get<Graph500.Node1>();

        [Benchmark]
        public Graph500.Node1 Ninject() => new Ninject.StandardKernel(new ModuleGraph500()).Get<Graph500.Node1>();

        [Benchmark]
        public Graph500.Node1 SimpleInjector() => new SimpleInjector.Container().GetInstance<Graph500.Node1>();
    }
}