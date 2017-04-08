namespace Gu.Inject.Tests.Types
{
    public static class OneToOneGeneric
    {
        public class Generic<T>
        {
            public Generic(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
        }

        public class GenericOfDefaultCtor : Generic<DefaultCtor>
        {
            public GenericOfDefaultCtor(DefaultCtor value)
                : base(value)
            {
            }
        }
    }
}