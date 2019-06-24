namespace Gu.Inject.Analyzers.CodeFixes
{
    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Threading.Tasks;
    using Gu.Roslyn.AnalyzerExtensions;
    using Gu.Roslyn.CodeFixExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AutoBindFix))]
    [Shared]
    public class AutoBindFix : CodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
            GuInj001AddAutoBind.DiagnosticId);

        public override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var syntaxRoot = await context.Document.GetSyntaxRootAsync(context.CancellationToken)
                                          .ConfigureAwait(false);
            var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken)
                                             .ConfigureAwait(false);
            foreach (var diagnostic in context.Diagnostics)
            {
                if (syntaxRoot.TryFindNode(diagnostic, out ObjectCreationExpressionSyntax objectCreation) &&
                    semanticModel.TryGetType(objectCreation, context.CancellationToken, out var type))
                {
                    if (semanticModel.LookupSymbols(objectCreation.SpanStart, type, "AutoBind", includeReducedExtensionMethods: true)
                                     .Any(x => x is IMethodSymbol candidate && candidate.Parameters.Length == 0))
                    {
                        context.RegisterCodeFix(
                            CodeAction.Create(
                                "Call AutoBind()",
                                _ => Task.FromResult(context.Document.WithSyntaxRoot(WithCallToAutoBind())),
                                nameof(AutoBindFix)),
                            diagnostic);
                    }
                    else if (semanticModel.LookupSymbols(objectCreation.SpanStart, name: "ContainerExtensions")
                                          .TrySingle(x => x is ITypeSymbol candidate && candidate.HasCompilerGeneratedAttribute(), out var extensionsType) &&
                             extensionsType.TrySingleDeclaration(context.CancellationToken, out ClassDeclarationSyntax declaration))
                    {
                        context.RegisterCodeFix(
                            CodeAction.Create(
                                "Generate and call AutoBind()",
                                cancellationToken =>
                                {
                                    var sln = context.Document.Project.Solution;
                                    var extDoc = sln.GetDocument(declaration.SyntaxTree);
                                    return Task.FromResult(
                                        sln.WithDocumentSyntaxRoot(
                                               context.Document.Id,
                                               WithCallToAutoBind())
                                           .WithDocumentSyntaxRoot(
                                               extDoc.Id,
                                               declaration.SyntaxTree.GetRoot(cancellationToken)
                                                          .ReplaceNode(
                                                              declaration,
                                                              WithExtensionMethod(declaration))));
                                },
                                nameof(AutoBindFix)),
                            diagnostic);
                    }

                    SyntaxNode WithCallToAutoBind()
                    {
                        return syntaxRoot.ReplaceNode(
                            objectCreation,
                            SyntaxFactory.InvocationExpression(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    objectCreation,
                                    SyntaxFactory
                                        .IdentifierName("AutoBind"))));
                    }

                    ClassDeclarationSyntax WithExtensionMethod(ClassDeclarationSyntax declaration)
                    {
                        return declaration.AddMembers(Parse.MethodDeclaration(@"
        public static Container<C> AutoBind(this Container<C> container)
        { 
            container.Bind(() => new C());
            return container;
        }").WithLeadingElasticLineFeed()
           .WithTrailingElasticLineFeed());
                    }
                }
            }
        }
    }
}
