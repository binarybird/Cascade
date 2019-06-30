using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cascade.CodeAnalysis.Common.Roslyn;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Core.Simulator.Visitors;
using Cascade.CodeAnalysis.Graph;
using Cascade.Rule;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit.Abstractions;

namespace Cascade.CodeAnalysis.Tests
{
    public abstract class IntegrationTestBase : TestBase
    {
        internal IntegrationTestBase(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        protected Compilation GetCompilation(FileInfo codePath, MetadataReference[] references = null)
        {
            SyntaxTree syntaxTrees = SimpleParseUtil.Parse(codePath);
            references = references ?? SimpleCompileUtil.GetDefaultMetadataReferences();
            Compilation comp = SimpleCompileUtil.GetSimpleCSharpCompilation(new []{syntaxTrees}, references);
            return comp;
        }

        protected Compilation GetCompilation(string code, MetadataReference[] references = null)
        {
            IEnumerable<SyntaxTree> syntaxTrees = SimpleParseUtil.Parse(code);
            references = references ?? SimpleCompileUtil.GetDefaultMetadataReferences();
            Compilation comp = SimpleCompileUtil.GetSimpleCSharpCompilation(syntaxTrees, references);
            return comp;
        }

        protected Compilation GetSolutionCompilation(FileInfo solution)
        {
            MetadataReference[] references = SimpleCompileUtil.GetMetadataReferencesFromSolution(solution);
            FileInfo[] sources = SimpleCompileUtil.GetSourcesFromSolution(solution);

            List<SyntaxTree> trees = new List<SyntaxTree>();
            foreach (FileInfo source in sources)
            {
                trees.Add(SimpleParseUtil.Parse(source));
            }

            CSharpCompilation comp = SimpleCompileUtil.GetSimpleCSharpCompilation(trees, references);
            return comp;
        }

    }
}
