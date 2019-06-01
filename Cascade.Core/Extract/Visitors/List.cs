using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitAccessorList(AccessorListSyntax node)
        {
            foreach (AccessorDeclarationSyntax accessor in node.Accessors)
            {
                accessor.Accept(this);
            }

            base.VisitAccessorList(node);
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitArgumentList(node);
        }

        public override void VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            foreach (AttributeArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitAttributeArgumentList(node);
        }

        public override void VisitAttributeList(AttributeListSyntax node)
        {
            foreach (AttributeSyntax attribute in node.Attributes)
            {
                attribute.Accept(this);
            }

            node.Target?.Accept(this);

            base.VisitAttributeList(node);
        }

        public override void VisitBaseList(BaseListSyntax node)
        {
            foreach (BaseTypeSyntax type in node.Types)
            {
                type.Accept(this);
            }
            
            base.VisitBaseList(node);
        }

        public override void VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }
            
            base.VisitBracketedArgumentList(node);
        }

        public override void VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }
            
            base.VisitBracketedParameterList(node);
        }

        public override void VisitParameterList(ParameterListSyntax node)
        {
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }

            base.VisitParameterList(node);
        }

        public override void VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            foreach (TypeSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitTypeArgumentList(node);
        }

        public override void VisitTypeParameterList(TypeParameterListSyntax node)
        {
            foreach (TypeParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }

            base.VisitTypeParameterList(node);
        }
    }
}
