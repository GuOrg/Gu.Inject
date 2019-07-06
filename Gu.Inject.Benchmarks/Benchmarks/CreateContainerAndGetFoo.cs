#pragma warning disable CA2000 // Dispose objects before losing scope
#pragma warning disable IDISP001 // Dispose created.
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;
    using SimpleInjector;

    [MemoryDiagnoser]
    public class CreateContainerAndGetFoo
    {
        [Benchmark(Baseline = true)]
        public Foo GuInject() => new Container<Foo>().AutoBind().Get<Foo>();

        [Benchmark]
        public Foo DryIoc()
        {
            var container = new DryIoc.Container();
            container.Register<Foo>(Reuse.Singleton);
            return container.Resolve<Foo>();
        }

        [Benchmark]
        public Foo Ninject() => new Ninject.StandardKernel(new ModuleFoo()).Get<Foo>();

        [Benchmark]
        public Foo SimpleInjector()
        {
            var container = new SimpleInjector.Container();
            container.Register<Foo>(Lifestyle.Singleton);
            return container.GetInstance<Foo>();
        }
    }
}