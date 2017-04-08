namespace Gu.Inject
{
    using System;

    public class CircularDependencyException : ResolveException
    {
        public CircularDependencyException(Type type)
            : base(type, $"{type.PrettyName()}( Circular dependency detected.")
        {
        }
    }
}