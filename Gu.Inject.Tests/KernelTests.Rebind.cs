namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Rebind
        {
            [Test]
            public void BindThenReBindThenGet()
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
            public void ThrowsIfHasResolved()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Get<DefaultCtor>();
                    var exception = Assert.Throws<InvalidOperationException>(() => kernel.ReBind<IWith, With<With<DefaultCtor>>>());
                    Assert.AreEqual("ReBind not allowed after Get.", exception.Message);
                }
            }

            [Test]
            public void ThrowsIfNoBinding()
            {
                using (var kernel = new Kernel())
                {
                    var exception = Assert.Throws<InvalidOperationException>(() => kernel.ReBind<IWith, With<With<DefaultCtor>>>());
                    Assert.AreEqual("IWith does not have a binding.", exception.Message);
                }
            }
        }
    }
}