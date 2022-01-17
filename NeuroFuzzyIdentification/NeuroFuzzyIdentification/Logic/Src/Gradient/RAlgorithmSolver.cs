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
        public static IterationData Solve(Task task, Options options, Action<IterationData> iterationDelegate)
        {
            var x0 = task.InitialVector;
            var x = x0;
            var subgradient = task.Subgradient(x0);
            var newSubgradient = subgradient;

            var h = new Matrix(x0.Size, x0.Size);
            for (int i = 0; i < x0.Size; ++i)
                h[i, i] = 1;

            var step = options.InitialStep;
            
            int iterationNumber = 0;
            if (iterationDelegate != null)
                iterationDelegate(new IterationData(iterationNumber, x0));

            do
            {
                x0 = x;
                subgradient = newSubgradient;

                if (subgradient.Norm < options.Precision)
                    break;

                var direction = (h * subgradient.ToVerticalMatrix()).ToVector();
                direction /= Math.Sqrt(direction * subgradient);

                var stepsCount = 0;
                do
                {
                    ++stepsCount;

                    if (task.IsMaximizationTask)
                        x += step * direction;
                    else
                        x -= step * direction;

                    newSubgradient = task.Subgradient(x);

                    if (stepsCount > options.IterationsCountToIncreaseStep)
                        step *= options.StepIncreaseMultiplier;
                }
                while (direction * newSubgradient > 0);

                if (stepsCount == 1)
                    step *= options.StepDecreaseMultiplier;

                var gamma = newSubgradient - subgradient;

                if (gamma.Norm > 1e-8)
                {
                    var hGamma = h * gamma.ToVerticalMatrix();
                    h = h - (1 - 1 / options.SpaceStretchCoefficient / options.SpaceStretchCoefficient) * (hGamma * hGamma.Transposed()) / (gamma.ToHorizontalMatrix() * hGamma)[0, 0];
                }

                if (iterationNumber > 200)
                {
                    break;
                }
                ++iterationNumber;
                if (iterationDelegate != null)
                    iterationDelegate(new IterationData(iterationNumber, x));
            }
            while ((x - x0).Norm > options.Precision);

            return new IterationData(iterationNumber, x);
        }
    }
}
