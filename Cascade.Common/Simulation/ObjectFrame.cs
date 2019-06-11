using System;
using System.Threading;
using Cascade.Common.Extensions;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
{
    public class ObjectFrame : Frame
    {
        public string ObjectSignature { get; }

        public ObjectFrame(ISymbol symbol, Heap containingHeap) : base(symbol, containingHeap)
        {
            ITypeSymbol typeSymbol = symbol as ITypeSymbol;
            if (typeSymbol == null)
            {
                throw new Exception("Object frame must have a TypeSymbol");
            }

            ObjectSignature = typeSymbol.Name;//TODO - qualified sig
        }

        public ObjectFrame(string objectSignature, Heap containingHeap) : base(containingHeap)
        {
            ObjectSignature = objectSignature;
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