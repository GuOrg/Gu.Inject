namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public partial class ContainerTests
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
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    container.Bind(from, to);
                //    var actual = container.Get(from);
                //    Assert.AreSame(actual, container.Get(to));
                //}
            }

            [Test]
            public void BindInstanceThenGet()
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    var instance = new DefaultCtor();
                //    container.Bind(instance);
                //    var actual = container.Get<DefaultCtor>();
                //    Assert.AreSame(actual, instance);
                //}
            }

            [Test]
            public void BindInstanceAndInterfaceThenGet()
            {
                Assert.Inconclusive("Fix later.");
                //var instance = new With<DefaultCtor>(new DefaultCtor());

                //using (var container = new Container<object>())
                //{
                //    container.Bind(instance);
                //    container.Bind<IWith<DefaultCtor>, With<DefaultCtor>>();

                //    object actual = container.Get<With<DefaultCtor>>();
                //    Assert.AreSame(actual, instance);

                //    actual = container.Get<IWith<DefaultCtor>>();
                //    Assert.AreSame(actual, instance);
                //}
            }

            [Test]
            public void BindTwoThenGet()
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    container.Bind<IWith, IWith<DefaultCtor>, With<DefaultCtor>>();
                //    Assert.AreSame(container.Get<IWith<DefaultCtor>>(), container.Get<With<DefaultCtor>>());
                //    Assert.AreSame(container.Get<IWith>(), container.Get<With<DefaultCtor>>());
                //}
            }

            [Test]
            public void BoundInstanceIsNotDisposed()
            {
                Assert.Inconclusive("Fix later.");
                //using (var disposable = new Disposable())
                //{
                //    using (var container = new Container<object>())
                //    {
                //        container.Bind(disposable);
                //        var actual = container.Get<Disposable>();
                //        Assert.AreSame(actual, disposable);
                //    }

                //    Assert.AreEqual(0, disposable.Disposed);
                //}
            }

            [Test]
            public void BindFactory()
            {
                Assert.Inconclusive("Fix later.");
                //Mock<IDisposable> mock;
                //using (var container = new Container<object>())
                //{
                //    container.Bind(Mock.Of<IDisposable>);
                //    var actual = container.Get<IDisposable>();
                //    mock = Mock.Get(actual);
                //    mock.Setup(x => x.Dispose());
                //}

                //mock.Verify(x => x.Dispose(), Times.Once);
            }

            [Test]
            public void BindFactoryWithArgument()
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    container.Bind((DefaultCtor x) => new With<DefaultCtor>(x));
                //    var actual = container.Get<With<DefaultCtor>>();
                //    Assert.AreSame(actual, container.Get<With<DefaultCtor>>());
                //    Assert.AreSame(actual.Value, container.Get<DefaultCtor>());
                //}
            }

            [Test]
            public void BindFactoryWithGetter()
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    container.Bind(x => new With<DefaultCtor>(x.Get<DefaultCtor>()));
                //    var actual = container.Get<With<DefaultCtor>>();
                //    Assert.AreSame(actual, container.Get<With<DefaultCtor>>());
                //    Assert.AreSame(actual.Value, container.Get<DefaultCtor>());
                //}
            }

            [Test]
            public void BindFactoryWithArgumentDisposed()
            {
                Assert.Inconclusive("Fix later.");
                //DisposableWith<DefaultCtor> actual;
                //using (var container = new Container<object>())
                //{
                //    container.Bind((DefaultCtor x) => new DisposableWith<DefaultCtor>(x));
                //    actual = container.Get<DisposableWith<DefaultCtor>>();
                //    Assert.AreSame(actual.Value, container.Get<DefaultCtor>());
                //}

                //Assert.AreEqual(1, actual.Disposed);
            }
        }
    }
}