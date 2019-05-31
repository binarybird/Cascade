using Cascade.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node)
        {
            return base.VisitBadDirectiveTrivia(node);
        }

        public override Evaluation VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node)
        {
            return base.VisitDefineDirectiveTrivia(node);
        }

        public override Evaluation VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            return base.VisitDocumentationCommentTrivia(node);
        }

        public override Evaluation VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            return base.VisitElifDirectiveTrivia(node);
        }

        public override Evaluation VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
        {
            return base.VisitElseDirectiveTrivia(node);
        }

        public override Evaluation VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node)
        {
            return base.VisitEndIfDirectiveTrivia(node);
        }

        public override Evaluation VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            return base.VisitEndRegionDirectiveTrivia(node);
        }

        public override Evaluation VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node)
        {
            return base.VisitErrorDirectiveTrivia(node);
        }

        public override Evaluation VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
        {
            return base.VisitIfDirectiveTrivia(node);
        }

        public override Evaluation VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node)
        {
            return base.VisitLineDirectiveTrivia(node);
        }

        public override Evaluation VisitLoadDirectiveTrivia(LoadDirectiveTriviaSyntax node)
        {
            return base.VisitLoadDirectiveTrivia(node);
        }

        public override Evaluation VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node)
        {
            return base.VisitPragmaChecksumDirectiveTrivia(node);
        }

        public override Evaluation VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
        {
            return base.VisitPragmaWarningDirectiveTrivia(node);
        }

        public override Evaluation VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node)
        {
            return base.VisitReferenceDirectiveTrivia(node);
        }

        public override Evaluation VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            return base.VisitRegionDirectiveTrivia(node);
        }

        public override Evaluation VisitShebangDirectiveTrivia(ShebangDirectiveTriviaSyntax node)
        {
            return base.VisitShebangDirectiveTrivia(node);
        }

        public override Evaluation VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node)
        {
            return base.VisitSkippedTokensTrivia(node);
        }

        public override Evaluation VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node)
        {
            return base.VisitUndefDirectiveTrivia(node);
        }

        public override Evaluation VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node)
        {
            return base.VisitWarningDirectiveTrivia(node);
        }
    }
}
