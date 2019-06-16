using System.Collections.Generic;
using Cascade.CodeAnalysis.Graph;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public class EvaluationList : List<Evaluation>, Evaluation
    {
        public Node Node { get; set; }
    }
}
