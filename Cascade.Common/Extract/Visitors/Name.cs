using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            node.Alias?.Accept(this);
            node.Name?.Accept(this);

            base.VisitAliasQualifiedName(node);
        }

        public override void VisitGenericName(GenericNameSyntax node)
        {
            node.TypeArgumentList?.Accept(this);

            base.VisitGenericName(node);
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            Information.Add(InfoExtractor.Info.NAME, node.Identifier.Value);
            
            base.VisitIdentifierName(node);
        }

        public override void VisitNameColon(NameColonSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitNameColon(node);
        }

        public override void VisitNameEquals(NameEqualsSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitNameEquals(node);
        }

        public override void VisitQualifiedName(QualifiedNameSyntax node)
        {
            node.Right?.Accept(this);
            node.Left?.Accept(this);

            base.VisitQualifiedName(node);
        }
    }
}
