using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Common.Extract.Visitors
{
    partial class InfoExtractor
    {
        public override void VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            base.VisitXmlCDataSection(node);
        }

        public override void VisitXmlComment(XmlCommentSyntax node)
        {
            base.VisitXmlComment(node);
        }

        public override void VisitXmlCrefAttribute(XmlCrefAttributeSyntax node)
        {
            node.Cref?.Accept(this);
            node.Name?.Accept(this);

            base.VisitXmlCrefAttribute(node);
        }

        public override void VisitXmlElement(XmlElementSyntax node)
        {
            node.StartTag.Accept(this);
            foreach (XmlNodeSyntax syntax in node.Content)
            {
                syntax.Accept(this);
            }

            node.EndTag?.Accept(this);

            base.VisitXmlElement(node);
        }

        public override void VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitXmlElementEndTag(node);
        }

        public override void VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            node.Name?.Accept(this);
            foreach (XmlAttributeSyntax attribute in node.Attributes)
            {
                attribute.Accept(this);
            }

            base.VisitXmlElementStartTag(node);
        }

        public override void VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            node.Name?.Accept(this);
            foreach (XmlAttributeSyntax syntax in node.Attributes)
            {
                syntax.Accept(this);
            }

            base.VisitXmlEmptyElement(node);
        }

        public override void VisitXmlName(XmlNameSyntax node)
        {
            node.Prefix?.Accept(this);

            base.VisitXmlName(node);
        }

        public override void VisitXmlNameAttribute(XmlNameAttributeSyntax node)
        {
            node.Name?.Accept(this);
            node.Identifier?.Accept(this);

            base.VisitXmlNameAttribute(node);
        }

        public override void VisitXmlPrefix(XmlPrefixSyntax node)
        {
            base.VisitXmlPrefix(node);
        }

        public override void VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitXmlProcessingInstruction(node);
        }

        public override void VisitXmlText(XmlTextSyntax node)
        {
            base.VisitXmlText(node);
        }

        public override void VisitXmlTextAttribute(XmlTextAttributeSyntax node)
        {
            node.Name?.Accept(this);

            base.VisitXmlTextAttribute(node);
        }
    }
}
