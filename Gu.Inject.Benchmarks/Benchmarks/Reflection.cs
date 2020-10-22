namespace Gu.Inject.Benchmarks
{
    using System;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class Reflection
    {
        private static readonly ConstructorInfo Ctor = typeof(Simple).GetConstructors()[0];

        [Benchmark]
        public object GetConstructors()
        {
            return typeof(Simple).GetConstructors()[0];
        }

        [Benchmark]
        public object GetConstructorsGetParameters()
        {
            return typeof(Simple).GetConstructors()[0].GetParameters();
        }

        [Benchmark]
        public object InvokeCtor()
        {
            return Ctor.Invoke(null);
        }

        [Benchmark]
        public object ActivatorCreateInstance()
        {
            return Activator.CreateInstance<Simple>();
        }

        [Benchmark]
        public object GetConstructorInvoke()
        {
            return typeof(Simple).GetConstructors()[0].Invoke(null);
        }
    }
}
