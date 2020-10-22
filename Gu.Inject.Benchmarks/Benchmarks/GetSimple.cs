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
#pragma warning disable IDISP004 // Don't ignore created IDisposable.
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new Module());
#pragma warning restore IDISP004 // Don't ignore created IDisposable.
        private static readonly SimpleInjector.Container SimpleInjectorContainer = new SimpleInjector.Container
        {
            Options =
            {
                ResolveUnregisteredConcreteTypes = true,
                DefaultLifestyle = Lifestyle.Singleton,
            },
        };

        private static readonly DryIoc.Container DryIocContainer = new DryIoc.Container(x => x.WithConcreteTypeDynamicRegistrations()
            .WithDefaultReuse(Reuse.Singleton));

        private static readonly Kernel Kernel = new Kernel();

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

        private class Module : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                this.Bind<Simple>().ToSelf().InSingletonScope();
            }
        }
    }
}