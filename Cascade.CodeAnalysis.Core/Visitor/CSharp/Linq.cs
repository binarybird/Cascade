using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitConstantPattern(ConstantPatternSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitConstantPattern(node);
            
            PostVisit(node);
        }

        public override void VisitDeclarationPattern(DeclarationPatternSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Designation?.Accept(this);
            node.Type?.Accept(this);

            base.VisitDeclarationPattern(node);
            
            PostVisit(node);
        }

        public override void VisitIsPatternExpression(IsPatternExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Pattern?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitIsPatternExpression(node);
            
            PostVisit(node);
        }

        public override void VisitQueryBody(QueryBodySyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (QueryClauseSyntax clause in node.Clauses)
            {
                clause.Accept(this);
            }

            node.SelectOrGroup?.Accept(this);
            node.Continuation?.Accept(this);

            base.VisitQueryBody(node);
            
            PostVisit(node);
        }

        public override void VisitQueryContinuation(QueryContinuationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Body?.Accept(this);

            base.VisitQueryContinuation(node);
            
            PostVisit(node);
        }

        public override void VisitQueryExpression(QueryExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.FromClause?.Accept(this);
            node.Body?.Accept(this);

            base.VisitQueryExpression(node);
            
            PostVisit(node);
        }
    }
}
