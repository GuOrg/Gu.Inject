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
    using Microsoft.CodeAnalysis.Editing;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AutoBindFix))]
    [Shared]
    public class AutoBindFix : CodeFixProvider
    {
        private const string AutoBind = nameof(AutoBind);
        private const string ContainerExtensions = nameof(ContainerExtensions);

        public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
            GuInj001AddAutoBind.DiagnosticId);

        public override FixAllProvider GetFixAllProvider() => null;

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
                    if (syntaxRoot.TryFindNode(diagnostic, out ObjectCreationExpressionSyntax objectCreation) &&
                        semanticModel.TryGetType(objectCreation, context.CancellationToken, out var temp) &&
                        temp is INamedTypeSymbol containerType)
                    {
                        if (TryFindAutoBind(semanticModel, objectCreation, containerType, out var containerExtensions, out var autoBind))
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
                                                           declaration.SyntaxTree
                                                                      .GetRoot(cancellationToken)
                                                                      .ReplaceNode(
                                                                          declaration,
                                                                          declaration.AddMembers(ExtensionMethod(SyntaxGenerator.GetGenerator(context.Document.Project.GetDocument(declaration.SyntaxTree)))))));
                                            },
                                            nameof(AutoBindFix)),
                                        diagnostic);
                                }
                            }
                        }
                        else if (objectCreation.TryFirstAncestor(out NamespaceDeclarationSyntax namespaceDeclaration))
                        {
                            context.RegisterCodeFix(
                                CodeAction.Create(
                                    $"Generate and call {AutoBind}()",
                                    cancellationToken =>
                                    {
                                        var sln = context.Document.Project.Solution;
                                        return Task.FromResult(
                                            sln.WithDocumentSyntaxRoot(
                                                    context.Document.Id,
                                                    WithCallToAutoBind(AutoBind))
                                                .AddDocument(
                                                    DocumentId.CreateNewId(context.Document.Project.Id),
                                                    "Extensions.generated.cs",
                                                    ExtensionClass(namespaceDeclaration.Name),
                                                    context.Document.Folders));
                                    },
                                    nameof(AutoBindFix)),
                                diagnostic);
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

                        CompilationUnitSyntax ExtensionClass(NameSyntax ns)
                        {
                            var g = SyntaxGenerator.GetGenerator(context.Document.Project);
                            return (CompilationUnitSyntax)g.CompilationUnit(
                                g.NamespaceDeclaration(
                                    ns,
                                    ((ClassDeclarationSyntax)g.ClassDeclaration(
                                        accessibility: Accessibility.Public,
                                        modifiers: DeclarationModifiers.Static,
                                        name: ContainerExtensions,
                                        members: new[] { ExtensionMethod(g) }))
                                    .WithDocumentationText(
                                        StringBuilderPool.Borrow()
                                            //// .AppendLine("// <auto-generated/>")
                                            .AppendLine("/// <summary>")
                                            .AppendLine("/// Extension methods for <see cref=\"Gu.Inject.Container{T}\" />.")
                                            .AppendLine("/// This file is generated by Gu.Inject.Analyzers.")
                                            .AppendLine("/// </summary>")
                                            .Return())));
                        }

                        MethodDeclarationSyntax ExtensionMethod(SyntaxGenerator g)
                        {
                            return ((MethodDeclarationSyntax)g.MethodDeclaration(
                                    AutoBind,
                                    returnType: g.TypeExpression(containerType),
                                    accessibility: Accessibility.Public,
                                    modifiers: DeclarationModifiers.Static,
                                    parameters: new[]
                                    {
                                        SyntaxFactory.Parameter(
                                            default,
                                            SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ThisKeyword)),
                                            (TypeSyntax)g.TypeExpression(containerType),
                                            SyntaxFactory.Identifier("container"),
                                            default),
                                    },
                                    statements: new[]
                                    {
                                        g.ReturnStatement(Bind(SyntaxFactory.IdentifierName("container"), containerType.TypeArguments[0])),
                                    }))
                                .WithDocumentationText(
                                    StringBuilderPool.Borrow()
                                        .AppendLine("/// <summary>")
                                        .AppendLine("/// Adds generated bindings for the graph where <see cref=\"C\"/> is root.")
                                        .AppendLine("/// This method is generated by Gu.Inject.Analyzers.")
                                        .AppendLine("/// </summary>")
                                        .AppendLine("/// <param name=\"container\">The <see cref=\"Gu.Inject.Container{C}\"/>.</param>")
                                        .Return());

                            ExpressionSyntax Bind(ExpressionSyntax e, ITypeSymbol type)
                            {
                                if (type is INamedTypeSymbol namedType)
                                {
                                    if (namedType.Constructors.TrySingle(out var ctor) &&
                                        semanticModel.IsAccessible(objectCreation.SpanStart, ctor))
                                    {
                                        if (ctor.Parameters.Length == 0)
                                        {
                                            return (InvocationExpressionSyntax)g.InvocationExpression(
                                                g.MemberAccessExpression(e, "Bind"),
                                                g.ValueReturningLambdaExpression(
                                                    new[] { g.LambdaParameter("_") },
                                                    g.ObjectCreationExpression(type)));
                                        }

                                        if (ctor.Parameters.Any(x => x.RefKind != RefKind.None || x.HasExplicitDefaultValue))
                                        {
                                            return e;
                                        }

                                        return (InvocationExpressionSyntax)g.InvocationExpression(
                                            g.MemberAccessExpression(e, "Bind"),
                                            g.ValueReturningLambdaExpression(
                                                new[] { g.LambdaParameter("x") },
                                                g.ObjectCreationExpression(
                                                    type,
                                                    ctor.Parameters.Select(x =>
                                                        g.InvocationExpression(g.MemberAccessExpression(SyntaxFactory.IdentifierName("x"), g.GenericName("Get", x.Type)))))));
                                    }
                                }

                                return e;
                            }
                        }
                    }
                }
            }
        }

        private static bool TryFindAutoBind(SemanticModel semanticModel, ObjectCreationExpressionSyntax objectCreation, ITypeSymbol containerType, out INamedTypeSymbol containerExtensions, out IMethodSymbol autoBind)
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
