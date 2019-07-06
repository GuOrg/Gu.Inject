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
                    if (syntaxRoot.TryFindNode(diagnostic, out ObjectCreationExpressionSyntax containerCreation) &&
                        semanticModel.TryGetType(containerCreation, context.CancellationToken, out var temp) &&
                        temp is INamedTypeSymbol containerType)
                    {
                        if (TryFindAutoBind(semanticModel, containerCreation, containerType, out var containerExtensions, out var autoBind))
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
                                                                          declaration.AddMembers(
                                                                              AutoBindMethod(
                                                                                  SyntaxGenerator.GetGenerator(context.Document.Project.GetDocument(declaration.SyntaxTree)),
                                                                                  containerType,
                                                                                  semanticModel,
                                                                                  containerCreation.SpanStart)))));
                                            },
                                            nameof(AutoBindFix)),
                                        diagnostic);
                                }
                            }
                        }
                        else if (containerCreation.TryFirstAncestor(out NamespaceDeclarationSyntax namespaceDeclaration))
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
                                                    ExtensionClass(
                                                        SyntaxGenerator.GetGenerator(context.Document.Project),
                                                        namespaceDeclaration.Name,
                                                        containerType,
                                                        semanticModel,
                                                        containerCreation.SpanStart),
                                                    context.Document.Folders));
                                    },
                                    nameof(AutoBindFix)),
                                diagnostic);
                        }

                        CompilationUnitSyntax WithCallToAutoBind(string name)
                        {
                            return compilationUnit.ReplaceNode(
                                                      containerCreation,
                                                      SyntaxFactory.InvocationExpression(
                                                          SyntaxFactory.MemberAccessExpression(
                                                              SyntaxKind.SimpleMemberAccessExpression,
                                                              containerCreation,
                                                              SyntaxFactory
                                                                  .IdentifierName(name))));
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

        private static CompilationUnitSyntax ExtensionClass(SyntaxGenerator g, NameSyntax namespaceName, INamedTypeSymbol containerType, SemanticModel semanticModel, int position)
        {
            return SyntaxFactory.CompilationUnit(
                externs: default,
                usings: default,
                attributeLists: default,
                members: SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                    SyntaxFactory.NamespaceDeclaration(
                        namespaceKeyword: SyntaxFactory.Token(
                            leading: default,
                            kind: SyntaxKind.NamespaceKeyword,
                            trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                        name: namespaceName,
                        openBraceToken: SyntaxFactory.Token(
                            leading: default,
                            kind: SyntaxKind.OpenBraceToken,
                            trailing: SyntaxFactory.TriviaList(SyntaxFactory.LineFeed)),
                        externs: default,
                        usings: default,
                        members: SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                            SyntaxFactory.ClassDeclaration(
                                attributeLists: default,
                                modifiers: SyntaxFactory.TokenList(
                                    SyntaxFactory.Token(
                                        leading: Comment(),
                                        kind: SyntaxKind.PublicKeyword,
                                        trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                                    SyntaxFactory.Token(
                                        leading: default,
                                        kind: SyntaxKind.StaticKeyword,
                                        trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space))),
                                keyword: SyntaxFactory.Token(
                                    leading: default,
                                    kind: SyntaxKind.ClassKeyword,
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                                identifier: SyntaxFactory.Identifier(
                                    leading: default,
                                    text: ContainerExtensions,
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.LineFeed)),
                                typeParameterList: default,
                                baseList: default,
                                constraintClauses: default,
                                openBraceToken: SyntaxFactory.Token(
                                    leading: SyntaxFactory.TriviaList(SyntaxFactory.Whitespace("    ")),
                                    kind: SyntaxKind.OpenBraceToken,
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.LineFeed)),
                                members: SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                                    AutoBindMethod(g, containerType, semanticModel, position)),
                                closeBraceToken: SyntaxFactory.Token(
                                    leading: SyntaxFactory.TriviaList(SyntaxFactory.Whitespace("    ")),
                                    kind: SyntaxKind.CloseBraceToken,
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.LineFeed)),
                                semicolonToken: default)),
                        closeBraceToken: SyntaxFactory.Token(SyntaxKind.CloseBraceToken),
                        semicolonToken: default)),
                endOfFileToken: SyntaxFactory.Token(SyntaxKind.EndOfFileToken));

            SyntaxTriviaList Comment()
            {
                return SyntaxFactory.TriviaList(
                                SyntaxFactory.Whitespace("    "),
                                SyntaxFactory.Trivia(
                                    SyntaxFactory.DocumentationCommentTrivia(
                                        kind: SyntaxKind.SingleLineDocumentationCommentTrivia,
                                        content: SyntaxFactory.List(
                                            new XmlNodeSyntax[]
                                            {
                                                SyntaxFactory.XmlText(
                                                    textTokens: SyntaxFactory.TokenList(
                                                        SyntaxFactory.XmlTextLiteral(
                                                            leading: SyntaxFactory.TriviaList(
                                                                SyntaxFactory.DocumentationCommentExterior("///")),
                                                            text: " ",
                                                            value: " ",
                                                            trailing: default))),
                                                SyntaxFactory.XmlElement(
                                                    startTag: SyntaxFactory.XmlElementStartTag(
                                                        lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                        name: SyntaxFactory.XmlName(
                                                            prefix: default,
                                                            localName: SyntaxFactory.Identifier(
                                                                leading: default,
                                                                text: "summary",
                                                                trailing: default)),
                                                        attributes: default,
                                                        greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken)),
                                                    content: SyntaxFactory.List(
                                                        new XmlNodeSyntax[]
                                                        {
                                                            SyntaxFactory.XmlText(
                                                                textTokens: SyntaxFactory.TokenList(
                                                                    SyntaxFactory.XmlTextNewLine(
                                                                        leading: default,
                                                                        text: "\r\n",
                                                                        value: "\r\n",
                                                                        trailing: default),
                                                                    SyntaxFactory.XmlTextLiteral(
                                                                        leading: SyntaxFactory.TriviaList(
                                                                            SyntaxFactory.DocumentationCommentExterior("    ///")),
                                                                        text: " Extension methods for ",
                                                                        value: " Extension methods for ",
                                                                        trailing: default))),
                                                            SyntaxFactory.XmlEmptyElement(
                                                                lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                                name: SyntaxFactory.XmlName(
                                                                    prefix: default,
                                                                    localName: SyntaxFactory.Identifier(
                                                                        leading: default,
                                                                        text: "see",
                                                                        trailing: default)),
                                                                attributes: SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                                    SyntaxFactory.XmlCrefAttribute(
                                                                        name: SyntaxFactory.XmlName(
                                                                            prefix: default,
                                                                            localName: SyntaxFactory.Identifier(
                                                                                leading: SyntaxFactory.TriviaList(SyntaxFactory.Space),
                                                                                text: "cref",
                                                                                trailing: default)),
                                                                        equalsToken: SyntaxFactory.Token(SyntaxKind.EqualsToken),
                                                                        startQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                                        cref: SyntaxFactory.TypeCref(g.CrefType(containerType.ConstructedFrom)),
                                                                        endQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken))),
                                                                slashGreaterThanToken: SyntaxFactory.Token(
                                                                    leading: SyntaxFactory.TriviaList(SyntaxFactory.Space),
                                                                    kind: SyntaxKind.SlashGreaterThanToken,
                                                                    trailing: default)),
                                                            SyntaxFactory.XmlText(
                                                                textTokens: SyntaxFactory.TokenList(
                                                                    SyntaxFactory.XmlTextLiteral("."),
                                                                    SyntaxFactory.XmlTextNewLine(
                                                                        leading: default,
                                                                        text: "\r\n",
                                                                        value: "\r\n",
                                                                        trailing: default),
                                                                    SyntaxFactory.XmlTextLiteral(
                                                                        leading: SyntaxFactory.TriviaList(
                                                                            SyntaxFactory.DocumentationCommentExterior("    ///")),
                                                                        text: " This file is generated by Gu.Inject.Analyzers.",
                                                                        value: " This file is generated by Gu.Inject.Analyzers.",
                                                                        trailing: default),
                                                                    SyntaxFactory.XmlTextNewLine(
                                                                        leading: default,
                                                                        text: "\r\n",
                                                                        value: "\r\n",
                                                                        trailing: default),
                                                                    SyntaxFactory.XmlTextLiteral(
                                                                        leading: SyntaxFactory.TriviaList(
                                                                            SyntaxFactory.DocumentationCommentExterior("    ///")),
                                                                        text: " ",
                                                                        value: " ",
                                                                        trailing: default))),
                                                        }),
                                                    endTag: SyntaxFactory.XmlElementEndTag(
                                                        lessThanSlashToken: SyntaxFactory.Token(SyntaxKind.LessThanSlashToken),
                                                        name: SyntaxFactory.XmlName(
                                                            prefix: default,
                                                            localName: SyntaxFactory.Identifier(
                                                                leading: default,
                                                                text: "summary",
                                                                trailing: default)),
                                                        greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken))),
                                                SyntaxFactory.XmlText(
                                                    textTokens: SyntaxFactory.TokenList(
                                                        SyntaxFactory.XmlTextNewLine(
                                                            leading: default,
                                                            text: "\r\n",
                                                            value: "\r\n",
                                                            trailing: default))),
                                            }),
                                        endOfComment: SyntaxFactory.Token(SyntaxKind.EndOfDocumentationCommentToken))),
                                SyntaxFactory.Whitespace("    "),
                                SyntaxFactory.Comment("// <auto-generated/> "),
                                SyntaxFactory.LineFeed,
                                SyntaxFactory.Whitespace("    "));
            }
        }

        private static MethodDeclarationSyntax AutoBindMethod(SyntaxGenerator g, INamedTypeSymbol containerType, SemanticModel semanticModel, int position)
        {
            var rootType = (INamedTypeSymbol)containerType.TypeArguments[0];
            using (var bound = PooledSet<INamedTypeSymbol>.Borrow())
            {
                return SyntaxFactory.MethodDeclaration(
                    attributeLists: default,
                    modifiers: SyntaxFactory.TokenList(
                        SyntaxFactory.Token(
                            leading: Comment(),
                            kind: SyntaxKind.PublicKeyword,
                            trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Token(
                            leading: default,
                            kind: SyntaxKind.StaticKeyword,
                            trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space))),
                    returnType: (TypeSyntax)g.TypeExpression(containerType),
                    explicitInterfaceSpecifier: default,
                    identifier: SyntaxFactory.Identifier(
                        leading: default,
                        text: AutoBind,
                        trailing: default),
                    typeParameterList: default,
                    parameterList: SyntaxFactory.ParameterList(
                        openParenToken: SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                        parameters: SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                            SyntaxFactory.Parameter(
                                attributeLists: default,
                                modifiers: SyntaxFactory.TokenList(
                                    SyntaxFactory.Token(
                                        leading: default,
                                        kind: SyntaxKind.ThisKeyword,
                                        trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space))),
                                type: (TypeSyntax)g.TypeExpression(containerType),
                                identifier: SyntaxFactory.Identifier(
                                    leading: default,
                                    text: "container",
                                    trailing: default),
                                @default: default)),
                        closeParenToken: SyntaxFactory.Token(
                            leading: default,
                            kind: SyntaxKind.CloseParenToken,
                            trailing: SyntaxFactory.TriviaList(SyntaxFactory.LineFeed))),
                    constraintClauses: default,
                    body: default,
                    expressionBody: SyntaxFactory.ArrowExpressionClause(
                        Bind(SyntaxFactory.IdentifierName("container"), rootType)),
                    semicolonToken: SyntaxFactory.Token(SyntaxKind.SemicolonToken));

                ExpressionSyntax Bind(ExpressionSyntax e, INamedTypeSymbol type)
                {
                    if (bound.Add(type) &&
                        type.Constructors.TrySingle(x => !x.IsStatic, out var ctor))
                    {
                        if (!semanticModel.IsAccessible(position, ctor) ||
                            ctor.Parameters.Any(x => x.RefKind != RefKind.None ||
                                                     x.HasExplicitDefaultValue ||
                                                     !(x.Type is INamedTypeSymbol)))
                        {
                            return e;
                        }

                        e = (InvocationExpressionSyntax)g.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                e.WithTrailingTrivia(SyntaxFactory.ElasticEndOfLine("\n")),
                                SyntaxFactory.Token(SyntaxKind.DotToken).WithLeadingTrivia(SyntaxFactory.ElasticWhitespace("            ")),
                                SyntaxFactory.IdentifierName("Bind")),
                            Lambda());

                        foreach (var parameter in ctor.Parameters)
                        {
                            e = (InvocationExpressionSyntax)Bind(e, (INamedTypeSymbol)parameter.Type);
                        }

                        return e;

                        SyntaxNode Lambda()
                        {
                            if (ctor.Parameters.Length == 0)
                            {
                                return g.ValueReturningLambdaExpression(
                                    new[] { g.LambdaParameter("_") },
                                    g.ObjectCreationExpression(type));
                            }

                            return g.ValueReturningLambdaExpression(
                                new[] { g.LambdaParameter("x") },
                                g.ObjectCreationExpression(
                                    type,
                                    ctor.Parameters.Select(x =>
                                        g.InvocationExpression(
                                            g.MemberAccessExpression(
                                                SyntaxFactory.IdentifierName("x"),
                                                g.GenericName("Get", x.Type))))));
                        }
                    }

                    return e;
                }
            }

            SyntaxTriviaList Comment()
            {
                return SyntaxFactory.TriviaList(
                            SyntaxFactory.Whitespace("        "),
                            SyntaxFactory.Trivia(
                                SyntaxFactory.DocumentationCommentTrivia(
                                    kind: SyntaxKind.SingleLineDocumentationCommentTrivia,
                                    content: SyntaxFactory.List(
                                        new XmlNodeSyntax[]
                                        {
                                        SyntaxFactory.XmlText(
                                            textTokens: SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextLiteral(
                                                    leading: SyntaxFactory.TriviaList(
                                                        SyntaxFactory.DocumentationCommentExterior("///")),
                                                    text: " ",
                                                    value: " ",
                                                    trailing: default))),
                                        SyntaxFactory.XmlElement(
                                            startTag: SyntaxFactory.XmlElementStartTag(
                                                lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                name: SyntaxFactory.XmlName(
                                                    prefix: default,
                                                    localName: SyntaxFactory.Identifier(
                                                        leading: default,
                                                        text: "summary",
                                                        trailing: default)),
                                                attributes: default,
                                                greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken)),
                                            content: SyntaxFactory.List(
                                                new XmlNodeSyntax[]
                                                {
                                                    SyntaxFactory.XmlText(
                                                        textTokens: SyntaxFactory.TokenList(
                                                            SyntaxFactory.XmlTextNewLine(
                                                                leading: default,
                                                                text: "\r\n",
                                                                value: "\r\n",
                                                                trailing: default),
                                                            SyntaxFactory.XmlTextLiteral(
                                                                leading: SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                text: " Adds generated bindings for the graph where ",
                                                                value: " Adds generated bindings for the graph where ",
                                                                trailing: default))),
                                                    SyntaxFactory.XmlEmptyElement(
                                                        lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                        name: SyntaxFactory.XmlName(
                                                            prefix: default,
                                                            localName: SyntaxFactory.Identifier(
                                                                leading: default,
                                                                text: "see",
                                                                trailing: default)),
                                                        attributes: SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                            SyntaxFactory.XmlCrefAttribute(
                                                                name: SyntaxFactory.XmlName(
                                                                    prefix: default,
                                                                    localName: SyntaxFactory.Identifier(
                                                                        leading: SyntaxFactory.TriviaList(SyntaxFactory.Space),
                                                                        text: "cref",
                                                                        trailing: default)),
                                                                equalsToken: SyntaxFactory.Token(SyntaxKind.EqualsToken),
                                                                startQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                                cref: SyntaxFactory.TypeCref(g.CrefType(rootType)),
                                                                endQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken))),
                                                        slashGreaterThanToken: SyntaxFactory.Token(SyntaxKind.SlashGreaterThanToken)),
                                                    SyntaxFactory.XmlText(
                                                        textTokens: SyntaxFactory.TokenList(
                                                            SyntaxFactory.XmlTextLiteral(" is root."),
                                                            SyntaxFactory.XmlTextNewLine(
                                                                leading: default,
                                                                text: "\r\n",
                                                                value: "\r\n",
                                                                trailing: default),
                                                            SyntaxFactory.XmlTextLiteral(
                                                                leading: SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                text: " This method is generated by Gu.Inject.Analyzers.",
                                                                value: " This method is generated by Gu.Inject.Analyzers.",
                                                                trailing: default),
                                                            SyntaxFactory.XmlTextNewLine(
                                                                leading: default,
                                                                text: "\r\n",
                                                                value: "\r\n",
                                                                trailing: default),
                                                            SyntaxFactory.XmlTextLiteral(
                                                                leading: SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                text: " ",
                                                                value: " ",
                                                                trailing: default))),
                                                }),
                                            endTag: SyntaxFactory.XmlElementEndTag(
                                                lessThanSlashToken: SyntaxFactory.Token(SyntaxKind.LessThanSlashToken),
                                                name: SyntaxFactory.XmlName(
                                                    prefix: default,
                                                    localName: SyntaxFactory.Identifier(
                                                        leading: default,
                                                        text: "summary",
                                                        trailing: default)),
                                                greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken))),
                                        SyntaxFactory.XmlText(
                                            textTokens: SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextNewLine(
                                                    leading: default,
                                                    text: "\r\n",
                                                    value: "\r\n",
                                                    trailing: default),
                                                SyntaxFactory.XmlTextLiteral(
                                                    leading: SyntaxFactory.TriviaList(
                                                        SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                    text: " ",
                                                    value: " ",
                                                    trailing: default))),
                                        SyntaxFactory.XmlElement(
                                            startTag: SyntaxFactory.XmlElementStartTag(
                                                lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                name: SyntaxFactory.XmlName(
                                                    prefix: default,
                                                    localName: SyntaxFactory.Identifier(
                                                        leading: default,
                                                        text: "param",
                                                        trailing: default)),
                                                attributes: SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                    SyntaxFactory.XmlNameAttribute(
                                                        name: SyntaxFactory.XmlName(
                                                            prefix: default,
                                                            localName: SyntaxFactory.Identifier(
                                                                leading: SyntaxFactory.TriviaList(SyntaxFactory.Space),
                                                                text: "name",
                                                                trailing: default)),
                                                        equalsToken: SyntaxFactory.Token(SyntaxKind.EqualsToken),
                                                        startQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                        identifier: SyntaxFactory.IdentifierName(
                                                            identifier: SyntaxFactory.Identifier(
                                                                leading: default,
                                                                text: "container",
                                                                trailing: default)),
                                                        endQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken))),
                                                greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken)),
                                            content: SyntaxFactory.List(
                                                new XmlNodeSyntax[]
                                                {
                                                    SyntaxFactory.XmlText(
                                                        textTokens: SyntaxFactory.TokenList(
                                                            SyntaxFactory.XmlTextLiteral("The "))),
                                                    SyntaxFactory.XmlEmptyElement(
                                                        lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                        name: SyntaxFactory.XmlName(
                                                            prefix: default,
                                                            localName: SyntaxFactory.Identifier(
                                                                leading: default,
                                                                text: "see",
                                                                trailing: default)),
                                                        attributes: SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                            SyntaxFactory.XmlCrefAttribute(
                                                                name: SyntaxFactory.XmlName(
                                                                    prefix: default,
                                                                    localName: SyntaxFactory.Identifier(
                                                                        leading: SyntaxFactory.TriviaList(SyntaxFactory.Space),
                                                                        text: "cref",
                                                                        trailing: default)),
                                                                equalsToken: SyntaxFactory.Token(SyntaxKind.EqualsToken),
                                                                startQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                                cref: SyntaxFactory.TypeCref(g.CrefType(containerType)),
                                                                endQuoteToken: SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken))),
                                                        slashGreaterThanToken: SyntaxFactory.Token(SyntaxKind.SlashGreaterThanToken)),
                                                    SyntaxFactory.XmlText(
                                                        textTokens: SyntaxFactory.TokenList(
                                                            SyntaxFactory.XmlTextLiteral("."))),
                                                }),
                                            endTag: SyntaxFactory.XmlElementEndTag(
                                                lessThanSlashToken: SyntaxFactory.Token(SyntaxKind.LessThanSlashToken),
                                                name: SyntaxFactory.XmlName(
                                                    prefix: default,
                                                    localName: SyntaxFactory.Identifier(
                                                        leading: default,
                                                        text: "param",
                                                        trailing: default)),
                                                greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken))),
                                        SyntaxFactory.XmlText(
                                            textTokens: SyntaxFactory.TokenList(
                                                SyntaxFactory.XmlTextNewLine(
                                                    leading: default,
                                                    text: "\r\n",
                                                    value: "\r\n",
                                                    trailing: default))),
                                        }),
                                    endOfComment: SyntaxFactory.Token(SyntaxKind.EndOfDocumentationCommentToken))),
                            SyntaxFactory.Whitespace("        "));
            }
        }
    }
}
