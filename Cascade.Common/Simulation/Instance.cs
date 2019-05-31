﻿using System;
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

        internal Instance(Frame declaringFrame, ITypeSymbol declaringType)
        {
            DeclaringFrame = declaringFrame ?? throw new ArgumentNullException(nameof(declaringFrame));
            DeclaredType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            InstanceHeap = new Heap(this);
        }

        public override string ToString()
        {
            return $"Instance[Identities=\"{String.Join(", ", Identities.Select(s => s.ToString()))}\"]";
        }
    }
}