namespace Gu.Inject.Benchmarks.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;
    using SimpleInjector;

    public class NewAndGet
    {
        [Benchmark]
        public object Ninject()
        {
            using (var kernel = new Ninject.StandardKernel())
            {
                return kernel.Get<Foo>();
            }
        }

        [Benchmark]
        public object SimpleInjector()
        {
            using (var container = new Container())
            {
                return container.GetInstance<Foo>();
            }
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            using (var kernel = new Kernel())
            {
                return kernel.Get<Foo>();
            }
        }
    }
}