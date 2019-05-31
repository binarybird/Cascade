using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitBreakStatement(BreakStatementSyntax node)
        {
            return base.VisitBreakStatement(node);
        }

        public override Evaluation VisitCheckedStatement(CheckedStatementSyntax node)
        {
            node.Block?.Accept<Evaluation>(this);

            return base.VisitCheckedStatement(node);
        }

        public override Evaluation VisitContinueStatement(ContinueStatementSyntax node)
        {
            return base.VisitContinueStatement(node);
        }

        public override Evaluation VisitDoStatement(DoStatementSyntax node)
        {
            node.Condition?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitDoStatement(node);
        }

        public override Evaluation VisitEmptyStatement(EmptyStatementSyntax node)
        {
            return base.VisitEmptyStatement(node);
        }

        public override Evaluation VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitExpressionStatement(node);
        }

        public override Evaluation VisitFixedStatement(FixedStatementSyntax node)
        {
            node.Declaration?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitFixedStatement(node);
        }

        public override Evaluation VisitForEachStatement(ForEachStatementSyntax node)
        {
            node.Type.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitForEachStatement(node);
        }

        public override Evaluation VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
        {
            node.Statement?.Accept<Evaluation>(this);
            node.Variable?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);
            
            return base.VisitForEachVariableStatement(node);
        }

        public override Evaluation VisitForStatement(ForStatementSyntax node)
        {
            node.Declaration?.Accept<Evaluation>(this);
            node.Condition?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            foreach (ExpressionSyntax initializer in node.Initializers)
            {
                initializer.Accept<Evaluation>(this);
            }

            foreach (ExpressionSyntax incrementor in node.Incrementors)
            {
                incrementor.Accept<Evaluation>(this);
            }

            return base.VisitForStatement(node);
        }

        public override Evaluation VisitGlobalStatement(GlobalStatementSyntax node)
        {
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitGlobalStatement(node);
        }

        public override Evaluation VisitGotoStatement(GotoStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitGotoStatement(node);
        }

        public override Evaluation VisitIfStatement(IfStatementSyntax node)
        { 
            node.Condition?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);
            node.Else?.Accept<Evaluation>(this);

            return base.VisitIfStatement(node);
        }

        public override Evaluation VisitLabeledStatement(LabeledStatementSyntax node)
        {
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitLabeledStatement(node);
        }

        public override Evaluation VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            node.Declaration?.Accept<Evaluation>(this);

            return base.VisitLocalDeclarationStatement(node);
        }

        public override Evaluation VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
        {
            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept<Evaluation>(this);
            }

            node.ParameterList?.Accept<Evaluation>(this);
            node.TypeParameterList.Accept<Evaluation>(this);
            node.ExpressionBody?.Accept<Evaluation>(this);
            node.Body.Accept<Evaluation>(this);
            node.ReturnType?.Accept<Evaluation>(this);
            
            return base.VisitLocalFunctionStatement(node);
        }

        public override Evaluation VisitLockStatement(LockStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitLockStatement(node);
        }

        public override Evaluation VisitReturnStatement(ReturnStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitReturnStatement(node);
        }

        public override Evaluation VisitSwitchStatement(SwitchStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);
            foreach (SwitchSectionSyntax section in node.Sections)
            {
                section.Accept<Evaluation>(this);
            }

            return base.VisitSwitchStatement(node);
        }

        public override Evaluation VisitThrowStatement(ThrowStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitThrowStatement(node);
        }

        public override Evaluation VisitTryStatement(TryStatementSyntax node)
        {
            node.Block.Accept<Evaluation>(this);
            foreach (CatchClauseSyntax clauseSyntax in node.Catches)
            {
                clauseSyntax.Accept<Evaluation>(this);
            }

            node.Finally?.Accept<Evaluation>(this);

            return base.VisitTryStatement(node);
        }

        public override Evaluation VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            node.Block?.Accept<Evaluation>(this);

            return base.VisitUnsafeStatement(node);
        }

        public override Evaluation VisitUsingStatement(UsingStatementSyntax node)
        {
            node.Declaration?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitUsingStatement(node);
        }

        public override Evaluation VisitWhileStatement(WhileStatementSyntax node)
        {
            node.Condition?.Accept<Evaluation>(this);
            node.Statement?.Accept<Evaluation>(this);

            return base.VisitWhileStatement(node);
        }

        public override Evaluation VisitYieldStatement(YieldStatementSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitYieldStatement(node);
        }
    }
}
