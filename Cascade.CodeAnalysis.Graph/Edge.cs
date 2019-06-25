using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class Edge<T>
    {
        public IReadOnlyCollection<Node<T>> ToNodes { get; }
        public Node<T> FromNode { get; }

        public EdgeKind EdgeKind { get; }

        internal Edge(EdgeKind kind, Node<T> from, params Node<T>[] to)
        {
            ToNodes = new ReadOnlyCollection<Node<T>>(to);
            FromNode = from;
            EdgeKind = kind;
        }

        public override string ToString()
        {
            return $"Edge[Kind=\"{EdgeKind}\", From=\"{FromNode}\", To=\"{String.Join(", ",ToNodes)}\"]";
        }
    }
}