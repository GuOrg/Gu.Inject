namespace Gu.Inject.Tests
{
    using System;

    using Gu.Inject.Tests.Types;
    using Moq;
    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Rebind
        {
            [Test]
            public void BindThenReBindGenericThenGet()
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
            public void BindThenReBindTypeThenGet()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind<IWith, With<DefaultCtor>>();
                    kernel.ReBind(typeof(IWith), typeof(With<With<DefaultCtor>>));
                    var actual = kernel.Get<IWith>();
                    Assert.AreSame(actual, kernel.Get<With<With<DefaultCtor>>>());
                }
            }

            [Test]
            public void BindThenReBindInstanceThenGet()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind<IWith, With<DefaultCtor>>();
                    var instance = new With<DefaultCtor>(new DefaultCtor());
                    kernel.ReBindInstance<IWith>(instance);
                    var actual = kernel.Get<IWith>();
                    Assert.AreSame(instance, actual);
                    Assert.AreNotSame(instance.Value, kernel.Get<DefaultCtor>());
                }
            }

            [Test]
            public void BindThenReBindFuncThenGet()
            {
                using (var kernel = new Kernel())
                {
                    kernel.Bind<IWith, With<DefaultCtor>>();
                    kernel.ReBindFactory(Mock.Of<IWith>);
                    var actual = kernel.Get<IWith>();
                    Assert.NotNull(Mock.Get(actual));
                }
            }

            [Test]
            public void Func()
            {
                Mock<IDisposable> mock;
                using (var kernel = new Kernel())
                {
                    using (var instance = new Disposable())
                    {
                        kernel.BindInstance(instance);
                        kernel.BindFactory(Mock.Of<IDisposable>);
                        var actual = kernel.Get<IDisposable>();
                        Assert.AreNotSame(actual, instance);
                        Assert.AreEqual(0, instance.Disposed);
                        mock = Mock.Get(actual);
                        mock.Setup(x => x.Dispose());
                    }
                }

                mock.Verify(x => x.Dispose(), Times.Once);
            }
        }
    }
}