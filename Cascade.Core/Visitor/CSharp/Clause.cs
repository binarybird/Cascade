using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);
           
            base.VisitArrowExpressionClause(node);
            
            PostVisit(node);
        }

        public override void VisitCatchClause(CatchClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Declaration?.Accept(this);
            node.Filter?.Accept(this);
            node.Block?.Accept(this);

            base.VisitCatchClause(node);
            
            PostVisit(node);
        }

        public override void VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.FilterExpression?.Accept(this);
            
            base.VisitCatchFilterClause(node);
            
            PostVisit(node);
        }

        public override void VisitElseClause(ElseClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Statement?.Accept(this);

            base.VisitElseClause(node);
            
            PostVisit(node);
        }

        public override void VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Value?.Accept(this);

            base.VisitEqualsValueClause(node);
            
            PostVisit(node);
        }

        public override void VisitFinallyClause(FinallyClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Block?.Accept(this);

            base.VisitFinallyClause(node);
            
            PostVisit(node);
        }

        public override void VisitFromClause(FromClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitFromClause(node);
            
            PostVisit(node);
        }

        public override void VisitGroupClause(GroupClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ByExpression?.Accept(this);
            node.GroupExpression?.Accept(this);

            base.VisitGroupClause(node);
            
            PostVisit(node);
        }

        public override void VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Value?.Accept(this);

            base.VisitInterpolationAlignmentClause(node);
            
            PostVisit(node);
        }

        public override void VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitInterpolationFormatClause(node);
            
            PostVisit(node);
        }

        public override void VisitJoinClause(JoinClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.InExpression?.Accept(this);
            node.Into?.Accept(this);
            node.LeftExpression?.Accept(this);
            node.RightExpression?.Accept(this);
            node.Type?.Accept(this);

            base.VisitJoinClause(node);
            
            PostVisit(node);
        }

        public override void VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitJoinIntoClause(node);
            
            PostVisit(node);
        }

        public override void VisitLetClause(LetClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);
            base.VisitLetClause(node);
            
            PostVisit(node);
        }

        public override void VisitOrderByClause(OrderByClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (OrderingSyntax ordering in node.Orderings)
            {
                ordering.Accept(this);
            }

            base.VisitOrderByClause(node);
            
            PostVisit(node);
        }

        public override void VisitSelectClause(SelectClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitSelectClause(node);
            
            PostVisit(node);
        }

        public override void VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (TypeParameterConstraintSyntax constraint in node.Constraints)
            {
                constraint.Accept(this);
            }

            node.Name?.Accept(this);
            
            base.VisitTypeParameterConstraintClause(node);
            
            PostVisit(node);
        }

        public override void VisitWhenClause(WhenClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Condition?.Accept(this);

            base.VisitWhenClause(node);
            
            PostVisit(node);
        }

        public override void VisitWhereClause(WhereClauseSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Condition?.Accept(this);

            base.VisitWhereClause(node);
            
            PostVisit(node);
        }
    }
}
