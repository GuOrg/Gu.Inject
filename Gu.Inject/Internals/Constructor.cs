namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class Constructor
    {
        private static readonly ConcurrentDictionary<Type, IFactory> ConstructorMap = new ConcurrentDictionary<Type, IFactory>();

        internal static IFactory GetFactory(Type type)
        {
            return ConstructorMap.GetOrAdd(type, Create);
        }

        private static IFactory Create(Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 1)
            {
                var message = $"Type {type.PrettyName()} has more than one constructor.\r\n" +
                              "Add a binding specifying which constructor to use.";
                throw new ResolveException(type, message);
            }

            var ctor = ctors[0];
            var parameters = ctor.GetParameters()
                                 .Select(x => x.ParameterType)
                                 .ToArray();

            return new Factory(ctor, parameters);
        }

        internal class Factory : IFactory
        {
            private readonly ConstructorInfo ctor;

            internal Factory(ConstructorInfo ctor, IReadOnlyList<Type> parameterTypes)
            {
                this.ctor = ctor;
                this.ParameterTypes = parameterTypes;
            }

            public IReadOnlyList<Type> ParameterTypes { get; }

            public object Create(object[]? args)
            {
                return this.ctor.Invoke(args);
            }
        }
    }
}