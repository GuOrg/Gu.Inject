namespace Gu.Inject.Analyzers.NodeAnalyzers
{
    using System.Collections.Immutable;
    using Gu.Roslyn.AnalyzerExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ObjectCreationAnalyzer : DiagnosticAnalyzer
    {
        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            GuInj001AddAutoBind.Descriptor);

        /// <inheritdoc/>
        public override void Initialize(AnalysisContext context)
        {
            if (context == null)
            {
                return;
            }

            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(Handle, SyntaxKind.ObjectCreationExpression);
        }

        private static void Handle(SyntaxNodeAnalysisContext context)
        {
            if (!context.IsExcludedFromAnalysis() &&
                context.Node is ObjectCreationExpressionSyntax objectCreation &&
                objectCreation.Type is GenericNameSyntax &&
                context.SemanticModel.TryGetType(objectCreation, context.CancellationToken, out var type) &&
                type is INamedTypeSymbol namedType &&
                type == KnownSymbol.ContainerOfT &&
                namedType.TypeArguments.TrySingle(out var typeArg) &&
                typeArg != KnownSymbol.Object &&
                !IsAutoBound(objectCreation))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    GuInj001AddAutoBind.Descriptor,
                    objectCreation.GetLocation()));
            }

            bool IsAutoBound(ObjectCreationExpressionSyntax candidate)
            {
                var parent = candidate.Parent;
                while (parent is MemberAccessExpressionSyntax memberAccess &&
                       memberAccess.Parent is InvocationExpressionSyntax invocation)
                {
                    if (invocation.TryGetMethodName(out var name) &&
                        name == "AutoBind")
                    {
                        return true;
                    }

                    parent = invocation.Parent;
                }

                return false;
            }
        }
    }
}
