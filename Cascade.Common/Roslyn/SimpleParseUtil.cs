using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using NLog.Fluent;

namespace Cascade.CodeAnalysis.Common.Roslyn
{
    public class SimpleParseUtil
    {
        public static IEnumerable<SyntaxTree> Parse(string code)
        {
            return new[] { CSharpSyntaxTree.ParseText(SourceText.From(code), path: "") };
        }

        public static IEnumerable<SyntaxTree> Parse(List<FileInfo> sources)
        {
            List<SyntaxTree> trees = new List<SyntaxTree>();
            foreach (FileInfo source in sources)
            {
                using (FileStream fs = File.OpenRead(source.FullName))
                {
                    trees.Add(CSharpSyntaxTree.ParseText(SourceText.From(fs), path: source.FullName));
                }
            }

            return trees;
        }
    }
}
