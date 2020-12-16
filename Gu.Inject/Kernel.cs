namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
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
            this.BindCore(typeof(IGetter), Binding.Mapped(this));
        }

        /// <summary>
        /// This notifies before creating an instance of a type.
        /// </summary>
        public event EventHandler<CreatingEventArgs>? Creating;

        /// <summary>
        /// This notifies after creating an instance of a type.
        /// </summary>
        public event EventHandler<CreatedEventArgs>? Created;

        /// <summary>
        /// This notifies before an instance is removed when calling <see cref="Dispose"/>.
        /// Note that the event notifies for all instances not only types that implement <see cref="IDisposable"/>.
        /// It is called before the call to instance.Dispose() if it was created by the kernel.
        /// </summary>
        public event EventHandler<DisposingEventArgs>? Disposing;

        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        public T Get<T>() => (T)this.GetCore(typeof(T))!;

        /// <summary>
        /// Get the singleton instance of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>The singleton instance of <paramref name="type"/>.</returns>
        public object? Get(Type type)
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
                    case BindingKind.Map:
                    case BindingKind.Mapped:
                        break;
                    case BindingKind.Instance:
                        this.Disposing?.Invoke(this, new DisposingEventArgs(kvp.Value.Value));
                        break;
                    case BindingKind.Created:
                    case BindingKind.Resolved:
                    case BindingKind.AutoResolved:
                    case BindingKind.Initialized:
                        this.Disposing?.Invoke(this, new DisposingEventArgs(kvp.Value.Value));
                        (kvp.Value.Value as IDisposable)?.Dispose();
                        break;
                    default:
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                        throw new InvalidOperationException($"Not handling dispose of Kind: {kvp.Value.Kind}, Value: {kvp.Value.Value ?? "null"} ");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
            }
        }

        /// <summary>
        /// Only exposing this via RebindExtensions as it is the only use case I can think of.
        /// So that we don't clutter API for the common use.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <returns>True if there is a binding.</returns>
        internal bool HasBinding(Type type) => this.map?.TryGetValue(type, out _) ?? false;

        internal void Rebind(Type key, Binding binding, bool requireExistingBinding)
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
                t => AddValueFactory(t),
                (_, _) => UpdateValueFactory());

            Binding AddValueFactory(Type t)
            {
                if (requireExistingBinding)
                {
                    throw new InvalidOperationException($"{t.PrettyName()} does not have a binding. For Rebind an existing binding is assumed.");
                }

                return binding;
            }

            Binding UpdateValueFactory() => binding;
        }

        private void BindCore(Type key, Binding binding)
        {
            if (this.hasResolved)
            {
                throw new InvalidOperationException(
                    "Bind not allowed after Get<T>().\r\n" +
                    "This could create hard to track down graph bugs.");
            }

            if (this.map is null)
            {
                throw new ObjectDisposedException(nameof(Kernel));
            }

            if (binding is { Kind: BindingKind.Map, Value: Type to } &&
                key == to)
            {
                throw new InvalidOperationException(
                    "Trying to bind to the same type.\r\n" +
                    "This is the equivalent of kernel.Bind<C, C>().\r\n" +
                    "It is not strictly wrong but redundant and could indicate a mistake and hence disallowed.");
            }

            _ = this.map.AddOrUpdate(
                key,
                _ => AddValueFactory(),
                (t, b) => b.Kind switch
                {
                    BindingKind.Func => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the func {b.Value ?? "null"}"),
                    BindingKind.ResolverFunc => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the resolver func {b.Value ?? "null"}"),
                    BindingKind.Map => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is mapped to the type {((Type?)b.Value)?.PrettyName() ?? "null"}"),
                    BindingKind.Instance => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to an instance of {b.Value?.GetType().PrettyName() ?? "null"}"),
                    BindingKind.Created => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the created instance {b.Value ?? "null"}"),
                    BindingKind.Resolved => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is bound to the resolved instance {b.Value ?? "null"}"),
                    BindingKind.Mapped => throw new InvalidOperationException($"{t.PrettyName()} already has a binding. It is mapped to {b.Value?.GetType().PrettyName() ?? "null"}"),
                    _ => throw new InvalidOperationException($"Not handling binding error for Kind: {b.Kind}, Value: {b.Value ?? "null"} "),
                });

            Binding AddValueFactory() => binding;
        }

        private object? GetCore(Type type)
        {
            this.hasResolved = true;

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
                (_, b) => b switch
                {
                    { Kind: BindingKind.Initialized } => b,
                    { Kind: BindingKind.AutoResolved } => b,
                    { Kind: BindingKind.Resolved } => b,
                    { Kind: BindingKind.Instance } => b,
                    { Kind: BindingKind.Created } => b,
                    { Kind: BindingKind.Mapped } => b,
                    { Kind: BindingKind.Uninitialized } => Initialize(b.Value!),
                    { Kind: BindingKind.Func, Value: Func<object?> func } => Create(func),
                    { Kind: BindingKind.ResolverFunc, Value: Func<IGetter, object?> func } => Resolve(func),
                    { Kind: BindingKind.Map, Value: Type mappedType } => Map(mappedType),
                    _ => throw new InvalidOperationException($"Not handling resolve Kind: {b.Kind}, Value: {b.Value ?? "null"} "),
                }).Value;

            Binding AutoResolve(Type candidate)
            {
                if (Constructor.Get(candidate) is { } constructor)
                {
                    this.Creating?.Invoke(this, new CreatingEventArgs(type));
                    try
                    {
                        var item = constructor.Invoke(null, x => ResolveParameter(x));
                        this.Created?.Invoke(this, new CreatedEventArgs(item));
                        return Binding.AutoResolved(item);
                    }
                    catch (NoBindingException e)
                    {
                        throw new NoBindingException(candidate, NoBindingMessage($"new {type.PrettyName()}(", e), e);
                    }
                }

                var messageBuilder = new StringBuilder();
                var padding = "  ";
                messageBuilder.AppendLine($"new {candidate.PrettyName()}(");
                foreach (var parameter in Constructor.Cycle(candidate))
                {
                    messageBuilder.AppendLine($"{padding}new {parameter.ParameterType.PrettyName()}(");
                    padding += "  ";
                }

                messageBuilder.AppendLine($"{padding}new {candidate.PrettyName()}(... Circular dependency detected.");
                throw new CircularDependencyException(candidate, messageBuilder.ToString());
            }

            Binding Initialize(object obj)
            {
                if (Constructor.Get(obj.GetType()) is { } constructor)
                {
                    this.Creating?.Invoke(this, new CreatingEventArgs(type));
                    var item = constructor.Invoke(obj, x => ResolveParameter(x));
                    this.Created?.Invoke(this, new CreatedEventArgs(item));
                    return Binding.Initialized(item);
                }

                return Binding.Initialized(obj);
            }

            Binding Create(Func<object?> create)
            {
                this.Creating?.Invoke(this, new CreatingEventArgs(type));
                try
                {
                    var item = create();
                    this.Created?.Invoke(this, new CreatedEventArgs(item));
                    if (item is null ||
                        type == item.GetType())
                    {
                        return Binding.Created(item);
                    }

                    if (this.map.TryAdd(item.GetType(), Binding.Created(item)))
                    {
                        return Binding.Mapped(item);
                    }

                    var existing = this.map[item.GetType()];
                    if (ReferenceEquals(existing.Value, item) ||
                        item.GetType().IsValueType)
                    {
                        return existing;
                    }

                    throw new ResolveException(type, AlreadyCreatedMessage(existing, create));
                }
                catch (NoBindingException e)
                {
                    throw new NoBindingException(type, NoBindingMessage($"Func<{type.PrettyName()}>.Invoke(", e), e);
                }
            }

            Binding Resolve(Func<IGetter, object?> resolve)
            {
                this.Creating?.Invoke(this, new CreatingEventArgs(type));
                try
                {
                    var item = resolve(this);
                    this.Created?.Invoke(this, new CreatedEventArgs(item));

                    if (item is null ||
                        type == item.GetType())
                    {
                        return Binding.Resolved(item);
                    }

                    if (this.map.TryAdd(item.GetType(), Binding.Resolved(item)))
                    {
                        return Binding.Mapped(item);
                    }

                    var existing = this.map[item.GetType()];
                    if (ReferenceEquals(existing.Value, item) ||
                        item.GetType().IsValueType)
                    {
                        return existing;
                    }

                    throw new ResolveException(type, AlreadyCreatedMessage(existing, resolve));
                }
                catch (NoBindingException e)
                {
                    throw new NoBindingException(type, NoBindingMessage($"getter.Get<{type.PrettyName()}>(", e), e);
                }
            }

            Binding Map(Type to)
            {
                return Binding.Mapped(this.GetCore(to));
            }

            object? ResolveParameter(Type parameterType) => this.GetCore(parameterType);

            string AlreadyCreatedMessage(Binding duplicate, Delegate func)
            {
                return $"An instance of type {duplicate.Value?.GetType().PrettyName()} was already created.\r\n" +
                       $"The existing instance was created via {CreatedVia()}.\r\n" +
                       "This can happen by doing:\r\n" +
                       $"1. Bind<I>({Lambda()})\r\n" +
                       "2. Get<C>() this creates an instance of C using the constructor.\r\n" +
                       $"3. Get<I>() this creates an instance of C using the bound {Func()} and then detects the instance created in 2.\r\n" +
                       "\r\n" +
                       "Specify explicit binding for the concrete type.\r\n" +
                       "For example by:\r\n" +
                       $"Bind<I, C>({Lambda()})\r\n" +
                       "or\r\n" +
                       $"Bind<I, C>()\r\n" +
                       $"Bind<C>({Lambda()})";

                string Lambda() => func switch
                {
                    Func<object?> => "() => new C()",
                    Func<IGetter, object?> => "x => new C(...)",
                    _ => func.ToString() ?? "null",
                };

                string CreatedVia() => duplicate.Kind switch
                {
                    BindingKind.Func => "Func<C>",
                    BindingKind.ResolverFunc => "Func<IGetter, C>",
                    BindingKind.Map => "map type",
                    BindingKind.Instance => "bound instance",
                    BindingKind.Uninitialized => "bound uninitialized",
                    BindingKind.Initialized => "initialized",
                    BindingKind.AutoResolved => "constructor",
                    BindingKind.Created => "bound Func<C>",
                    BindingKind.Resolved => "bound Func<IGetter, C>",
                    BindingKind.Mapped => "mapped type",
                    _ => "unknown",
                };

                string Func() => func switch
                {
                    Func<object?> => "Func<C>",
                    Func<IGetter, object?> => "Func<IGetter, C>",
                    _ => func.ToString() ?? "null",
                };
            }

            string NoBindingMessage(string line, NoBindingException inner)
            {
                var message = new StringBuilder();
                if (inner.InnerException is null)
                {
                    return message.AppendLine(inner.Message)
                                  .AppendLine()
                                  .AppendLine(line)
                                  .Append($"  could not resolve {inner.Type.PrettyName()} here.")
                                  .ToString();
                }

                using var reader = new StringReader(inner.Message);
                message.AppendLine(reader.ReadLine());
                message.AppendLine(reader.ReadLine());
                message.Append(line);
                while (reader.Peek() > 0)
                {
                    message.AppendLine();
                    message.Append("  ");
                    message.Append(reader.ReadLine());
                }

                return message.ToString();
            }
        }
    }
}
