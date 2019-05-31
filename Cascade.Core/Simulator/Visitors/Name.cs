using Cascade.Common.Extensions;
using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            node.Alias?.Accept<Evaluation>(this);
            node.Name?.Accept<Evaluation>(this);

            return base.VisitAliasQualifiedName(node);
        }

        public override Evaluation VisitGenericName(GenericNameSyntax node)
        {
            node.TypeArgumentList?.Accept<Evaluation>(this);

            return base.VisitGenericName(node);
        }

        public override Evaluation VisitIdentifierName(IdentifierNameSyntax node)
        {
            ISymbol info = node.GetSymbolInfo(_comp).Symbol;
            return new Identity(_callStack.Peek(), info, node.Identifier.ValueText);
        }

        public override Evaluation VisitNameColon(NameColonSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitNameColon(node);
        }

        public override Evaluation VisitNameEquals(NameEqualsSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitNameEquals(node);
        }

        public override Evaluation VisitQualifiedName(QualifiedNameSyntax node)
        {
            node.Right?.Accept<Evaluation>(this);
            node.Left?.Accept<Evaluation>(this);

            return base.VisitQualifiedName(node);
        }
    }
}
