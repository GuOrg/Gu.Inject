// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Ninject;
    using SimpleInjector;

    [MemoryDiagnoser]
    public abstract class NewAndGet<T>
        where T : class
    {
        [Benchmark]
        public object Ninject()
        {
            using var kernel = new Ninject.StandardKernel();
            return kernel.Get<T>();
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
            return container.GetInstance<T>();
        }

        [Benchmark]
        public object DryIoc()
        {
            using var container = new DryIoc.Container(x => x.WithConcreteTypeDynamicRegistrations()
                                                                  .WithDefaultReuse(Reuse.Singleton));
            return container.Resolve<T>();
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            using var kernel = new Kernel();
            return kernel.Get<T>();
        }
    }
}