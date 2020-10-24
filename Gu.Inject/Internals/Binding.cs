namespace Gu.Inject
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{this.DebuggerDisplayString}")]
    internal readonly struct Binding
    {
        internal readonly object Value;
        internal readonly BindingKind Kind;

        private Binding(object value, BindingKind kind)
        {
            this.Value = value;
            this.Kind = kind;
        }

        private string DebuggerDisplayString => $"Type: {this.Kind}, Value: {this.Value ?? "null"}";

        internal static Binding Map(Type type) => new Binding(type, BindingKind.Map);

        internal static Binding Map<T>() => new Binding(typeof(T), BindingKind.Map);

        internal static Binding Func<T>(Func<T> create) => new Binding(create, BindingKind.Func);

        internal static Binding Resolver<T>(Func<IGetter, T> create) => new Binding(create, BindingKind.ResolverFunc);

        internal static Binding Mapped<T>(T instance) => new Binding(instance!, BindingKind.Mapped);

        internal static Binding Created<T>(T instance) => new Binding(instance!, BindingKind.Created);

        internal static Binding Resolved<T>(T instance) => new Binding(instance!, BindingKind.Resolved);

        internal static Binding AutoResolved<T>(T instance) => new Binding(instance!, BindingKind.AutoResolved);

        internal static Binding Instance<T>(T instance) => new Binding(instance!, BindingKind.Instance);
    }
}