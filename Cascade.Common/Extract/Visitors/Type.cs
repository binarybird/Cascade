using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitArrayType(ArrayTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            node.ElementType?.Accept(this);
            foreach (ArrayRankSpecifierSyntax rankSpecifier in node.RankSpecifiers)
            {
                rankSpecifier.Accept(this);
            }

            base.VisitArrayType(node);
        }

        public override void VisitNullableType(NullableTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            node.ElementType?.Accept(this);

            base.VisitNullableType(node);
        }

        public override void VisitPointerType(PointerTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            node.ElementType?.Accept(this);

            base.VisitPointerType(node);
        }

        public override void VisitPredefinedType(PredefinedTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            base.VisitPredefinedType(node);
        }

        public override void VisitRefType(RefTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            node.Type?.Accept(this);

            base.VisitRefType(node);
        }

        public override void VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            node.Type?.Accept(this);

            base.VisitSimpleBaseType(node);
        }

        public override void VisitTupleType(TupleTypeSyntax node)
        {
            Information.Add(InfoExtractor.Info.TYPE, node);
            
            foreach (TupleElementSyntax elementSyntax in node.Elements)
            {
                elementSyntax.Accept(this);
            }

            base.VisitTupleType(node);
        }
    }
}
