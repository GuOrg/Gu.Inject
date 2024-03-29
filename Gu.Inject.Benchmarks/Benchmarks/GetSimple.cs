namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;
    using SimpleInjector;

    [MemoryDiagnoser]
    public class GetSimple
    {
        private static readonly Ninject.StandardKernel StandardKernel = new(new Module());

        private static readonly SimpleInjector.Container SimpleInjectorContainer = new()
        {
            Options =
            {
                ResolveUnregisteredConcreteTypes = true,
                DefaultLifestyle = Lifestyle.Singleton,
            },
        };

        private static readonly DryIoc.Container DryIocContainer = new(x => x.WithConcreteTypeDynamicRegistrations()
            .WithDefaultReuse(Reuse.Singleton));

        private static readonly Kernel Kernel = new();

        private static readonly Kernel BoundKernel = new Kernel()
            .Bind(c => new Simple());

        [Benchmark]
        public object Ninject()
        {
            return StandardKernel.Get<Simple>();
        }

        [Benchmark]
        public object SimpleInjector()
        {
            return SimpleInjectorContainer.GetInstance<Simple>();
        }

        [Benchmark]
        public object DryIoc()
        {
            return DryIocContainer.Resolve<Simple>();
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Kernel.Get<Simple>();
        }

        [Benchmark]
        public object GuInjectBound()
        {
            return BoundKernel.Get<Simple>();
        }

        private sealed class Module : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                this.Bind<Simple>().ToSelf().InSingletonScope();
            }
        }
    }
}
