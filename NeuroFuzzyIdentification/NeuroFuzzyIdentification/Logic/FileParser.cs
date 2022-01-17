using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Logic
{
    class GridParams
    {
        public double left;
        public double right;
        public int numberOfSteps;

        public GridParams(double left, double right, int numberOfSteps)
        {
            this.left = left;
            this.right = right;
            this.numberOfSteps = numberOfSteps;
        }
    }
    class FileParser
    {
        public int numberOfRecords;
        public List<List<double>> mathRecords;
        public List<int> numberOfTerms;
        public List<List<MembershipFunction>> termsFunctions;
        public List<Rule> rules;
        public List<GridParams> gridParams;

        public string path;
        
        public FileParser(string path)
        {
            this.path = path;
            using (StreamReader reader = new StreamReader(path))
            {
                // Results
                var mathRecords = new List<List<double>>();
                var numberOfTerms = new List<int>();
                var termsFunctions = new List<List<MembershipFunction>>();

                int n = Int32.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string oneRecord = reader.ReadLine();
                    var splitedRecord = oneRecord.Split(null);
                    splitedRecord = splitedRecord.Where(x => x.Length > 0).ToArray();
                    var mathRecord = new List<Double>();
                    for (int j = 0; j < splitedRecord.Length; j++)
                    {
                        mathRecord.Add(Double.Parse(splitedRecord[j]));
                    }
                    mathRecords.Add(mathRecord);
                }
                reader.ReadLine(); // Пустая строка
                reader.ReadLine(); // Количество термов (строка разделитель)
                for (int i = 0; i < mathRecords[0].Count; i++)
                {
                    reader.ReadLine();
                    int number = Int32.Parse(reader.ReadLine());
                    numberOfTerms.Add(number);
                }
                reader.ReadLine(); // Пустая строка
                reader.ReadLine(); // Параметры термов
                for (int p = 0; p < mathRecords[0].Count; p++)
                {
                    termsFunctions.Add(new List<MembershipFunction>());
                    reader.ReadLine();
                    var currentCount = numberOfTerms[p];
                    for (int j = 0; j < currentCount; j++)
                    {
                        var stringRepresentation = reader.ReadLine();
                        var splitedRepresentation = stringRepresentation.Split(null);
                        splitedRepresentation = splitedRepresentation.Where(x => x.Length > 0).ToArray();
                        var type = splitedRepresentation[0];
                        var parameters = new List<Double>();
                        for (int k = 1; k < splitedRepresentation.Length; k++)
                        {
                            parameters.Add(Double.Parse(splitedRepresentation[k]));
                        }
                        MembershipFunction currentFunction;
                        switch (type)
                        {
                            case "bell": currentFunction = new MembershipFunction(MembershipFunctionType.bell, parameters);
                                break;
                            case "trapezoid": currentFunction = new MembershipFunction(MembershipFunctionType.trapezoid, parameters);
                                break;
                            case "generic_bell": currentFunction = new MembershipFunction(MembershipFunctionType.generic_bell, parameters);
                                break;
                            default: currentFunction = new MembershipFunction(MembershipFunctionType.bell, parameters);
                                break;
                            // TODO: Add support of other functions
                        }
                        termsFunctions[p].Add(currentFunction);
                    }
                }
                
                reader.ReadLine(); // ПУСТАЯ СТРОКА
                reader.ReadLine(); // Параметры сетки

                //var gridParams = new List<GridParams>();
                //for (int i = 0; i < mathRecords[0].Count - 1; i++)
                //{
                //    reader.ReadLine();
                //    var stringRepresentation = reader.ReadLine();
                //    var splitedRepresentation = stringRepresentation.Split(null);
                //    splitedRepresentation = splitedRepresentation.Where(x => x.Length > 0).ToArray();
                //    double left, right;
                //    int numberOfSteps;
                //    left = double.Parse(splitedRepresentation[0]);
                //    right = double.Parse(splitedRepresentation[1]);
                //    numberOfSteps = Int32.Parse(splitedRepresentation[2]);
                //    gridParams.Add(new GridParams(left, right, numberOfSteps));
                //}


                // Finalize reading
                this.numberOfRecords = n;
                this.mathRecords = mathRecords;
                this.numberOfTerms = numberOfTerms;
                this.termsFunctions = termsFunctions;
                this.gridParams = gridParams;
                this.rules = new List<Rule>();
            }
        }

        public static void Save(string toPath, MainFunction mainFunction)
        {
            using (StreamWriter writer = new StreamWriter(toPath))
            {
                // Results
                var mathRecords = new List<List<double>>();
                var numberOfTerms = new List<int>();
                var termsFunctions = new List<List<MembershipFunction>>();

                writer.WriteLine(mainFunction.experimentalData.Count);
                //int n = Int32.Parse(writer.ReadLine());
                for (int i = 0; i < mainFunction.experimentalData.Count; i++)
                {
                    for (int j = 0; j < mainFunction.experimentalData[i].Count; j++)
                    {
                        writer.Write(mainFunction.experimentalData[i][j]);
                        writer.Write(" ");
                    }
                    writer.WriteLine();
                }
                writer.WriteLine();
                writer.WriteLine();
                writer.WriteLine();

                for (int i = 0; i < mainFunction.termsNumbers.Count; i++)
                {
                    writer.WriteLine(mainFunction.termsNumbers[i]);
                    writer.WriteLine();
                }

                writer.WriteLine();
                writer.WriteLine();
                for (int i = 0; i < mainFunction.termsFunctions.Count; i++)
                {
                    for (int j = 0; j < mainFunction.termsFunctions[i].Count; j++)
                    {
                        var func = mainFunction.termsFunctions[i][j];
                        writer.Write(func.type.DisplayProgramName());
                        writer.Write(" ");
                        for (int k = 0; k < func.parameters.Count; k++)
                        {
                            writer.Write(func.parameters[k]);
                            writer.Write(" ");
                            if (k == func.parameters.Count - 1) {
                                writer.WriteLine();
                            }
                        }
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
