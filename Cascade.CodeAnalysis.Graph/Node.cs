using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class Node<T>
    {
        public enum Kind
        {
            Root,
            Namespace,
            Class,
            Functional,
            Delegate,
            Property,
            Field,
            LocalVariable,
            Enum,
            Collection,
        }

        public Kind NodeKind { get; }
        public T NodeInfo { get; }

        public IReadOnlyList<Edge<T>> Edges => _edges.AsReadOnly();
        private readonly List<Edge<T>> _edges = new List<Edge<T>>();

        public Node(Kind kind, T nodeInfo = default(T))
        {
            NodeKind = kind;
            NodeInfo = nodeInfo;
        }

        internal Edge<T> AddEdge(Edge<T>.Kind kind, params Node<T>[] to)
        {
            if (to == null || to.Length == 0)
            {
                throw new ArgumentNullException(nameof(to));
            }

            Edge<T> edge = new Edge<T>(kind, this, to);
            _edges.Add(edge);
            return edge;
        }
    }
}
