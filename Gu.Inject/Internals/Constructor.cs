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
        internal readonly ConstructorInfo Info;

        private static readonly ConcurrentDictionary<Type, Constructor> Cache = new();
        private static readonly ConcurrentDictionary<int, ConcurrentQueue<object?[]>> ArrayPool = new();

        private readonly ParameterInfo[]? parameters;
        private readonly ConcurrentQueue<object?[]>? pool;

        private Constructor(ConstructorInfo info, ParameterInfo[]? parameters, ConcurrentQueue<object?[]>? pool)
        {
            this.Info = info;
            this.parameters = parameters;
            this.pool = pool;
        }

        /// <summary>
        /// Setting this.arguments[last] = this.arguments; when resolving.
        /// Reason for this hack is silly optimization.
        /// </summary>
        private bool IsBusy => this.parameters is { } gate && Monitor.IsEntered(gate);

        internal static Constructor? Get(Type type)
        {
            var ctor = Cache.GetOrAdd(type, t => Create(t));
            return ctor.IsBusy ? null : ctor;
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

        internal object?[]? ResolveArguments(Func<ParameterInfo, object?> resolve)
        {
            if (this.parameters is null)
            {
                return null;
            }

            var args = this.pool!.TryDequeue(out var cached)
                ? cached
                : new object[this.parameters.Length];
            lock (this.parameters)
            {
                for (var i = 0; i < args.Length; i++)
                {
                    args[i] = resolve(this.parameters[i]);
                }
            }

            return args;
        }

        internal void Return(object?[]? args)
        {
            if (args is { })
            {
                Array.Clear(args, 0, args.Length);
                this.pool!.Enqueue(args);
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
                return new Constructor(ctor, null, null);
            }

            if (parameters.Last() is { CustomAttributes: { } attributes } &&
                attributes.Any(x => x.AttributeType == typeof(ParamArrayAttribute)))
            {
                var message = $"Type {type.PrettyName()} has params parameter which is not supported.\r\n" +
                              "Add a binding specifying how to create an instance.";
                throw new ResolveException(type, message);
            }

            return new Constructor(
                ctor,
                parameters,
                ArrayPool.GetOrAdd(parameters.Length, _ => new ConcurrentQueue<object?[]>()));
        }
    }
}
