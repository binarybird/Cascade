using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node)
        {
            node.Parameters?.Accept<Evaluation>(this);
            node.Type?.Accept<Evaluation>(this);

            return base.VisitConversionOperatorMemberCref(node);
        }

        public override Evaluation VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node)
        {
            foreach (CrefParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept<Evaluation>(this);
            }

            return base.VisitCrefBracketedParameterList(node);
        }

        public override Evaluation VisitCrefParameter(CrefParameterSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitCrefParameter(node);
        }

        public override Evaluation VisitCrefParameterList(CrefParameterListSyntax node)
        {
            foreach (CrefParameterSyntax parameter in node.Parameters)
            {
                parameter.Accept<Evaluation>(this);
            }
            
            return base.VisitCrefParameterList(node);
        }

        public override Evaluation VisitIndexerMemberCref(IndexerMemberCrefSyntax node)
        {
            node.Parameters?.Accept<Evaluation>(this);

            return base.VisitIndexerMemberCref(node);
        }

        public override Evaluation VisitNameMemberCref(NameMemberCrefSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);
            node.Parameters?.Accept<Evaluation>(this);
            
            return base.VisitNameMemberCref(node);
        }

        public override Evaluation VisitOperatorMemberCref(OperatorMemberCrefSyntax node)
        {
            node.Parameters?.Accept<Evaluation>(this);

            return base.VisitOperatorMemberCref(node);
        }

        public override Evaluation VisitQualifiedCref(QualifiedCrefSyntax node)
        {
            node.Container?.Accept<Evaluation>(this);
            node.Member?.Accept<Evaluation>(this);

            return base.VisitQualifiedCref(node);
        }

        public override Evaluation VisitTypeCref(TypeCrefSyntax node)
        {
            node.Type?.Accept<Evaluation>(this);

            return base.VisitTypeCref(node);
        }
    }
}
