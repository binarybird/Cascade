using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Buildalyzer;
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

        public static SyntaxTree Parse(FileInfo source)
        {
            using (FileStream fs = File.OpenRead(source.FullName))
            {
                return CSharpSyntaxTree.ParseText(SourceText.From(fs), path: source.FullName);
            }
        }

        public IEnumerable<FileInfo> GetSources(FileInfo solution)
        {
            List<FileInfo> ret = new List<FileInfo>();

            AnalyzerManager manager = new AnalyzerManager(solution.FullName);
            foreach (KeyValuePair<string, ProjectAnalyzer> proj in manager.Projects)
            {
                ProjectAnalyzer analyzer = proj.Value;
                analyzer.IgnoreFaultyImports = true;
                if (analyzer.ProjectFile.RequiresNetFramework)
                {
                    throw new Exception(
                        ".NET Framework Solutions not supported. Please use a .NET Core Solution instead.");
                }

                AnalyzerResults results = analyzer.Build();
                foreach (string filePath in results.SelectMany(s => s.SourceFiles))
                {
                    if (!File.Exists(filePath))
                    {
                        throw new Exception($"Source file {filePath} is missing!");
                    }
                    ret.Add(new FileInfo(filePath));
                }
            }

            return ret;
        }
    }
}
