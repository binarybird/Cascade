using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitArrayType(ArrayTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ElementType?.Accept(this);
            foreach (ArrayRankSpecifierSyntax rankSpecifier in node.RankSpecifiers)
            {
                rankSpecifier.Accept(this);
            }

            base.VisitArrayType(node);
            
            PostVisit(node);
        }

        public override void VisitNullableType(NullableTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ElementType?.Accept(this);

            base.VisitNullableType(node);
            
            PostVisit(node);
        }

        public override void VisitPointerType(PointerTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.ElementType?.Accept(this);

            base.VisitPointerType(node);
            
            PostVisit(node);
        }

        public override void VisitPredefinedType(PredefinedTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitPredefinedType(node);
            
            PostVisit(node);
        }

        public override void VisitRefType(RefTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitRefType(node);
            
            PostVisit(node);
        }

        public override void VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Type?.Accept(this);

            base.VisitSimpleBaseType(node);
            
            PostVisit(node);
        }

        public override void VisitTupleType(TupleTypeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            foreach (TupleElementSyntax elementSyntax in node.Elements)
            {
                elementSyntax.Accept(this);
            }

            base.VisitTupleType(node);
            
            PostVisit(node);
        }
    }
}
