namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;

    using Moq;

    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Bind
        {
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

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            public void BindConcreteAndInterfaceThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            public void BindConcreteAndTwoInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            public void BindConcreteAndTwoInterfacesInTwoStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(C), typeof(I3))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I3), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            [TestCase(typeof(I3), typeof(I2))]
            [TestCase(typeof(I3), typeof(I3))]
            public void BindConcreteAndThreeInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, I3, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(C), typeof(I3))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I3), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            [TestCase(typeof(I3), typeof(I2))]
            [TestCase(typeof(I3), typeof(I3))]
            public void BindConcreteAndThreeInterfacesInTwoStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                kernel.Bind<I3, C>();
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(C), typeof(I3))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I3), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            [TestCase(typeof(I3), typeof(I2))]
            [TestCase(typeof(I3), typeof(I3))]
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

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            public void BindInstanceAndInterfaceThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            public void BindInstanceAndInterfaceExplicitThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(I1),typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            public void BindInstanceAndTwoInterfacesThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            public void BindInstanceAndTwoInterfacesExplicitThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [TestCase(typeof(C), typeof(C))]
            [TestCase(typeof(C), typeof(I1))]
            [TestCase(typeof(C), typeof(I2))]
            [TestCase(typeof(I1), typeof(C))]
            [TestCase(typeof(I2), typeof(C))]
            [TestCase(typeof(I1), typeof(I1))]
            [TestCase(typeof(I1), typeof(I2))]
            [TestCase(typeof(I2), typeof(I1))]
            [TestCase(typeof(I2), typeof(I2))]
            public void BindInstanceAndTwoInterfacesInStepsThenGet(Type type1, Type type2)
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(new C());
                kernel.Bind<I2, C>(new C());
                Assert.AreSame(kernel.Get(type1), kernel.Get(type2));
                Assert.AreSame(kernel.Get(type2), kernel.Get(type1));
            }

            [Test]
            public void BindFactoryAndInterfaceThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith>(() => new With<DefaultCtor>(new DefaultCtor()));
                Assert.AreSame(kernel.Get<With<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(kernel.Get<IWith>(), kernel.Get<IWith>());
            }

            [Test]
            public void BindFactoryAndInterfaceExplicitThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith<DefaultCtor>, With<DefaultCtor>>(() => new With<DefaultCtor>(new DefaultCtor()));
                Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
            }

            [Test]
            public void BindFactoryAndTwoInterfacesThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, IWith<DefaultCtor>, With<DefaultCtor>>(() => new With<DefaultCtor>(new DefaultCtor()));
                Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(kernel.Get<IWith>(), kernel.Get<With<DefaultCtor>>());
            }

            [Test]
            public void BindFactoryWithGetter()
            {
                using var kernel = new Kernel();
                kernel.Bind(x => new With<DefaultCtor>(x.Get<DefaultCtor>()));
                var actual = kernel.Get<With<DefaultCtor>>();
                Assert.AreSame(actual, kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(actual.Value, kernel.Get<DefaultCtor>());
            }

            [Test]
            public void BindFactoryWithGetterAndInterface()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith>(x => new With<DefaultCtor>(x.Get<DefaultCtor>()));
                var actual = kernel.Get<With<DefaultCtor>>();
                Assert.AreSame(actual, kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(actual, kernel.Get<IWith>());
                Assert.AreSame(actual.Value, kernel.Get<DefaultCtor>());
            }

            [Test]
            public void BindFactoryWithGetterAndInterfaceExplicit()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, With<DefaultCtor>>(x => new With<DefaultCtor>(x.Get<DefaultCtor>()));
                var actual = kernel.Get<With<DefaultCtor>>();
                Assert.AreSame(actual, kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(actual, kernel.Get<IWith>());
                Assert.AreSame(actual.Value, kernel.Get<DefaultCtor>());
            }
        }
    }
}