// ReSharper disable All
#pragma warning disable CA1801 // Review unused parameters
namespace Gu.Inject.Tests.Types
{
   public static class Error
    {
        public class ParamsCtor
        {
            public ParamsCtor(params DefaultCtor[] meh)
            {
            }
        }

        public class TwoCtors
        {
            public TwoCtors()
            {
            }

            public TwoCtors(DefaultCtor meh)
            {
            }
        }
    }
}
