using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using NLog;

namespace Cascade.CodeAnalysis.Common.Simulation
{
    public interface Evaluation
    {

    }

    public static class EvaluationUtil
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static IList<T> From<T>(IEnumerable<Evaluation> evals) where T : Evaluation
        {
            if (evals == null)
            {
                return ImmutableList<T>.Empty;
            }

            List<T> ret = new List<T>();
            foreach (Evaluation arg in evals)
            {
                if (!(arg is T instance))
                {
                    throw new ArgumentException("Unexpected argument!");
                }

                ret.Add(instance);
            }

            return ret;
        }
    }
}