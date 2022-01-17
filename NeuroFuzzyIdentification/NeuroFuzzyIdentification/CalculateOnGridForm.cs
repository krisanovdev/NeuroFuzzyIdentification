using JustCalculateIt.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuroFuzzyIdentification.Logic;


namespace NeuroFuzzyIdentification
{
    public partial class CalculateOnGridForm : Form
    {
        public CalculateOnGridForm()
        {
            InitializeComponent();
        }

        public MainFunction mainFunction;
        public List<Tuple<List<double>, double>> ongridResults = new List<Tuple<List<double>, double>>();

        private List<Tuple<List<double>, double>> Calculate()
        {
            var gridParams = Enumerable.Range(0, mainFunction.numberOfVariables - 1).Select(index =>
            {
                var minMax = mainFunction.findMinMaxFor(index);
                return new GridParams(minMax.Item1, minMax.Item2, (int)gridSizeNumericUpDown.Value);
            }).ToList();
            var pointsNumber = 1;
            var xNumber = mainFunction.numberOfVariables;
            var results = new List<Tuple<List<double>, double>>();
            for (int i = 0; i < gridParams.Count; i++)
            {
                pointsNumber *= gridParams[i].numberOfSteps;
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
                    var curCoor = currentNumber % gridParams[j].numberOfSteps;
                    coordinates.Add(left + curCoor * (right - left) / (gridParams[j].numberOfSteps - 1));
                    currentNumber /= gridParams[j].numberOfSteps;
                    j++;
                    j %= gridParams.Count;
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
            ongridResults = results;
            return results;
        }

        private void PopulateDataGridColumns()
        {
            for (int column = 0; column < mainFunction.numberOfVariables - 1; ++column)
            {
                String headerText = String.Format("x{0}", column + 1);
                dataGridViewResults.Columns.Add(headerText, headerText);
            }
            String yHeaderText = "y";
            dataGridViewResults.Columns.Add(yHeaderText, yHeaderText);
        }

        private void PopulateDataGridRows()
        {
            var results = Calculate();
            foreach (var result in results)
            {
                var index = dataGridViewResults.Rows.Add();
                dataGridViewResults.Rows[index].HeaderCell.Value = String.Format("{0}", index + 1);
                for (var j = 0; j < result.Item1.Count; j++)
                {
                    dataGridViewResults[j, index].Value = result.Item1[j];
                }
                dataGridViewResults[result.Item1.Count, index].Value = result.Item2;
            }
        }

        private void ClearDataGrid()
        {
            dataGridViewResults.Rows.Clear();
            dataGridViewResults.Columns.Clear();
        }

        private void PopulateDataGrid()
        {
            PopulateDataGridColumns();
            PopulateDataGridRows();
            dataGridViewResults.Size = dataGridViewResults.PreferredSize;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            ClearDataGrid();
            PopulateDataGrid();
        }

        private void gridSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void CalculateOnGridForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовый файл (.сsv) | *.csv";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var results = ongridResults.Select(x =>
                {
                    var copy = x.Item1.Select(y => y).ToList();
                    copy.Add(x.Item2);
                    return copy;
                }).ToList();
                CSVParser.WriteToFile(results, saveDialog.FileName);
            }
        }
    }
}
