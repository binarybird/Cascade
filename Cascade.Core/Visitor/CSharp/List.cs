using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitAccessorList(AccessorListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AccessorDeclarationSyntax accessor in node.Accessors)
            {
                accessor.Accept(this);
            }

            base.VisitAccessorList(node);
            
            PostVisit(node);
        }

        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitArgumentList(node);
            
            PostVisit(node);
        }

        public override void VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitAttributeArgumentList(node);
            
            PostVisit(node);
        }

        public override void VisitAttributeList(AttributeListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (AttributeSyntax attribute in node.Attributes)
            {
                attribute.Accept(this);
            }

            node.Target?.Accept(this);

            base.VisitAttributeList(node);
            
            PostVisit(node);
        }

        public override void VisitBaseList(BaseListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (BaseTypeSyntax type in node.Types)
            {
                type.Accept(this);
            }
            
            base.VisitBaseList(node);
            
            PostVisit(node);
        }

        public override void VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ArgumentSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }
            
            base.VisitBracketedArgumentList(node);
            
            PostVisit(node);
        }

        public override void VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }
            
            base.VisitBracketedParameterList(node);
            
            PostVisit(node);
        }

        public override void VisitParameterList(ParameterListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (ParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }

            base.VisitParameterList(node);
            
            PostVisit(node);
        }

        public override void VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (TypeSyntax argument in node.Arguments)
            {
                argument.Accept(this);
            }

            base.VisitTypeArgumentList(node);
            
            PostVisit(node);
        }

        public override void VisitTypeParameterList(TypeParameterListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (TypeParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }

            base.VisitTypeParameterList(node);
            
            PostVisit(node);
        }
    }
}
