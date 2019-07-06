namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;
    using SimpleInjector;

    [MemoryDiagnoser]
    public class CreateContainerAndGetGraph50
    {
        [Benchmark(Baseline = true)]
        public Graph50.Node1 GuInject() => new Container<Graph50.Node1>().AutoBind().Get<Graph50.Node1>();

        [Benchmark]
        public Graph50.Node1 DryIoc()
        {
            var container = new DryIoc.Container();
            container.Register<Graph50.Node1>(Reuse.Singleton);
            container.Register<Graph50.Node2>(Reuse.Singleton);
            container.Register<Graph50.Node4>(Reuse.Singleton);
            container.Register<Graph50.Node8>(Reuse.Singleton);
            container.Register<Graph50.Node32>(Reuse.Singleton);
            container.Register<Graph50.Node36>(Reuse.Singleton);
            container.Register<Graph50.Node16>(Reuse.Singleton);
            container.Register<Graph50.Node48>(Reuse.Singleton);
            container.Register<Graph50.Node7>(Reuse.Singleton);
            container.Register<Graph50.Node35>(Reuse.Singleton);
            container.Register<Graph50.Node49>(Reuse.Singleton);
            container.Register<Graph50.Node10>(Reuse.Singleton);
            container.Register<Graph50.Node18>(Reuse.Singleton);
            container.Register<Graph50.Node24>(Reuse.Singleton);
            container.Register<Graph50.Node26>(Reuse.Singleton);
            container.Register<Graph50.Node27>(Reuse.Singleton);
            container.Register<Graph50.Node29>(Reuse.Singleton);
            return container.Resolve<Graph50.Node1>();
        }

        [Benchmark]
        public Graph50.Node1 Ninject() => new Ninject.StandardKernel(new ModuleGraph50()).Get<Graph50.Node1>();

        [Benchmark]
        public Graph50.Node1 SimpleInjector()
        {
            var container = new SimpleInjector.Container();
            container.Register<Graph50.Node1>(Lifestyle.Singleton);
            container.Register<Graph50.Node2>(Lifestyle.Singleton);
            container.Register<Graph50.Node4>(Lifestyle.Singleton);
            container.Register<Graph50.Node8>(Lifestyle.Singleton);
            container.Register<Graph50.Node32>(Lifestyle.Singleton);
            container.Register<Graph50.Node36>(Lifestyle.Singleton);
            container.Register<Graph50.Node16>(Lifestyle.Singleton);
            container.Register<Graph50.Node48>(Lifestyle.Singleton);
            container.Register<Graph50.Node7>(Lifestyle.Singleton);
            container.Register<Graph50.Node35>(Lifestyle.Singleton);
            container.Register<Graph50.Node49>(Lifestyle.Singleton);
            container.Register<Graph50.Node10>(Lifestyle.Singleton);
            container.Register<Graph50.Node18>(Lifestyle.Singleton);
            container.Register<Graph50.Node24>(Lifestyle.Singleton);
            container.Register<Graph50.Node26>(Lifestyle.Singleton);
            container.Register<Graph50.Node27>(Lifestyle.Singleton);
            container.Register<Graph50.Node29>(Lifestyle.Singleton);
            return container.GetInstance<Graph50.Node1>();
        }
    }
}