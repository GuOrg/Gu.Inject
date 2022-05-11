namespace Gu.Inject.Tests.Types
{
    public interface IWith<out T> : IWith
    {
        T Value { get; }
    }
}
