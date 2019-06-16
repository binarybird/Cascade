using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitBadDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitDefineDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitDocumentationCommentTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitElifDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitElseDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitEndIfDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitEndRegionDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitErrorDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitIfDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitLineDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitLoadDirectiveTrivia(LoadDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitLoadDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitPragmaChecksumDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitPragmaWarningDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitReferenceDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitRegionDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitShebangDirectiveTrivia(ShebangDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitShebangDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitSkippedTokensTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitUndefDirectiveTrivia(node);
            
            PostVisit(node);
        }

        public override void VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitWarningDirectiveTrivia(node);
            
            PostVisit(node);
        }
    }
}
