using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Cascade.CodeAnalysis.Common.Collections;
using Cascade.CodeAnalysis.Common.Extensions;
using Cascade.CodeAnalysis.Common.Extract;
using Cascade.CodeAnalysis.Common.Extract.Visitors;
using Cascade.CodeAnalysis.Graph;
using Microsoft.CodeAnalysis;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public abstract class Frame : Evaluation
    {
        public ISymbol Symbol { get; }
        public ICollection<Instance> Instances { get; }
        public Heap ContainingHeap { get; }
        public abstract Node<Evaluation> Node { get; }

        internal Frame(ISymbol symbol, Heap containingHeap)
        {
            Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
            Instances = new List<Instance>();
            ContainingHeap = containingHeap;
        }

        protected internal Frame(Heap containingHeap)
        {
            Instances = new List<Instance>();
            ContainingHeap = containingHeap;
        }

        public Instance CreateInstance(ITypeSymbol instanceType, NodeKind kind)
        {
            Instance instance = new Instance(this, instanceType, kind);
            Instances.Add(instance);
            return instance;
        }

        public Instance CreateInstance(Identity identity, NodeKind kind)
        {
            Instance instance = new Instance(this, identity.Type, kind);
            instance.Identities.Push(identity);
            Instances.Add(instance);

            return instance;
        }

        public Instance CreateInstance(ISymbol instanceDecl, ITypeSymbol instanceType, NodeKind kind, string identifier = null)
        {
            Instance instance = new Instance(this, instanceType, kind);
            instance.Identities.Push(new Identity(instanceDecl, kind, this, identifier));
            Instances.Add(instance);

            return instance;
        }

        public Instance CreateInstance(SyntaxReference reference, Compilation compilation, ITypeSymbol instanceType, NodeKind kind,
            string identifier = null)
        {
            Instance instance = new Instance(this, instanceType, kind);
            instance.Identities.Push(new Identity(reference, compilation, kind, this, identifier));
            Instances.Add(instance);

            return instance;
        }

        public IEnumerable<Instance> FindLocalInstance(Identity ident)
        {
            if (ident == null)
            {
                return ImmutableArray<Instance>.Empty;
            }

            return Instances.Where(s =>
            {
                if (s.Identities.Any(q => q.Symbol.Equals(ident.Symbol)))//TODO Identity.Equals()??
                {
                    return true;
                }

                if (s.Identities.Any(q => q.EqualsIdentifier(ident.Identifier) || ident.EqualsIdentifier(q.Identifier)))//TODO Identity.Equals()??
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
                if (s.Identities.Any(q => q.EqualsIdentifier(identifier)))//TODO Identity.Equals()??
                {
                    return true;
                }

                return false;
            });
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Frame other))
            {
                return false;
            }

            return Symbol?.OriginalDefinition.Equals(other.Symbol?.OriginalDefinition) ?? false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}