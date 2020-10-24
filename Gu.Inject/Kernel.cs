namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// A factory for resolving object graphs.
    /// </summary>
    public sealed partial class Kernel : IDisposable, IGetter
    {
        private ConcurrentDictionary<Type, Binding>? map = new ConcurrentDictionary<Type, Binding>();
        private bool hasResolved;

        /// <summary>
        /// Initializes a new instance of the <see cref="Kernel"/> class.
        /// </summary>
        public Kernel()
        {
            this.BindCore(typeof(IGetter), new Binding(this, BindingKind.Instance));
        }

        /// <summary>
        /// This notifies before creating an instance of a type.
        /// </summary>
        public event EventHandler<Type>? Creating;

        /// <summary>
        /// This notifies after creating an instance of a type.
        /// </summary>
        public event EventHandler<object>? Created;

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        public T Get<T>()
            where T : class =>
            (T)this.GetCore(typeof(T));

        /// <summary>
        /// Get the singleton instance of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>The singleton instance of <paramref name="type"/>.</returns>
        public object Get(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return this.GetCore(type);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (this.map is null)
            {
                return;
            }

            var local = this.map;
            this.map = null!;
            foreach (var kvp in local)
            {
                switch (kvp.Value.Kind)
                {
                    case BindingKind.Func:
                    case BindingKind.ResolverFunc:
                    case BindingKind.Instance:
                    case BindingKind.Map:
                    case BindingKind.Mapped:
                        break;
                    case BindingKind.Created:
                    case BindingKind.Resolved:
                        (kvp.Value.Value as IDisposable)?.Dispose();
                        break;
                    default:
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                        throw new InvalidOperationException($"Not handling dispose of Kind: {kvp.Value.Kind}, Value: {kvp.Value.Value ?? "null"} ");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
            }
        }

        private void BindCore(Type key, Binding binding)
        {
            if (this.hasResolved)
            {
                throw new InvalidOperationException("Bind not allowed after resolving. This could create hard to track down graph bugs.");
            }

            if (this.map is null)
            {
                throw new ObjectDisposedException(nameof(Kernel));
            }

            if (binding is { Kind: BindingKind.Map, Value: Type to } &&
                key == to)
            {
                throw new InvalidOperationException("Trying to bind to the same type.\r\n This is the equivalent of kernel.Bind<SomeType, SomeType>() which is not strictly wrong but redundant and could indicate a real error hence this exception.");
            }

            _ = this.map.AddOrUpdate(
                key,
                t => binding,
                (t, b) => b.Kind switch
                {
                    BindingKind.Func => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the func {b.Value ?? "null"}"),
                    BindingKind.ResolverFunc => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the resolver func {b.Value ?? "null"}"),
                    BindingKind.Map => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is mapped to the type {((Type)b.Value)?.PrettyName() ?? "null"}"),
                    BindingKind.Instance => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the instance {b.Value ?? "null"}"),
                    BindingKind.Created => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the created instance {b.Value ?? "null"}"),
                    BindingKind.Resolved => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the resolved instance {b.Value ?? "null"}"),
                    BindingKind.Mapped => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the mapped instance {b.Value ?? "null"}"),
                    _ => throw new InvalidOperationException($"Not handling binding error for Kind: {b.Kind}, Value: {b.Value ?? "null"} "),
                });
        }

        private object GetCore(Type type)
        {
            if (this.map is null)
            {
                throw new ObjectDisposedException(nameof(Kernel));
            }

            return this.map.AddOrUpdate(
                type,
                t => t switch
                {
                    { IsInterface: true } => throw new NoBindingException(t),
                    { IsAbstract: true } => throw new NoBindingException(t),
                    { IsValueType: true } => throw new NoBindingException(t),
                    { IsArray: true } => throw new NoBindingException(t),
                    _ => Resolve(Constructor.GetResolver(t)),
                },
                (t, b) => b.Kind switch
                {
                    BindingKind.Resolved => b,
                    BindingKind.Instance => b,
                    BindingKind.Created => b,
                    BindingKind.Mapped => b,
                    BindingKind.Func => Create((Func<object>)b.Value),
                    BindingKind.ResolverFunc => Resolve((Func<IGetter, object>)b.Value),
                    BindingKind.Map => Map((Type)b.Value),
                    _ => throw new InvalidOperationException($"Not handling resolve Kind: {b.Kind}, Value: {b.Value ?? "null"} "),
                }).Value;

            Binding Resolve(Func<IGetter, object> resolve)
            {
                this.hasResolved = true;
                this.Creating?.Invoke(this, type);
                var item = resolve(this);
                this.Created?.Invoke(this, item);
                return new Binding(item, BindingKind.Created);
            }

            Binding Create(Func<object> create)
            {
                this.Creating?.Invoke(this, type);
                var item = create();
                this.Created?.Invoke(this, item);
                return new Binding(item, BindingKind.Created);
            }

            Binding Map(Type to)
            {
                return new Binding(this.GetCore(to), BindingKind.Mapped);
            }
        }
    }
}
