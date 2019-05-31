using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            node.ParameterList?.Accept(this);
            node.Block?.Accept(this);
            node.Body?.Accept(this);

            base.VisitAnonymousMethodExpression(node);
        }

        public override void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            foreach (AnonymousObjectMemberDeclaratorSyntax initializer in node.Initializers)
            {
                initializer.Accept(this);
            }

            base.VisitAnonymousObjectCreationExpression(node);
        }

        public override void VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            node.Initializer?.Accept(this);
            node.Type?.Accept(this);

            base.VisitArrayCreationExpression(node);
        }

        public override void VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            node.Right?.Accept(this);
            node.Left?.Accept(this);

            base.VisitAssignmentExpression(node);
        }

        public override void VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitAwaitExpression(node);
        }

        public override void VisitBaseExpression(BaseExpressionSyntax node)
        {
            base.VisitBaseExpression(node);
        }

        public override void VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            node.Right?.Accept(this);
            node.Left?.Accept(this);

            base.VisitBinaryExpression(node);
        }

        public override void VisitCastExpression(CastExpressionSyntax node)
        {
            node.Type?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitCastExpression(node);
        }

        public override void VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitCheckedExpression(node);
        }

        public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            node.WhenNotNull?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitConditionalAccessExpression(node);
        }

        public override void VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            node.Condition?.Accept(this);
            node.WhenTrue?.Accept(this);
            node.WhenFalse?.Accept(this);

            base.VisitConditionalExpression(node);
        }

        public override void VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            node.Type?.Accept(this);
            node.Designation?.Accept(this);

            base.VisitDeclarationExpression(node);
        }

        public override void VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitDefaultExpression(node);
        }

        public override void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            node.ArgumentList?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitElementAccessExpression(node);
        }

        public override void VisitElementBindingExpression(ElementBindingExpressionSyntax node)
        {
            node.ArgumentList?.Accept(this);

            base.VisitElementBindingExpression(node);
        }

        public override void VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            node.Initializer?.Accept(this);

            base.VisitImplicitArrayCreationExpression(node);
        }

        public override void VisitImplicitStackAllocArrayCreationExpression(ImplicitStackAllocArrayCreationExpressionSyntax node)
        {
            node.Initializer?.Accept(this);

            base.VisitImplicitStackAllocArrayCreationExpression(node);
        }

        public override void VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            foreach (ExpressionSyntax nodeExpression in node.Expressions)
            {
                nodeExpression.Accept(this);
            }

            base.VisitInitializerExpression(node);
        }

        public override void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            foreach (InterpolatedStringContentSyntax content in node.Contents)
            {
                content.Accept(this);
            }

            base.VisitInterpolatedStringExpression(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {

            node.ArgumentList?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitInvocationExpression(node);
        }

        public override void VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            base.VisitLiteralExpression(node);
        }

        public override void VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitMakeRefExpression(node);
        }

        public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            node.Name?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitMemberAccessExpression(node);
        }

        public override void VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitMemberBindingExpression(node);
        }

        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            node.ArgumentList?.Accept(this);
            node.Type?.Accept(this);
            node.Initializer?.Accept(this);

            base.VisitObjectCreationExpression(node);
        }

        public override void VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            base.VisitOmittedArraySizeExpression(node);
        }

        public override void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitParenthesizedExpression(node);
        }

        public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            node.ParameterList?.Accept(this);
            node.Body?.Accept(this);

            base.VisitParenthesizedLambdaExpression(node);
        }

        public override void VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            node.Operand?.Accept(this);

            base.VisitPostfixUnaryExpression(node);
        }

        public override void VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            node.Operand?.Accept(this);

            base.VisitPrefixUnaryExpression(node);
        }

        public override void VisitRefExpression(RefExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitRefExpression(node);
        }

        public override void VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitRefTypeExpression(node);
        }

        public override void VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            node.Type?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitRefValueExpression(node);
        }

        public override void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            node.Parameter?.Accept(this);
            node.Body?.Accept(this);

            base.VisitSimpleLambdaExpression(node);
        }

        public override void VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitSizeOfExpression(node);
        }

        public override void VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            node.Type?.Accept(this);
            node.Initializer?.Accept(this);

            base.VisitStackAllocArrayCreationExpression(node);
        }

        public override void VisitThisExpression(ThisExpressionSyntax node)
        {
            base.VisitThisExpression(node);
        }

        public override void VisitThrowExpression(ThrowExpressionSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitThrowExpression(node);
        }

        public override void VisitTupleExpression(TupleExpressionSyntax node)
        {
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitTupleExpression(node);
        }

        public override void VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitTypeOfExpression(node);
        }
    }
}