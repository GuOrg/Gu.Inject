namespace Gu.Inject.Tests.Types
{
    using System;

    public sealed class Disposable : IDisposable
    {
        public int Disposed { get; private set; }

        public void Dispose()
        {
            this.Disposed++;
        }
    }
}