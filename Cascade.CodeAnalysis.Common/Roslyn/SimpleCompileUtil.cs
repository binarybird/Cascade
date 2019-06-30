using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Buildalyzer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NLog;

namespace Cascade.CodeAnalysis.Common.Roslyn
{
    public class SimpleCompileUtil
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static CSharpCompilation GetSimpleCSharpCompilation(IEnumerable<SyntaxTree> trees,
            IEnumerable<MetadataReference> references, CSharpCompilationOptions options = null)
        { 
            if (options == null)
            {
                options = new CSharpCompilationOptions(allowUnsafe: true, outputKind: OutputKind.ConsoleApplication);
            }

            return CSharpCompilation.Create("simplecomp", trees, references, options: options);
        }

        public static MetadataReference[] GetMetadataReferencesFromSolution(FileInfo solution)
        {
            List<MetadataReference> ret = new List<MetadataReference>();

            //We are using Buildalyzer because it is xplat
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
                foreach (string filePath in results.SelectMany(s=>s.References))//TODO - are these all references? Research needed
                {
                    if (!File.Exists(filePath))
                    {
                        Log.Warn("Library {0} is missing. Did you restore the Solution libraries?");
                    }
                    ret.Add(MetadataReference.CreateFromFile(filePath));
                }
            }

            return ret.ToArray();
        }

        public static FileInfo[] GetSourcesFromSolution(FileInfo solution)
        {
            List<FileInfo> ret = new List<FileInfo>();

            //We are using Buildalyzer because it is xplat
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
                        Log.Warn("Source file {0} is missing.");
                    }
                    ret.Add(new FileInfo(filePath));
                }
            }

            return ret.ToArray();
        }

        public static MetadataReference[] GetDefaultMetadataReferences()
        {
            return new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(System.String).Assembly.Location),
            };
        }
    }
}