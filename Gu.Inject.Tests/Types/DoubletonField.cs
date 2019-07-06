namespace Gu.Inject.Tests.Types
{
    public sealed class DoubletonField
    {
        public static readonly DoubletonField Instance1 = new DoubletonField();

        public static readonly DoubletonField Instance2 = new DoubletonField();

        private DoubletonField()
        {
        }
    }
}