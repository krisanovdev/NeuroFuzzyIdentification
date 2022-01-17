using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCalculateIt.Supplementary;

namespace JustCalculateIt.RAlgorithm
{
    public static partial class Solver
    {
        public class IterationData
        {
            public int IterationNumber { get; set; }
            public Vector Vector { get; set; }

            public IterationData(int iterationNumber, Vector vector)
            {
                IterationNumber = iterationNumber;
                Vector = vector;
            }
        }
    }
}
