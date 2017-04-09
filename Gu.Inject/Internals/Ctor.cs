namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class Ctor
    {
        private static readonly ConcurrentDictionary<Type, Factory> Ctors = new ConcurrentDictionary<Type, Factory>();

        internal static Factory GetFactory(Type type)
        {
            return Ctors.GetOrAdd(type, Create);
        }

        private static Factory Create(Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 1)
            {
                var message = $"Type {type.PrettyName()} has more than one constructor.\r\n" +
                              "Add a binding specifying which constructor to use.";
                throw new ResolveException(type, message);
            }

            var ctor = ctors[0];
            return new Factory(ctor, ctor.GetParameters().Select(x => x.ParameterType).ToArray());
        }

        internal class Factory : IFactory
        {
            internal readonly IReadOnlyList<Type> ParameterTypes;
            private readonly ConstructorInfo ctor;

            public Factory(ConstructorInfo ctor, IReadOnlyList<Type> parameterTypes)
            {
                this.ctor = ctor;
                this.ParameterTypes = parameterTypes;
            }

            public object Create(object[] args)
            {
                return this.ctor.Invoke(args);
            }
        }
    }
}