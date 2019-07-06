namespace Gu.Inject.Analyzers
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Editing;

    public static class SyntaxGeneratorExtensions
    {
        public static TypeSyntax CrefType(this SyntaxGenerator g, ITypeSymbol type)
        {
            return GenericCrefRewriter.Update((TypeSyntax)g.TypeExpression(type));
        }

        private class GenericCrefRewriter : CSharpSyntaxRewriter
        {
            private static readonly GenericCrefRewriter Default = new GenericCrefRewriter();

            public static TypeSyntax Update(TypeSyntax node) => (TypeSyntax)Default.Visit(node);

            public override SyntaxNode VisitTypeArgumentList(TypeArgumentListSyntax node)
            {
                return base.VisitTypeArgumentList(node)
                           .ReplaceTokens(
                               new[] { node.LessThanToken, node.GreaterThanToken },
                               (x, _) => Replace(x));

                SyntaxToken Replace(SyntaxToken old)
                {
                    switch (old.Kind())
                    {
                        case SyntaxKind.GreaterThanToken:
                            return SyntaxFactory.Token(
                                leading: old.LeadingTrivia,
                                kind: SyntaxKind.GreaterThanToken,
                                text: "}",
                                valueText: ">",
                                trailing: old.TrailingTrivia);

                        case SyntaxKind.LessThanToken:
                            return SyntaxFactory.Token(
                                leading: old.LeadingTrivia,
                                kind: SyntaxKind.LessThanToken,
                                text: "{",
                                valueText: "<",
                                trailing: old.TrailingTrivia);
                        default:
                            throw new InvalidOperationException("Not getting here.");
                    }
                }
            }
        }
    }
}
