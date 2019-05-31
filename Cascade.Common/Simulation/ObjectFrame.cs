using System;
using Cascade.Common.Extensions;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
{
    public class ObjectFrame : Frame
    {
        public ObjectFrame(ISymbol symbol, Heap containingHeap) : base(symbol, containingHeap)
        {
            ITypeSymbol typeSymbol = symbol as ITypeSymbol;
            if (typeSymbol == null)
            {
                throw new Exception("Object frame must have a TypeSymbol");
            }
        }
        
        internal ObjectFrame(Heap containingHeap) : base(null, containingHeap)
        {
            
        }
        
        public override string ToString()
        {
            return $"Frame[Type=\"{Symbol.ToDisplayString(RoslynExtensions.TYPE_FMT)}\"]";
        }
    }
}