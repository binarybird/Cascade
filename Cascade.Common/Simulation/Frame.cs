using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
using System.Linq;
using Cascade.Common.Collections;
using Cascade.Common.Extensions;
using Cascade.Common.Extract.Visitors;
using Microsoft.CodeAnalysis;

namespace Cascade.Common.Simulation
{
    public abstract class Frame : Evaluation
    {
        public ISymbol Symbol { get; }
        public ICollection<Instance> Instances { get; }
        public Heap ContainingHeap { get; }

        internal Frame(ISymbol symbol, Heap containingHeap)
        {
            Symbol = symbol;
            Instances = new List<Instance>();
            ContainingHeap = containingHeap;
        }

        public Instance CreateInstance(ITypeSymbol instanceType)
        {
            Instance instance = new Instance(this, instanceType);
            Instances.Add(instance);
            return instance;
        }

        public Instance CreateInstance(Identity identity)
        {
            Instance instance = new Instance(this, identity.Type);
            instance.Identities.Push(identity);
            Instances.Add(instance);

            return instance;
        }

//        public Instance CreateInstance(Identity identity, ITypeSymbol instanceType)
//        {
//            Instance instance = new Instance(this, instanceType);
//            instance.Identities.Push(identity);
//            Instances.Add(instance);
//
//            return instance;
//        }

        public Instance CreateInstance(ISymbol instanceDecl, ITypeSymbol instanceType, string identifier = null)
        {
            Instance instance = new Instance(this, instanceType);
            instance.Identities.Push(new Identity(this, instanceDecl, identifier));
            Instances.Add(instance);

            return instance;
        }

        public Instance CreateInstance(SyntaxReference reference, Compilation compilation, ITypeSymbol instanceType,
            string identifier = null)
        {
            Instance instance = new Instance(this, instanceType);
            instance.Identities.Push(new Identity(this, reference, compilation, identifier));
            Instances.Add(instance);

            return instance;
        }

        public IEnumerable<Instance> FindLocalInstance(Identity ident)
        {
            return Instances.Where(s =>
            {
                if (s.Identities.Any(q => q.Symbol.Equals(ident.Symbol)))
                {
                    return true;
                }

                if (s.Identities.Any(q => q.Identifier.Equals(ident.Identifier)))
                {
                    return true;
                }

                return false;
            });
        }

        public IEnumerable<Instance> FindLocalInstance(SyntaxReference reference, Compilation compilation)
        {
            ISymbol symbol = reference.GetDeclaringSymbol(compilation);
            if (symbol == null)
            {
                symbol = reference.GetSymbolInfo(compilation).Symbol;
            }

            if (symbol != null)
            {
                //Should we search the whole identity stack or just the top one or search via the frame?
                return Instances.Where(s =>
                {
                    if (s.Identities.Any(q => q.Symbol.Equals(symbol)))
                    {
                        return true;
                    }

                    return false;
                });
            }

            HashSet<Instance> found = new HashSet<Instance>();

            MultiDictionary<InfoExtractor.Info, object> info = InfoExtractor.ExtractInfo(reference);
            if (info.ContainsKey(InfoExtractor.Info.NAME))
            {
                foreach (Object n in info[InfoExtractor.Info.NAME])
                {
                    String name = n as string;
                    if (name == null)
                    {
                        continue;
                    }

                    foreach (Instance instance in FindLocalInstance(name))
                    {
                        found.Add(instance);
                    }
                }
            }

            return found;
        }

        public IEnumerable<Instance> FindLocalInstance(string identifier)
        {
            return Instances.Where(s =>
            {
                if (s.Identities.Any(q => q.Identifier.Equals(identifier)))
                {
                    return true;
                }

                return false;
            });
        }
    }
}