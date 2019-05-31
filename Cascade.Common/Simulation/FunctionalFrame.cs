using System;
using Cascade.Common.Extensions;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
{
    public class FunctionalFrame : Frame
    {
        public MethodKind Kind { get; }
        public ITypeSymbol ReturnType { get; }

        public FunctionalFrame(ISymbol symbol, Heap containingHeap) : base(symbol, containingHeap)
        {
            IMethodSymbol methSymb = symbol as IMethodSymbol;
            if (methSymb == null)
            {
                throw new Exception("Functional frame must have a MethodSymbol");
            }
            
            Kind = methSymb.MethodKind;
            ReturnType = methSymb.ReturnType;
        }
        
        public override string ToString()
        {
            return $"Frame[Reciever=\"{Symbol.ToDisplayString(RoslynExtensions.TYPE_FMT)}\" Kind=\"{Kind}\"]";
        }
    }
}