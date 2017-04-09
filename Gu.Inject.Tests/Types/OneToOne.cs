namespace Gu.Inject.Tests.Types
{
    public static class OneToOne
    {
        public interface IAbstract
        {
        }

        public interface IConcrete
        {
        }

        public abstract class Abstract : IAbstract
        {
        }

        public class Concrete : Abstract, IConcrete
        {
        }
    }
}
