using System;
using System.Collections.Generic;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class Edge
    {
        public enum Kind
        {
            ElementAccess,
            ElementAssignment,
            MemberAccess,
            MemberAssignment,
            MemberInvocation,
            LocalAccess,
            LocalAssignment,
            ObjectCreation,
            Inherits,
            Overrides,
            Implements,
            Declares,
        }

        internal Edge(Kind kind, Node from, params Node[] to)
        {

        }
    }
}
