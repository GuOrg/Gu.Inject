namespace Gu.Inject.Tests.Types
{
    public static class OneToOne
    {
        public interface IAbstract
        {
        }

        public abstract class Abstract : IAbstract
        {
        }

        public interface IConcrete
        {
        }

        public class Concrete : Abstract, IConcrete
        {
        }
    }
}
