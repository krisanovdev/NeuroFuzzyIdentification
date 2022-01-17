using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCalculateIt.Supplementary;

namespace JustCalculateIt.RAlgorithm
{
    public static partial class Solver
    {
        public class Options
        {
            public double InitialStep { get; set; }
            public double Precision { get; set; }
            public double StepDecreaseMultiplier { get; set; }
            public double StepIncreaseMultiplier { get; set; }
            public int IterationsCountToIncreaseStep { get; set; }
            public double SpaceStretchCoefficient { get; set; }
            
            public Options()
            {
                InitialStep = 0.1;
                Precision = 1e-3;
                StepDecreaseMultiplier = 0.9;
                StepIncreaseMultiplier = 1.1;
                IterationsCountToIncreaseStep = 3;
                SpaceStretchCoefficient = 2;
            }

            public Options(StreamReader streamReader) : this()
            {
                var strings = streamReader.ReadLine().ToArray(s => s);
                InitialStep = strings[0].ToDouble();
                Precision = strings[1].ToDouble();

                strings = streamReader.ReadLine().ToArray(s => s);
                StepDecreaseMultiplier = strings[0].ToDouble();
                StepIncreaseMultiplier = strings[1].ToDouble();
                IterationsCountToIncreaseStep = strings[2].ToInt();

                SpaceStretchCoefficient = streamReader.ReadLine().ToDouble();
            }

            public void Serialize(StreamWriter streamWriter)
            {
                streamWriter.WriteLine("{0} {1}", InitialStep, Precision);
                streamWriter.WriteLine("{0} {1} {2}", StepDecreaseMultiplier, StepIncreaseMultiplier, IterationsCountToIncreaseStep);
                streamWriter.WriteLine(SpaceStretchCoefficient);
            }
        }
    }
}
