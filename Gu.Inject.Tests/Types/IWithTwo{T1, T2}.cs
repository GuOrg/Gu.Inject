namespace Gu.Inject.Tests.Types
{
    public interface IWithTwo<T1, T2>
    {
        T1 Value1 { get; }

        T2 Value2 { get; }
    }
}
