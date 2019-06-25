using System;
using System.Collections.Generic;
using System.Linq;
using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public class Heap
    {
        public Instance OwningInstance { get; private set; }
        public IList<FunctionalFrame> FunctionalFrames;
        public ObjectFrame ObjectFrame { get; }

        public Heap(string objectName)
        {
            ObjectFrame = new ObjectFrame(objectName, this, NodeKind.Class);
        }

        public Heap(Instance owningInstance)
        {
            OwningInstance = owningInstance ?? throw new ArgumentNullException(nameof(owningInstance));

            if (owningInstance.Identities.Count != 0)
            {
                ObjectFrame = new ObjectFrame(owningInstance.Identities.Peek()?.Type, this, NodeKind.Class);
            }
            else
            {
                //root "instance"
                ObjectFrame = new ObjectFrame("Object", this, NodeKind.Class);
            }
        }

        internal void SetOwningInstance(Instance instance)
        {
            OwningInstance = instance;
        }

        public FunctionalFrame CreateFrame(SyntaxReference reference, Compilation compilation, NodeKind kind)
        {
            ISymbol symbol = reference.GetSymbol(compilation);
            if (!(symbol is IMethodSymbol meth))
            {
                throw new ArgumentNullException(nameof(symbol), "Unhandled symbol for FunctionalFrame");
            }

            if (FunctionalFrames == null)
            {
                FunctionalFrames = new List<FunctionalFrame>();
            }
            else
            {
                IEnumerable<FunctionalFrame> functionalFrames =
                    FunctionalFrames.Where(w => w.Symbol.Equals(symbol)).ToList();
                if (functionalFrames.Any())
                {
                    return functionalFrames.First();
                }
            }

            Identity[] argIdents = meth.Parameters.Select(s =>
            {
                SyntaxReference paramRef = s.DeclaringSyntaxReferences.FirstOrDefault();
                return new Identity(paramRef, compilation, kind, manualIdentifier: s.Name);
            }).ToArray();

            FunctionalFrame ff = new FunctionalFrame(symbol, this, kind, argIdents);
            FunctionalFrames.Add(ff);

            return ff;
        }

        public ICollection<Instance> FindInstance(Identity ident)
        {
            List<Instance> ret = new List<Instance>();
            foreach (FunctionalFrame frame in FunctionalFrames)
            {
                ret.AddRange(frame.FindLocalInstance(ident));
            }

            ret.AddRange(ObjectFrame.FindLocalInstance(ident));

            return ret;
        }

        public ICollection<Instance> FindInstance(SyntaxReference reference, Compilation compilation)
        {
            List<Instance> ret = new List<Instance>();
            foreach (FunctionalFrame frame in FunctionalFrames)
            {
                ret.AddRange(frame.FindLocalInstance(reference, compilation));
            }

            ret.AddRange(ObjectFrame.FindLocalInstance(reference, compilation));

            return ret;
        }

        public override string ToString()
        {
            return $"Heap[OwningInstance={OwningInstance}, FunctionalFrameCount={FunctionalFrames.Count}]";
        }
    }
}