using System;
using System.Collections.Generic;
using System.Linq;
using Cascade.Common.Collections;
using Cascade.Common.Extensions;
using Cascade.Common.Simulation;
using Cascade.Graph;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NLog;

namespace Cascade.Core.Simulator.Visitors
{
    public partial class Simulator : CSharpSyntaxVisitor<Evaluation>
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly Stack<Frame> _callStack = new Stack<Frame>();
        private readonly MultiDictionary<SyntaxReference, CodeGraph> _graphs = new MultiDictionary<SyntaxReference, CodeGraph>();
        private readonly Compilation _comp;
        private readonly SyntaxNode _entryPoint;
        private readonly Heap _rootHeap;

        public Simulator(Compilation comp, SyntaxNode entryPoint)
        {
            this._comp = comp;
            this._entryPoint = entryPoint;
            this._rootHeap = new Heap(null);   
        }

        public void Analyze()
        {
            Frame entry = _rootHeap.CreateFrame(_entryPoint.GetReference(), _comp);
            SimulateFrame(entry);
        }

        public void SimulateFrame(Frame frame)
        {
            InitializeInstance(frame.ContainingHeap.OwningInstance);
            
            _callStack.Push(frame);

            foreach (SyntaxReference reference in frame.Symbol.DeclaringSyntaxReferences)
            {
                Visit(reference.GetSyntax());
            }

            _callStack.Pop();
        }

        public void InitializeInstance(Instance instance)
        {
            if (instance == null)
            {
                return;
            }

            foreach (SyntaxReference reference in instance.DeclaredType.DeclaringSyntaxReferences)
            {
                //TODO - initialize inherited
                
                ClassDeclarationSyntax syntaxNode = reference.GetSyntax() as ClassDeclarationSyntax;
                if (syntaxNode == null)
                {
                    Log.Info("Cannot initialize instance {0}", instance);
                    continue;
                }

                foreach (MemberDeclarationSyntax member in syntaxNode.Members)
                {
                    InitializeMember(member, instance.InstanceHeap.ObjectFrame);
                }
            }
        }

        private void InitializeMember(MemberDeclarationSyntax member, ObjectFrame objFrame)
        {
            if (member is FieldDeclarationSyntax field)
            {
                foreach (VariableDeclaratorSyntax variable in field.Declaration.Variables)
                {
                    IFieldSymbol symb = variable.GetDeclaringSymbol(_comp) as IFieldSymbol;
                    if (symb == null)
                    {
                        Log.Error("Cannot resolve field");
                        continue;
                    }

                    Instance instance = objFrame.CreateInstance(symb, symb.Type, variable.Identifier.ValueText);
                    int y = 0;
                }
            } else if (member is PropertyDeclarationSyntax prop)
            {
                
                IPropertySymbol t = prop.GetDeclaringSymbol(_comp) as IPropertySymbol;
                int y = 0;
            }
            else
            {
                Log.Warn("Not initializing {0}", member);
            }
        }
        
        public IEnumerable<Instance> FindInstance(Identity ident, int depth = -1)
        {
            if (ident == null)
            {
                throw new ArgumentNullException(nameof(ident));
            } 
            
            if (depth < 0)
            {
                depth = _callStack.Count;
            }

            IEnumerable<Instance> ret = null;
            using (Stack<Frame>.Enumerator enumerator = _callStack.GetEnumerator())
            {
                while (ret == null && enumerator.MoveNext() && depth > 0)
                {
                    depth--;
                    Frame currentFrame = enumerator.Current;
                    if (currentFrame == null)
                    {
                        continue;
                    }

                    IEnumerable<Instance> instances = currentFrame.FindLocalInstance(ident);
                    if (!instances.Any())
                    {
                        instances = currentFrame.ContainingHeap.ObjectFrame.FindLocalInstance(ident);
                    }

                    if (instances.Any())
                    {
                        ret = instances;
                    }
                }
            }

            if (ret == null)
            {
                ret = Enumerable.Empty<Instance>();
            }
            
            return ret;
        }

        public IEnumerable<Instance> FindInstance(SyntaxReference node, int depth = -1)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }   
            
            if (depth < 0)
            {
                depth = _callStack.Count;
            }
            
            Stack<Frame>.Enumerator enumerator = _callStack.GetEnumerator();

            IEnumerable<Instance> ret = null;
            while (ret == null && enumerator.MoveNext() && depth > 0)
            {
                depth--;
                Frame currentFrame = enumerator.Current;
                if (currentFrame == null)
                {
                    continue;
                }
                
                IEnumerable<Instance> instances = currentFrame.FindLocalInstance(node, _comp);
                if (!instances.Any())
                {
                    instances = currentFrame.ContainingHeap.ObjectFrame.FindLocalInstance(node, _comp);
                }

                if (instances.Any())
                {
                    ret = instances;
                }
            }
            
            enumerator.Dispose();

            return ret;
        }
    }
}
