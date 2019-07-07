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
            GuInj001MissingBinding.Descriptor,
            GuInj002RedundantBinding.Descriptor);

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
                context.SemanticModel.TryGetNamedType(objectCreation, context.CancellationToken, out var containerType) &&
                containerType == KnownSymbol.ContainerOfT &&
                containerType.TypeArguments.TrySingleOfType(out INamedTypeSymbol rootType) &&
                rootType != KnownSymbol.Object)
            {
                using (var bindings = Binding.FindBindings(objectCreation, context.SemanticModel, context.CancellationToken))
                {
                    using (var graph = Binding.Graph(rootType, context.SemanticModel, objectCreation.SpanStart))
                    {
                        foreach (var kvp in bindings)
                        {
                            if (kvp.Value.Length > 1)
                            {
                                context.ReportDiagnostic(
                                    Diagnostic.Create(
                                        GuInj002RedundantBinding.Descriptor,
                                        objectCreation.GetLocation(),
                                        kvp.Key.ToDisplayString()));
                            }
                        }

                        graph.ExceptWith(bindings.Keys);
                        foreach (var missing in graph)
                        {
                            context.ReportDiagnostic(
                                Diagnostic.Create(
                                    GuInj001MissingBinding.Descriptor,
                                    objectCreation.GetLocation(),
                                    ImmutableDictionary<string, string>.Empty.Add(nameof(INamedTypeSymbol), missing.FullName()),
                                    missing.ToMinimalDisplayString(context.SemanticModel, objectCreation.SpanStart)));
                        }
                    }
                }
            }
        }
    }
}
