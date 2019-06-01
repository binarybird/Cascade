using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Core.Visitor.CSharp
{
    public partial class CSharpVisitor
    {
        public override void VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitXmlCDataSection(node);
            
            PostVisit(node);
        }

        public override void VisitXmlComment(XmlCommentSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitXmlComment(node);
            
            PostVisit(node);
        }

        public override void VisitXmlCrefAttribute(XmlCrefAttributeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Cref?.Accept(this);
            node.Name?.Accept(this);

            base.VisitXmlCrefAttribute(node);
            
            PostVisit(node);
        }

        public override void VisitXmlElement(XmlElementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.StartTag.Accept(this);
            foreach (XmlNodeSyntax syntax in node.Content)
            {
                syntax.Accept(this);
            }

            node.EndTag?.Accept(this);

            base.VisitXmlElement(node);
            
            PostVisit(node);
        }

        public override void VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitXmlElementEndTag(node);
            
            PostVisit(node);
        }

        public override void VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);
            foreach (XmlAttributeSyntax attribute in node.Attributes)
            {
                attribute.Accept(this);
            }

            base.VisitXmlElementStartTag(node);
            
            PostVisit(node);
        }

        public override void VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);
            foreach (XmlAttributeSyntax syntax in node.Attributes)
            {
                syntax.Accept(this);
            }

            base.VisitXmlEmptyElement(node);
            
            PostVisit(node);
        }

        public override void VisitXmlName(XmlNameSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Prefix?.Accept(this);

            base.VisitXmlName(node);
            
            PostVisit(node);
        }

        public override void VisitXmlNameAttribute(XmlNameAttributeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);
            node.Identifier?.Accept(this);

            base.VisitXmlNameAttribute(node);
            
            PostVisit(node);
        }

        public override void VisitXmlPrefix(XmlPrefixSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitXmlPrefix(node);
            
            PostVisit(node);
        }

        public override void VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitXmlProcessingInstruction(node);
            PostVisit(node);
            
        }

        public override void VisitXmlText(XmlTextSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            base.VisitXmlText(node);
            
            PostVisit(node);
        }

        public override void VisitXmlTextAttribute(XmlTextAttributeSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }
            
            node.Name?.Accept(this);

            base.VisitXmlTextAttribute(node);
            
            PostVisit(node);
        }
    }
}
