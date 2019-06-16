using Cascade.CodeAnalysis.Common.Simulation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.CodeAnalysis.Core.Simulator.Visitors
{
    partial class Simulator
    {
        public override Evaluation VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            return base.VisitXmlCDataSection(node);
        }

        public override Evaluation VisitXmlComment(XmlCommentSyntax node)
        {
            return base.VisitXmlComment(node);
        }

        public override Evaluation VisitXmlCrefAttribute(XmlCrefAttributeSyntax node)
        {
            node.Cref?.Accept<Evaluation>(this);
            node.Name?.Accept<Evaluation>(this);

            return base.VisitXmlCrefAttribute(node);
        }

        public override Evaluation VisitXmlElement(XmlElementSyntax node)
        {
            node.StartTag.Accept<Evaluation>(this);
            foreach (XmlNodeSyntax syntax in node.Content)
            {
                syntax.Accept<Evaluation>(this);
            }

            node.EndTag?.Accept<Evaluation>(this);

            return base.VisitXmlElement(node);
        }

        public override Evaluation VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitXmlElementEndTag(node);
        }

        public override Evaluation VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);
            foreach (XmlAttributeSyntax attribute in node.Attributes)
            {
                attribute.Accept<Evaluation>(this);
            }

            return base.VisitXmlElementStartTag(node);
        }

        public override Evaluation VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);
            foreach (XmlAttributeSyntax syntax in node.Attributes)
            {
                syntax.Accept<Evaluation>(this);
            }

            return base.VisitXmlEmptyElement(node);
        }

        public override Evaluation VisitXmlName(XmlNameSyntax node)
        {
            node.Prefix?.Accept<Evaluation>(this);

            return base.VisitXmlName(node);
        }

        public override Evaluation VisitXmlNameAttribute(XmlNameAttributeSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);
            node.Identifier?.Accept<Evaluation>(this);

            return base.VisitXmlNameAttribute(node);
        }

        public override Evaluation VisitXmlPrefix(XmlPrefixSyntax node)
        {
            return base.VisitXmlPrefix(node);
        }

        public override Evaluation VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitXmlProcessingInstruction(node);
        }

        public override Evaluation VisitXmlText(XmlTextSyntax node)
        {
            return base.VisitXmlText(node);
        }

        public override Evaluation VisitXmlTextAttribute(XmlTextAttributeSyntax node)
        {
            node.Name?.Accept<Evaluation>(this);

            return base.VisitXmlTextAttribute(node);
        }
    }
}
