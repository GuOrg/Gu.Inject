namespace Gu.Inject.Analyzers.CodeFixes
{
    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Threading.Tasks;
    using Gu.Roslyn.CodeFixExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Editing;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(BindFix))]
    [Shared]
    public class BindFix : DocumentEditorCodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
            GuInj001MissingBinding.DiagnosticId);

        protected override async Task RegisterCodeFixesAsync(DocumentEditorCodeFixContext context)
        {
            var syntaxRoot = await context.Document.GetSyntaxRootAsync(context.CancellationToken)
                                          .ConfigureAwait(false);
            var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken)
                                             .ConfigureAwait(false);
            foreach (var diagnostic in context.Diagnostics)
            {
                if (syntaxRoot.TryFindNode(diagnostic, out ObjectCreationExpressionSyntax containerCreation) &&
                    diagnostic.Properties.TryGetValue(nameof(INamedTypeSymbol), out var typeName) &&
                    semanticModel.Compilation.GetTypeByMetadataName(typeName) is INamedTypeSymbol type &&
                    Binding.TryGetMember(type, semanticModel, containerCreation.SpanStart, out var member))
                {
                    context.RegisterCodeFix(
                        "Generate binding.",
                        (editor, cancellationToken) => editor.ReplaceNode(
                                                 containerCreation,
                                                 x => Bind(x, member, editor)),
                        nameof(BindFix),
                        diagnostic);
                }
            }
        }

        private static ExpressionSyntax Bind(ExpressionSyntax e, ISymbol member, DocumentEditor editor)
        {
            if (TryCreateLambda(out var lambda))
            {
                return SyntaxFactory.InvocationExpression(
                    expression: SyntaxFactory.MemberAccessExpression(
                        kind: SyntaxKind.SimpleMemberAccessExpression,
                        expression: e,
                        operatorToken: SyntaxFactory.Token(
                            leading: SyntaxFactory.TriviaList(SyntaxFactory.ElasticLineFeed, SyntaxFactory.Whitespace("                ")),
                            kind: SyntaxKind.DotToken,
                            trailing: default),
                        name: SyntaxFactory.IdentifierName(
                            identifier: SyntaxFactory.Identifier(
                                leading: default,
                                text: "Bind",
                                trailing: default))),
                    argumentList: SyntaxFactory.ArgumentList(
                        openParenToken: SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                        arguments: SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(
                                nameColon: default,
                                refOrOutKeyword: default,
                                expression: lambda)),
                        closeParenToken: SyntaxFactory.Token(SyntaxKind.CloseParenToken)));
            }

            return e;

            bool TryCreateLambda(out ExpressionSyntax result)
            {
                switch (member)
                {
                    case IMethodSymbol ctor when ctor.MethodKind == MethodKind.Constructor:
                        if (ctor.Parameters.Length == 0)
                        {
                            result = SyntaxFactory.ParenthesizedLambdaExpression(
                                asyncKeyword: default,
                                parameterList: EmptyParameterList(),
                                arrowToken: Arrow(),
                                body: SyntaxFactory.ObjectCreationExpression(
                                    newKeyword: SyntaxFactory.Token(
                                        leading: default,
                                        kind: SyntaxKind.NewKeyword,
                                        trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                                    type: (TypeSyntax)editor.Generator.TypeExpression(ctor.ContainingType),
                                    argumentList: EmptyArgumentList(),
                                    initializer: default));
                            return true;
                        }

                        result = SyntaxFactory.SimpleLambdaExpression(
                            asyncKeyword: default,
                            parameter: Parameter(),
                            arrowToken: Arrow(),
                            body: SyntaxFactory.ObjectCreationExpression(
                                newKeyword: SyntaxFactory.Token(
                                    leading: default,
                                    kind: SyntaxKind.NewKeyword,
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                                type: (TypeSyntax)editor.Generator.TypeExpression(ctor.ContainingType),
                                argumentList: ArgumentList(ctor.Parameters),
                                initializer: default));
                        return true;
                    case IMethodSymbol factory when factory.MethodKind == MethodKind.Ordinary:
                        if (factory.Parameters.Length == 0)
                        {
                            result = SyntaxFactory.ParenthesizedLambdaExpression(
                                asyncKeyword: default,
                                parameterList: EmptyParameterList(),
                                arrowToken: Arrow(),
                                body: SyntaxFactory.InvocationExpression(
                                    expression: SyntaxFactory.MemberAccessExpression(
                                        kind: SyntaxKind.SimpleMemberAccessExpression,
                                        expression: (ExpressionSyntax)editor.Generator.TypeExpression(member.ContainingType),
                                        operatorToken: SyntaxFactory.Token(SyntaxKind.DotToken),
                                        name: SyntaxFactory.IdentifierName(
                                            identifier: SyntaxFactory.Identifier(
                                                leading: default,
                                                text: member.Name,
                                                trailing: default))),
                                    argumentList: EmptyArgumentList()));
                            return true;
                        }

                        result = SyntaxFactory.SimpleLambdaExpression(
                            asyncKeyword: default,
                            parameter: Parameter(),
                            arrowToken: Arrow(),
                            body: SyntaxFactory.InvocationExpression(
                                expression: SyntaxFactory.MemberAccessExpression(
                                    kind: SyntaxKind.SimpleMemberAccessExpression,
                                    expression: (ExpressionSyntax)editor.Generator.TypeExpression(member.ContainingType),
                                    operatorToken: SyntaxFactory.Token(SyntaxKind.DotToken),
                                    name: SyntaxFactory.IdentifierName(
                                        identifier: SyntaxFactory.Identifier(
                                            leading: default,
                                            text: member.Name,
                                            trailing: default))),
                                argumentList: ArgumentList(factory.Parameters)));
                        return true;

                    case IFieldSymbol _:
                    case IPropertySymbol _:
                        result = SyntaxFactory.ParenthesizedLambdaExpression(
                            asyncKeyword: default,
                            parameterList: EmptyParameterList(),
                            arrowToken: Arrow(),
                            body: SyntaxFactory.MemberAccessExpression(
                                kind: SyntaxKind.SimpleMemberAccessExpression,
                                expression: (ExpressionSyntax)editor.Generator.TypeExpression(member.ContainingType),
                                operatorToken: SyntaxFactory.Token(SyntaxKind.DotToken),
                                name: SyntaxFactory.IdentifierName(
                                    identifier: SyntaxFactory.Identifier(
                                        leading: default,
                                        text: member.Name,
                                        trailing: default))));
                        return true;

                        SyntaxToken Arrow()
                        {
                            return SyntaxFactory.Token(
                                leading: default,
                                kind: SyntaxKind.EqualsGreaterThanToken,
                                trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space));
                        }

                        ParameterSyntax Parameter()
                        {
                            return SyntaxFactory.Parameter(
                                attributeLists: default,
                                modifiers: default,
                                type: default,
                                identifier: SyntaxFactory.Identifier(
                                    leading: default,
                                    text: "x",
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)),
                                @default: default);
                        }

                        ParameterListSyntax EmptyParameterList()
                        {
                            return SyntaxFactory.ParameterList(
                                openParenToken: SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                                parameters: default,
                                closeParenToken: SyntaxFactory.Token(
                                    leading: default,
                                    kind: SyntaxKind.CloseParenToken,
                                    trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)));
                        }

                        ArgumentListSyntax EmptyArgumentList()
                        {
                            return SyntaxFactory.ArgumentList(
                                openParenToken: SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                                arguments: default,
                                closeParenToken: SyntaxFactory.Token(SyntaxKind.CloseParenToken));
                        }

                        ArgumentListSyntax ArgumentList(ImmutableArray<IParameterSymbol> parameters)
                        {
                            return SyntaxFactory.ArgumentList(
                                openParenToken: SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                                arguments: SyntaxFactory.SeparatedList(
                                    parameters.Select(CreateArgument),
                                    parameters.Skip(1).Select(_ => SyntaxFactory.Token(leading: default, kind: SyntaxKind.CommaToken, trailing: SyntaxFactory.TriviaList(SyntaxFactory.Space)))),
                                closeParenToken: SyntaxFactory.Token(SyntaxKind.CloseParenToken));

                            ArgumentSyntax CreateArgument(IParameterSymbol parameter)
                            {
                                return SyntaxFactory.Argument(
                                    nameColon: default,
                                    refOrOutKeyword: default,
                                    expression: SyntaxFactory.InvocationExpression(
                                        expression: SyntaxFactory.MemberAccessExpression(
                                            kind: SyntaxKind.SimpleMemberAccessExpression,
                                            expression: SyntaxFactory.IdentifierName(
                                                identifier: SyntaxFactory.Identifier(
                                                    leading: default,
                                                    text: "x",
                                                    trailing: default)),
                                            operatorToken: SyntaxFactory.Token(SyntaxKind.DotToken),
                                            name: SyntaxFactory.GenericName(
                                                identifier: SyntaxFactory.Identifier(
                                                    leading: default,
                                                    text: "Get",
                                                    trailing: default),
                                                typeArgumentList: SyntaxFactory.TypeArgumentList(
                                                    lessThanToken: SyntaxFactory.Token(SyntaxKind.LessThanToken),
                                                    arguments: SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                        (TypeSyntax)editor.Generator.TypeExpression(parameter.Type)),
                                                    greaterThanToken: SyntaxFactory.Token(SyntaxKind.GreaterThanToken)))),
                                        argumentList: EmptyArgumentList()));
                            }
                        }
                }

                result = null;
                return false;
            }
        }
    }
}
