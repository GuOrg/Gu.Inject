namespace Gu.Inject
{
    using System.Diagnostics;

    [DebuggerDisplay("{this.DebuggerDisplayString}")]
    internal struct Binding
    {
        internal readonly object Value;
        internal readonly BindingKind Kind;

        internal Binding(object value, BindingKind kind)
        {
            this.Value = value;
            this.Kind = kind;
        }

        private string DebuggerDisplayString => $"Type: {this.Kind}, Value: {this.Value ?? "null"}";
    }
}