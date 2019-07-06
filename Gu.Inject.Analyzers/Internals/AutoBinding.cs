namespace Gu.Inject.Analyzers
{
    using System.Linq;
    using Gu.Roslyn.AnalyzerExtensions;
    using Microsoft.CodeAnalysis;

    internal static class AutoBinding
    {
        internal static bool TryGetMember(INamedTypeSymbol type, SemanticModel semanticModel, int position, out ISymbol member)
        {
            if (type == null)
            {
                member = null;
                return false;
            }

            if (type.Constructors.TrySingle(x => !x.IsStatic, out var ctor))
            {
                if (ctor.Parameters.Any(x => x.RefKind != RefKind.None ||
                                             x.HasExplicitDefaultValue ||
                                             !(x.Type is INamedTypeSymbol)))
                {
                    member = null;
                    return false;
                }

                if (semanticModel.IsAccessible(position, ctor))
                {
                    member = ctor;
                    return true;
                }
            }

            member = null;
            return false;
        }
    }
}