namespace Gu.Inject.Benchmarks.Benchmarks
{
    using System;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    public class Reflection
    {
        private static readonly ConstructorInfo Ctor = typeof(Foo).GetConstructors()[0];

        [Benchmark]
        public object GetConstructors()
        {
           return typeof(Foo).GetConstructors()[0];
        }

        [Benchmark]
        public object GetConstructorsGetParameters()
        {
            return typeof(Foo).GetConstructors()[0].GetParameters();
        }

        [Benchmark]
        public object InvokeCtor()
        {
            return Ctor.Invoke(null);
        }

        [Benchmark]
        public object ActivatorCreateInstance()
        {
            return Activator.CreateInstance<Foo>();
        }

        [Benchmark]
        public object GetConstructorInvoke()
        {
            return typeof(Foo).GetConstructors()[0].Invoke(null);
        }
    }
}
