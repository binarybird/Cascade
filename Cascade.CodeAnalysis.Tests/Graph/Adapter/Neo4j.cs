using System;
using System.Collections.Generic;
using System.Text;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Core.Simulator.Visitors;
using Cascade.CodeAnalysis.Graph;
using Cascade.Rule;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit;
using Xunit.Abstractions;

namespace Cascade.CodeAnalysis.Tests.Graph.Adapter
{
    public class Neo4j : IntegrationTestBase
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

        public Neo4j(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void Test()
        {
            Compilation comp = GetCompilation(SomeCode);

            EntryPointFinder finder = new EntryPointFinder();
            foreach (SyntaxTree tree in comp.SyntaxTrees)
            {
                finder.Visit(tree.GetRoot());
            }

            List<Node<Evaluation>> simGraphs = new List<Node<Evaluation>>();
            foreach (MethodDeclarationSyntax entryPoint in finder.EntryPoints)
            {
                Simulator sim = new Simulator(comp, entryPoint);

                INamedTypeSymbol arr = comp.GetSpecialType(SpecialType.System_Array);//TODO - array as instance?

                sim.SimulateFrame(sim.EntryFrame, new Instance(arr, NodeKind.Root));

                simGraphs.Add(sim.StaticInstance.Node);
            }



        }
    }
}
