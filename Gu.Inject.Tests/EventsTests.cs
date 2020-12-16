#pragma warning disable IDISP017 // Prefer using.
namespace Gu.Inject.Tests
{
    using System;
    using System.Collections.Generic;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public static class EventsTests
    {
        [Test]
        public static void Creating()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (_, e) => actual.Add(e.Type);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public static void Created()
        {
            using var kernel = new Kernel();
            var actual = new List<object?>();
            kernel.Created += (_, e) => actual.Add(e.Instance);
            var defaultCtor = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { defaultCtor }, actual);
        }

        [Test]
        public static void Disposing()
        {
            var kernel = new Kernel();
            var actual = new List<object?>();
            kernel.Disposing += (_, e) => actual.Add(e.Instance);
            var defaultCtor = kernel.Get<DefaultCtor>();
            kernel.Dispose();
            CollectionAssert.AreEqual(new[] { defaultCtor }, actual);
        }

        [Test]
        public static void CreatingFunc()
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
        public static void CreatedFunc()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Bind<DefaultCtor>(() => new DefaultCtor());
            kernel.Creating += (_, e) => actual.Add(e.Type);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public static void DisposingFunc()
        {
            var kernel = new Kernel();
            kernel.Bind<DefaultCtor>(() => new DefaultCtor());
            var actual = new List<object?>();
            kernel.Disposing += (_, e) => actual.Add(e.Instance);
            var defaultCtor = kernel.Get<DefaultCtor>();
            kernel.Dispose();
            CollectionAssert.AreEqual(new[] { defaultCtor }, actual);
        }

        [Test]
        public static void CreatingInstance()
        {
            var kernel = new Kernel();
            var instance = new DefaultCtor();
            kernel.Bind<DefaultCtor>(instance);
            var actual = new List<Type>();
            kernel.Creating += (_, e) => actual.Add(e.Type);
            kernel.Dispose();
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public static void CreatedInstance()
        {
            var kernel = new Kernel();
            var instance = new DefaultCtor();
            kernel.Bind<DefaultCtor>(instance);
            var actual = new List<object?>();
            kernel.Created += (_, e) => actual.Add(e.Instance);
            kernel.Dispose();
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public static void DisposingInstance()
        {
            var kernel = new Kernel();
            var instance = new DefaultCtor();
            kernel.Bind<DefaultCtor>(instance);
            var actual = new List<object?>();
            kernel.Disposing += (_, e) => actual.Add(e.Instance);
            kernel.Dispose();
            CollectionAssert.AreEqual(new[] { instance }, actual);
        }

        [Test]
        public static void CreatingResolver()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Creating += (_, e) => actual.Add(e.Type);
            kernel.Bind(_ =>
            {
                // check that we notify before creating.
                CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
                return new DefaultCtor();
            });
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public static void CreatedResolver()
        {
            using var kernel = new Kernel();
            var actual = new List<Type>();
            kernel.Bind<DefaultCtor>(_ => new DefaultCtor());
            kernel.Creating += (_, e) => actual.Add(e.Type);
            _ = kernel.Get<DefaultCtor>();
            CollectionAssert.AreEqual(new[] { typeof(DefaultCtor) }, actual);
        }

        [Test]
        public static void DisposingResolver()
        {
            var kernel = new Kernel();
            kernel.Bind<DefaultCtor>(_ => new DefaultCtor());
            var actual = new List<object?>();
            kernel.Disposing += (_, e) => actual.Add(e.Instance);
            var defaultCtor = kernel.Get<DefaultCtor>();
            kernel.Dispose();
            CollectionAssert.AreEqual(new[] { defaultCtor }, actual);
        }

        [Test]
        public static void CreatingCircular()
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
        public static void CreatedCircular()
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
    }
}
