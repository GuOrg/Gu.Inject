namespace Gu.Inject.Analyzers
{
    using Gu.Roslyn.AnalyzerExtensions;

    internal static class KnownSymbol
    {
        internal static readonly QualifiedType Object = new QualifiedType("System.Object", "object");
        internal static readonly QualifiedType Boolean = new QualifiedType("System.Boolean", "bool");
        internal static readonly QualifiedType ContainerOfT = new QualifiedType("Gu.Inject.Container`1");
    }
}
