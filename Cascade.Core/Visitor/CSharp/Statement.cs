using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitBreakStatement(node);
            
            PostVisit(node);
        }

        public override void VisitCheckedStatement(CheckedStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Block?.Accept(this);

            base.VisitCheckedStatement(node);
            
            PostVisit(node);
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitContinueStatement(node);
            
            PostVisit(node);
        }

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitDoStatement(node);
            
            PostVisit(node);
        }

        public override void VisitEmptyStatement(EmptyStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitEmptyStatement(node);
            
            PostVisit(node);
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitExpressionStatement(node);
            
            PostVisit(node);
        }

        public override void VisitFixedStatement(FixedStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Declaration?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitFixedStatement(node);
            
            PostVisit(node);
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type.Accept(this);
            node.Expression?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitForEachStatement(node);
            
            PostVisit(node);
        }

        public override void VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Statement?.Accept(this);
            node.Variable?.Accept(this);
            node.Expression?.Accept(this);
            
            base.VisitForEachVariableStatement(node);
            
            PostVisit(node);
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
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
            
            PostVisit(node);
        }

        public override void VisitGlobalStatement(GlobalStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Statement?.Accept(this);

            base.VisitGlobalStatement(node);
            
            PostVisit(node);
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitGotoStatement(node);
            
            PostVisit(node);
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        { 
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);
            node.Else?.Accept(this);

            base.VisitIfStatement(node);
            
            PostVisit(node);
        }

        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Statement?.Accept(this);

            base.VisitLabeledStatement(node);
            
            PostVisit(node);
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Declaration?.Accept(this);

            base.VisitLocalDeclarationStatement(node);
            
            PostVisit(node);
        }

        public override void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
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
            
            PostVisit(node);
        }

        public override void VisitLockStatement(LockStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitLockStatement(node);
            
            PostVisit(node);
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitReturnStatement(node);
            
            PostVisit(node);
        }

        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);
            foreach (SwitchSectionSyntax section in node.Sections)
            {
                section.Accept(this);
            }

            base.VisitSwitchStatement(node);
            
            PostVisit(node);
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitThrowStatement(node);
            
            PostVisit(node);
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Block.Accept(this);
            foreach (CatchClauseSyntax clauseSyntax in node.Catches)
            {
                clauseSyntax.Accept(this);
            }

            node.Finally?.Accept(this);

            base.VisitTryStatement(node);
            
            PostVisit(node);
        }

        public override void VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Block?.Accept(this);

            base.VisitUnsafeStatement(node);
            
            PostVisit(node);
        }

        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Declaration?.Accept(this);
            node.Expression?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitUsingStatement(node);
            
            PostVisit(node);
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Condition?.Accept(this);
            node.Statement?.Accept(this);

            base.VisitWhileStatement(node);
            
            PostVisit(node);
        }

        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitYieldStatement(node);
            
            PostVisit(node);
        }
    }
}
