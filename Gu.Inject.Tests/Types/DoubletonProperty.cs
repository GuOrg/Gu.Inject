namespace Gu.Inject.Tests.Types
{
    public sealed class DoubletonProperty
    {
        public static DoubletonProperty Instance1 { get; } = new DoubletonProperty();
        public static DoubletonProperty Instance2 { get; } = new DoubletonProperty();

        private DoubletonProperty()
        {
        }
    }
}