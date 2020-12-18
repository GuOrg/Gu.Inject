namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    internal readonly struct Constructor
    {
        private static readonly ConcurrentDictionary<Type, Constructor> Cache = new();

        private readonly ConstructorInfo info;
        private readonly ParameterInfo[]? parameters;
        private readonly object?[]? arguments;

        private Constructor(ConstructorInfo info, ParameterInfo[]? parameters)
        {
            this.info = info;
            this.parameters = parameters;
            this.arguments = parameters is null ? null : new object[parameters.Length];
        }

        /// <summary>
        /// Setting this.arguments[last] = this.arguments; when resolving.
        /// Reason for this hack is silly optimization.
        /// </summary>
        private bool IsBusy => this.arguments is { } gate && Monitor.IsEntered(gate);

        internal static Constructor? Get(Type type)
        {
            var ctor = Cache.GetOrAdd(type, t => Create(t));
            if (ctor.arguments is { })
            {
                return ctor.IsBusy
                    ? null
                    : (Constructor?)ctor;
            }

            return ctor;
        }

        internal static IEnumerable<ParameterInfo> Cycle(Type candidate)
        {
            var parameter = Find(candidate);
            while (parameter.ParameterType != candidate)
            {
                yield return parameter;
                parameter = Find(parameter.ParameterType);
            }

            yield break;

            static ParameterInfo Find(Type current)
            {
                return Cache[current].parameters!.First(p => Cache[p.ParameterType].IsBusy);
            }
        }

        internal object Invoke(object? obj, Func<Type, object?> resolve, EventHandler<CreatingEventArgs>? eventHandler)
        {
            if (this.arguments is null)
            {
                eventHandler?.Invoke(this, new CreatingEventArgs(this.info.DeclaringType!));

                if (obj is null)
                {
                    return this.info.Invoke(null);
                }

                _ = this.info.Invoke(obj, null);
                return obj;
            }

            lock (this.arguments)
            {
                for (var i = 0; i < this.arguments.Length; i++)
                {
                    this.arguments[i] = resolve(this.parameters![i].ParameterType);
                }

                eventHandler?.Invoke(this, new CreatingEventArgs(this.info.DeclaringType!));
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
                attributes.Any(x => x.AttributeType == typeof(ParamArrayAttribute)))
            {
                var message = $"Type {type.PrettyName()} has params parameter which is not supported.\r\n" +
                              "Add a binding specifying how to create an instance.";
                throw new ResolveException(type, message);
            }

            return new Constructor(ctor, parameters);
        }
    }
}
