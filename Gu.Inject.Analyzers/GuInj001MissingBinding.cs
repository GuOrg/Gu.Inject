namespace Gu.Inject.Analyzers
{
    using Microsoft.CodeAnalysis;

    public static class GuInj001MissingBinding
    {
        public const string DiagnosticId = "GUINJ001";

        public static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "Missing bindings.",
            messageFormat: "Provide binding for the type {0}.",
            category: AnalyzerCategory.Correctness,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Use the code fix to generate binding code.",
            helpLinkUri: HelpLink.ForId(DiagnosticId));
    }
}
