// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    using DryIoc;

    using Ninject;
    using SimpleInjector;

    [MemoryDiagnoser]
    public abstract class Get<T>
        where T : class
    {
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new Module());
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

        [Benchmark]
        public object Ninject()
        {
            return StandardKernel.Get<T>();
        }

        [Benchmark]
        public object SimpleInjector()
        {
            return SimpleInjectorContainer.GetInstance<T>();
        }

        [Benchmark]
        public object DryIoc()
        {
            return DryIocContainer.Resolve<T>();
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Kernel.Get<T>();
        }

        private class Module : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                this.Bind<T>().ToSelf().InSingletonScope();
            }
        }
    }
}
