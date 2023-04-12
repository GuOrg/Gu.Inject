namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;
    using Ninject.Modules;
    using SimpleInjector;

    [MemoryDiagnoser]
    public class NewAndGetSimple
    {
        [Benchmark]
        public object Ninject()
        {
            using var kernel = new Ninject.StandardKernel(new Module());
            return kernel.Get<Simple>();
        }

        [Benchmark]
        public object SimpleInjector()
        {
            using var container = new SimpleInjector.Container
            {
                Options =
                {
                    ResolveUnregisteredConcreteTypes = true,
                    DefaultLifestyle = Lifestyle.Singleton,
                },
            };
            return container.GetInstance<Simple>();
        }

        [Benchmark]
        public object DryIoc()
        {
            using var container = new DryIoc.Container(x => x.WithConcreteTypeDynamicRegistrations()
                                                             .WithDefaultReuse(Reuse.Singleton));
            return container.Resolve<Simple>();
        }

        [Benchmark(Baseline = true, Description = "Gu.Inject")]
        public object GuInject()
        {
            using var kernel = new Kernel();
            return kernel.Get<Simple>();
        }

        [Benchmark]
        public object GuInjectBound()
        {
            using var kernel = new Kernel().Bind(() => new Simple());
            return kernel.Get<Simple>();
        }

        private sealed class Module : NinjectModule
        {
            public override void Load()
            {
                this.Bind<Simple>().ToSelf().InSingletonScope();
            }
        }
    }
}
