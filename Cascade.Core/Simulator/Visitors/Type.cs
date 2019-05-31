using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitArrayType(ArrayTypeSyntax node)
        {
            node.ElementType?.Accept<Evaluation>(this);
            foreach (ArrayRankSpecifierSyntax rankSpecifier in node.RankSpecifiers)
            {
                rankSpecifier.Accept<Evaluation>(this);
            }

            return base.VisitArrayType(node);
        }

        public override Evaluation VisitNullableType(NullableTypeSyntax node)
        {
            node.ElementType?.Accept<Evaluation>(this);

            return base.VisitNullableType(node);
        }

        public override Evaluation VisitPointerType(PointerTypeSyntax node)
        {
            node.ElementType?.Accept<Evaluation>(this);

            return base.VisitPointerType(node);
        }

        public override Evaluation VisitPredefinedType(PredefinedTypeSyntax node)
        {
            return base.VisitPredefinedType(node);
        }

        public override Evaluation VisitRefType(RefTypeSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitRefType(node);
        }

        public override Evaluation VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitSimpleBaseType(node);
        }

        public override Evaluation VisitTupleType(TupleTypeSyntax node)
        {
            foreach (TupleElementSyntax elementSyntax in node.Elements)
            {
                elementSyntax.Accept<Evaluation>(this);
            }

            return base.VisitTupleType(node);
        }
    }
}
