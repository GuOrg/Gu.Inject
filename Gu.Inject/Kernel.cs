namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;

    public sealed class Kernel : IDisposable
    {
        private readonly ConcurrentDictionary<Type, object> map = new ConcurrentDictionary<Type, object>();
        private bool disposed;

        public T Get<T>()
            where T : class
        {
            return (T)this.Get(typeof(T));
        }

        public object Get(Type type)
        {
            this.ThrowIfDisposed();
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
            if (type.IsInterface ||
                type.IsAbstract)
            {
                var mapped = DefaultTypeMap.GetMapped(type);
                if (mapped.Count == 0)
                {
                    throw new InvalidOperationException($"Type {type.PrettyName()} has no bindings.");
                }

                if (mapped.Count > 1)
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
