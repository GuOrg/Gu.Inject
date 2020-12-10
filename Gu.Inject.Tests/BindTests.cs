namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;

    using Moq;

    using NUnit.Framework;

    public static class BindTests
    {
        private static readonly TestCaseData[] ConcreteAndInterface =
        {
                new TestCaseData(typeof(C), typeof(C)),
                new TestCaseData(typeof(C), typeof(I1)),
                new TestCaseData(typeof(I1), typeof(C)),
                new TestCaseData(typeof(I1), typeof(I1)),
        };

        private static readonly TestCaseData[] ConcreteAndTwoInterfaces =
        {
                new TestCaseData(typeof(C), typeof(C)),
                new TestCaseData(typeof(C), typeof(I1)),
                new TestCaseData(typeof(C), typeof(I2)),
                new TestCaseData(typeof(I1), typeof(C)),
                new TestCaseData(typeof(I2), typeof(C)),
                new TestCaseData(typeof(I1), typeof(I1)),
                new TestCaseData(typeof(I1), typeof(I2)),
                new TestCaseData(typeof(I2), typeof(I1)),
                new TestCaseData(typeof(I2), typeof(I2)),
        };

        private static readonly TestCaseData[] ConcreteAndThreeInterfaces =
        {
                new TestCaseData(typeof(C), typeof(C)),
                new TestCaseData(typeof(C), typeof(I1)),
                new TestCaseData(typeof(C), typeof(I2)),
                new TestCaseData(typeof(C), typeof(I3)),
                new TestCaseData(typeof(I1), typeof(C)),
                new TestCaseData(typeof(I2), typeof(C)),
                new TestCaseData(typeof(I3), typeof(C)),
                new TestCaseData(typeof(I1), typeof(I1)),
                new TestCaseData(typeof(I1), typeof(I2)),
                new TestCaseData(typeof(I1), typeof(I3)),
                new TestCaseData(typeof(I2), typeof(I1)),
                new TestCaseData(typeof(I2), typeof(I2)),
                new TestCaseData(typeof(I2), typeof(I3)),
                new TestCaseData(typeof(I3), typeof(I1)),
                new TestCaseData(typeof(I3), typeof(I2)),
                new TestCaseData(typeof(I3), typeof(I3)),
        };

        [TestCase(typeof(I1), typeof(C))]
        [TestCase(typeof(I2), typeof(C))]
        [TestCase(typeof(I3), typeof(C))]
        [TestCase(typeof(IWith), typeof(With<DefaultCtor>))]
        [TestCase(typeof(OneToMany.Abstract), typeof(OneToMany.Concrete1))]
        [TestCase(typeof(OneToMany.Abstract), typeof(OneToMany.Concrete2))]
        [TestCase(typeof(OneToMany.IAbstract), typeof(OneToMany.Concrete1))]
        [TestCase(typeof(OneToMany.IAbstract), typeof(OneToMany.Concrete2))]
        [TestCase(typeof(OneToMany.IConcrete), typeof(OneToMany.Concrete1))]
        [TestCase(typeof(OneToMany.IConcrete), typeof(OneToMany.Concrete2))]
        [TestCase(typeof(OneToMany.IConcrete), typeof(OneToMany.Concrete2))]
        [TestCase(typeof(With<OneToMany.IConcrete>), typeof(With<OneToMany.Concrete2>))]
        [TestCase(typeof(IWith<OneToMany.IConcrete>), typeof(With<OneToMany.Concrete2>))]
        [TestCase(typeof(InheritNonAbstract.Foo), typeof(InheritNonAbstract.FooDerived))]
        public static void BindThenGet(Type from, Type to)
        {
            using var kernel = new Kernel();
            kernel.Bind(@from, to);
            var actual = kernel.Get(@from);
            Assert.AreSame(actual, kernel.Get(to));
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindConcreteAndInterfaceThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindConcreteAndTwoInterfacesThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2, C>();
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindConcreteAndTwoInterfacesInTwoStepsThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            kernel.Bind<I2, C>();
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndThreeInterfaces))]
        public static void BindConcreteAndThreeInterfacesThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2, I3, C>();
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndThreeInterfaces))]
        public static void BindConcreteAndThreeInterfacesInTwoStepsThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            kernel.Bind<I2, C>();
            kernel.Bind<I3, C>();
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndThreeInterfaces))]
        public static void BindConcreteAndThreeInterfacesRecursiveThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I3, C>();
            kernel.Bind<I1, I2>();
            kernel.Bind<I2, I3>();
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [Test]
        public static void BindGenericAndTwoInterfacesThenGet()
        {
            using var kernel = new Kernel();
            kernel.Bind<IWith, IWith<DefaultCtor>, With<DefaultCtor>>();
            Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
            Assert.AreSame(kernel.Get<IWith>(), kernel.Get<With<DefaultCtor>>());
        }

        [Test]
        public static void BindInstanceThenGet()
        {
            using var kernel = new Kernel();
            var instance = new C();
            kernel.Bind(instance);
            var actual = kernel.Get<C>();
            Assert.AreSame(actual, instance);
        }

        [Test]
        public static void BindMockObjectThenGet()
        {
            using var kernel = new Kernel();
            var instance = new Mock<I1>().Object;
            kernel.Bind<I1>(instance);
            var actual = kernel.Get<I1>();
            Assert.AreSame(actual, instance);
        }

        [Test]
        public static void BindResolveGetThenGet()
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(x => x.Get<C>());
            var actual = kernel.Get<I1>();
            Assert.AreSame(actual, kernel.Get<I1>());
        }

        [Test]
        public static void BindFuncGetThenGet()
        {
            using var kernel = new Kernel();
            //// ReSharper disable once AccessToDisposedClosure
            kernel.Bind<I1>(() => kernel.Get<C>());
            var actual = kernel.Get<I1>();
            Assert.AreSame(actual, kernel.Get<I1>());
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindInstanceAndInterfaceThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindInstanceAndInterfaceExplicitThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>(new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindInstanceAndTwoInterfacesThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2>(new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindInstanceAndTwoInterfacesExplicitThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2, C>(new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindInstanceAndTwoInterfacesInStepsThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            kernel.Bind<I2, C>(new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindInstanceAndTwoInterfacesInStepsAndExplicitThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            kernel.Bind<I2, C>();
            kernel.Bind(new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindFuncAndInterfaceThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(() => new C());
            if (type1.IsClass && type2.IsInterface)
            {
                _ = kernel.Get(type1);
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
                    Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
            }
            else
            {
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindFuncAndInterfaceExplicitThenGe(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>(() => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindFuncAndTwoInterfacesThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2>(() => new C());
            if (type1.IsClass && type2.IsInterface)
            {
                _ = kernel.Get(type1);
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
                    Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
            }
            else
            {
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindFuncAndTwoInterfacesExplicitThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2, C>(() => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindFuncAndTwoInterfacesInStepsThenGet(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2>();
            kernel.Bind<I2, C>(() => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [Test]
        public static void BindResolver()
        {
            using var kernel = new Kernel();
            kernel.Bind<C>(c => new C());
            Assert.AreSame(kernel.Get<C>(), kernel.Get<C>());
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindResolverAndInterface(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1>(_ => new C());
            if (type1.IsClass && type2.IsInterface)
            {
                _ = kernel.Get(type1);
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
                    Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
            }
            else
            {
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindResolverAndInterfaceExplicit(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>(_ => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndInterface))]
        public static void BindResolverAndInterfaceInSteps(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, C>();
            kernel.Bind(_ => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindResolverAndTwoInterfaces(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2>(_ => new C());
            if (type1.IsClass && type2.IsInterface)
            {
                _ = kernel.Get(type1);
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
                    Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
            }
            else
            {
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindResolverAndTwoInterfacesExplicit(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2, C>(_ => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }

        [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
        public static void BindResolverAndTwoInterfacesInSteps(Type type1, Type type2)
        {
            using var kernel = new Kernel();
            kernel.Bind<I1, I2>();
            kernel.Bind<I2, C>(_ => new C());
            Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
            Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
        }
    }
}
