using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            node.Pattern?.Accept(this);
            node.WhenClause?.Accept(this);

            base.VisitCasePatternSwitchLabel(node);
        }

        public override void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            node.Value?.Accept(this);

            base.VisitCaseSwitchLabel(node);
        }

        public override void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            base.VisitDefaultSwitchLabel(node);
        }
    }
}
