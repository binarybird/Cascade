using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class Node
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
        }

        public Kind NodeKind { get; }
        public Object NodeInfo { get; }

        public IReadOnlyCollection<Edge> Edges => new ReadOnlyCollection<Edge>(_edges);
        private readonly List<Edge> _edges = new List<Edge>();

        public Node(Kind kind, Object nodeInfo = null)
        {
            NodeKind = kind;
            NodeInfo = nodeInfo;
        }

        public Edge AddEdge(Edge.Kind kind, params Node[] to)
        {
            Edge edge = new Edge(kind, this, to);
            _edges.Add(edge);
            return edge;
        }
    }
}
