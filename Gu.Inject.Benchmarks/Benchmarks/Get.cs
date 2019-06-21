// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Ninject;
    using Ninject.Modules;
    using SimpleInjector;

    [MemoryDiagnoser]
    public abstract class Get<T>
        where T : class
    {
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new Module());
        private static readonly Container Container = new Container();
        private static readonly Kernel<object> Kernel = new Kernel<object>();

        [Benchmark]
        public object Ninject()
        {
            return StandardKernel.Get<T>();
        }

        [Benchmark]
        public object SimpleInjector()
        {
            return Container.GetInstance<T>();
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Kernel.Get<T>();
        }

        private class Module : NinjectModule
        {
            public override void Load()
            {
                this.Bind<T>().ToSelf().InSingletonScope();
            }
        }
    }
}
