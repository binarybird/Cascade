using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cascade.Core.Visitor.CSharp;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cascade.Rule
{
    public class EntryPointFinder : CSharpVisitor
    {
        public ICollection<MethodDeclarationSyntax> EntryPoints { get; }
        private readonly string[] _simpleNames = { "Main", "EntryPoint" };

        public EntryPointFinder()
        {
            EntryPoints = new List<MethodDeclarationSyntax>();
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (!PreVisit(node))
            {
                return;
            }

            if (_simpleNames.Any(a => Regex.Match(node.Identifier.ValueText, a).Success))
            {
                EntryPoints.Add(node);
            }

            PostVisit(node);
        }
    }
}
