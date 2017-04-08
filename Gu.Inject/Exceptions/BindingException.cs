namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;

    public abstract class BindingException : ResolveException
    {
        protected BindingException(Type type, IReadOnlyList<Type> mapped, string message)
            : base(type, message)
        {
            this.Mapped = mapped;
        }

        /// <summary>
        /// Gets the candidate types to resolve.
        /// </summary>
        public IReadOnlyList<Type> Mapped { get; }
    }
}