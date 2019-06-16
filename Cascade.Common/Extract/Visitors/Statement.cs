using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            base.VisitBreakStatement(node);
        }

        public override void VisitCheckedStatement(CheckedStatementSyntax node)
        {
            node.Block?.Accept(this);

            base.VisitCheckedStatement(node);
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            base.VisitContinueStatement(node);
        }

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitDoStatement(node);
        }

        public override void VisitEmptyStatement(EmptyStatementSyntax node)
        {
            base.VisitEmptyStatement(node);
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitExpressionStatement(node);
        }

        public override void VisitFixedStatement(FixedStatementSyntax node)
        {
            node.Declaration?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitFixedStatement(node);
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            node.Type.Accept(this);
            node.Expression?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitForEachStatement(node);
        }

        public override void VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
        {
            node.Statement?.Accept(this);
            node.Variable?.Accept(this);
            node.Expression?.Accept(this);
            
            base.VisitForEachVariableStatement(node);
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            node.Declaration?.Accept(this);
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);

            foreach (ExpressionSyntax initializer in node.Initializers)
            {
                initializer.Accept(this);
            }

            foreach (ExpressionSyntax incrementor in node.Incrementors)
            {
                incrementor.Accept(this);
            }

            base.VisitForStatement(node);
        }

        public override void VisitGlobalStatement(GlobalStatementSyntax node)
        {
            node.Statement?.Accept(this);

            base.VisitGlobalStatement(node);
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitGotoStatement(node);
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        { 
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);
            node.Else?.Accept(this);

            base.VisitIfStatement(node);
        }

        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            node.Statement?.Accept(this);

            base.VisitLabeledStatement(node);
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            node.Declaration?.Accept(this);

            base.VisitLocalDeclarationStatement(node);
        }

        public override void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
        {
            foreach (TypeParameterConstraintClauseSyntax clause in node.ConstraintClauses)
            {
                clause.Accept(this);
            }

            node.ParameterList?.Accept(this);
            node.TypeParameterList.Accept(this);
            node.ExpressionBody?.Accept(this);
            node.Body.Accept(this);
            node.ReturnType?.Accept(this);
            
            base.VisitLocalFunctionStatement(node);
        }

        public override void VisitLockStatement(LockStatementSyntax node)
        {
            node.Expression?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitLockStatement(node);
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitReturnStatement(node);
        }

        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            node.Expression?.Accept(this);
            foreach (SwitchSectionSyntax section in node.Sections)
            {
                section.Accept(this);
            }

            base.VisitSwitchStatement(node);
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitThrowStatement(node);
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            node.Block.Accept(this);
            foreach (CatchClauseSyntax clauseSyntax in node.Catches)
            {
                clauseSyntax.Accept(this);
            }

            node.Finally?.Accept(this);

            base.VisitTryStatement(node);
        }

        public override void VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            node.Block?.Accept(this);

            base.VisitUnsafeStatement(node);
        }

        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            node.Declaration?.Accept(this);
            node.Expression?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitUsingStatement(node);
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitWhileStatement(node);
        }

        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitYieldStatement(node);
        }
    }
}
