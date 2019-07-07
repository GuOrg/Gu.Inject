namespace Gu.Inject.Analyzers
{
    using Microsoft.CodeAnalysis;

    public static class GuInj003Cycle
    {
        public const string DiagnosticId = "GUINJ003";

        public static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "Cycle detected in graph.",
            messageFormat: "Cycle detected in graph.",
            category: AnalyzerCategory.Correctness,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Cycle detected in graph.",
            helpLinkUri: HelpLink.ForId(DiagnosticId));
    }
}