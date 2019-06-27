namespace Gu.Inject.Analyzers.CodeFixes
{
    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Threading;
    using System.Threading.Tasks;
    using Gu.Roslyn.AnalyzerExtensions;
    using Gu.Roslyn.AnalyzerExtensions.StyleCopComparers;
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
        private const string AutoBind = nameof(AutoBind);
        private const string ContainerExtensions = nameof(ContainerExtensions);

        public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
            GuInj001AddAutoBind.DiagnosticId);

        public override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var syntaxRoot = await context.Document.GetSyntaxRootAsync(context.CancellationToken)
                                          .ConfigureAwait(false);
            var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken)
                                             .ConfigureAwait(false);
            if (syntaxRoot is CompilationUnitSyntax compilationUnit)
            {
                foreach (var diagnostic in context.Diagnostics)
                {
                    if (syntaxRoot.TryFindNode(diagnostic, out ObjectCreationExpressionSyntax objectCreation))
                    {
                        if (TryFindAutoBind(semanticModel, objectCreation, context.CancellationToken, out var containerExtensions, out var autoBind))
                        {
                            if (autoBind != null)
                            {
                                context.RegisterCodeFix(
                                    CodeAction.Create(
                                        $"Call {AutoBind}()",
                                        _ => Task.FromResult(
                                            context.Document.WithSyntaxRoot(
                                                WithCallToAutoBind(autoBind.Name).AddUsing(autoBind.ContainingType, semanticModel))),
                                        nameof(AutoBindFix)),
                                    diagnostic);
                            }
                            else
                            {
                                foreach (var reference in containerExtensions.DeclaringSyntaxReferences)
                                {
                                    var declaration = (ClassDeclarationSyntax)reference.GetSyntax(context.CancellationToken);
                                    context.RegisterCodeFix(
                                        CodeAction.Create(
                                            $"Generate and call {AutoBind}()",
                                            cancellationToken =>
                                            {
                                                var sln = context.Document.Project.Solution;
                                                var extDoc = sln.GetDocument(declaration.SyntaxTree);
                                                return Task.FromResult(
                                                    sln.WithDocumentSyntaxRoot(
                                                           context.Document.Id,
                                                           WithCallToAutoBind(AutoBind).AddUsing(containerExtensions, semanticModel))
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
                            }
                        }
                        else
                        {
                            //context.RegisterCodeFix(
                            //    CodeAction.Create(
                            //        $"Generate and call {AutoBind}()",
                            //        cancellationToken =>
                            //        {
                            //            var sln = context.Document.Project.Solution;
                            //            return Task.FromResult(
                            //                sln.WithDocumentSyntaxRoot(
                            //                        context.Document.Id,
                            //                        WithCallToAutoBind())
                            //                    .AddDocument(
                            //                        DocumentId.CreateNewId(context.Document.Project.Id),
                            //                        "Extensions.generated.cs",
                            //                        SyntaxFactory.CompilationUnit(""),
                            //                        context.Document.Folders,
                            //                        isGenerated: true,
                            //                        preservationMode: PreservationMode.PreserveValue));
                            //        },
                            //        nameof(AutoBindFix)),
                            //    diagnostic);                        
                        }

                        CompilationUnitSyntax WithCallToAutoBind(string name)
                        {
                            return compilationUnit.ReplaceNode(
                                                      objectCreation,
                                                      SyntaxFactory.InvocationExpression(
                                                          SyntaxFactory.MemberAccessExpression(
                                                              SyntaxKind.SimpleMemberAccessExpression,
                                                              objectCreation,
                                                              SyntaxFactory
                                                                  .IdentifierName(name))));
                        }

                        ClassDeclarationSyntax WithExtensionMethod(ClassDeclarationSyntax declaration)
                        {
                            var code = StringBuilderPool.Borrow()
                                                        .AppendLine("        // <auto-generated/>")
                                                        .AppendLine($"        public static Container<C> {AutoBind}(this Container<C> container)")
                                                        .AppendLine("        {")
                                                        .AppendLine("            container.Bind(() => new C());")
                                                        .AppendLine("            return container;")
                                                        .AppendLine("        }")
                                                        .Return();
                            return declaration.AddMembers(Parse.MethodDeclaration(code)
                                                               .WithLeadingElasticLineFeed()
                                                               .WithTrailingElasticLineFeed());
                        }
                    }
                }
            }
        }

        private static bool TryFindAutoBind(SemanticModel semanticModel, ObjectCreationExpressionSyntax objectCreation, CancellationToken cancellationToken, out INamedTypeSymbol containerExtensions, out IMethodSymbol autoBind)
        {
            if (semanticModel.TryGetType(objectCreation, cancellationToken, out var containerType))
            {
                foreach (var candidate in semanticModel.LookupSymbols(objectCreation.SpanStart, containerType, AutoBind, includeReducedExtensionMethods: true))
                {
                    if (candidate is IMethodSymbol method &&
                        method.IsExtensionMethod &&
                        method.Parameters.Length == 0)
                    {
                        containerExtensions = method.ContainingType;
                        autoBind = method;
                        return true;
                    }
                }

                foreach (var candidate in semanticModel.LookupNamespacesAndTypes(objectCreation.SpanStart, name: ContainerExtensions))
                {
                    if (candidate is INamedTypeSymbol type &&
                        type.IsStatic)
                    {
                        autoBind = null;
                        containerExtensions = type;
                        return true;
                    }
                }

                foreach (var candidate in semanticModel.LookupNamespacesAndTypes(objectCreation.SpanStart))
                {
                    if (candidate is INamespaceSymbol ns)
                    {
                        if (TryFindRecursive(ns, objectCreation, containerType, semanticModel, out containerExtensions, out autoBind))
                        {
                            return true;
                        }
                    }
                }
            }

            containerExtensions = null;
            autoBind = null;
            return false;
        }

        private static bool TryFindRecursive(INamespaceSymbol ns, ObjectCreationExpressionSyntax objectCreation, ITypeSymbol containerType, SemanticModel semanticModel, out INamedTypeSymbol containerExtensions, out IMethodSymbol autoBind)
        {
            foreach (var candidate in semanticModel.LookupNamespacesAndTypes(objectCreation.SpanStart, ns))
            {
                switch (candidate)
                {
                    case INamespaceSymbol nested when TryFindRecursive(nested, objectCreation, containerType, semanticModel, out containerExtensions, out autoBind):
                        return true;
                    case INamedTypeSymbol type when type.IsStatic && type.Name == ContainerExtensions:
                        containerExtensions = type;
                        _ = type.TryFindFirstMethod(
                            AutoBind,
                            x => x.IsExtensionMethod &&
                                 x.Parameters.TrySingle(out var parameter) &&
                                 Equals(parameter.Type, containerType),
                            out autoBind);
                        return true;
                }
            }

            containerExtensions = null;
            autoBind = null;
            return false;
        }
    }
}
