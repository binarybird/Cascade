using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            node.Expression?.Accept(this);
           
            base.VisitArrowExpressionClause(node);
        }

        public override void VisitCatchClause(CatchClauseSyntax node)
        {
            node.Declaration?.Accept(this);
            node.Filter?.Accept(this);
            node.Block?.Accept(this);

            base.VisitCatchClause(node);
        }

        public override void VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            node.FilterExpression?.Accept(this);
            
            base.VisitCatchFilterClause(node);
        }

        public override void VisitElseClause(ElseClauseSyntax node)
        {
            node.Statement?.Accept(this);

            base.VisitElseClause(node);
        }

        public override void VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            node.Value?.Accept(this);

            base.VisitEqualsValueClause(node);
        }

        public override void VisitFinallyClause(FinallyClauseSyntax node)
        {
            node.Block?.Accept(this);

            base.VisitFinallyClause(node);
        }

        public override void VisitFromClause(FromClauseSyntax node)
        {
            node.Type?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitFromClause(node);
        }

        public override void VisitGroupClause(GroupClauseSyntax node)
        {
            node.ByExpression?.Accept(this);
            node.GroupExpression?.Accept(this);

            base.VisitGroupClause(node);
        }

        public override void VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node)
        {
            node.Value?.Accept(this);

            base.VisitInterpolationAlignmentClause(node);
        }

        public override void VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node)
        {
            base.VisitInterpolationFormatClause(node);
        }

        public override void VisitJoinClause(JoinClauseSyntax node)
        {
            node.InExpression?.Accept(this);
            node.Into?.Accept(this);
            node.LeftExpression?.Accept(this);
            node.RightExpression?.Accept(this);
            node.Type?.Accept(this);

            base.VisitJoinClause(node);
        }

        public override void VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            base.VisitJoinIntoClause(node);
        }

        public override void VisitLetClause(LetClauseSyntax node)
        {
            node.Expression?.Accept(this);
            base.VisitLetClause(node);
        }

        public override void VisitOrderByClause(OrderByClauseSyntax node)
        {
            foreach (OrderingSyntax ordering in node.Orderings)
            {
                ordering.Accept(this);
            }

            base.VisitOrderByClause(node);
        }

        public override void VisitSelectClause(SelectClauseSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitSelectClause(node);
        }

        public override void VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            foreach (TypeParameterConstraintSyntax constraint in node.Constraints)
            {
                constraint.Accept(this);
            }

            node.Name?.Accept(this);
            
            base.VisitTypeParameterConstraintClause(node);
        }

        public override void VisitWhenClause(WhenClauseSyntax node)
        {
            node.Condition?.Accept(this);

            base.VisitWhenClause(node);
        }

        public override void VisitWhereClause(WhereClauseSyntax node)
        {
            node.Condition?.Accept(this);

            base.VisitWhereClause(node);
        }
    }
}
