namespace Gu.Inject.Analyzers
{
    using System;
    using System.Collections.Generic;
    using Gu.Roslyn.AnalyzerExtensions;
    using Gu.Roslyn.AnalyzerExtensions.StyleCopComparers;
    using Gu.Roslyn.CodeFixExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [Obsolete("Temporary, will be in Gu.Roslyn.Extensions #45")]
    public static class CompilationUintSyntaxExtensions
    {
        public static CompilationUnitSyntax AddUsing(this CompilationUnitSyntax compilationUnit, ITypeSymbol type, SemanticModel semanticModel)
        {
            if (compilationUnit == null)
            {
                throw new System.ArgumentNullException(nameof(compilationUnit));
            }

            if (type == null)
            {
                throw new System.ArgumentNullException(nameof(type));
            }

            if (semanticModel == null)
            {
                throw new System.ArgumentNullException(nameof(semanticModel));
            }

            return AddUsing(compilationUnit, SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(type.ContainingNamespace.ToDisplayString())), semanticModel);
        }

        public static CompilationUnitSyntax AddUsing(this CompilationUnitSyntax compilationUnit, UsingDirectiveSyntax usingDirective, SemanticModel semanticModel)
        {
            if (compilationUnit == null)
            {
                throw new System.ArgumentNullException(nameof(compilationUnit));
            }

            if (semanticModel == null)
            {
                throw new System.ArgumentNullException(nameof(semanticModel));
            }

            if (usingDirective == null)
            {
                throw new System.ArgumentNullException(nameof(usingDirective));
            }

            if (compilationUnit.Members.TrySingleOfType(out NamespaceDeclarationSyntax ns) &&
                IsSameOrContained(ns, usingDirective))
            {
                return compilationUnit;
            }

            using (var walker = UsingDirectiveWalker.Borrow(compilationUnit))
            {
                if (walker.UsingDirectives.Count == 0)
                {
                    if (walker.NamespaceDeclarations.TryFirst(out var namespaceDeclaration))
                    {
                        if (CodeStyle.UsingDirectivesInsideNamespace(semanticModel))
                        {
                            return compilationUnit.ReplaceNode(namespaceDeclaration, namespaceDeclaration.WithUsings(SyntaxFactory.SingletonList(usingDirective)));
                        }

                        return compilationUnit.ReplaceNode(compilationUnit, compilationUnit.WithUsings(SyntaxFactory.SingletonList(usingDirective)));
                    }

                    return compilationUnit;
                }

                UsingDirectiveSyntax previous = null;
                foreach (var directive in walker.UsingDirectives)
                {
                    var compare = UsingDirectiveComparer.Compare(directive, usingDirective);
                    if (compare == 0)
                    {
                        return compilationUnit;
                    }

                    if (compare > 0)
                    {
                        return compilationUnit.InsertNodesBefore(directive, new[] { usingDirective.WithTrailingElasticLineFeed() });
                    }

                    previous = directive;
                }

                return compilationUnit.InsertNodesAfter(previous, new[] { usingDirective.WithTrailingElasticLineFeed() });
            }
        }

        private static bool IsSameOrContained(NamespaceDeclarationSyntax namespaceDeclaration, UsingDirectiveSyntax usingDirective)
        {
            var ns = namespaceDeclaration.Name.ToString();
            var us = usingDirective.Name.ToString();
            if (ns == us)
            {
                return true;
            }

            return ns.Length > us.Length &&
                   ns.StartsWith(us, StringComparison.Ordinal) &&
                   ns[us.Length] == '.';
        }

        private sealed class UsingDirectiveWalker : PooledWalker<UsingDirectiveWalker>
        {
            private readonly List<UsingDirectiveSyntax> usingDirectives = new List<UsingDirectiveSyntax>();
            private readonly List<NamespaceDeclarationSyntax> namespaceDeclarations = new List<NamespaceDeclarationSyntax>();

            public IReadOnlyList<UsingDirectiveSyntax> UsingDirectives => this.usingDirectives;

            public IReadOnlyList<NamespaceDeclarationSyntax> NamespaceDeclarations => this.namespaceDeclarations;

            public static UsingDirectiveWalker Borrow(CompilationUnitSyntax compilationUnit) => BorrowAndVisit(compilationUnit, () => new UsingDirectiveWalker());

            public override void VisitUsingDirective(UsingDirectiveSyntax node)
            {
                this.usingDirectives.Add(node);
            }

            public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
            {
                this.namespaceDeclarations.Add(node);
                base.VisitNamespaceDeclaration(node);
            }

            public override void VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                // Stop walking here
            }

            public override void VisitStructDeclaration(StructDeclarationSyntax node)
            {
                // Stop walking here
            }

            protected override void Clear()
            {
                this.usingDirectives.Clear();
                this.namespaceDeclarations.Clear();
            }
        }
    }
}
