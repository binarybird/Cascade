using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);
           
            return base.VisitArrowExpressionClause(node);
        }

        public override Evaluation VisitCatchClause(CatchClauseSyntax node)
        {
            node.Declaration?.Accept<Evaluation>(this);
            node.Filter?.Accept<Evaluation>(this);
            node.Block?.Accept<Evaluation>(this);

            return base.VisitCatchClause(node);
        }

        public override Evaluation VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            node.FilterExpression?.Accept<Evaluation>(this);
            
            return base.VisitCatchFilterClause(node);
        }

        public override Evaluation VisitElseClause(ElseClauseSyntax node)
        {
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitElseClause(node);
        }

        public override Evaluation VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            return node.Value?.Accept<Evaluation>(this);
        }

        public override Evaluation VisitFinallyClause(FinallyClauseSyntax node)
        {
            node.Block?.Accept<Evaluation>(this);

            return base.VisitFinallyClause(node);
        }

        public override Evaluation VisitFromClause(FromClauseSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitFromClause(node);
        }

        public override Evaluation VisitGroupClause(GroupClauseSyntax node)
        {
            node.ByExpression?.Accept<Evaluation>(this);
            node.GroupExpression?.Accept<Evaluation>(this);

            return base.VisitGroupClause(node);
        }

        public override Evaluation VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node)
        {
            node.Value?.Accept<Evaluation>(this);

            return base.VisitInterpolationAlignmentClause(node);
        }

        public override Evaluation VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node)
        {
            return base.VisitInterpolationFormatClause(node);
        }

        public override Evaluation VisitJoinClause(JoinClauseSyntax node)
        {
            node.InExpression?.Accept<Evaluation>(this);
            node.Into?.Accept<Evaluation>(this);
            node.LeftExpression?.Accept<Evaluation>(this);
            node.RightExpression?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitJoinClause(node);
        }

        public override Evaluation VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            return base.VisitJoinIntoClause(node);
        }

        public override Evaluation VisitLetClause(LetClauseSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);
            return base.VisitLetClause(node);
        }

        public override Evaluation VisitOrderByClause(OrderByClauseSyntax node)
        {
            foreach (OrderingSyntax ordering in node.Orderings)
            {
                ordering.Accept<Evaluation>(this);
            }

            return base.VisitOrderByClause(node);
        }

        public override Evaluation VisitSelectClause(SelectClauseSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitSelectClause(node);
        }

        public override Evaluation VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            foreach (TypeParameterConstraintSyntax constraint in node.Constraints)
            {
                constraint.Accept<Evaluation>(this);
            }

            node.Name?.Accept<Evaluation>(this);
            
            return base.VisitTypeParameterConstraintClause(node);
        }

        public override Evaluation VisitWhenClause(WhenClauseSyntax node)
        {
            node.Condition?.Accept<Evaluation>(this);

            return base.VisitWhenClause(node);
        }

        public override Evaluation VisitWhereClause(WhereClauseSyntax node)
        {
            node.Condition?.Accept<Evaluation>(this);

            return base.VisitWhereClause(node);
        }
    }
}
