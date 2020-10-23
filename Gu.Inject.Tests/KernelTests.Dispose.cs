namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using Moq;
    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Dispose
        {
            [Test]
            public void BoundInstanceIsNotDisposed()
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
            public void BoundFactoryIsDisposed()
            {
                Mock<IDisposable> mock;
                using (var kernel = new Kernel())
                {
                    kernel.Bind(Mock.Of<IDisposable>);
                    var actual = kernel.Get<IDisposable>();
                    mock = Mock.Get(actual);
                    mock.Setup(x => x.Dispose());
                }

                mock.Verify(x => x.Dispose(), Times.Once);
            }

            [Test]
            public void BoundResolverFactoryIsDisposed()
            {
                Mock<IDisposable> mock;
                using (var kernel = new Kernel())
                {
                    kernel.Bind(x => Mock.Of<IDisposable>());
                    var actual = kernel.Get<IDisposable>();
                    mock = Mock.Get(actual);
                    mock.Setup(x => x.Dispose());
                }

                mock.Verify(x => x.Dispose(), Times.Once);
            }
        }
    }
}