namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;

    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Bind
        {
            [Test]
            public void BindThenGet()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind<IWith, With<DefaultCtor>>();
                    var actual = kernel.Get<IWith>();
                    Assert.AreSame(actual, kernel.Get<With<DefaultCtor>>());
                }
            }

            [Test]
            public void ThrowsIfHasResolved()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Get<DefaultCtor>();
                    var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                    Assert.AreEqual("Bind not allowed after Get.", exception.Message);
                }
            }

            [Test]
            public void ThrowsIfHasBinding()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind<IWith, With<DefaultCtor>>();
                    var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                    Assert.AreEqual("IWith already has a binding to With<DefaultCtor>", exception.Message);
                }
            }
        }
    }
}