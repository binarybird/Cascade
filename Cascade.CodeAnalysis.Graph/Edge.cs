using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class Edge
    {
        public enum Kind
        {
            AccessesElement,
            AssignsElement,
            AccessesMember,
            AssignsMember,
            InvokesMember,
            AccessesLocal,
            AssignsLocal,
            CreatesObject,
            Inherits,
            Overrides,
            Implements,
            Declares,
            InstanceOwns,
            Initializes,
        }

        public IReadOnlyCollection<Node> ToNodes { get; }
        public Node FromNode { get; }

        public Kind EdgeKind { get; }

        internal Edge(Kind kind, Node from, params Node[] to)
        {
            ToNodes = new ReadOnlyCollection<Node>(to);
            FromNode = from;
            EdgeKind = kind;
        }
    }
}