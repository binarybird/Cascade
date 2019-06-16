using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Pattern?.Accept(this);
            node.WhenClause?.Accept(this);

            base.VisitCasePatternSwitchLabel(node);
            
            PostVisit(node);
        }

        public override void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Value?.Accept(this);

            base.VisitCaseSwitchLabel(node);
            
            PostVisit(node);
        }

        public override void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitDefaultSwitchLabel(node);
            
            PostVisit(node);
        }
    }
}
