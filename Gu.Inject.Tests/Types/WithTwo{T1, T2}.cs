namespace Gu.Inject.Tests.Types
{
    public class WithTwo<T1, T2>
    {
        public WithTwo(T1 value1, T2 value2)
        {
            this.Value1 = value1;
            this.Value2 = value2;
        }

        public T1 Value1 { get; }

        public T2 Value2 { get; }
    }
}
