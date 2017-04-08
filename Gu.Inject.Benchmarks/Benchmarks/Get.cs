namespace Gu.Inject.Benchmarks.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;
    using Ninject.Modules;

    using SimpleInjector;

    public class Get
    {
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new Module());
        private static readonly Container Container = new Container();
        private static readonly Kernel Kernel = new Kernel();

        [Benchmark]
        public object Ninject()
        {
            return StandardKernel.Get<Foo>();
        }

        [Benchmark]
        public object SimpleInjector()
        {
            return Container.GetInstance<Foo>();
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            return Kernel.Get<Foo>();
        }

        private class Module : NinjectModule
        {
            public override void Load()
            {
                this.Bind<Foo>().ToSelf().InSingletonScope();
            }
        }
    }
}
