using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Alias?.Accept(this);
            node.Name?.Accept(this);

            base.VisitAliasQualifiedName(node);
            
            PostVisit(node);
        }

        public override void VisitGenericName(GenericNameSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.TypeArgumentList?.Accept(this);

            base.VisitGenericName(node);
            
            PostVisit(node);
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitIdentifierName(node);
            
            PostVisit(node);
        }

        public override void VisitNameColon(NameColonSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitNameColon(node);
            
            PostVisit(node);
        }

        public override void VisitNameEquals(NameEqualsSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitNameEquals(node);
            
            PostVisit(node);
        }

        public override void VisitQualifiedName(QualifiedNameSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Right?.Accept(this);
            node.Left?.Accept(this);

            base.VisitQualifiedName(node);
            
            PostVisit(node);
        }
    }
}
