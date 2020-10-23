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

            [Test]
            public void BindTwoInterfacesThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>();
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
            }

            [Test]
            public void BindTwoInterfacesInTwoStepsThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
            }

            [Test]
            public void BindThreeInterfacesThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, I3, C>();
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I3>(), kernel.Get<C>());
            }

            [Test]
            public void BindThreeInterfacesInTwoStepsThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>();
                kernel.Bind<I2, C>();
                kernel.Bind<I3, C>();
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
            }

            [Test]
            public void BindThreeInterfacesRecursiveThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I3, C>();
                kernel.Bind<I1, I2>();
                kernel.Bind<I2, I3>();
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
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

            [Test]
            public void BindInstanceAndInterfaceThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1>(new C());
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
            }

            [Test]
            public void BindInstanceAndInterfaceExplicitThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(new C());
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
            }

            [Test]
            public void BindInstanceAndTwoInterfacesThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2>(new C());
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
            }

            [Test]
            public void BindInstanceAndTwoInterfacesExplicitThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, I2, C>(new C());
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
            }

            [Test]
            public void BindInstanceAndTwoInterfacesInStepsThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<I1, C>(new C());
                kernel.Bind<I2, C>(new C());
                Assert.AreSame(kernel.Get<I1>(), kernel.Get<C>());
                Assert.AreSame(kernel.Get<I2>(), kernel.Get<C>());
            }

            [Test]
            public void BindTwoThenGet()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, IWith<DefaultCtor>, With<DefaultCtor>>();
                Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
                Assert.AreSame(kernel.Get<IWith>(), kernel.Get<With<DefaultCtor>>());
            }

            [Test]
            public void BoundInstanceIsNotDisposed()
            {
                using var disposable = new Disposable();
                using (var kernel = new Kernel())
                {
                    kernel.Bind(disposable);
                    var actual = kernel.Get<Disposable>();
                    Assert.AreSame(actual, disposable);
                }

                Assert.AreEqual(0, disposable.Disposed);
            }

            [Test]
            public void BindFactory()
            {
                Mock<IDisposable> mock;
                using (var kernel = new Kernel())
                {
                    kernel.Bind(Mock.Of<IDisposable>);
                    var actual = kernel.Get<IDisposable>();
                    mock = Mock.Get(actual);
                    mock.Setup(x => x.Dispose());
                }

                mock.Verify(x => x.Dispose(), Times.Once);
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