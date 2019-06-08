﻿using System;
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

        public Heap RootHeap { get; }
        public Frame EntryFrame { get; }

        public Simulator(Compilation comp, SyntaxNode entryPoint)
        {
            this._comp = comp;
            this._entryPoint = entryPoint;

            RootHeap = new Heap("root");
            EntryFrame = RootHeap.CreateFrame(_entryPoint.GetReference(), _comp);
        }

        public void SimulateFrame(Frame frame)
        {
            if (frame == null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            if (frame.Symbol.IsStatic)
            {
                InitializeStaticMembers(frame.ContainingHeap, frame.Symbol.ContainingType);//containing type or symbol.recievertype?
            }
            else
            {
                InitializeInstance(frame.ContainingHeap.OwningInstance);
            }

            _callStack.Push(frame);

            foreach (SyntaxReference reference in frame.Symbol.DeclaringSyntaxReferences)
            {
                Visit(reference.GetSyntax());
            }

            _callStack.Pop();
        }

        public void InitializeStaticMembers(Heap heap, ITypeSymbol type)
        {
            foreach (ISymbol member in type.GetMembers())
            {
                if (!member.IsStatic || member is IMethodSymbol)
                {
                    continue;
                }

                Identity ident = new Identity(RootHeap.ObjectFrame, member);
                heap.ObjectFrame.CreateInstance(ident);
            }
        }

        public void InitializeInstance(Instance instance)
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

                Identity ident = new Identity(instance.InstanceHeap.ObjectFrame, member);
                instance.InstanceHeap.ObjectFrame.CreateInstance(ident);
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
    }
}
