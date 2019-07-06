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
                if (ctor.Parameters.All(x => Injectable(x)) &&
                    semanticModel.IsAccessible(position, ctor))
                {
                    member = ctor;
                    return true;
                }

                member = null;
                return false;
            }

            return type.TryFindSingleMember(x => IsMatch(x), out member);

            bool IsMatch(ISymbol candidate)
            {
                if (candidate.IsStatic &&
                    semanticModel.IsAccessible(position, candidate))
                {
                    if (FieldOrProperty.TryCreate(candidate, out var fieldOrProperty))
                    {
                        return Equals(fieldOrProperty.Type, type);
                    }

                    if (candidate is IMethodSymbol method &&
                        method.MethodKind == MethodKind.Ordinary &&
                        Equals(method.ReturnType, type) &&
                        method.Parameters.All(x => Injectable(x)))
                    {
                        return true;
                    }
                }

                return false;
            }

            bool Injectable(IParameterSymbol parameter)
            {
                if (parameter.Type is INamedTypeSymbol)
                {
                    return parameter.Type.IsReferenceType &&
                           !parameter.IsOptional &&
                           !parameter.IsParams &&
                           parameter.RefKind == RefKind.None;
                }

                return false;
            }
        }
    }
}