namespace Gu.Inject.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public partial class KernelTests
    {
        [TestCase(typeof(IGetter))]
        [TestCase(typeof(DefaultCtor))]
        [TestCase(typeof(StaticConstructor))]
        [TestCase(typeof(With<DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, With<DefaultCtor>>))]
        [TestCase(typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOneGeneric.GenericOfDefaultCtor))]
        [TestCase(typeof(InheritNonAbstract.FooDerived))]
        [TestCase(typeof(ManyToOne.Foo))]
        public void Get(Type type)
        {
            using var kernel = new Kernel();
            var actual = kernel.Get(type);
            Assert.AreSame(actual, kernel.Get(type));
        }

        [Test]
        public void GetSubclassesReturnsDifferentByDefault()
        {
            using var kernel = new Kernel();
            Assert.AreNotSame(kernel.Get<InheritNonAbstract.Foo>(), kernel.Get<InheritNonAbstract.FooDerived>());
        }

        [Test]
        public void GetSubclassesReturnsSameWithBindings()
        {
            using var kernel = new Kernel();
            kernel.Bind<InheritNonAbstract.Foo, InheritNonAbstract.FooDerived>();
            Assert.AreSame(kernel.Get<InheritNonAbstract.Foo>(), kernel.Get<InheritNonAbstract.FooDerived>());
        }

        [TestCase(typeof(IDefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(IWith<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(OneToOne.Abstract), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.IAbstract), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.IConcrete), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOneGeneric.AbstractGeneric<DefaultCtor>), typeof(OneToOneGeneric.GenericOfDefaultCtor))]
        [TestCase(typeof(InheritNonAbstract.Foo), typeof(InheritNonAbstract.FooDerived))]
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
        public void BindThenGet(Type type, Type expected)
        {
            using var kernel = new Kernel();
            kernel.Bind(type, expected);
            var actual = kernel.Get(type);
            Assert.AreEqual(expected.PrettyName(), actual.GetType().PrettyName());
            Assert.AreSame(actual, kernel.Get(expected));
        }

        [Test]
        public void InjectsSingletons1()
        {
            using var kernel = new Kernel();
            var actual = kernel.Get<WithTwo<DefaultCtor, DefaultCtor>>();
            Assert.AreSame(actual.Value1, actual.Value2);
        }

        [Test]
        public void InjectsSingletonsWithBindings()
        {
            using var kernel = new Kernel();
            kernel.Bind<ManyToOne.IFoo, ManyToOne.Foo>();
            kernel.Bind<ManyToOne.IFooBase1, ManyToOne.Foo>();
            var actual = kernel.Get<WithTwo<WithTwo<ManyToOne.IFoo, ManyToOne.IFooBase1>, With<DefaultCtor>>>();
            Assert.AreSame(actual.Value1.Value1, actual.Value1.Value2);
        }

        [Test]
        public void GetGraph50()
        {
            using var kernel = new Kernel();
            var root = kernel.Get<Graph50.Node1>();
            var allChildren = root.AllChildren.ToArray();
            Console.WriteLine($"Total count: {allChildren.Length}");
            var distinct = allChildren.Distinct().ToArray();
            Console.WriteLine($"Unique count: {distinct.Length}");
            Assert.AreEqual(distinct.Length, allChildren.Select(x => x.GetType()).Distinct().Count());
        }

        [Test]
        public void DisposesCreated()
        {
            Disposable actual;
            using (var kernel = new Kernel())
            {
                actual = kernel.Get<Disposable>();
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }

        [Test]
        public void NotifiesCreating()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (sender, item) => actual.Add(item);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public void NotifiesCreated()
        {
            using var kernel = new Kernel();
            var actual = new List<object>();
            kernel.Created += (sender, item) => actual.Add(item);
            var defaultCtor = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { defaultCtor }, actual);
        }

        [Test]
        public void NotifiesCreatingFunc()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (sender, type) => actual.Add(type);
            kernel.Bind(() =>
            {
                // check that we notify before creating.
                CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
                return new DefaultCtor();
            });
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public void NotifiesFuncCreatedFunc()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (sender, type) => actual.Add(type);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }
    }
}
