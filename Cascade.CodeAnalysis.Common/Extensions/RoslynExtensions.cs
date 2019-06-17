using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Cascade.CodeAnalysis.Common.Extensions
{
    public static class RoslynExtensions
    {
        public static SymbolDisplayFormat TYPE_FMT = new SymbolDisplayFormat(
            memberOptions: SymbolDisplayMemberOptions.IncludeContainingType | SymbolDisplayMemberOptions.IncludeType,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        public static Node<Evaluation>.Kind NodeKind(this ISymbol symb)
        {
            if (symb is ILocalSymbol local)
            {
                return Node<Evaluation>.Kind.LocalVariable;
            }
            else if (symb is IFieldSymbol field)
            {
                return Node<Evaluation>.Kind.Field;
            }
            else if (symb is IPropertySymbol prop)
            {
                return Node<Evaluation>.Kind.Property;
            }
            else if (symb is IParameterSymbol param)
            {
                return Node<Evaluation>.Kind.LocalVariable;
            }
            else if (symb is ITypeSymbol type)
            { 
                return Node<Evaluation>.Kind.Class;
            }
            else if (symb is IMethodSymbol meth)
            {
                return Node<Evaluation>.Kind.Functional;
            }
            else
            {
                throw new Exception("Unhandled symbol type");
            }
        }

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