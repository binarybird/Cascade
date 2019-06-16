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
            ElementRead,
            ElementWrite,
            MemberAccess,
            MemberRead,
            MemberWrite,
            MemberInvocation,
            TypeCreation,
            Inherits,
            Overrides,
            Implements,
            Declares,
        }
    }
}
