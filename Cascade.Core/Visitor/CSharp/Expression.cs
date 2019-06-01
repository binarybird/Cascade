using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ParameterList?.Accept(this);
            node.Block?.Accept(this);
            node.Body?.Accept(this);
           
            base.VisitAnonymousMethodExpression(node);
            
            PostVisit(node);
        }

        public override void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AnonymousObjectMemberDeclaratorSyntax initializer in node.Initializers)
            {
                initializer.Accept(this);
            }
           
            base.VisitAnonymousObjectCreationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Initializer?.Accept(this);
            node.Type?.Accept(this);

            base.VisitArrayCreationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Right?.Accept(this);
            node.Left?.Accept(this);
            
            base.VisitAssignmentExpression(node);
            
            PostVisit(node);
        }

        public override void VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitAwaitExpression(node);
            
            PostVisit(node);
        }

        public override void VisitBaseExpression(BaseExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitBaseExpression(node);
            
            PostVisit(node);
        }

        public override void VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Right?.Accept(this);
            node.Left?.Accept(this);

            base.VisitBinaryExpression(node);
            
            PostVisit(node);
        }

        public override void VisitCastExpression(CastExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitCastExpression(node);
            
            PostVisit(node);
        }

        public override void VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitCheckedExpression(node);
            
            PostVisit(node);
        }

        public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.WhenNotNull?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitConditionalAccessExpression(node);
            
            PostVisit(node);
        }

        public override void VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Condition?.Accept(this);
            node.WhenTrue?.Accept(this);
            node.WhenFalse?.Accept(this);

            base.VisitConditionalExpression(node);
            
            PostVisit(node);
        }

        public override void VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            node.Designation?.Accept(this);

            base.VisitDeclarationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            
            base.VisitDefaultExpression(node);
            
            PostVisit(node);
        }

        public override void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitElementAccessExpression(node);
            
            PostVisit(node);
        }

        public override void VisitElementBindingExpression(ElementBindingExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);

            base.VisitElementBindingExpression(node);
            
            PostVisit(node);
        }

        public override void VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Initializer?.Accept(this);

            base.VisitImplicitArrayCreationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitImplicitStackAllocArrayCreationExpression(ImplicitStackAllocArrayCreationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Initializer?.Accept(this);
            
            base.VisitImplicitStackAllocArrayCreationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ExpressionSyntax nodeExpression in node.Expressions)
            {
                nodeExpression.Accept(this);
            }

            base.VisitInitializerExpression(node);
            
            PostVisit(node);
        }

        public override void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (InterpolatedStringContentSyntax content in node.Contents)
            {
                content.Accept(this);
            }

            base.VisitInterpolatedStringExpression(node);
            
            PostVisit(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitInvocationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitLiteralExpression(node);
            
            PostVisit(node);
        }

        public override void VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitMakeRefExpression(node);
            
            PostVisit(node);
        }

        public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitMemberAccessExpression(node);
            
            PostVisit(node);
        }

        public override void VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitMemberBindingExpression(node);
            
            PostVisit(node);
        }

        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);
            node.Type?.Accept(this);
            node.Initializer?.Accept(this);

            base.VisitObjectCreationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitOmittedArraySizeExpression(node);
            
            PostVisit(node);
        }

        public override void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitParenthesizedExpression(node);
            
            PostVisit(node);
        }

        public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ParameterList?.Accept(this);
            node.Body?.Accept(this);

            base.VisitParenthesizedLambdaExpression(node);
            
            PostVisit(node);
        }

        public override void VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Operand?.Accept(this);

            base.VisitPostfixUnaryExpression(node);
            
            PostVisit(node);
        }

        public override void VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Operand?.Accept(this);

            base.VisitPrefixUnaryExpression(node);
            
            PostVisit(node);
        }

        public override void VisitRefExpression(RefExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitRefExpression(node);
            
            PostVisit(node);
        }

        public override void VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitRefTypeExpression(node);
            
            PostVisit(node);
        }

        public override void VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitRefValueExpression(node);
            
            PostVisit(node);
        }

        public override void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Parameter?.Accept(this);
            node.Body?.Accept(this);

            base.VisitSimpleLambdaExpression(node);
            
            PostVisit(node);
        }

        public override void VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitSizeOfExpression(node);
            
            PostVisit(node);
        }

        public override void VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);
            node.Initializer?.Accept(this);

            base.VisitStackAllocArrayCreationExpression(node);
            
            PostVisit(node);
        }

        public override void VisitThisExpression(ThisExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitThisExpression(node);
            
            PostVisit(node);
        }

        public override void VisitThrowExpression(ThrowExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);
            
            base.VisitThrowExpression(node);
            
            PostVisit(node);
        }

        public override void VisitTupleExpression(TupleExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitTupleExpression(node);
            
            PostVisit(node);
        }

        public override void VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitTypeOfExpression(node);
            
            PostVisit(node);
        }
    }
}
