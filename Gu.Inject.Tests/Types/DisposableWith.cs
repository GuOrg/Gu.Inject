namespace Gu.Inject.Tests.Types
{
    using System;

    public sealed class DisposableWith<T> : IDisposable
    {
        public DisposableWith(T value)
        {
            this.Value = value;
        }

        public T Value { get;  }

        public int Disposed { get; private set; }

        public void Dispose()
        {
            this.Disposed++;
        }
    }
}