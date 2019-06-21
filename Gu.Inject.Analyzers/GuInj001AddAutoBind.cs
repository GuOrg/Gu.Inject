namespace Gu.Inject.Analyzers
{
    using Microsoft.CodeAnalysis;

    internal static class GuInj001AddAutoBind
    {
        public const string DiagnosticId = "GUINJ001";

        internal static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "Use AutoBind() to wire up bindings.",
            messageFormat: "Use AutoBind() to wire up bindings.",
            category: AnalyzerCategory.Correctness,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "AutoBind is generated and checked by the analyzer.",
            helpLinkUri: HelpLink.ForId(DiagnosticId));
    }
}
