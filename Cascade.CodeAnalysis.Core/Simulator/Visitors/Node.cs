using System;
using System.Collections.Generic;
using System.Linq;
using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation DefaultVisit(SyntaxNode node)
        {
            return base.DefaultVisit(node);
        }

        public override Evaluation Visit(SyntaxNode node)
        {
            return base.Visit(node);
        }

        public override Evaluation VisitCompilationUnit(CompilationUnitSyntax node)
        {
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept<Evaluation>(this);
            }

            foreach (ExternAliasDirectiveSyntax nodeExtern in node.Externs)
            {
                nodeExtern.Accept<Evaluation>(this);
            }

            foreach (UsingDirectiveSyntax nodeUsing in node.Usings)
            {
                nodeUsing.Accept<Evaluation>(this);
            }

            foreach (MemberDeclarationSyntax member in node.Members)
            {
                member.Accept<Evaluation>(this);
            }

            return base.VisitCompilationUnit(node);
        }

        public override Evaluation VisitArgument(ArgumentSyntax node)
        {
            Frame frame = _callStack.Peek();

            IEnumerable<Instance> found = frame.ContainingHeap.FindInstance(node.GetReference(), _comp);

            node.NameColon?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            int count = found.Count();
            if (count > 1)
            {
                Log.Warn("More then one instance found for argument: {0}", node.ToString());
            }
            else if (count == 0)
            {
                Log.Error("Argument instance not found for node {0}", node.ToString());
            }

            return found.FirstOrDefault();
        }

        public override Evaluation VisitParameter(ParameterSyntax node)
        {
            Frame frame = _callStack.Peek();

            IParameterSymbol symb = node.GetSymbol(_comp) as IParameterSymbol;
            if (symb == null)
            {
                throw new Exception("Unable to resolve parameter");
            }

            Identity ident = new Identity(symb, Node<Evaluation>.Kind.LocalVariable, frame, node.Identifier.ValueText);
            ICollection<Instance> findInstance = frame.FindLocalInstance(ident).ToList();
            Instance instance = null;
            if (findInstance.Any())
            {
                instance = findInstance.First(); //TODO - only one out of enum??
            }
            else
            {
                instance = frame.CreateInstance(ident, Node<Evaluation>.Kind.LocalVariable);
                Log.Error("Unable to find argument instance! Creating new instance {0}", instance.ToString());
            }

            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept<Evaluation>(this);
            }

            node.Default?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return instance;
        }

        public override Evaluation VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            foreach (ExpressionSyntax nodeSize in node.Sizes)
            {
                nodeSize.Accept<Evaluation>(this);
            }

            return base.VisitArrayRankSpecifier(node);
        }

        public override Evaluation VisitAttribute(AttributeSyntax node)
        {
            node.ArgumentList.Accept<Evaluation>(this);
            node.Name.Accept<Evaluation>(this);

            return base.VisitAttribute(node);
        }

        public override Evaluation VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            node.NameEquals?.Accept<Evaluation>(this);
            node.NameColon?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitAttributeArgument(node);
        }

        public override Evaluation VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            return base.VisitAttributeTargetSpecifier(node);
        }

        public override Evaluation VisitBlock(BlockSyntax node)
        {
            foreach (StatementSyntax statement in node.Statements)
            {
                statement.Accept<Evaluation>(this);
            }

            return base.VisitBlock(node);
        }

        public override Evaluation VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            return base.VisitClassOrStructConstraint(node);
        }

        public override Evaluation VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            return base.VisitConstructorConstraint(node);
        }

        public override Evaluation VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            node.ArgumentList?.Accept<Evaluation>(this);

            return base.VisitConstructorInitializer(node);
        }

        public override Evaluation VisitDiscardDesignation(DiscardDesignationSyntax node)
        {
            return base.VisitDiscardDesignation(node);
        }

        public override Evaluation VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitExplicitInterfaceSpecifier(node);
        }

        public override Evaluation VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            return base.VisitExternAliasDirective(node);
        }

        public override Evaluation VisitImplicitElementAccess(ImplicitElementAccessSyntax node)
        {
            node.ArgumentList?.Accept<Evaluation>(this);

            return base.VisitImplicitElementAccess(node);
        }

        public override Evaluation VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            foreach (AttributeListSyntax attributeList in node.AttributeLists)
            {
                attributeList.Accept<Evaluation>(this);
            }

            node.Type?.Accept<Evaluation>(this);

            return base.VisitIncompleteMember(node);
        }

        public override Evaluation VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
        {
            return base.VisitInterpolatedStringText(node);
        }

        public override Evaluation VisitInterpolation(InterpolationSyntax node)
        {
            node.AlignmentClause?.Accept<Evaluation>(this);
            node.FormatClause?.Accept<Evaluation>(this);
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitInterpolation(node);
        }

        public override Evaluation VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            return base.VisitOmittedTypeArgument(node);
        }

        public override Evaluation VisitOrdering(OrderingSyntax node)
        {
            node.Expression?.Accept<Evaluation>(this);

            return base.VisitOrdering(node);
        }

        public override Evaluation VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
        {
            foreach (VariableDesignationSyntax variable in node.Variables)
            {
                variable.Accept<Evaluation>(this);
            }

            return base.VisitParenthesizedVariableDesignation(node);
        }

        public override Evaluation VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
        {
            return base.VisitSingleVariableDesignation(node);
        }

        public override Evaluation VisitSwitchSection(SwitchSectionSyntax node)
        {
            foreach (SwitchLabelSyntax labelSyntax in node.Labels)
            {
                labelSyntax.Accept<Evaluation>(this);
            }

            foreach (StatementSyntax statement in node.Statements)
            {
                statement.Accept<Evaluation>(this);
            }

            return base.VisitSwitchSection(node);
        }

        public override Evaluation VisitTupleElement(TupleElementSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitTupleElement(node);
        }

        public override Evaluation VisitTypeConstraint(TypeConstraintSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitTypeConstraint(node);
        }

        public override Evaluation VisitTypeParameter(TypeParameterSyntax node)
        {
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept<Evaluation>(this);
            }

            return base.VisitTypeParameter(node);
        }

        public override Evaluation VisitUsingDirective(UsingDirectiveSyntax node)
        {
            node.Alias?.Accept<Evaluation>(this);
            node.Name?.Accept<Evaluation>(this);

            return base.VisitUsingDirective(node);
        }
    }
}