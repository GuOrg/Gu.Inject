namespace Gu.Inject.Tests.Types
{
    public class Generic<T>
    {
        public Generic(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}