namespace Gu.Inject.Tests.Types
{
   public class With<T> : IWith<T>
    {
        public With(T value)
        {
            this.Value = value;
        }

        public T Value { get;  }
    }
}
