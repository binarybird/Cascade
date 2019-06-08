using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cascade.Common.Extensions;
using Microsoft.CodeAnalysis;
using static System.Reflection.MethodBase;

namespace Cascade.Common.Simulation
{
    public class Heap
    {
        public Instance OwningInstance { get; }
        public IList<FunctionalFrame> FunctionalFrames;
        public ObjectFrame ObjectFrame { get; }

        public Heap(string objectName)
        {
            ObjectFrame = new ObjectFrame(objectName, this);
        }

        public Heap(Instance owningInstance)
        {
            OwningInstance = owningInstance ?? throw new ArgumentNullException(nameof(owningInstance));

            if (owningInstance.Identities.Count != 0)
            {
                ObjectFrame = new ObjectFrame(owningInstance.Identities.Peek()?.Type, this);
            }
            else
            {
                //root "instance"
                ObjectFrame = new ObjectFrame("Object",this);
            }
        }

        public FunctionalFrame CreateFrame(SyntaxReference reference, Compilation compilation)
        {
            ISymbol symbol = reference.GetDeclaringSymbol(compilation);
            if (symbol == null)
            {
                symbol = reference.GetSymbolInfo(compilation).Symbol;
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

            FunctionalFrame ff = new FunctionalFrame(symbol, this);
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
            return $"Heap[]";
        }
    }
}