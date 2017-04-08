namespace Gu.Inject.Tests.Types
{
    public static class OneToMany
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

        public class Concrete1 : Abstract, IConcrete
        {
        }

        public class Concrete2 : Abstract, IConcrete
        {
        }
    }
}