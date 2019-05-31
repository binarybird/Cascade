using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            node.Pattern?.Accept<Evaluation>(this);
            node.WhenClause?.Accept<Evaluation>(this);

            return base.VisitCasePatternSwitchLabel(node);
        }

        public override Evaluation VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            node.Value?.Accept<Evaluation>(this);

            return base.VisitCaseSwitchLabel(node);
        }

        public override Evaluation VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            return base.VisitDefaultSwitchLabel(node);
        }
    }
}
