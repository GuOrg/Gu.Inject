namespace Gu.Inject.Analyzers
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading;
    using Gu.Roslyn.AnalyzerExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class Binding
    {
        internal static PooledDictionary<INamedTypeSymbol, ImmutableArray<InvocationExpressionSyntax>> FindBindings(ObjectCreationExpressionSyntax containerCreation, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            var map = PooledDictionary<INamedTypeSymbol, ImmutableArray<InvocationExpressionSyntax>>.Borrow();
            if (containerCreation.TryFirstAncestor(out MemberDeclarationSyntax member))
            {
                using (var walker = BindingWalker.Borrow(member, semanticModel, cancellationToken))
                {
                    foreach (var invocation in walker.Invocations)
                    {
                        if (invocation.ArgumentList is ArgumentListSyntax argumentList &&
                            argumentList.Arguments.TrySingle(out var argument) &&
                            semanticModel.TryGetSymbol(argument.Expression, cancellationToken, out IMethodSymbol lambdaType) &&
                            lambdaType.ReturnType is INamedTypeSymbol returnType &&
                            returnType.TypeKind != TypeKind.Error)
                        {
                            if (map.TryGetValue(returnType, out var bindings))
                            {
                                map[returnType] = bindings.Add(invocation);
                            }
                            else
                            {
                                map[returnType] = ImmutableArray.Create(invocation);
                            }
                        }
                    }
                }
            }

            return map;
        }

        internal static PooledSet<INamedTypeSymbol> Graph(INamedTypeSymbol root, SemanticModel semanticModel, int position)
        {
            var set = PooledSet<INamedTypeSymbol>.Borrow();
            if (root.TypeKind != TypeKind.Error)
            {
                set.Add(root);
                AddRecursive(root);
            }

            return set;

            void AddRecursive(INamedTypeSymbol type)
            {
                if (TryGetMember(type, semanticModel, position, out var member) &&
                    member is IMethodSymbol method)
                {
                    foreach (var parameter in method.Parameters)
                    {
                        var parameterType = (INamedTypeSymbol)parameter.Type;
                        if (parameterType.TypeKind != TypeKind.Error)
                        {
                            set.Add(parameterType);
                            AddRecursive(parameterType);
                        }
                    }
                }
            }
        }

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

        internal sealed class BindingWalker : ExecutionWalker<BindingWalker>
        {
            private readonly List<InvocationExpressionSyntax> invocations = new List<InvocationExpressionSyntax>();

            private BindingWalker()
            {
            }

            /// <summary>
            /// Gets the <see cref="InvocationExpressionSyntax"/>s found in the scope.
            /// </summary>
            public IReadOnlyList<InvocationExpressionSyntax> Invocations => this.invocations;

            /// <summary>
            /// Get a walker that has visited <paramref name="node"/>.
            /// </summary>
            /// <param name="node">The node.</param>
            /// <param name="semanticModel">The <see cref="SemanticModel"/>.</param>
            /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
            /// <returns>A walker that has visited <paramref name="node"/>.</returns>
            public static BindingWalker Borrow(SyntaxNode node, SemanticModel semanticModel, CancellationToken cancellationToken)
            {
                return BorrowAndVisit(node, Scope.Recursive, semanticModel, cancellationToken, () => new BindingWalker());
            }

            public override void VisitInvocationExpression(InvocationExpressionSyntax node)
            {
                if (node.TryGetMethodName(out var name) &&
                    name == "Bind" &&
                    this.SemanticModel.TryGetSymbol(node, this.CancellationToken, out var candidate) &&
                    candidate.ContainingType == KnownSymbol.ContainerOfT)
                {
                    this.invocations.Add(node);
                }
                else
                {
                    base.VisitInvocationExpression(node);
                }
            }

            /// <inheritdoc />
            protected override void Clear()
            {
                this.invocations.Clear();
                base.Clear();
            }
        }
    }
}