namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Bind
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
            public void BindThenGet(Type from, Type to)
            {
                using var kernel = new Kernel();
                kernel.Bind(@from, to);
                var actual = kernel.Get(@from);
                Assert.AreSame(actual, kernel.Get(to));
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindConcreteAndInterfaceThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindConcreteAndTwoInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindConcreteAndTwoInterfacesInTwoStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndThreeInterfaces))]
            public void BindConcreteAndThreeInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, I3, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndThreeInterfaces))]
            public void BindConcreteAndThreeInterfacesInTwoStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                kernel.Bind<I3, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndThreeInterfaces))]
            public void BindConcreteAndThreeInterfacesRecursiveThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I3, C>();
                kernel.Bind<I1, I2>();
                kernel.Bind<I2, I3>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [Test]
            public void BindGenericAndTwoInterfacesThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, IWith<DefaultCtor>, With<DefaultCtor>>();
                Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(kernel.Get<IWith>(), kernel.Get<With<DefaultCtor>>());
            }

            [Test]
            public void BindInstanceThenGet()
            {
                using var kernel = new Kernel();
                var instance = new C();
                kernel.Bind(instance);
                var actual = kernel.Get<C>();
                Assert.AreSame(actual, instance);
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindInstanceAndInterfaceThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindInstanceAndInterfaceExplicitThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindInstanceAndTwoInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindInstanceAndTwoInterfacesExplicitThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindInstanceAndTwoInterfacesInStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindInstanceAndTwoInterfacesInStepsAndExplicitThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                kernel.Bind(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindFactoryAndInterfaceThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1>(() => new C());
                if (type1.IsClass && type2.IsInterface)
                {
                    _ = kernel.Get(type1);
                    Assert.AreEqual(
                        "There was already an instance created.\r\n" +
                        "This can happen by doing:\r\n" +
                        "1. Bind<I>(() => new C())" +
                        "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                        "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                        "Solution:\r\n" +
                        "Specify explicit binding for the concrete type.\r\n" +
                        "For example by: Bind<I, C>(() => new C())",
                        Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
                }
                else
                {
                    Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                    Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
                }
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindFactoryAndInterfaceExplicitThenGe(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(() => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindFactoryAndTwoInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>(() => new C());
                if (type1.IsClass && type2.IsInterface)
                {
                    _ = kernel.Get(type1);
                    Assert.AreEqual(
                        "There was already an instance created.\r\n" +
                        "This can happen by doing:\r\n" +
                        "1. Bind<I>(() => new C())" +
                        "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                        "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                        "Solution:\r\n" +
                        "Specify explicit binding for the concrete type.\r\n" +
                        "For example by: Bind<I, C>(() => new C())",
                        Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
                }
                else
                {
                    Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                    Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
                }
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindFactoryAndTwoInterfacesExplicitThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>(() => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindFactoryAndTwoInterfacesInStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>();
                kernel.Bind<I2, C>(() => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [Test]
            public void BindGetterFactory()
            {
                using var kernel = new Kernel();
                kernel.Bind<C>(c => new C());
                Assert.AreSame(kernel.Get<C>(), kernel.Get<C>());
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindGetterFactoryAndInterface(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1>(c => new C());
                if (type1.IsClass && type2.IsInterface)
                {
                    _ = kernel.Get(type1);
                    Assert.AreEqual(
                        "There was already an instance created.\r\n" +
                        "This can happen by doing:\r\n" +
                        "1. Bind<I>(x => new C())" +
                        "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                        "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                        "Solution:\r\n" +
                        "Specify explicit binding for the concrete type.\r\n" +
                        "For example by: Bind<I, C>(x => new C())",
                        Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
                }
                else
                {
                    Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                    Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
                }
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindGetterFactoryAndInterfaceExplicit(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(c => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndInterface))]
            public void BindGetterFactoryAndInterfaceInSteps(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind(c => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindGetterFactoryAndTwoInterfaces(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>(c => new C());
                if (type1.IsClass && type2.IsInterface)
                {
                    _ = kernel.Get(type1);
                    Assert.AreEqual(
                        "There was already an instance created.\r\n" +
                        "This can happen by doing:\r\n" +
                        "1. Bind<I>(x => new C())" +
                        "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                        "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                        "Solution:\r\n" +
                        "Specify explicit binding for the concrete type.\r\n" +
                        "For example by: Bind<I, C>(x => new C())",
                        Assert.Throws<ResolveException>(() => kernel.Get(type2)).Message);
                }
                else
                {
                    Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                    Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
                }
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindGetterFactoryAndTwoInterfacesExplicit(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>(c => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCaseSource(nameof(ConcreteAndTwoInterfaces))]
            public void BindGetterFactoryAndTwoInterfacesInSteps(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>();
                kernel.Bind<I2, C>(c => new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }
        }
    }
}