namespace Gu.Inject.Analyzers
{
    using Microsoft.CodeAnalysis;

    public static class GuInj002IncorrectAutoBind
    {
        public const string DiagnosticId = "GUINJ002";

        public static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "Regenerate bindings.",
            messageFormat: "Regenerate bindings.",
            category: AnalyzerCategory.Correctness,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "The bindings are incorrect and must be regenerated.",
            helpLinkUri: HelpLink.ForId(DiagnosticId));
    }
}