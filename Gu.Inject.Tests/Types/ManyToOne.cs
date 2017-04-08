namespace Gu.Inject.Tests.Types
{
    public static class ManyToOne
    {
        public interface IFoo : IFooFoo
        {
        }

        public interface IFooFoo 
        {
        }

        public interface IFoo1
        {
        }

        public interface IFoo2
        {
        }

        public interface IGenericFoo1<T>
        {
        }

        public interface IGenericFoo2<T>
        {
        }

        public interface IFooBase1
        {
        }

        public interface IFooBase2
        {
        }

        public abstract class FooBaseBase
        {
        }

        public abstract class FooBase : FooBaseBase, IFooBase1, IFooBase2
        {
        }

        public class Foo : FooBase, IFoo, IFoo1, IFoo2, IGenericFoo1<int>, IGenericFoo1<double>, IGenericFoo2<int>
        {
        }
    }
}