using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void DefaultVisit(SyntaxNode node)
        {
            base.DefaultVisit(node);
        }

        public override void Visit(SyntaxNode node)
        {
            base.Visit(node);
        }
        
        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
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
        }

        public override void VisitArgument(ArgumentSyntax node)
        {
            node.NameColon?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitArgument(node);
        }
        
        public override void VisitParameter(ParameterSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept(this);
            }

            node.Default?.Accept(this);
            node.Type?.Accept(this);

            base.VisitParameter(node);
        }

        public override void VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            foreach (ExpressionSyntax nodeSize in node.Sizes)
            {
                nodeSize.Accept(this);
            }

            base.VisitArrayRankSpecifier(node);
        }

        public override void VisitAttribute(AttributeSyntax node)
        {
            node.ArgumentList.Accept(this);
            node.Name.Accept(this);

            base.VisitAttribute(node);
        }

        public override void VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            node.NameEquals?.Accept(this);
            node.NameColon?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitAttributeArgument(node);
        }

        public override void VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            base.VisitAttributeTargetSpecifier(node);
        }

        public override void VisitBlock(BlockSyntax node)
        {
            foreach (StatementSyntax statement in node.Statements)
            {
                statement.Accept(this);
            }
            
            base.VisitBlock(node);
        }

        public override void VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            base.VisitClassOrStructConstraint(node);
        }

        public override void VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            base.VisitConstructorConstraint(node);
        }

        public override void VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            node.ArgumentList?.Accept(this);

            base.VisitConstructorInitializer(node);
        }

        public override void VisitDiscardDesignation(DiscardDesignationSyntax node)
        {
            base.VisitDiscardDesignation(node);
        }

        public override void VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitExplicitInterfaceSpecifier(node);
        }

        public override void VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            base.VisitExternAliasDirective(node);
        }

        public override void VisitImplicitElementAccess(ImplicitElementAccessSyntax node)
        {
            node.ArgumentList?.Accept(this);

            base.VisitImplicitElementAccess(node);
        }

        public override void VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept(this);
            }

            node.Type?.Accept(this);

            base.VisitIncompleteMember(node);
        }

        public override void VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
        {
            base.VisitInterpolatedStringText(node);
        }

        public override void VisitInterpolation(InterpolationSyntax node)
        {
            node.AlignmentClause?.Accept(this);
            node.FormatClause?.Accept(this);
            node.Expression?.Accept(this);

            base.VisitInterpolation(node);
        }

        public override void VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            base.VisitOmittedTypeArgument(node);
        }

        public override void VisitOrdering(OrderingSyntax node)
        {
            node.Expression?.Accept(this);

            base.VisitOrdering(node);
        }

        public override void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
        {
            foreach (VariableDesignationSyntax variable in node.Variables)
            {
                variable.Accept(this);
            }

            base.VisitParenthesizedVariableDesignation(node);
        }

        public override void VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
        {
            base.VisitSingleVariableDesignation(node);
        }

        public override void VisitSwitchSection(SwitchSectionSyntax node)
        {
            foreach (SwitchLabelSyntax labelSyntax in node.Labels)
            {
                labelSyntax.Accept(this);
            }

            foreach (StatementSyntax statement in node.Statements)
            {
                statement.Accept(this);
            }

            base.VisitSwitchSection(node);
        }

        public override void VisitTupleElement(TupleElementSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitTupleElement(node);
        }

        public override void VisitTypeConstraint(TypeConstraintSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitTypeConstraint(node);
        }

        public override void VisitTypeParameter(TypeParameterSyntax node)
        {
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept(this);
            }

            base.VisitTypeParameter(node);
        }

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            node.Alias?.Accept(this);
            node.Name?.Accept(this);

            base.VisitUsingDirective(node);
        }
    }
}
