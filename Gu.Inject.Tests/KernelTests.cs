namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public class KernelTests
    {
        [TestCase(typeof(DefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(IDefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(With<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(IWith<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, DefaultCtor>), typeof(WithTwo<DefaultCtor, DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, With<DefaultCtor>>), typeof(WithTwo<DefaultCtor, With<DefaultCtor>>))]
        [TestCase(typeof(Concrete), typeof(Concrete))]
        [TestCase(typeof(Abstract), typeof(Concrete))]
        [TestCase(typeof(Generic<DefaultCtor>), typeof(Generic<DefaultCtor>))]
        [TestCase(typeof(GenericOfDefaultCtor), typeof(GenericOfDefaultCtor))]
        public void Get(Type t1, Type t2)
        {
            using (var kernel = new Kernel())
            {
                var actual = kernel.Get(t1);
                Assert.AreEqual(t2, actual.GetType());
                Assert.AreSame(actual, kernel.Get(t2));
            }
        }

        [Test]
        public void InjectsSingletons()
        {
            using (var kernel = new Kernel())
            {
                var actual = kernel.Get<WithTwo<DefaultCtor, DefaultCtor>>();
                Assert.AreSame(actual.Value1, actual.Value2);
            }
        }

        [Test]
        public void Loop()
        {
            using (var kernel = new Kernel())
            {
                Assert.Fail("Throw ninject style exception.");
                var actual = kernel.Get<A>();
                Assert.AreSame(actual.B.A, actual);
            }
        }

        [TestCase(typeof(IWith))]
        public void Throws(Type type)
        {
            using (var kernel = new Kernel())
            {
                Assert.Throws<InvalidOperationException>(() => kernel.Get(type));
            }
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
        public void Bind()
        {
            using (var kernel = new Kernel())
            {
                kernel.Bind<IWith, With<DefaultCtor>>();
                var actual = kernel.Get<IWith>();
                Assert.AreSame(actual, kernel.Get<With<DefaultCtor>>());
            }
        }

        [Test]
        public void BindThrowsIfHasResolved()
        {
            using (var kernel = new Kernel())
            {
                var defaultCtor = kernel.Get<DefaultCtor>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("Bind not allowed after Get.", exception.Message);
            }
        }

        [Test]
        public void BindThrowsIfHasBinding()
        {
            using (var kernel = new Kernel())
            {
                kernel.Bind<IWith, With<DefaultCtor>>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("IWith already has a binding to With<DefaultCtor>", exception.Message);
            }
        }

        [Test]
        public void ReBind()
        {
            using (var kernel = new Kernel())
            {
                kernel.Bind<IWith, With<DefaultCtor>>();
                kernel.ReBind<IWith, With<With<DefaultCtor>>>();
                var actual = kernel.Get<IWith>();
                Assert.AreSame(actual, kernel.Get<With<With<DefaultCtor>>>());
            }
        }

        [Test]
        public void ReBindThrowsIfHasResolved()
        {
            using (var kernel = new Kernel())
            {
                kernel.Bind<IWith, With<DefaultCtor>>();
                var defaultCtor = kernel.Get<DefaultCtor>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.ReBind<IWith, With<With<DefaultCtor>>>());
                Assert.AreEqual("ReBind not allowed after Get.", exception.Message);
            }
        }

        [Test]
        public void ReBindThrowsIfNoBinding()
        {
            using (var kernel = new Kernel())
            {
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.ReBind<IWith, With<With<DefaultCtor>>>());
                Assert.AreEqual("IWith does not have a binding.", exception.Message);
            }
        }
    }
}
