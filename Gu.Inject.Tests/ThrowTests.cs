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
            Assert.AreEqual(
                expected,
                Assert.Throws<NoBindingException>(() => kernel.Get(type)).Message);
        }

        [TestCase(typeof(Circular1.A), "Circular1.A(\r\n  Circular1.B(\r\n    Circular1.A(... Circular dependency detected.\r\n")]
        [TestCase(typeof(Circular2.A), "Circular2.A(\r\n  Circular2.E(\r\n    Circular2.G(\r\n      Circular2.A(... Circular dependency detected.\r\n")]
        public static void GetWhenCircular(Type type, string message)
        {
            using var kernel = new Kernel();
            Assert.AreEqual(
                message,
                Assert.Throws<CircularDependencyException>(() => kernel.Get(type)).Message);
        }

        [Test]
        public static void GetWhenTwoConstructors()
        {
            using var kernel = new Kernel();
            Assert.AreEqual(
                "Type Error.TwoCtors has more than one constructor.\r\n" +
                "Add a binding specifying which constructor to use.",
                Assert.Throws<ResolveException>(() => kernel.Get<Error.TwoCtors>()).Message);
        }

        [Test]
        public static void GetWhenParamsCtor()
        {
            using var kernel = new Kernel();
            Assert.AreEqual(
                "Type Error.ParamsCtor has params parameter which is not supported.\r\n" +
                "Add a binding specifying how to create an instance.",
                Assert.Throws<ResolveException>(() => kernel.Get<Error.ParamsCtor>()).Message);
        }

        [Test]
        public static void BindWhenHasResolved()
        {
            using var kernel = new Kernel();
            _ = kernel.Get<DefaultCtor>();
            Assert.AreEqual(
                "Bind not allowed after Get<T>().\r\n" +
                "This could create hard to track down graph bugs.",
                Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>()).Message);
        }

        [Test]
        public static void BindBindingToSame()
        {
            using var kernel = new Kernel();
            Assert.AreEqual(
                "Trying to bind to the same type.\r\n" +
                "This is the equivalent of kernel.Bind<C, C>().\r\n" +
                "It is not strictly wrong but redundant and could indicate a mistake and hence disallowed.",
                Assert.Throws<InvalidOperationException>(() => kernel.Bind<C, C>()).Message);
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
            Assert.AreEqual(
                "I1 already has a binding. It is mapped to C",
                Assert.Throws<InvalidOperationException>(() => kernel.Bind<I1, C>()).Message);
        }

        [Test]
        public static void BindInstanceWhenHasTypeBinding()
        {
            using var kernel = new Kernel();
            kernel.Bind<IWith, With<DefaultCtor>>();
            var instance = new With<DefaultCtor>(new DefaultCtor());
            Assert.AreEqual(
                "IWith already has a binding. It is mapped to the type With<DefaultCtor>",
                Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith>(instance)).Message);
        }

        [Test]
        public static void BindFactoryAndInterfaceThenGetTypeFirst()
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(() => new C());

            _ = kernel.Get<C>(); // This works as it resolves using reflection and constructor.

            // Next get fails as there is already an instance created. Solution is Bind<I1, C>(() => new C())
            Assert.AreEqual(
                "An instance of type C was already created.\r\n" +
                "The existing instance was created via constructor.\r\n" +
                "This can happen by doing:\r\n" +
                "1. Bind<I>(() => new C())\r\n" +
                "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                "3. Get<I>() this creates an instance of C using the bound Func<C> and then detects the instance created in 2.\r\n" +
                "\r\n" +
                "Specify explicit binding for the concrete type.\r\n" +
                "For example by:\r\n" +
                "Bind<I, C>(() => new C())\r\n" +
                "or\r\n" +
                "Bind<I, C>()\r\n" +
                "Bind<C>(() => new C())",
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
                "An instance of type C was already created.\r\n" +
                "The existing instance was created via constructor.\r\n" +
                "This can happen by doing:\r\n" +
                "1. Bind<I>(x => new C(...))\r\n" +
                "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                "3. Get<I>() this creates an instance of C using the bound Func<IGetter, C> and then detects the instance created in 2.\r\n" +
                "\r\n" +
                "Specify explicit binding for the concrete type.\r\n" +
                "For example by:\r\n" +
                "Bind<I, C>(x => new C(...))\r\n" +
                "or\r\n" +
                "Bind<I, C>()\r\n" +
                "Bind<C>(x => new C(...))",
                Assert.Throws<ResolveException>(() => kernel.Get<I1>()).Message);
        }
    }
}
