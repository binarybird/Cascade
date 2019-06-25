using System.Collections.Generic;
using Cascade.CodeAnalysis.Graph;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public class EvaluationList : List<Evaluation>, Evaluation
    {
        public Node<Evaluation> Node { get; }

        public EvaluationList()
        {
            Node = new Node<Evaluation>(NodeKind.Collection, this);
        }
    }
}
