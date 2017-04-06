﻿namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;

    public sealed class Kernel : IDisposable
    {
        private readonly ConcurrentDictionary<Type, object> map = new ConcurrentDictionary<Type, object>();
        private readonly ConcurrentDictionary<Type, Type> bindings = new ConcurrentDictionary<Type, Type>();
        private bool disposed;

        public event EventHandler<Type> Resolving;

        public void Bind<TInterface, TConcrete>()
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

            return this.map.GetOrAdd(type, this.Create);
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

        private object Create(Type type)
        {
            if (this.bindings.TryGetValue(type, out Type bound))
            {
                return this.map.GetOrAdd(bound, this.Create);
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
                    throw new InvalidOperationException($"Type {type.PrettyName()} has more than one binding {string.Join(",", mapped.Select(t => t.PrettyName()))}.");
                }

                if (mapped[0].IsGenericType && !type.IsGenericType)
                {
                    throw new InvalidOperationException($"Type {type.PrettyName()} has more than one binding {string.Join(",", mapped.Select(t => t.PrettyName()))}.");
                }

                return this.map.GetOrAdd(mapped[0], this.Create);
            }

            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 1)
            {
                throw new InvalidOperationException($"Injectable type can only have one constructor. Type {type.PrettyName()} has {ctors.Length}");
            }

            var ctor = ctors[0];
            var parameters = ctor.GetParameters().Select(p => this.map.GetOrAdd(p.ParameterType, this.Create)).ToArray();
            this.Resolving?.Invoke(this, type);
            return ctor.Invoke(parameters);
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
