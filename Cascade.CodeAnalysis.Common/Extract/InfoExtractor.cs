using System;
using Cascade.CodeAnalysis.Common.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Cascade.CodeAnalysis.Common.Extract.Visitors
{
    public partial class InfoExtractor : CSharpSyntaxVisitor
    {
        public enum Info
        {
            NAME,
            TYPE,
        }
        
        public MultiDictionary<Info, Object> Information = new MultiDictionary<Info, object>();

        public static MultiDictionary<Info, Object> ExtractInfo(SyntaxReference reference)
        {
            CSharpSyntaxNode node = reference.GetSyntax() as CSharpSyntaxNode;
            if (node == null)
            {
                throw new Exception("Invalid node type");
            }

            return ExtractInfo(node);
        }
        
        public static MultiDictionary<Info, Object> ExtractInfo(CSharpSyntaxNode node)
        {
            InfoExtractor ext = new InfoExtractor(node);
            node.Accept(ext);
            return ext.Information;
        }
        
        public InfoExtractor(CSharpSyntaxNode node)
        {
            node.Accept(this);
        }
    }
}