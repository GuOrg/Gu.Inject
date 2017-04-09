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
            [TestCase(typeof(InheritNonAbstract.FooDerived), typeof(InheritNonAbstract.FooDerived))]
            [TestCase(typeof(InheritNonAbstract.Foo), typeof(InheritNonAbstract.FooDerived))]
            [TestCase(typeof(InheritNonAbstract.Foo), typeof(InheritNonAbstract.Foo))]
            public void BindThenGet(Type from, Type to)
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind(from, to);
                    var actual = kernel.Get(from);
                    Assert.AreSame(actual, kernel.Get(to));
                }
            }

            [Test]
            public void BindInstanceThenGet()
            {
                using (var kernel = new Kernel())
                {
                    var instance = new DefaultCtor();
                    kernel.BindConstant(instance);
                    var actual = kernel.Get<DefaultCtor>();
                    Assert.AreSame(actual, instance);
                }
            }

            [Test]
            public void BindInstanceAndInterfaceThenGet()
            {
                var instance = new With<DefaultCtor>(new DefaultCtor());

                using (var kernel = new Kernel())
                {
                    kernel.BindConstant(instance);
                    kernel.Bind<IWith<DefaultCtor>, With<DefaultCtor>>();

                    object actual = kernel.Get<With<DefaultCtor>>();
                    Assert.AreSame(actual, instance);

                    actual = kernel.Get<IWith<DefaultCtor>>();
                    Assert.AreSame(actual, instance);
                }
            }

            [Test]
            public void BindTwoThenGet()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind<IWith, IWith<DefaultCtor>, With<DefaultCtor>>();
                    Assert.AreSame(kernel.Get<IWith<DefaultCtor>>(), kernel.Get<With<DefaultCtor>>());
                    Assert.AreSame(kernel.Get<IWith>(), kernel.Get<With<DefaultCtor>>());
                }
            }

            [Test]
            public void BoundInstanceIsNotDisposed()
            {
                using (var disposable = new Disposable())
                {
                    using (var kernel = new Kernel())
                    {
                        kernel.BindConstant(disposable);
                        var actual = kernel.Get<Disposable>();
                        Assert.AreSame(actual, disposable);
                    }

                    Assert.AreEqual(0, disposable.Disposed);
                }
            }

            [Test]
            public void BindFunc()
            {
                Mock<IDisposable> mock;
                using (var kernel = new Kernel())
                {
                    kernel.BindMethod(Mock.Of<IDisposable>);
                    var actual = kernel.Get<IDisposable>();
                    mock = Mock.Get(actual);
                    mock.Setup(x => x.Dispose());
                }

                mock.Verify(x => x.Dispose(), Times.Once);
            }
        }
    }
}