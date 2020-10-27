namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Text;

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
            this.BindCore(typeof(IGetter), Binding.Instance(this));
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
        public T Get<T>() => (T)this.GetCore(typeof(T));

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
                    case BindingKind.AutoResolved:
                    case BindingKind.Initialized:
                        (kvp.Value.Value as IDisposable)?.Dispose();
                        break;
                    default:
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                        throw new InvalidOperationException($"Not handling dispose of Kind: {kvp.Value.Kind}, Value: {kvp.Value.Value ?? "null"} ");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
            }
        }

        internal void RebindCore(Type key, Binding binding)
        {
            if (this.hasResolved)
            {
                throw new InvalidOperationException("Rebind not allowed after resolving. This could create hard to track down graph bugs.");
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
                t => throw new InvalidOperationException($"{t.PrettyName()} does not have a binding. For Rebind an existing binding is assumed."),
                (t, b) => UpdateValueFactory());

            Binding UpdateValueFactory() => binding;
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
                t => AddValueFactory(),
                (t, b) => b.Kind switch
                {
                    BindingKind.Func => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the func {b.Value ?? "null"}"),
                    BindingKind.ResolverFunc => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the resolver func {b.Value ?? "null"}"),
                    BindingKind.Map => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is mapped to the type {((Type)b.Value)?.PrettyName() ?? "null"}"),
                    BindingKind.Instance => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to an instance of {b.Value?.GetType().PrettyName() ?? "null"}"),
                    BindingKind.Created => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the created instance {b.Value ?? "null"}"),
                    BindingKind.Resolved => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the resolved instance {b.Value ?? "null"}"),
                    BindingKind.Mapped => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is mapped to {b.Value?.GetType().PrettyName() ?? "null"}"),
                    _ => throw new InvalidOperationException($"Not handling binding error for Kind: {b.Kind}, Value: {b.Value ?? "null"} "),
                });

            Binding AddValueFactory() => binding;
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
                    _ => AutoResolve(t),
                },
                (t, b) => b.Kind switch
                {
                    BindingKind.Initialized => b,
                    BindingKind.AutoResolved => b,
                    BindingKind.Resolved => b,
                    BindingKind.Instance => b,
                    BindingKind.Created => b,
                    BindingKind.Mapped => b,
                    BindingKind.Uninitialized => Initialize(b.Value),
                    BindingKind.Func => Create((Func<object>)b.Value),
                    BindingKind.ResolverFunc => Resolve((Func<IGetter, object>)b.Value),
                    BindingKind.Map => Map((Type)b.Value),
                    _ => throw new InvalidOperationException($"Not handling resolve Kind: {b.Kind}, Value: {b.Value ?? "null"} "),
                }).Value;

            Binding AutoResolve(Type candidate)
            {
                if (Constructor.Get(candidate) is { } constructor)
                {
                    this.hasResolved = true;
                    this.Creating?.Invoke(this, type);
                    var item = constructor.Invoke(null, x => ResolveParameter(x));
                    this.Created?.Invoke(this, item);
                    return Binding.AutoResolved(item);
                }

                var messageBuilder = new StringBuilder();
                var padding = "  ";
                messageBuilder.AppendLine($"{candidate.PrettyName()}(");
                foreach (var parameter in Constructor.Cycle(candidate))
                {
                    messageBuilder.AppendLine($"{padding}{parameter.ParameterType.PrettyName()}(");
                    padding += "  ";
                }

                messageBuilder.AppendLine($"{padding}{candidate.PrettyName()}(... Circular dependency detected.");
                ////messageBuilder.AppendLine($"Potential solution: {nameof(this.BindUninitialized)}<{type?.PrettyName()}>()")
                ////              .AppendLine($"Note that when using {nameof(this.BindUninitialized)}<{type?.PrettyName()}>() types taking {type?.PrettyName()} as constructor parameter get an uninitialized instance while in the constructor.");
                throw new CircularDependencyException(candidate, messageBuilder.ToString());
            }

            Binding Initialize(object obj)
            {
                if (Constructor.Get(obj.GetType()) is { } constructor)
                {
                    this.hasResolved = true;
                    this.Creating?.Invoke(this, type);
                    var item = constructor.Invoke(obj, x => ResolveParameter(x));
                    this.Created?.Invoke(this, item);
                    return Binding.Initialized(item);
                }

                return Binding.Initialized(obj);
            }

            Binding Create(Func<object> create)
            {
                this.Creating?.Invoke(this, type);
                var item = create();
                this.Created?.Invoke(this, item);
                //// ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (item is null ||
                    type == item?.GetType())
                {
                    return Binding.Created(item);
                }

                if (this.map!.TryAdd(item!.GetType(), Binding.Created(item)))
                {
                    return Binding.Mapped(item);
                }

                var message = "There was already an instance created.\r\n" +
                                    "This can happen by doing:\r\n" +
                                    "1. Bind<I>(() => new C())" +
                                    "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                                    "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                                    "Solution:\r\n" +
                                    "Specify explicit binding for the concrete type.\r\n" +
                                    "For example by: Bind<I, C>(() => new C())";
                throw new ResolveException(type, message);
            }

            Binding Resolve(Func<IGetter, object> resolve)
            {
                this.hasResolved = true;
                this.Creating?.Invoke(this, type);
                var item = resolve(this);
                this.Created?.Invoke(this, item);
                //// ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (item is null ||
                    type == item?.GetType())
                {
                    return Binding.Resolved(item);
                }

                if (this.map!.TryAdd(item!.GetType(), Binding.Resolved(item)))
                {
                    return Binding.Mapped(item);
                }

                var message = "There was already an instance created.\r\n" +
                                    "This can happen by doing:\r\n" +
                                    "1. Bind<I>(x => new C())" +
                                    "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                                    "3. Get<I>() this creates an instance of C using the func and then detects there is already an instance.\r\n" +
                                    "Solution:\r\n" +
                                    "Specify explicit binding for the concrete type.\r\n" +
                                    "For example by: Bind<I, C>(x => new C())";
                throw new ResolveException(type, message);
            }

            Binding Map(Type to)
            {
                return Binding.Mapped(this.GetCore(to));
            }

            object ResolveParameter(Type parameterType) => this.GetCore(parameterType);
        }
    }
}
