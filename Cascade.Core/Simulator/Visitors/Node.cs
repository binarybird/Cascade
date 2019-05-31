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

            return base.VisitArgument(node);
        }
        
        public override Evaluation VisitParameter(ParameterSyntax node)
        {
            Frame frame = _callStack.Peek();
            Instance instance = null;
            
            ISymbol symb = node.GetDeclaringSymbol(_comp);
            if (symb == null)
            {
                symb = node.GetSymbolInfo(_comp).Symbol;
            }
            if (symb as IParameterSymbol != null)
            {
                Identity ident = new Identity(frame, symb as IParameterSymbol, node.Identifier.ValueText);
                ICollection<Instance> findInstance = frame.FindLocalInstance(ident).ToList();
                if (findInstance.Any())
                {
                    instance = findInstance.First();//TODO - only one out of enum??
                    instance.Identities.Push(ident);
                }
                else
                {
                    instance = frame.CreateInstance(ident, (symb as IParameterSymbol).Type);
                }
            }
            else
            {
                throw new Exception("Unable to resolve param");
            }
            
            //do stuff with instance
            
            foreach (AttributeListSyntax listSyntax in node.AttributeLists)
            {
                listSyntax.Accept<Evaluation>(this);
            }

            node.Default?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitParameter(node);
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
