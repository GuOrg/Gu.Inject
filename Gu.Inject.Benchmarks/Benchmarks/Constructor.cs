namespace Gu.Inject.Benchmarks
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using BenchmarkDotNet.Attributes;
    using Gu.Inject.Benchmarks.Types;

    [MemoryDiagnoser]
    public class Constructor
    {
        private static readonly ConstructorInfo ConstructorInfo = typeof(Simple).GetConstructors()[0];
        private static readonly Func<Simple> ConstructorDelegate = CreateDelegate();

        [Benchmark(Baseline = true)]
        public object New()
        {
            return new Simple();
        }

        [Benchmark]
        public object ConstructorDelegateInvoke()
        {
            return ConstructorDelegate.Invoke();
        }

        [Benchmark]
        public object CreateConstructorDelegate()
        {
            return CreateDelegate();
        }

        [Benchmark]
        public object ConstructorInfoInvoke()
        {
            return ConstructorInfo.Invoke(null);
        }

        [Benchmark]
        public object ActivatorCreateInstance()
        {
            return Activator.CreateInstance<Simple>();
        }

        private static Func<Simple> CreateDelegate()
        {
            // http://stackoverflow.com/a/10593806/1069200
            var type = typeof(Simple);
            var dynamic = new DynamicMethod(
                string.Empty,
                type,
                Type.EmptyTypes,
                type);
            var il = dynamic.GetILGenerator();
            _ = il.DeclareLocal(type);
            il.Emit(OpCodes.Newobj, ConstructorInfo);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);

            return (Func<Simple>)dynamic.CreateDelegate(typeof(Func<Simple>));
        }
    }
}