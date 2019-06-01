﻿using System;
using System.Collections.Generic;
using System.IO;
using Cascade.Core.Simulator;
using Cascade.Core.Simulator.Visitors;
using Cascade.Rule;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Targets;

namespace Cascade
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static readonly string SomeCode = 
        "namespace Org.Gscx.Analysis.Cli\n"+
        "{\n"+
            "class Program\n"+
            "{\n"+
                "static void Main(string[] args)\n"+
                "{\n"+
                    "Test()"+
                "}\n"+
                "static void Test()\n" +
                "{\n" +
                "}\n" +
            "}\n" +
        "}";

        public static void Main(string[] args)
        {
            InitLogger();
            CSharpCompilation comp = CSharpCompilation.Create("comp", Parse(SomeCode));

            EntryPointFinder finder = new EntryPointFinder();
            foreach (SyntaxTree tree in comp.SyntaxTrees)
            {
                finder.Visit(tree.GetRoot());
            }


            foreach (MethodDeclarationSyntax entryPoint in finder.EntryPoints)
            {
                Simulator sim = new Simulator(comp, entryPoint);
                sim.Analyze();

            }

            int y = 0;
        }

        static void InitLogger()
        {
            Console.WriteLine("Initializing logger");
            LoggingConfiguration config = new LoggingConfiguration();
            ConsoleTarget console = new ConsoleTarget()
            {
                Name = "console",
                Layout = @"[${longdate}] ${level:uppercase=true} ${logger}: ${message} ${exception}"
            };
            config.AddRule(LogLevel.Info, LogLevel.Fatal, console);
            LogManager.Configuration = config;
        }

        static IEnumerable<SyntaxTree> Parse(string code)
        {
            Log.Info("Parsing code");
            return new []{CSharpSyntaxTree.ParseText(SourceText.From(code), path: "")};
        }

        static IEnumerable<SyntaxTree> Parse(List<string> sources)
        {
            List<SyntaxTree> trees = new List<SyntaxTree>();
            foreach (string source in sources)
            {
                Log.Info("Parsing {0}", source);
                using (FileStream fs = File.OpenRead(source))
                {
                    trees.Add(CSharpSyntaxTree.ParseText(SourceText.From(fs), path: source));
                }
            }

            return trees;
        }
    }
}
