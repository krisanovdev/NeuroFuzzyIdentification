using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustCalculateIt.Logic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace NeuroFuzzyIdentification
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        public MainFunction mainFunction;
        private bool _isCalculated = false;
        public bool isCalculated
        {
            get {
                return _isCalculated;
            }
            set
            {
                _isCalculated = value;
                if (_isCalculated)
                {
                    label1.Text = "Модель після налаштування";
                }
                else
                {
                    label1.Text = "Модель до налаштування";
                }
            }
        }

        private void viewTermsButton_Click(object sender, EventArgs e)
        {
            var formTerms = new TermsOutput(mainFunction.numberOfVariables, mainFunction);
            var functions = mainFunction.termsFunctions.Clone();
            formTerms.initialTerms = functions;
            formTerms.Show();
        }

        private void viewBaseButton_Click(object sender, EventArgs e)
        {
            var formRules = new RulesOutput(mainFunction.rules.Clone(), this.isCalculated);
            formRules.Show();
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            var scatterDataRealValues = new List<double>();
            var scatterDataCalculatedValues = new List<double>();

            double sum = 0;
            int number = mainFunction.experimentalData.Count;
            for (int i = 0; i < mainFunction.experimentalData.Count; i++)
            {
                var realVector = mainFunction.experimentalData[i];
                var coordinates = realVector.GetRange(0, realVector.Count - 1);
                var realResult = realVector.Last();
                scatterDataRealValues.Add(realResult);
                var calculatedValue = mainFunction.resolve(coordinates);
                scatterDataCalculatedValues.Add(calculatedValue);
                //writetext.WriteLine(calculatedValue);
                sum += Math.Pow((calculatedValue - realResult), 2);
            }

            double deviation = Math.Sqrt(sum / number);
            //using (StreamWriter writetext2 = new StreamWriter("deviation_Before.txt"))
            //{
            //    writetext2.WriteLine(deviation);
            //}


            Graphic graphic = new Graphic();
            graphic.Show();
            var endingData = new List<List<double>>();
            endingData.Add(scatterDataRealValues);
            endingData.Add(scatterDataCalculatedValues);
            graphic.buildScatter("", endingData);
        }

        public void calcDeviation()
        {
            var scatterDataRealValues = new List<double>();
            var scatterDataCalculatedValues = new List<double>();

            double sum = 0;
            int number = mainFunction.experimentalData.Count;
            for (int i = 0; i < mainFunction.experimentalData.Count; i++)
            {
                var realVector = mainFunction.experimentalData[i];
                var coordinates = realVector.GetRange(0, realVector.Count - 1);
                var realResult = realVector.Last();
                scatterDataRealValues.Add(realResult);
                var calculatedValue = mainFunction.resolve(coordinates);
                scatterDataCalculatedValues.Add(calculatedValue);
                //writetext.WriteLine(calculatedValue);
                sum += Math.Pow((calculatedValue - realResult), 2);
            }

            double deviation = Math.Sqrt(sum / number);
            deviationLabel.Text = "Середньоквадратичний\nухил: " + string.Format("{0:0.00000}", deviation);


            numericUpDown1.Value = 1;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = mainFunction.numberOfVariables - 1;
            if (mainFunction.numberOfVariables - 1 == 2)
            {
                numericUpDown1.ReadOnly = true;
                numericUpDown2.ReadOnly = true;
            }
            numericUpDown2.Value = 2;
            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = mainFunction.numberOfVariables - 1;

            if (mainFunction.numberOfVariables - 1 == 1)
            {
                viewSurfaceButton.Enabled = false;
            }
        }

        private void calculateOnGridButton_Click(object sender, EventArgs e)
        {
            var form = new CalculateOnGridForm();
            form.mainFunction = mainFunction;
            form.Show();
        }

        private void viewSurfaceButton_Click(object sender, EventArgs e)
        {
            decimal index1 = 0;
            decimal index2 = 1;
            if (mainFunction.numberOfVariables - 1 != 2)
            {
                if (numericUpDown1.Value != numericUpDown2.Value)
                {
                    index1 = numericUpDown1.Value - 1;
                    index2 = numericUpDown2.Value - 1;
                }
                else
                {
                    return;
                }
            }
            var numberOfSteps = 100;
            
            var results = new List<Tuple<List<double>, double>>();
            var xNumber = mainFunction.experimentalData[0].Count - 1;
            var pointsNumber = 1;
            for (int i = 0; i < 2; i++)
            {
                pointsNumber *= numberOfSteps;
            }
            for (int i = 0; i < pointsNumber; i++)
            {
                int j = 0;
                var currentNumber = i;
                var coordinates = new List<double>();
                while (currentNumber > 0)
                {
                    var columnNumber = coordinates.Count;
                    var minMax = mainFunction.findMinMaxFor(xNumber - columnNumber - 1);
                    var left = minMax.Item1;
                    var right = minMax.Item2;
                    var curCoor = currentNumber % numberOfSteps;
                    coordinates.Add(left + curCoor * (right - left) / (numberOfSteps - 1));
                    currentNumber /= numberOfSteps;
                    j++;
                    j %= 2;
                }
                while (coordinates.Count < (mainFunction.experimentalData[0].Count - 1))
                {
                    var columnNumber = coordinates.Count;
                    var minMax = mainFunction.findMinMaxFor(xNumber - columnNumber - 1);
                    var left = minMax.Item1;
                    coordinates.Add(left);
                }
                coordinates.Reverse();
                results.Add(Tuple.Create<List<double>, double>(coordinates, mainFunction.resolve(coordinates)));
            }

            using (StreamWriter writetext = new StreamWriter("data.txt"))
            {
                writetext.WriteLine(numberOfSteps);
                writetext.WriteLine(numberOfSteps);
                writetext.WriteLine(mainFunction.findMinMaxFor(Convert.ToInt32(index1)).Item1);
                writetext.WriteLine(mainFunction.findMinMaxFor(Convert.ToInt32(index1)).Item2);
                writetext.WriteLine(mainFunction.findMinMaxFor(Convert.ToInt32(index2)).Item1);
                writetext.WriteLine(mainFunction.findMinMaxFor(Convert.ToInt32(index2)).Item2);
                for (int i = 0; i < results.Count; i++)
                {
                   // writetext.WriteLine(results[i].Item1[0] + " " + results[i].Item1[1] + " ");
                    writetext.WriteLine(results[i].Item2);
                }
            }
            run_cmd();
        }

        private void run_cmd()
        {
            try
            {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string fileName = path.Substring(6) + "\\3dplotnew.py";

                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Python27\python.exe", fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch
            {
                MessageBox.Show("Python installation not found");
            }
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CalculateInCoordinates();
            form.mainFunction = mainFunction;
            form.UpdateDataGridViewDataSetValues();
            form.Show();
        }
    }
}
