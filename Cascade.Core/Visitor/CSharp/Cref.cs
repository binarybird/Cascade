using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Parameters?.Accept(this);
            node.Type?.Accept(this);

            base.VisitConversionOperatorMemberCref(node);
            
            PostVisit(node);
        }

        public override void VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (CrefParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }

            base.VisitCrefBracketedParameterList(node);
            
            PostVisit(node);
        }

        public override void VisitCrefParameter(CrefParameterSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitCrefParameter(node);
            
            PostVisit(node);
        }

        public override void VisitCrefParameterList(CrefParameterListSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (CrefParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept(this);
            }
            
            base.VisitCrefParameterList(node);
            
            PostVisit(node);
        }

        public override void VisitIndexerMemberCref(IndexerMemberCrefSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Parameters?.Accept(this);

            base.VisitIndexerMemberCref(node);
            
            PostVisit(node);
        }

        public override void VisitNameMemberCref(NameMemberCrefSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);
            node.Parameters?.Accept(this);
            
            base.VisitNameMemberCref(node);
            
            PostVisit(node);
        }

        public override void VisitOperatorMemberCref(OperatorMemberCrefSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Parameters?.Accept(this);

            base.VisitOperatorMemberCref(node);
            
            PostVisit(node);
        }

        public override void VisitQualifiedCref(QualifiedCrefSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Container?.Accept(this);
            node.Member?.Accept(this);

            base.VisitQualifiedCref(node);
            
            PostVisit(node);
        }

        public override void VisitTypeCref(TypeCrefSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitTypeCref(node);
            
            PostVisit(node);
        }
    }
}
