namespace Gu.Inject.Analyzers.NodeAnalyzers
{
    using System.Collections.Immutable;
    using Gu.Roslyn.AnalyzerExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Diagnostics;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MethodDeclarationAnalyzer : DiagnosticAnalyzer
    {
        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            GuInj002IncorrectAutoBind.Descriptor);

        /// <inheritdoc/>
        public override void Initialize(AnalysisContext context)
        {
            if (context == null)
            {
                return;
            }

            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(Handle, SyntaxKind.MethodDeclaration);
        }

        private static void Handle(SyntaxNodeAnalysisContext context)
        {
            if (context.ContainingSymbol is IMethodSymbol method &&
                method.Parameters.TrySingle(out var parameter) &&
                parameter.Type == KnownSymbol.ContainerOfT &&
                parameter.Type is INamedTypeSymbol containerType &&
                containerType.TypeArguments.TrySingle(out var rootType))
            {
            }
        }
    }
}