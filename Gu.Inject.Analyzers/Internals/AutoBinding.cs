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

            return type.TryFindSingleMember(x => IsMatch(x), out member);

            bool IsMatch(ISymbol candidate)
            {
                if (!candidate.IsStatic ||
                    !semanticModel.IsAccessible(position, candidate))
                {
                    return false;
                }

                if (FieldOrProperty.TryCreate(candidate, out var fieldOrProperty))
                {
                    return Equals(fieldOrProperty.Type, type);
                }

                if (candidate is IMethodSymbol method &&
                        method.MethodKind == MethodKind.Ordinary &&
                        Equals(method.ReturnType, type) &&
                        !method.Parameters.Any(x => x.IsOptional || x.IsParams || x.RefKind != RefKind.None))
                {
                    return true;
                }

                return false;
            }
        }
    }
}