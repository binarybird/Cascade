using System;
using System.Collections.Generic;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public enum NodeKind
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
}
