namespace Gu.Inject.Tests.Types
{
    public class ParamsCtor
    {
        public ParamsCtor(params Bar[] bars)
        {
            this.Bars = bars;
        }

        public Bar[] Bars { get; }
    }
}