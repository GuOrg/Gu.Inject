namespace Gu.Inject.Tests.Types
{
    public interface IWith
    {
    }

    public interface IWith<T> : IWith
    {
        T Value { get; }
    }
}