using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitConstantPattern(ConstantPatternSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitConstantPattern(node);
        }

        public override void VisitDeclarationPattern(DeclarationPatternSyntax node)
        {
            node.Designation?.Accept(this);
            node.Type?.Accept(this);

            base.VisitDeclarationPattern(node);
        }

        public override void VisitIsPatternExpression(IsPatternExpressionSyntax node)
        {
            node.Pattern?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitIsPatternExpression(node);
        }

        public override void VisitQueryBody(QueryBodySyntax node)
        {
            foreach (QueryClauseSyntax clause in node.Clauses)
            {
                clause.Accept(this);
            }

            node.SelectOrGroup?.Accept(this);
            node.Continuation?.Accept(this);

            base.VisitQueryBody(node);
        }

        public override void VisitQueryContinuation(QueryContinuationSyntax node)
        {
            node.Body?.Accept(this);

            base.VisitQueryContinuation(node);
        }

        public override void VisitQueryExpression(QueryExpressionSyntax node)
        {
            node.FromClause?.Accept(this);
            node.Body?.Accept(this);

            base.VisitQueryExpression(node);
        }
    }
}
