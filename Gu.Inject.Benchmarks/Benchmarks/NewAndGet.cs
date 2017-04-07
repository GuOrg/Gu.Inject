namespace Gu.Inject.Benchmarks.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    public class NewAndGet
    {
        [Benchmark(Baseline = true)]
        public object Ninject()
        {
            using (var kernel = new Ninject.StandardKernel())
            {
                return kernel.Get<Foo>();
            }
        }

        [Benchmark]
        public object GuInject()
        {
            using (var kernel = new Kernel())
            {
                return kernel.Get<Foo>();
            }
        }
    }
}