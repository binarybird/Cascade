using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
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

        public Instance(ITypeSymbol declaringType)
        {
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = new Heap(this);
            DeclaringFrame = null;
            HasBeenInitialized = false;
        }

        public Instance(Frame declaringFrame, ITypeSymbol declaringType)
        {
            DeclaringFrame = declaringFrame;
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = new Heap(this);
            HasBeenInitialized = false;
        }

        public Instance(Heap instanceHeap, Frame declaringFrame, ITypeSymbol declaringType)
        {
            DeclaringFrame = declaringFrame;
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = instanceHeap ?? throw new ArgumentNullException(nameof(declaringType));
            HasBeenInitialized = false;
        }

        public override string ToString()
        {
            return $"Instance[Identities=\"{String.Join(", ", Identities.Select(s => s.ToString()))}\"]";
        }
    }
}