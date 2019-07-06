namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    [MemoryDiagnoser]
    public class CreateContainerAndGetGraph50
    {
        [Benchmark(Baseline = true)]
        public Graph50.Node1 GuInject() => new Container<Graph50.Node1>().AutoBind().Get<Graph50.Node1>();

        [Benchmark]
        public Graph50.Node1 Ninject() => new Ninject.StandardKernel(new ModuleGraph50()).Get<Graph50.Node1>();

        [Benchmark]
        public Graph50.Node1 SimpleInjector() => new SimpleInjector.Container().GetInstance<Graph50.Node1>();
    }
}