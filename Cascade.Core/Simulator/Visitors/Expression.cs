using System;
using System.Collections.Generic;
using System.Linq;
using Cascade.Common.Extensions;
using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            node.ParameterList?.Accept<Evaluation>(this);
            node.Block?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);

            return base.VisitAnonymousMethodExpression(node);
        }

        public override Evaluation VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            foreach (AnonymousObjectMemberDeclaratorSyntax initializer in node.Initializers)
            {
                initializer.Accept<Evaluation>(this);
            }

            return base.VisitAnonymousObjectCreationExpression(node);
        }

        public override Evaluation VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            node.Initializer?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitArrayCreationExpression(node);
        }

        public override Evaluation VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            Evaluation rightEval = node.Right?.Accept<Evaluation>(this);
            if (rightEval == null)
            {
                IEnumerable<Instance> findInstance = FindInstance(node.Right?.GetReference(), 1);
            }
            else
            {
                if (rightEval is Identity)
                {
                    IEnumerable<Instance> findInstance = FindInstance((Identity) rightEval, 1);
                } else if (rightEval is Frame)
                {
                    
                } else if (rightEval is Instance)
                {
                    
                }
            }
            
            Evaluation leftEval = node.Left?.Accept<Evaluation>(this);
            if (leftEval == null)
            {
               
            }
            else
            {
                
            }

            return base.VisitAssignmentExpression(node);
        }

        public override Evaluation VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitAwaitExpression(node);
        }

        public override Evaluation VisitBaseExpression(BaseExpressionSyntax node)
        {
            return base.VisitBaseExpression(node);
        }

        public override Evaluation VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            node.Right?.Accept<Evaluation>(this);
            node.Left?.Accept<Evaluation>(this);

            return base.VisitBinaryExpression(node);
        }

        public override Evaluation VisitCastExpression(CastExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitCastExpression(node);
        }

        public override Evaluation VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitCheckedExpression(node);
        }

        public override Evaluation VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            node.WhenNotNull?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitConditionalAccessExpression(node);
        }

        public override Evaluation VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            node.Condition?.Accept<Evaluation>(this);
            node.WhenTrue?.Accept<Evaluation>(this);
            node.WhenFalse?.Accept<Evaluation>(this);

            return base.VisitConditionalExpression(node);
        }

        public override Evaluation VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            node.Designation?.Accept<Evaluation>(this);

            return base.VisitDeclarationExpression(node);
        }

        public override Evaluation VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitDefaultExpression(node);
        }

        public override Evaluation VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            node.ArgumentList?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitElementAccessExpression(node);
        }

        public override Evaluation VisitElementBindingExpression(ElementBindingExpressionSyntax node)
        {
            node.ArgumentList?.Accept<Evaluation>(this);

            return base.VisitElementBindingExpression(node);
        }

        public override Evaluation VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            node.Initializer?.Accept<Evaluation>(this);

            return base.VisitImplicitArrayCreationExpression(node);
        }

        public override Evaluation VisitImplicitStackAllocArrayCreationExpression(ImplicitStackAllocArrayCreationExpressionSyntax node)
        {
            node.Initializer?.Accept<Evaluation>(this);

            return base.VisitImplicitStackAllocArrayCreationExpression(node);
        }

        public override Evaluation VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            foreach (ExpressionSyntax nodeExpression in node.Expressions)
            {
                nodeExpression.Accept<Evaluation>(this);
            }

            return base.VisitInitializerExpression(node);
        }

        public override Evaluation VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            foreach (InterpolatedStringContentSyntax content in node.Contents)
            {
                content.Accept<Evaluation>(this);
            }

            return base.VisitInterpolatedStringExpression(node);
        }

        public override Evaluation VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            EvaluationList args = node.ArgumentList?.Accept<Evaluation>(this) as EvaluationList;
            Evaluation methodExpression = node.Expression?.Accept<Evaluation>(this);

            IMethodSymbol declaringSymbol = node.GetSymbol(_comp) as IMethodSymbol;
            if (declaringSymbol == null)
            {
                throw new Exception("Unhandled symbol type");
            }

            if (declaringSymbol.DeclaringSyntaxReferences.Length != 1)
            {
                throw new Exception("Unhandled declaring references length");
            }

            SyntaxReference methReference = declaringSymbol.DeclaringSyntaxReferences.FirstOrDefault();

            Frame newFrame = null;
            if (declaringSymbol.IsStatic)
            {
                //static method calls have no "instance"
                Heap tmpHeap = new Heap("static");//TODO - static heaps?
                newFrame = tmpHeap.CreateFrame(methReference, _comp);
            }
            else
            {
                //method call on an instance
                IEnumerable<Instance> findInstance = FindInstance(node.GetReference());
                if (findInstance.Count() != 1)
                {
                    throw new Exception("Unhandled instance length");
                }

                Instance instance = findInstance.FirstOrDefault();
                newFrame = instance.InstanceHeap.CreateFrame(methReference, _comp);
            }

            SimulateFrame(newFrame, EvaluationUtil.From<Instance>(args).ToArray());

            return base.VisitInvocationExpression(node);
        }

        public override Evaluation VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            return base.VisitLiteralExpression(node);
        }

        public override Evaluation VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitMakeRefExpression(node);
        }

        public override Evaluation VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitMemberAccessExpression(node);
        }

        public override Evaluation VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitMemberBindingExpression(node);
        }

        public override Evaluation VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            //node.ArgumentList?.Accept(this);
            Evaluation evaluation = node.Initializer?.Accept<Evaluation>(this); //TODO - choose ret
            EvaluationList accept = node.ArgumentList.Accept(this) as EvaluationList;


            node.Type?.Accept<Evaluation>(this);

            ITypeSymbol type = node.Type.GetSymbol(_comp) as ITypeSymbol;
            
            Instance instance = _callStack.Peek().CreateInstance(type);
            InitializeInstance(instance);

            FunctionalFrame constructor = instance.InstanceHeap.CreateFrame(node.GetReference(), _comp);
            
            
            SimulateFrame(constructor, EvaluationUtil.From<Instance>(accept).ToArray());

            return instance;
        }

        public override Evaluation VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            return base.VisitOmittedArraySizeExpression(node);
        }

        public override Evaluation VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitParenthesizedExpression(node);
        }

        public override Evaluation VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            node.ParameterList?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);

            return base.VisitParenthesizedLambdaExpression(node);
        }

        public override Evaluation VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            node.Operand?.Accept<Evaluation>(this);

            return base.VisitPostfixUnaryExpression(node);
        }

        public override Evaluation VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            node.Operand?.Accept<Evaluation>(this);

            return base.VisitPrefixUnaryExpression(node);
        }

        public override Evaluation VisitRefExpression(RefExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitRefExpression(node);
        }

        public override Evaluation VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitRefTypeExpression(node);
        }

        public override Evaluation VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitRefValueExpression(node);
        }

        public override Evaluation VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            node.Parameter?.Accept<Evaluation>(this);
            node.Body?.Accept<Evaluation>(this);

            return base.VisitSimpleLambdaExpression(node);
        }

        public override Evaluation VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitSizeOfExpression(node);
        }

        public override Evaluation VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);
            node.Initializer?.Accept<Evaluation>(this);

            return base.VisitStackAllocArrayCreationExpression(node);
        }

        public override Evaluation VisitThisExpression(ThisExpressionSyntax node)
        {
            return base.VisitThisExpression(node);
        }

        public override Evaluation VisitThrowExpression(ThrowExpressionSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitThrowExpression(node);
        }

        public override Evaluation VisitTupleExpression(TupleExpressionSyntax node)
        {
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept<Evaluation>(this);
            }

            return base.VisitTupleExpression(node);
        }

        public override Evaluation VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitTypeOfExpression(node);
        }
    }
}