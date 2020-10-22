// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Ninject;

    [MemoryDiagnoser]
    public abstract class Get<T>
        where T : class
    {
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new Module());
        private static readonly SimpleInjector.Container Container = new SimpleInjector.Container();
        private static readonly Kernel Kernel = new Kernel();

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

        private class Module : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                this.Bind<T>().ToSelf().InSingletonScope();
            }
        }
    }
}
