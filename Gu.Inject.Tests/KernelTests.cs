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
            Assert.Fail("Reminder.");
        }

        [Test]
        public void Bind()
        {
            Assert.Fail("Reminder.");
            Assert.Fail("Throw if has resolved.");
            Assert.Fail("Throw if there is already a binding, require rebind.");
        }

        [Test]
        public void ReBind()
        {
            Assert.Fail("Reminder.");
            Assert.Fail("Throw if has resolved.");
            Assert.Fail("Throw if there is no binding, require rebind.");
        }
    }
}
