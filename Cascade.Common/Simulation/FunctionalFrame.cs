using System;
using System.Linq;
using Cascade.Common.Extensions;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
{
    public class FunctionalFrame : Frame
    {
        public MethodKind Kind { get; }
        public ITypeSymbol ReturnType { get; }
        public Identity[] DeclaredArguments { get; }

        public FunctionalFrame(ISymbol symbol, Heap containingHeap, params Identity[] args) : base(symbol, containingHeap)
        {
            IMethodSymbol methSymb = symbol as IMethodSymbol;
            if (methSymb == null)
            {
                throw new Exception("Functional frame must have a MethodSymbol");
            }

            Kind = methSymb.MethodKind;
            ReturnType = methSymb.ReturnType;
            DeclaredArguments = args;
            foreach (Identity argument in DeclaredArguments)
            {
                if (argument.Frame != null)
                {
                    continue;
                }

                argument.Frame = this;
            }
        }
        public FunctionalFrame(string signature, string returnType, string recieverType, Heap containingHeap, params Identity[] args) : base(containingHeap)
        {
            throw new Exception("Not yet implemented");
            //todo sigs
        }

        public override bool Equals(object obj)
        {
            if (obj is FunctionalFrame other)
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
            string args = DeclaredArguments == null ? "" : String.Join(", ", (object[]) DeclaredArguments);
            return $"Frame[Receiver=\"{Symbol.ToDisplayString(RoslynExtensions.TYPE_FMT)}\" Kind=\"{Kind}\" Args=\"{args}\"]";
        }
    }
}