namespace Gu.Inject
{
    using System;
    using System.Diagnostics;
    using System.Runtime.Serialization;

    [DebuggerDisplay("{this.DebuggerDisplayString}")]
    internal readonly struct Binding
    {
        internal readonly object? Value;
        internal readonly BindingKind Kind;

        private Binding(object? value, BindingKind kind)
        {
            this.Value = value;
            this.Kind = kind;
        }

        private string DebuggerDisplayString => $"Type: {this.Kind}, Value: {this.Value ?? "null"}";

        internal static Binding Map(Type type) => new(type, BindingKind.Map);

        internal static Binding Map<T>() => new(typeof(T), BindingKind.Map);

        internal static Binding Func<T>(Func<T> create) => new(create, BindingKind.Func);

        internal static Binding Resolver<T>(Func<IReadOnlyKernel, T> create) => new(create, BindingKind.ResolverFunc);

        internal static Binding Mapped<T>(T instance) => new(instance!, BindingKind.Mapped);

        internal static Binding Created<T>(T instance) => new(instance!, BindingKind.Created);

        internal static Binding Resolved<T>(T instance) => new(instance!, BindingKind.Resolved);

        internal static Binding Uninitialized<T>()
            where T : class
        {
            return new Binding(FormatterServices.GetUninitializedObject(typeof(T)), BindingKind.Uninitialized);
        }

        internal static Binding Initialized(object obj) => new(obj, BindingKind.Initialized);

        internal static Binding AutoResolved<T>(T instance) => new(instance!, BindingKind.AutoResolved);

        internal static Binding Instance<T>(T instance) => new(instance!, BindingKind.Instance);
    }
}
