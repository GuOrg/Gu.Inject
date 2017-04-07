namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class Ctor
    {
        private static readonly ConcurrentDictionary<Type, Info> Ctors = new ConcurrentDictionary<Type, Info>();

        internal static Info GetInfo(Type type)
        {
            return Ctors.GetOrAdd(type, Create);
        }

        internal static Info Create(Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 1)
            {
                throw new InvalidOperationException($"Injectable type can only have one constructor. Type {type.PrettyName()} has {ctors.Length}");
            }

            var ctor = ctors[0];
            return new Info(ctor, ctor.GetParameters().Select(x => x.ParameterType).ToArray());
        }

        internal class Info
        {
            internal readonly ConstructorInfo Ctor;
            internal readonly IReadOnlyList<Type> ParameterTypes;

            public Info(ConstructorInfo ctor, IReadOnlyList<Type> parameterTypes)
            {
                this.Ctor = ctor;
                this.ParameterTypes = parameterTypes;
            }
        }
    }
}