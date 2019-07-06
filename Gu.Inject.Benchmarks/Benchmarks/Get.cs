// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Ninject;
    using Ninject.Modules;

    [MemoryDiagnoser]
    public abstract class Get<T>
        where T : class
    {
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel(new Module());
        private static readonly SimpleInjector.Container SimpleInjectorContainer = new SimpleInjector.Container();

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

        private class Module : NinjectModule
        {
            public override void Load()
            {
                this.Bind<T>().ToSelf().InSingletonScope();
            }
        }
    }
}
