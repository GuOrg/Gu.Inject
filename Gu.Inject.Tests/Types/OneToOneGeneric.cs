namespace Gu.Inject.Tests.Types
{
    public static class OneToOneGeneric
    {
        public abstract class AbstractGeneric<T>
        {
            protected AbstractGeneric(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
        }

        public class GenericOfDefaultCtor : AbstractGeneric<DefaultCtor>
        {
            public GenericOfDefaultCtor(DefaultCtor value)
                : base(value)
            {
            }
        }
    }
}