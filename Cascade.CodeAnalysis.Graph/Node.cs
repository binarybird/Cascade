using System;
using System.Collections.Generic;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public class Node
    {
        public enum Kind
        {
            Namespace,
            Class,
            Functional,
            Delegate,
            Property,
            Field,
            LocalVariable,
        }
    }
}
