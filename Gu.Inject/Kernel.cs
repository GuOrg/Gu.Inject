namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public sealed class Kernel : IDisposable
    {
        private readonly ConcurrentDictionary<Type, object> map = new ConcurrentDictionary<Type, object>();
        private readonly ConcurrentDictionary<Type, Type> bindings = new ConcurrentDictionary<Type, Type>();
        private bool disposed;

        public event EventHandler<Type> Resolving;

        public void Bind<TInterface, TConcrete>()
            where TConcrete : TInterface
        {
            if (this.map.Count != 0)
            {
                throw new InvalidOperationException("Bind not allowed after Get.");
            }

            this.bindings.AddOrUpdate(
                typeof(TInterface),
                t => typeof(TConcrete),
                (t1, t2) => throw new InvalidOperationException($"{t1.PrettyName()} already has a binding to {t2.PrettyName()}"));
        }

        public void ReBind<TInterface, TConcrete>()
            where TConcrete : TInterface
        {
            if (this.map.Count != 0)
            {
                throw new InvalidOperationException("ReBind not allowed after Get.");
            }

            this.bindings.AddOrUpdate(
                typeof(TInterface),
                t => throw new InvalidOperationException($"{t.PrettyName()} does not have a binding."),
                (t1, t2) => typeof(TConcrete));
        }

        public T Get<T>()
            where T : class
        {
            if (!TypeMap.IsInitialized)
            {
                TypeMap.Initialize(Assembly.GetCallingAssembly());
            }

            return (T)this.Get(typeof(T));
        }

        public object Get(Type type)
        {
            this.ThrowIfDisposed();
            if (!TypeMap.IsInitialized)
            {
                TypeMap.Initialize(Assembly.GetCallingAssembly());
            }

            return this.map.GetOrAdd(type, this.Resolve);
        }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            foreach (var kvp in this.map)
            {
                (kvp.Value as IDisposable)?.Dispose();
            }

            this.map.Clear();
        }

        private object Resolve(Type type)
        {
            return this.Resolve(type, new HashSet<Type>(), new Stack<Type>());
        }

        private object Resolve(Type type, HashSet<Type> alreadyVisited, Stack<Type> explicitStack)
        {
            explicitStack.Push(type);
            try
            {
                alreadyVisited.Add(type);

                if (this.bindings.TryGetValue(type, out Type bound))
                {
                    return this.map.GetOrAdd(bound, t => this.Resolve(t, alreadyVisited, explicitStack));
                }

                if (type.IsInterface ||
                    type.IsAbstract)
                {
                    var mapped = TypeMap.GetMapped(type);
                    if (mapped.Count == 0)
                    {
                        throw new InvalidOperationException($"Type {type.PrettyName()} has no bindings.");
                    }

                    if (mapped.Count > 1)
                    {
                        throw new InvalidOperationException(
                            $"Type {type.PrettyName()} has more than one binding {string.Join(",", mapped.Select(t => t.PrettyName()))}.");
                    }

                    if (mapped[0].IsGenericType && !type.IsGenericType)
                    {
                        throw new InvalidOperationException(
                            $"Type {type.PrettyName()} has more than one binding {string.Join(",", mapped.Select(t => t.PrettyName()))}.");
                    }

                    return this.map.GetOrAdd(mapped[0], t => this.Resolve(t, alreadyVisited, explicitStack));
                }

                var info = Ctor.GetInfo(type);
                this.Resolving?.Invoke(this, type);
                if (info.ParameterTypes.Count == 0)
                {
                    return info.Ctor.Invoke(null);
                }

                var args = new object[info.ParameterTypes.Count];
                for (var i = 0; i < info.ParameterTypes.Count; i++)
                {
                    if (alreadyVisited.Contains(info.ParameterTypes[i]))
                    {
                        explicitStack.Push(info.ParameterTypes[i]);
                        throw new InvalidOperationException(
                            $"Circular dependency detected {string.Join(" -> ", explicitStack.Reverse().Select(t => t.PrettyName()))}");
                    }

                    args[i] = this.map.GetOrAdd(
                        info.ParameterTypes[i],
                        t => this.Resolve(t, alreadyVisited, explicitStack));
                }

                return info.Ctor.Invoke(args);
            }
            finally
            {
                explicitStack.Pop();
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
}
