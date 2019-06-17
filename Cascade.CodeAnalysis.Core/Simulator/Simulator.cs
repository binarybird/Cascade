using System;
using System.Collections.Generic;
using System.Linq;
using Cascade.CodeAnalysis.Common.Collections;
using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NLog;

namespace Cascade.CodeAnalysis.Core.Simulator.Visitors
{
    public partial class Simulator : CSharpSyntaxVisitor<Evaluation>
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly Stack<Frame> _callStack = new Stack<Frame>();

        private readonly Compilation _comp;
        private readonly SyntaxNode _entryPoint;

        public Instance RootInstance { get; }
        public Frame EntryFrame { get; }

        public Simulator(Compilation comp, SyntaxNode entryPoint)
        {
            this._comp = comp;
            this._entryPoint = entryPoint;

            RootInstance = new Instance(new Heap("root"), null, entryPoint.GetSymbol(_comp).ContainingType, Node<Evaluation>.Kind.Root);
            EntryFrame = RootInstance.InstanceHeap.CreateFrame(_entryPoint.GetReference(), _comp, Node<Evaluation>.Kind.Root);

            GraphBuilder<Evaluation>.From(RootInstance.Node).Kind(Edge<Evaluation>.Kind.CreatesObject).To(RootInstance.Node);

            InitializeInstance(RootInstance);
        }

        public void SimulateFrame(Frame frame, params Instance[] args)
        {
            if (frame == null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            Log.Info("Simulating {0}", frame.ToString());

            FunctionalFrame functionalFrame = frame as FunctionalFrame;
            if (functionalFrame != null)
            {
                //TODO named args, parameterized args
                if (args != null && args.Length != functionalFrame.DeclaredArguments.Length)
                {
                    throw new ArgumentException("Unhandled argument length");
                }

                for (int i = 0; i < functionalFrame.DeclaredArguments.Length; i++)
                {
                    Identity newArgIdent = functionalFrame.DeclaredArguments[i];
                    Instance incommingInstance = args[i];

                    newArgIdent.IsDisposed = false;
                    incommingInstance.Identities.Push(newArgIdent);

                    functionalFrame.Instances.Add(incommingInstance);
                }
            }

            _callStack.Push(frame);

            foreach (SyntaxReference reference in frame.Symbol.DeclaringSyntaxReferences)
            {
                Visit(reference.GetSyntax());
            }

            if (functionalFrame != null)
            {
                foreach (Identity argument in functionalFrame.DeclaredArguments)
                {
                    argument.IsDisposed = true;
                }
            }

            _callStack.Pop();
        }

        public void InitializeInstance(Instance instance)
        {
            if (instance.DeclaredType?.IsStatic ?? false)
            {
                InitializeStaticMembers(instance);
            }
            else
            {
                InitializeInstanceMembers(instance);
            }
        }

        protected void InitializeStaticMembers(Instance instance)
        {
            foreach (ISymbol member in instance.DeclaredType.GetMembers())
            {
                if (!member.IsStatic || member is IMethodSymbol)
                {
                    continue;
                }

                Identity ident = new Identity(member, member.NodeKind(), instance.InstanceHeap.ObjectFrame);
                instance.InstanceHeap.ObjectFrame.CreateInstance(ident, member.NodeKind());
            }
        }

        protected void InitializeInstanceMembers(Instance instance)
        {
            if (instance == null)
            {
                return;
            }

            if (instance.HasBeenInitialized)
            {
                Log.Warn("Instance {0} has already been initialized, skipping...", instance);
                return;
            }

            foreach (ISymbol member in instance.DeclaredType.GetMembers())
            {
                if (member is IMethodSymbol)
                {
                    continue;
                }

                Identity ident = new Identity(member, member.NodeKind(), instance.InstanceHeap.ObjectFrame);
                instance.InstanceHeap.ObjectFrame.CreateInstance(ident, member.NodeKind());
            }

            instance.HasBeenInitialized = true;
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

        public override string ToString()
        {
            return String.Join("\n", _callStack);
        }
    }
}