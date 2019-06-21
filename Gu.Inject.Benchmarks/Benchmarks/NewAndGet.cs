// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Ninject;
    using SimpleInjector;

    [MemoryDiagnoser]
    public abstract class NewAndGet<T>
        where T : class
    {
        [Benchmark]
        public object Ninject()
        {
            using (var kernel = new Ninject.StandardKernel())
            {
                return kernel.Get<T>();
            }
        }

        [Benchmark]
        public object SimpleInjector()
        {
            using (var container = new Container())
            {
                return container.GetInstance<T>();
            }
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            using (var kernel = new Kernel<object>())
            {
                return kernel.Get<T>();
            }
        }
    }
}