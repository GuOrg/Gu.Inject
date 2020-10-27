namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public static class DisposeTests
    {
        [Test]
        public static void DisposesCreated()
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
        public static void DisposesCreatedNested()
        {
            Disposable actual;
            using (var kernel = new Kernel())
            {
                actual = kernel.Get<With<Disposable>>().Value;
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }

        [Test]
        public static void DisposesBoundCreated()
        {
            Disposable actual;
            using (var kernel = new Kernel())
            {
                kernel.Bind<IDisposable, Disposable>();
                actual = (Disposable)kernel.Get<IDisposable>();
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }

        [Test]
        public static void BoundInstanceIsNotDisposed()
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
        public static void BoundFactoryIsDisposed()
        {
            Disposable actual;
            using (var kernel = new Kernel())
            {
                kernel.Bind(() => new Disposable());
                actual = kernel.Get<Disposable>();
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }

        [Test]
        public static void BoundResolverFactoryIsDisposed()
        {
            Disposable actual;
            using (var kernel = new Kernel())
            {
                kernel.Bind(x => new Disposable());
                actual = kernel.Get<Disposable>();
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }

        public sealed class Disposable : IDisposable
        {
            public int Disposed { get; private set; }

            public void Dispose()
            {
                this.Disposed++;
            }
        }
    }
}