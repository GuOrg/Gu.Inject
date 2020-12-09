namespace Gu.Inject.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public static class KernelTests
    {
        [TestCase(typeof(IGetter))]
        [TestCase(typeof(DefaultCtor))]
        [TestCase(typeof(Graph2.Node1))]
        [TestCase(typeof(Graph50.Node1))]
        [TestCase(typeof(StaticConstructor))]
        [TestCase(typeof(With<DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, With<DefaultCtor>>))]
        [TestCase(typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOneGeneric.GenericOfDefaultCtor))]
        [TestCase(typeof(InheritNonAbstract.FooDerived))]
        [TestCase(typeof(ManyToOne.Foo))]
        public static void Get(Type type)
        {
            using var kernel = new Kernel();
            var actual = kernel.Get(type);
            Assert.AreSame(actual, kernel.Get(type));
        }

        [Test]
        public static void GetCircularSimple()
        {
            using var kernel = new Kernel();
            kernel.BindUninitialized<Circular1.A>();
            var a = kernel.Get<Circular1.A>();
            var b = kernel.Get<Circular1.B>();
            Assert.AreSame(a.B, b);
            Assert.AreSame(a, b.A);
        }

        [Test]
        public static void GetCircularComplex()
        {
            using var kernel = new Kernel();
            kernel.BindUninitialized<Circular2.A>();
            var a = kernel.Get<Circular2.A>();
            var b = kernel.Get<Circular2.B>();
            var c = kernel.Get<Circular2.C>();
            var d = kernel.Get<Circular2.D>();
            var e = kernel.Get<Circular2.E>();
            var f = kernel.Get<Circular2.F>();
            var g = kernel.Get<Circular2.G>();
            Assert.AreSame(a.B, b);
            Assert.AreSame(a.E, e);
            Assert.AreSame(b.C, c);
            Assert.AreSame(b.D, d);
            Assert.AreSame(c, kernel.Get<Circular2.C>());
            Assert.AreSame(d, kernel.Get<Circular2.D>());
            Assert.AreSame(e.F, f);
            Assert.AreSame(e.G, g);
        }

        [Test]
        public static void GetSubclassesReturnsDifferentByDefault()
        {
            using var kernel = new Kernel();
            Assert.AreNotSame(kernel.Get<InheritNonAbstract.Foo>(), kernel.Get<InheritNonAbstract.FooDerived>());
        }

        [Test]
        public static void GetSubclassesReturnsSameWithBindings()
        {
            using var kernel = new Kernel();
            kernel.Bind<InheritNonAbstract.Foo, InheritNonAbstract.FooDerived>();
            Assert.AreSame(kernel.Get<InheritNonAbstract.Foo>(), kernel.Get<InheritNonAbstract.FooDerived>());
        }

        [TestCase(typeof(I1), typeof(C))]
        [TestCase(typeof(IDefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(IWith), typeof(With<DefaultCtor>))]
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
        public static void BindThenGet(Type type, Type expected)
        {
            using var kernel = new Kernel();
            kernel.Bind(type, expected);
            var actual = kernel.Get(type);
            Assert.AreEqual(expected.PrettyName(), actual!.GetType().PrettyName());
            Assert.AreSame(actual, kernel.Get(expected));
        }

        [Test]
        public static void InjectsSingletons1()
        {
            using var kernel = new Kernel();
            var actual = kernel.Get<WithTwo<DefaultCtor, DefaultCtor>>();
            Assert.AreSame(actual.Value1, actual.Value2);
        }

        [Test]
        public static void InjectsSingletonsWithBindings()
        {
            using var kernel = new Kernel();
            kernel.Bind<ManyToOne.IFoo, ManyToOne.Foo>();
            kernel.Bind<ManyToOne.IFooBase1, ManyToOne.Foo>();
            var actual = kernel.Get<WithTwo<WithTwo<ManyToOne.IFoo, ManyToOne.IFooBase1>, With<DefaultCtor>>>();
            Assert.AreSame(actual.Value1.Value1, actual.Value1.Value2);
        }

        [Test]
        public static void GetGraph50()
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
        public static void NotifiesCreating()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (_, e) => actual.Add(e.Type);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public static void NotifiesCreated()
        {
            using var kernel = new Kernel();
            var actual = new List<object?>();
            kernel.Created += (_, e) => actual.Add(e.Instance);
            var defaultCtor = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { defaultCtor }, actual);
        }

        [Test]
        public static void NotifiesCreatingFunc()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (_, e) => actual.Add(e.Type);
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
        public static void NotifiesFuncCreatedFunc()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (_, e) => actual.Add(e.Type);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public static void NotifiesCreatingCircular()
        {
            var actual = new List<Type>();
            using var kernel = new Kernel();
            kernel.Creating += (_, e) => actual.Add(e.Type);
            kernel.BindUninitialized<Circular1.A>();
            var a = kernel.Get<Circular1.A>();
            var b = kernel.Get<Circular1.B>();
            Assert.AreSame(a.B, b);
            Assert.AreSame(a, b.A);
            CollectionAssert.AreEqual(new[] { typeof(Circular1.A), typeof(Circular1.B) }, actual);
        }

        [Test]
        public static void NotifiesCreatedCircular()
        {
            var actual = new List<object?>();
            using var kernel = new Kernel();
            kernel.Created += (_, e) => actual.Add(e.Instance);
            kernel.BindUninitialized<Circular1.A>();
            var a = kernel.Get<Circular1.A>();
            var b = kernel.Get<Circular1.B>();
            Assert.AreSame(a.B, b);
            Assert.AreSame(a, b.A);
            CollectionAssert.AreEqual(new object[] { b, a }, actual);
        }

        [Test]
        public static void FuncTypes()
        {
            using var kernel = new Kernel();
            //// ReSharper disable AccessToDisposedClosure
            kernel.Bind<Func<FuncTypes.A>>(() => kernel.Get<FuncTypes.A>());
            kernel.Bind<Func<FuncTypes.B>>(() => kernel.Get<FuncTypes.B>());
            //// ReSharper restore AccessToDisposedClosure
            Assert.AreSame(kernel.Get<FuncTypes.A>(), kernel.Get<FuncTypes.A>());
            Assert.AreSame(kernel.Get<FuncTypes.B>(), kernel.Get<FuncTypes.B>());
        }
    }
}
