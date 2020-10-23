namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;

    internal static class Constructor
    {
        private static readonly ConcurrentDictionary<Type, Func<IGetter, object>> ConstructorMap = new ConcurrentDictionary<Type, Func<IGetter, object>>();

        internal static Func<IGetter, object> GetResolver(Type type)
        {
            return ConstructorMap.GetOrAdd(type, Create);
        }

        private static Func<IGetter, object> Create(Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 1)
            {
                var message = $"Type {type.PrettyName()} has more than one constructor.\r\n" +
                                     "Add a binding specifying which constructor to use.";
                throw new ResolveException(type, message);
            }

            var ctor = ctors[0];
            var parameters = ctor.GetParameters();
            if (parameters.Length == 0)
            {
                return x => ctor.Invoke(null);
            }

            if (parameters.Last() is { CustomAttributes: { } attributes } &&
                attributes.Any(x => x.AttributeType == typeof(System.ParamArrayAttribute)))
            {
                var message = $"Type {type.PrettyName()} has params parameter which is not supported.\r\n" +
                                     "Add a binding specifying how to create an instance.";
                return x => throw new ResolveException(type, message);
            }

            return x => ctor.Invoke(parameters.Select(p => x.Get(p.ParameterType)).ToArray());
        }
    }
}