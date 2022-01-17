using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCalculateIt.Supplementary;

namespace JustCalculateIt.RAlgorithm
{
    public class Task
    {
        public Vector InitialVector { get; set; }
        public Func<Vector, double> Function { get; set; }
        public Func<Vector, Vector> Subgradient { get; set; }
        public bool IsMaximizationTask { get; set; }

        public Task()
        {
            IsMaximizationTask = true;
        }
    }
}
