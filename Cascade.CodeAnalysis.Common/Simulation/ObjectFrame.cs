using System;
using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public class ObjectFrame : Frame
    {
        public string ObjectSignature { get; }
        public override Node<Evaluation> Node { get; }

        public ObjectFrame(ISymbol symbol, Heap containingHeap, NodeKind kind) : base(symbol, containingHeap)
        {
            ITypeSymbol typeSymbol = symbol as ITypeSymbol;
            if (typeSymbol == null)
            {
                throw new Exception("Object frame must have a TypeSymbol");
            }

            ObjectSignature = typeSymbol.Name;//TODO - qualified sig
            Node = new Node<Evaluation>(kind, this);
        }

        public ObjectFrame(string objectSignature, Heap containingHeap, NodeKind kind) : base(containingHeap)
        {
            ObjectSignature = objectSignature;
            Node = new Node<Evaluation>(kind, this);
        }

        public override bool Equals(object obj)
        {
            if (obj is ObjectFrame other)
            {
                throw new Exception("Not yet implemented");
                //todo object sig
                //return Symbol.OriginalDefinition.Equals(other.Symbol.OriginalDefinition);
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Frame[Type=\"{Symbol.ToDisplayString(RoslynExtensions.TYPE_FMT)}\"]";
        }
    }
}