using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node)
        {
            node.Parameters?.Accept(this);
            node.Type?.Accept(this);

            base.VisitConversionOperatorMemberCref(node);
        }

        public override void VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node)
        {
            foreach (CrefParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }

            base.VisitCrefBracketedParameterList(node);
        }

        public override void VisitCrefParameter(CrefParameterSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitCrefParameter(node);
        }

        public override void VisitCrefParameterList(CrefParameterListSyntax node)
        {
            foreach (CrefParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }
            
            base.VisitCrefParameterList(node);
        }

        public override void VisitIndexerMemberCref(IndexerMemberCrefSyntax node)
        {
            node.Parameters?.Accept(this);

            base.VisitIndexerMemberCref(node);
        }

        public override void VisitNameMemberCref(NameMemberCrefSyntax node)
        {
            node.Name?.Accept(this);
            node.Parameters?.Accept(this);
            
            base.VisitNameMemberCref(node);
        }

        public override void VisitOperatorMemberCref(OperatorMemberCrefSyntax node)
        {
            node.Parameters?.Accept(this);

            base.VisitOperatorMemberCref(node);
        }

        public override void VisitQualifiedCref(QualifiedCrefSyntax node)
        {
            node.Container?.Accept(this);
            node.Member?.Accept(this);

            base.VisitQualifiedCref(node);
        }

        public override void VisitTypeCref(TypeCrefSyntax node)
        {
            node.Type?.Accept(this);

            base.VisitTypeCref(node);
        }
    }
}
