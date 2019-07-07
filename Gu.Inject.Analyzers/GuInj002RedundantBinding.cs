namespace Gu.Inject.Analyzers
{
    using Microsoft.CodeAnalysis;

    public static class GuInj002RedundantBinding
    {
        public const string DiagnosticId = "GUINJ002";

        public static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "The type already has a binding.",
            messageFormat: "The type {0} is bound more than once.",
            category: AnalyzerCategory.Correctness,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "The type already has a binding.",
            helpLinkUri: HelpLink.ForId(DiagnosticId));
    }
}