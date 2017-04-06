namespace Gu.Inject.Tests.Types
{
    public class GenericOfDefaultCtor : Generic<DefaultCtor>
    {
        public GenericOfDefaultCtor(DefaultCtor value) 
            : base(value)
        {
        }
    }
}