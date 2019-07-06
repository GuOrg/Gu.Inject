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
        public object Ninject() => new Ninject.StandardKernel().Get<T>();

        [Benchmark]
        public object SimpleInjector() => new Container().GetInstance<T>();
    }
}