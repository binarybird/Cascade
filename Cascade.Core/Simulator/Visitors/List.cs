using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitAccessorList(AccessorListSyntax node)
        {
            foreach (AccessorDeclarationSyntax accessor in node.Accessors)
            {
                accessor.Accept<Evaluation>(this);
            }

            return base.VisitAccessorList(node);
        }

        public override Evaluation VisitArgumentList(ArgumentListSyntax node)
        {
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept<Evaluation>(this);
            }

            return base.VisitArgumentList(node);
        }

        public override Evaluation VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            foreach (AttributeArgumentSyntax argument in node.Arguments)
            {
                argument.Accept<Evaluation>(this);
            }

            return base.VisitAttributeArgumentList(node);
        }

        public override Evaluation VisitAttributeList(AttributeListSyntax node)
        {
            foreach (AttributeSyntax attribute in node.Attributes)
            {
                attribute.Accept<Evaluation>(this);
            }

            node.Target?.Accept<Evaluation>(this);

            return base.VisitAttributeList(node);
        }

        public override Evaluation VisitBaseList(BaseListSyntax node)
        {
            foreach (BaseTypeSyntax type in node.Types)
            {
                type.Accept<Evaluation>(this);
            }
            
            return base.VisitBaseList(node);
        }

        public override Evaluation VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept<Evaluation>(this);
            }
            
            return base.VisitBracketedArgumentList(node);
        }

        public override Evaluation VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept<Evaluation>(this);
            }
            
            return base.VisitBracketedParameterList(node);
        }

        public override Evaluation VisitParameterList(ParameterListSyntax node)
        {
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept<Evaluation>(this);
            }

            return base.VisitParameterList(node);
        }

        public override Evaluation VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            foreach (TypeSyntax argument in node.Arguments)
            {
                argument.Accept<Evaluation>(this);
            }

            return base.VisitTypeArgumentList(node);
        }

        public override Evaluation VisitTypeParameterList(TypeParameterListSyntax node)
        {
            foreach (TypeParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept<Evaluation>(this);
            }

            return base.VisitTypeParameterList(node);
        }
    }
}
