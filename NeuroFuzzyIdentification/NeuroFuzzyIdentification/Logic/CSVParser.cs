using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroFuzzyIdentification.Logic
{
    public class CSVParser
    {
        public List<List<double>> coordinates;
        public CSVParser(string filepath)
        {
            coordinates = new List<List<double>>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                var headers = reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var results = line.Split(';');
                    var coordinate = results.Select(x =>
                    {
                        return Convert.ToDouble(x);
                    }).ToList();
                    coordinates.Add(coordinate);
                }  
            }
        }

        public static void WriteToFile(List<List<double>> results, string filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                if (results.Count > 0)
                {
                    for (var i = 0; i < results[0].Count; i++)
                    {
                        if (i != results[0].Count - 1)
                        {
                            writer.Write("x" + (i + 1));
                            writer.Write(";");
                        }
                        else
                        {
                            writer.Write("y");
                        }
                    }
                    writer.WriteLine();
                    foreach (var result in results)
                    {
                        var newLine = "";
                        for (var i = 0; i < result.Count; i++)
                        {
                            newLine += result[i];
                            if (i != result.Count - 1)
                            {
                                newLine += ";";
                            }
                        }
                        writer.WriteLine(newLine);
                    }
                }
            }
        }
    }
}
