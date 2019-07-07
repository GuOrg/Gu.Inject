namespace Gu.Inject.Analyzers
{
    using System;
    using System.Threading;
    using Gu.Roslyn.AnalyzerExtensions;
    using Microsoft.CodeAnalysis;

    [Obsolete("Temporary, will be in Gu.Roslyn.Extensions #45")]
    public static class SemanticModelExt
    {
        [Obsolete("Temporary, will be in Gu.Roslyn.Extensions #48")]
        public static bool TryGetNamedType(this SemanticModel semanticModel, SyntaxNode node, CancellationToken cancellationToken, out INamedTypeSymbol namedType)
        {
            if (semanticModel.TryGetType(node, cancellationToken, out var candidate))
            {
                namedType = candidate as INamedTypeSymbol;
                return namedType != null;

            }

            namedType = null;
            return false;
        }
    }
}