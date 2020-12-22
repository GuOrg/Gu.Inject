namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    internal readonly struct Constructor
    {
        internal readonly ConstructorInfo Info;

        private static readonly ConcurrentDictionary<Type, Constructor> Cache = new();

        private readonly Parameters? parameters;

        private Constructor(ConstructorInfo info, Parameters? parameters)
        {
            this.Info = info;
            this.parameters = parameters;
        }

        internal static Constructor? Get(Type type)
        {
            var ctor = Cache.GetOrAdd(type, t => Create(t));
            if (ctor.parameters is { Infos: { } gate } &&
                Monitor.IsEntered(gate))
            {
                return null;
            }

            return ctor;
        }

        internal object?[]? ResolveArguments(Func<ParameterInfo, object?> resolve)
        {
            if (this.parameters is { Infos: { } infos, Arguments: { } args })
            {
                lock (infos)
                {
                    for (var i = 0; i < args.Length; i++)
                    {
                        args[i] = resolve(infos[i]);
                    }
                }

                return args;
            }

            return null;
        }

        internal void Return(object?[]? args)
        {
            this.parameters?.Return(args!);
        }

        private static Constructor Create(Type type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (constructors.Length > 1)
            {
                var message = $"Type {type.PrettyName()} has more than one constructor.\r\n" +
                              "Add a binding specifying which constructor to use.";
                throw new ResolveException(type, message);
            }

            var ctor = constructors[0];
            var parameters = ctor.GetParameters();
            if (parameters.Length == 0)
            {
                return new Constructor(ctor, null);
            }

            if (parameters.Last() is { CustomAttributes: { } attributes } &&
                attributes.Any(x => x.AttributeType == typeof(ParamArrayAttribute)))
            {
                var message = $"Type {type.PrettyName()} has params parameter which is not supported.\r\n" +
                              "Add a binding specifying how to create an instance.";
                throw new ResolveException(type, message);
            }

            return new Constructor(ctor, new Parameters(parameters));
        }
    }
}
