using Cascade.CodeAnalysis.Common.Roslyn;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Core.Simulator.Visitors;
using Cascade.Rule;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using Xunit;

namespace Cascade.CodeAnalysis.UnitTests
{
    public class SimpleRunThrough
    {
        private static readonly string SomeCode =
            "using System;\n" +
            "namespace Org.Gscx.Analysis.Cli\n" +
            "{\n" +
            "class Program\n" +
            "{\n" +
            "static string y = \"something\";\n" +
            "public string z = \"somethingElse\";\n" +
            "public Program(string[] newargs)\n" +
            "{\n" +
            "" +
            "}\n" +
            "static void Main(string[] args)\n" +
            "{\n" +
            "Test(args);\n" +
            "}\n" +
            "static void Test(string[] something)\n" +
            "{\n" +
            "Program p = new Program(something);\n" +
            "string x = p.z;\n" +
            "}\n" +
            "}\n" +
            "}";

        public SimpleRunThrough()
        {
            TestUtil.InitLogger();
        }

        [Fact]
        public void Test()
        {
            IEnumerable<SyntaxTree> syntaxTrees = SimpleParseUtil.Parse(SomeCode);
            MetadataReference[] references = SimpleCompileUtil.GetDefaultMetadataReferences();
            Compilation comp = SimpleCompileUtil.GetSimpleCSharpCompilation(syntaxTrees, references);

            EntryPointFinder finder = new EntryPointFinder();
            foreach (SyntaxTree tree in comp.SyntaxTrees)
            {
                finder.Visit(tree.GetRoot());
            }

            foreach (MethodDeclarationSyntax entryPoint in finder.EntryPoints)
            {
                Simulator sim = new Simulator(comp, entryPoint);

                INamedTypeSymbol arr = comp.GetSpecialType(SpecialType.System_Array);//TODO - array as instance?

                sim.SimulateFrame(sim.EntryFrame, new Instance(arr));
            }
        }
    }
}
