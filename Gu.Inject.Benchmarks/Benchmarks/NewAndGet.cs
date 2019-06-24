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
        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            using (var container = new Container<object>())
            {
                return container.Get<T>();
            }
        }

        [Benchmark]
        public object Ninject()
        {
            using (var container = new Ninject.StandardKernel())
            {
                return container.Get<T>();
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
    }
}