namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;

    internal readonly struct Constructor
    {
        private static readonly ConcurrentDictionary<Type, Constructor> Cache = new ConcurrentDictionary<Type, Constructor>();

        private readonly ConstructorInfo info;
        private readonly ParameterInfo[]? parameters;
        private readonly object?[]? arguments;

        private Constructor(ConstructorInfo info, ParameterInfo[]? parameters)
        {
            this.info = info;
            this.parameters = parameters;
            this.arguments = parameters is null ? null : new object[parameters.Length];
        }

        internal static Constructor Get(Type type)
        {
            return Cache.GetOrAdd(type, t => Create(t));
        }

        internal static Constructor? GetOrNull(Type type)
        {
            var ctor = Get(type);
            if (ctor.arguments is { })
            {
                lock (ctor.arguments)
                {
                    if (ctor.arguments[ctor.arguments.Length - 1] is null)
                    {
                        return ctor;
                    }
                }

                return null;
            }

            return ctor;
        }

        internal object Invoke(object? obj, Func<Type, object> resolve)
        {
            if (this.arguments is null)
            {
                if (obj is null)
                {
                    return this.info.Invoke(null);
                }

                _ = this.info.Invoke(obj, null);
                return obj;
            }

            lock (this.arguments)
            {
                this.arguments[this.arguments.Length - 1] = this.arguments;

                for (var i = 0; i < this.arguments.Length; i++)
                {
                    this.arguments[i] = resolve(this.parameters![i].ParameterType);
                }

                if (obj is null)
                {
                    obj = this.info.Invoke(this.arguments);
                }
                else
                {
                    _ = this.info.Invoke(obj, this.arguments);
                }

                Array.Clear(this.arguments, 0, this.arguments.Length);
                return obj!;
            }
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
                attributes.Any(x => x.AttributeType == typeof(System.ParamArrayAttribute)))
            {
                var message = $"Type {type.PrettyName()} has params parameter which is not supported.\r\n" +
                              "Add a binding specifying how to create an instance.";
                throw new ResolveException(type, message);
            }

            return new Constructor(ctor, parameters);
        }
    }
}