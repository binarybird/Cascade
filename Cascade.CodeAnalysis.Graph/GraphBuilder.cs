using System;
using System.Collections.Generic;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class GraphBuilder<T>
    {
        private Node<T> _node;
        private Edge<T>.Kind _kind;

        public static GraphBuilder<T> From(Node<T> node)
        {
            GraphBuilder<T> builder = new GraphBuilder<T>();

            builder._node = node ?? throw new ArgumentNullException(nameof(node));

            return builder;
        }

        public GraphBuilder<T> Kind(Edge<T>.Kind kind)
        {
            if (kind == default)
            {
                throw new ArgumentNullException(nameof(kind));
            }
            this._kind = kind;
            return this;
        }

        public void To(params Node<T>[] nodes)
        {
            if (nodes == null || nodes.Length == 0)
            {
                throw new ArgumentNullException(nameof(nodes));
            }
            _node.AddEdge(_kind, nodes);
        }
    }
}
