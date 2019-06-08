using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Extensions
{
    public static class RoslynExtensions
    {
        public static SymbolDisplayFormat TYPE_FMT = new SymbolDisplayFormat(
            memberOptions: SymbolDisplayMemberOptions.IncludeContainingType | SymbolDisplayMemberOptions.IncludeType,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        public static ICollection<SyntaxReference> GetDeclaringReferences(this SyntaxReference reference,
            Compilation compilation, CancellationToken cancellationToken = default(CancellationToken))
        {
            return reference.GetSyntax(cancellationToken)?.GetDeclaringReferences(compilation);
        }

        public static ICollection<SyntaxReference> GetDeclaringReferences(this SyntaxNode node, Compilation compilation)
        {
            ISymbol declaringSymbol = node.GetDeclaringSymbol(compilation);
            return declaringSymbol?.DeclaringSyntaxReferences ?? ImmutableArray<SyntaxReference>.Empty;
        }

        public static ISymbol GetDeclaringSymbol(this SyntaxReference reference, Compilation compilation,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return reference.GetSyntax(cancellationToken)?.GetDeclaringSymbol(compilation);
        }

        public static ISymbol GetDeclaringSymbol(this SyntaxNode node, Compilation compilation)
        {
            return compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
        }

        public static SymbolInfo GetSymbolInfo(this SyntaxReference reference, Compilation compilation,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return reference.GetSyntax(cancellationToken)?.GetSymbolInfo(compilation) ?? default(SymbolInfo);
        }

        public static SymbolInfo GetSymbolInfo(this SyntaxNode node, Compilation compilation)
        {
            return compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node);
        }

        public static ISymbol GetSymbol(this SyntaxReference reference, Compilation compilation)
        {
            return reference.GetSyntax().GetSymbol(compilation);
        }

        public static ISymbol GetSymbol(this SyntaxNode node, Compilation compilation)
        {
            ISymbol symb = node.GetDeclaringSymbol(compilation);
            if (symb == null)
            {
                symb = node.GetSymbolInfo(compilation).Symbol;
            }

            return symb;
        }

        public static bool IsEqual(this SyntaxReference reference, SyntaxReference other)
        {
            if (other == null)
            {
                return false;
            }

            if (reference.Span != other.Span)
            {
                return false;
            }

            return reference.GetSyntax().Equals(other.GetSyntax());
        }

        public static SyntaxNode GetContext(this SyntaxNode node, Type type)
        {
            SyntaxNode idx = node;
            while (idx != null)
            {
                if (idx.GetType() == type)
                {
                    return idx;
                }

                idx = idx.Parent;
            }

            return null;
        }
    }
}