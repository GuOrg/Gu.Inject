namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public static class ThrowTests
    {
        [TestCase(typeof(IWith), "Type IWith has no binding.")]
        [TestCase(typeof(int), "Type int has no binding.")]
        [TestCase(typeof(int?), "Type Nullable<int> has no binding.")]
        [TestCase(typeof(int[]), "Type int[] has no binding.")]
        [TestCase(typeof(IWith<int>), "Type IWith<int> has no binding.")]
        [TestCase(typeof(IWith<int?>), "Type IWith<Nullable<int>> has no binding.")]
        [TestCase(typeof(IWith<IWith<int>>), "Type IWith<IWith<int>> has no binding.")]
        [TestCase(typeof(OneToMany.Abstract), "Type OneToMany.Abstract has no binding.")]
        [TestCase(typeof(OneToMany.IAbstract), "Type OneToMany.IAbstract has no binding.")]
        [TestCase(typeof(OneToMany.IConcrete), "Type OneToMany.IConcrete has no binding.")]
        public static void GetWhenNoBinding(Type type, string expected)
        {
            using var kernel = new Kernel();
            var exception = Assert.Throws<NoBindingException>(() => kernel.Get(type));
            Assert.AreEqual(expected, exception.Message);
        }

        [TestCase(typeof(Circular1.A), "Circular1.A(\r\n  Circular1.B(\r\n    Circular1.A(... Circular dependency detected.\r\n")]
        [TestCase(typeof(Circular2.A), "Circular2.A(\r\n  Circular2.E(\r\n    Circular2.G(\r\n      Circular2.A(... Circular dependency detected.\r\n")]
        public static void GetWhenCircular(Type type, string message)
        {
            using var kernel = new Kernel();
            var exception = Assert.Throws<CircularDependencyException>(() => kernel.Get(type));
            Assert.AreEqual(message, exception.Message);
        }

        [Test]
        public static void GetWhenTwoConstructors()
        {
            using var kernel = new Kernel();
            var exception = Assert.Throws<ResolveException>(() => kernel.Get<Error.TwoCtors>());
            var expected = "Type Error.TwoCtors has more than one constructor.\r\n" +
                           "Add a binding specifying which constructor to use.";
            Assert.AreEqual(expected, exception.Message);
        }

        [Test]
        public static void GetWhenParamsCtor()
        {
            using var kernel = new Kernel();
            var exception = Assert.Throws<ResolveException>(() => kernel.Get<Error.ParamsCtor>());
            var expected = "Type Error.ParamsCtor has params parameter which is not supported.\r\n" +
                                 "Add a binding specifying how to create an instance.";
            Assert.AreEqual(expected, exception.Message);
        }

        [Test]
        public static void BindWhenHasResolved()
        {
            using var kernel = new Kernel();
            _ = kernel.Get<DefaultCtor>();
            var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
            Assert.AreEqual("Bind not allowed after resolving. This could create hard to track down graph bugs.", exception.Message);
        }

        [Test]
        public static void BindBindingToSame()
        {
            using var kernel = new Kernel();
            var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<C, C>());
            Assert.AreEqual("Trying to bind to the same type.\r\n This is the equivalent of kernel.Bind<SomeType, SomeType>() which is not strictly wrong but redundant and could indicate a real error hence this exception.", exception.Message);
        }

        [Test]
        public static void BindTypeWhenHasBinding()
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<I1, C>());
            Assert.AreEqual("I1 already has a binding. It is mapped to the type C", exception.Message);
        }

        [Test]
        public static void BindTypeWhenHasInstanceBinding()
        {
            using var kernel = new Kernel();
            var instance = new C();
            kernel.Bind<I1>(instance);
            var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<I1, C>());
            Assert.AreEqual("I1 already has a binding. It is mapped to C", exception.Message);
        }

        [Test]
        public static void BindInstanceWhenHasTypeBinding()
        {
            using var kernel = new Kernel();
            kernel.Bind<IWith, With<DefaultCtor>>();
            var instance = new With<DefaultCtor>(new DefaultCtor());
            var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith>(instance));
            Assert.AreEqual("IWith already has a binding. It is mapped to the type With<DefaultCtor>", exception.Message);
        }

        [Test]
        public static void BindFactoryAndInterfaceThenGetTypeFirst()
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(() => new C());

            _ = kernel.Get<C>(); // This works as it resolves using reflection and constructor.

            // Next get fails as there is already an instance created. Solution is Bind<I1, C>(() => new C())
            Assert.AreEqual(
                "There was already an instance created.\r\n" +
                "This can happen by doing:\r\n" +
                "1. Bind<I>(() => new C())" +
                "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                "Solution:\r\n" +
                "Specify explicit binding for the concrete type.\r\n" +
                "For example by: Bind<I, C>(() => new C())",
                Assert.Throws<ResolveException>(() => kernel.Get<I1>()).Message);
        }

        [Test]
        public static void BindGetterFactoryAndInterfaceThenGetTypeFirst()
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(_ => new C());

            _ = kernel.Get<C>(); // This works as it resolves using reflection and constructor.

            // Next get fails as there is already an instance created. Solution is Bind<I1, C>(c => new C())
            Assert.AreEqual(
                "There was already an instance created.\r\n" +
                "This can happen by doing:\r\n" +
                "1. Bind<I>(x => new C())" +
                "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                "Solution:\r\n" +
                "Specify explicit binding for the concrete type.\r\n" +
                "For example by: Bind<I, C>(x => new C())",
                Assert.Throws<ResolveException>(() => kernel.Get<I1>()).Message);
        }
    }
}
