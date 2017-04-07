namespace Gu.Inject.Benchmarks.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;
    using Ninject;

    public class Get
    {
        private static readonly Ninject.StandardKernel StandardKernel = new Ninject.StandardKernel();
        private static readonly Kernel Kernel = new Kernel();

        [Benchmark(Baseline = true)]
        public object NinjectGetFoo()
        {
            return StandardKernel.Get<Foo>();
        }

        [Benchmark]
        public object GuInject()
        {
            return Kernel.Get<Foo>();
        }
    }
}
