using Cascade.CodeAnalysis.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitConstantPattern(ConstantPatternSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitConstantPattern(node);
        }

        public override Evaluation VisitDeclarationPattern(DeclarationPatternSyntax node)
        {
            node.Designation?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitDeclarationPattern(node);
        }

        public override Evaluation VisitIsPatternExpression(IsPatternExpressionSyntax node)
        {
            node.Pattern?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitIsPatternExpression(node);
        }

        public override Evaluation VisitQueryBody(QueryBodySyntax node)
        {
            foreach (QueryClauseSyntax clause in node.Clauses)
            {
                clause.Accept<Evaluation>(this);
            }

            node.SelectOrGroup?.Accept<Evaluation>(this);
            node.Continuation?.Accept<Evaluation>(this);

            return base.VisitQueryBody(node);
        }

        public override Evaluation VisitQueryContinuation(QueryContinuationSyntax node)
        {
            node.Body?.Accept<Evaluation>(this);

            return base.VisitQueryContinuation(node);
        }

        public override Evaluation VisitQueryExpression(QueryExpressionSyntax node)
        {
            node.FromClause?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);

            return base.VisitQueryExpression(node);
        }
    }
}
