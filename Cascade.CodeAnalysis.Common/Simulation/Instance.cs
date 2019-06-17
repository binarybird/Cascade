using System;
using System.Collections.Generic;
using System.Linq;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public class Instance : Evaluation
    {
        //Instance are passed around and given different identities
        //Anon instances dont have identities

        private Stack<Identity> _identities = null;

        public Stack<Identity> Identities
        {
            get
            {
                if (_identities == null)
                {
                    _identities = new Stack<Identity>();
                }

                return _identities;
            }
        }

        public Heap InstanceHeap { get; }
        public Frame DeclaringFrame { get; }
        public ITypeSymbol DeclaredType { get; }
        public bool HasBeenInitialized { get; set; }
        public Node<Evaluation> Node { get; }

        public Instance(ITypeSymbol declaringType, Node<Evaluation>.Kind kind)
        {
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = new Heap(this);
            DeclaringFrame = null;
            HasBeenInitialized = false;
            Node = new Node<Evaluation>(kind, this);
        }

        public Instance(Frame declaringFrame, ITypeSymbol declaringType, Node<Evaluation>.Kind kind)
        {
            DeclaringFrame = declaringFrame;
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = new Heap(this);
            HasBeenInitialized = false;
            Node = new Node<Evaluation>(kind, this);
        }

        public Instance(Heap instanceHeap, Frame declaringFrame, ITypeSymbol declaringType, Node<Evaluation>.Kind kind)
        {
            DeclaringFrame = declaringFrame;
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = instanceHeap ?? throw new ArgumentNullException(nameof(declaringType));
            HasBeenInitialized = false;
            Node = new Node<Evaluation>(kind, this);
        }

        public override string ToString()
        {
            return $"Instance[Identities=\"{String.Join(", ", Identities.Select(s => s.ToString()))}\"]";
        }
    }
}