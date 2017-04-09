namespace Gu.Inject
{
    using System;

    internal class Factory<T> : IFactory
    {
        private readonly Func<T> creator;

        public Factory(Func<T> creator)
        {
            this.creator = creator;
        }

        public object Create(object[] args)
        {
            return this.creator();
        }
    }
}