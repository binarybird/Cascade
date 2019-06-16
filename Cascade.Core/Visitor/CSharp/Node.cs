using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Visitor.CSharp
{
    public partial class CSharpVisitor : CSharpSyntaxVisitor, Visitor
    {
        public bool PreVisit(SyntaxNode node)
        {
            return true;
        }

        public void PostVisit(SyntaxNode node)
        {
            
        }
        
        public override void DefaultVisit(SyntaxNode node)
        {
            base.DefaultVisit(node);
        }

        public override void Visit(SyntaxNode node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.Visit(node);
            
            PostVisit(node);
        }

        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept(this);
            }

            foreach (ExternAliasDirectiveSyntax nodeExtern in node.Externs)
            {
                nodeExtern.Accept(this);
            }

            foreach (UsingDirectiveSyntax nodeUsing in node.Usings)
            {
                nodeUsing.Accept(this);
            }

            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept(this);
            }

            base.VisitCompilationUnit(node);
            
            PostVisit(node);
        }

        public override void VisitArgument(ArgumentSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.NameColon?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitArgument(node);
            
            PostVisit(node);
        }

        public override void VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ExpressionSyntax nodeSize in node.Sizes)
            {
                nodeSize.Accept(this);
            }

            base.VisitArrayRankSpecifier(node);
            
            PostVisit(node);
        }

        public override void VisitAttribute(AttributeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);
            node.Name?.Accept(this);

            base.VisitAttribute(node);
            
            PostVisit(node);
        }

        public override void VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.NameEquals?.Accept(this);
            node.NameColon?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitAttributeArgument(node);
            
            PostVisit(node);
        }

        public override void VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitAttributeTargetSpecifier(node);
            
            PostVisit(node);
        }

        public override void VisitBlock(BlockSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (StatementSyntax statement in node.Statements)
            {
                statement.Accept(this);
            }
            
            base.VisitBlock(node);
            
            PostVisit(node);
        }

        public override void VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitClassOrStructConstraint(node);
            
            PostVisit(node);
        }

        public override void VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitConstructorConstraint(node);
            
            PostVisit(node);
        }

        public override void VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);

            base.VisitConstructorInitializer(node);
            
            PostVisit(node);
        }

        public override void VisitDiscardDesignation(DiscardDesignationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitDiscardDesignation(node);
            
            PostVisit(node);
        }

        public override void VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitExplicitInterfaceSpecifier(node);
            
            PostVisit(node);
        }

        public override void VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitExternAliasDirective(node);
            
            PostVisit(node);
        }

        public override void VisitImplicitElementAccess(ImplicitElementAccessSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ArgumentList?.Accept(this);

            base.VisitImplicitElementAccess(node);
            
            PostVisit(node);
        }

        public override void VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Type?.Accept(this);

            base.VisitIncompleteMember(node);
            
            PostVisit(node);
        }

        public override void VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitInterpolatedStringText(node);
            
            PostVisit(node);
        }

        public override void VisitInterpolation(InterpolationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.AlignmentClause?.Accept(this);
            node.FormatClause?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitInterpolation(node);
            
            PostVisit(node);
        }

        public override void VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitOmittedTypeArgument(node);
            
            PostVisit(node);
        }

        public override void VisitOrdering(OrderingSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Expression?.Accept(this);

            base.VisitOrdering(node);
            
            PostVisit(node);
        }

        public override void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (VariableDesignationSyntax variable in node.Variables)
            {
                variable.Accept(this);
            }

            base.VisitParenthesizedVariableDesignation(node);
            
            PostVisit(node);
        }

        public override void VisitParameter(ParameterSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept(this);
            }

            node.Default?.Accept(this);
            node.Type?.Accept(this);

            base.VisitParameter(node);
            
            PostVisit(node);
        }

        public override void VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitSingleVariableDesignation(node);
            
            PostVisit(node);
        }

        public override void VisitSwitchSection(SwitchSectionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (SwitchLabelSyntax labelSyntax in node.Labels)
            {
                labelSyntax.Accept(this);
            }

            foreach (StatementSyntax statement in node.Statements)
            {
                statement.Accept(this);
            }

            base.VisitSwitchSection(node);
            
            PostVisit(node);
        }

        public override void VisitTupleElement(TupleElementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitTupleElement(node);
            
            PostVisit(node);
        }

        public override void VisitTypeConstraint(TypeConstraintSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitTypeConstraint(node);
            
            PostVisit(node);
        }

        public override void VisitTypeParameter(TypeParameterSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept(this);
            }

            base.VisitTypeParameter(node);
            
            PostVisit(node);
        }

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Alias?.Accept(this);
            node.Name?.Accept(this);

            base.VisitUsingDirective(node);
            
            PostVisit(node);
        }
    }
}
