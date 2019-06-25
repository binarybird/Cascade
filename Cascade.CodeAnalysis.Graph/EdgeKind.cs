using System;
using System.Collections.Generic;
using System.Text;

namespace Cascade.CodeAnalysis.Graph
{
    public enum EdgeKind
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
}
