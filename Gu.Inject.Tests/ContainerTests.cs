namespace Gu.Inject.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public partial class ContainerTests
    {
        [TestCase(typeof(DefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(IDefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(With<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(IWith<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, DefaultCtor>), typeof(WithTwo<DefaultCtor, DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, With<DefaultCtor>>), typeof(WithTwo<DefaultCtor, With<DefaultCtor>>))]
        [TestCase(typeof(WithTwo<WithTwo<ManyToOne.IFoo, ManyToOne.IFooBase1>, With<DefaultCtor>>), typeof(WithTwo<WithTwo<ManyToOne.IFoo, ManyToOne.IFooBase1>, With<DefaultCtor>>))]
        [TestCase(typeof(OneToOne.Concrete), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.Abstract), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.IAbstract), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.IConcrete), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOneGeneric.AbstractGeneric<DefaultCtor>), typeof(OneToOneGeneric.GenericOfDefaultCtor))]
        [TestCase(typeof(OneToOneGeneric.GenericOfDefaultCtor), typeof(OneToOneGeneric.GenericOfDefaultCtor))]
        [TestCase(typeof(InheritNonAbstract.FooDerived), typeof(InheritNonAbstract.FooDerived))]
        [TestCase(typeof(ManyToOne.Foo), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.FooBase), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.FooBaseBase), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IFoo1), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IFoo2), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IFooBase1), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IFooBase2), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IGenericFoo1<int>), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IGenericFoo1<double>), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IGenericFoo2<int>), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IFooFoo), typeof(ManyToOne.Foo))]
        [TestCase(typeof(ManyToOne.IFoo), typeof(ManyToOne.Foo))]
        public void Get(Type type, Type expected)
        {
            Assert.Inconclusive("Fix later.");
            //using (var container = new Container<object>())
            //{
            //    var actual = container.Get(type);
            //    Assert.AreEqual(expected.PrettyName(), actual.GetType().PrettyName());
            //    Assert.AreSame(actual, container.Get(expected));
            //}
        }

        [Test]
        public void Singletons()
        {
            using (var container = new Container<Foo>().AutoBind())
            {
                var x = container.Get<Foo>();
                var y = container.Get<Foo>();
                Assert.AreSame(x, y);
                Assert.AreSame(x.Bar, y.Bar);
            }
        }

        [Test]
        public void SingletonsWhenTwoParameters()
        {
            using (var container = new Container<WithTwo<DefaultCtor, DefaultCtor>>().AutoBind())
            {
                var actual = container.Get<WithTwo<DefaultCtor, DefaultCtor>>();
                Assert.AreSame(actual.Value1, actual.Value2);
            }
        }

        [Test]
        public void GetGraph50()
        {
            using (var container = new Container<Graph50.Node1>().AutoBind())
            {
                var root = container.Get<Graph50.Node1>();
                var allChildren = root.AllChildren.ToArray();
                Console.WriteLine($"Total count: {allChildren.Length}");
                var distinct = allChildren.Distinct().ToArray();
                Console.WriteLine($"Unique count: {distinct.Length}");
                Assert.AreEqual(distinct.Length, allChildren.Select(x => x.GetType()).Distinct().Count());
            }
        }

        [Test]
        public void DisposesCreated()
        {
            Disposable actual;
            using (var container = new Container<Disposable>().AutoBind())
            {
                actual = container.Get<Disposable>();
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }

        [Test]
        public void NotifiesCreating()
        {
            using (var container = new Container<object>())
            {
                var actual = new List<Type>();
                container.Creating += (sender, type) => actual.Add(type);
                container.Bind(() =>
                {
                    // check that we notify before creating.
                    CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
                    return new DefaultCtor();
                });
                _ = container.Get<DefaultCtor>();
                CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
            }
        }
    }
}
