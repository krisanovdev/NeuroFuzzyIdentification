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
using NeuroFuzzyIdentification.Logic;

namespace NeuroFuzzyIdentification
{
    public partial class CalculateInCoordinates : Form
    {
        public CalculateInCoordinates()
        {
            InitializeComponent();
        }

        private void CalculateInCoordinates_Load(object sender, EventArgs e)
        {

        }

        public MainFunction mainFunction;

        public void UpdateDataGridViewDataSetValues()
        {
            var elementsCount = 1;
            var variablesCount = mainFunction.numberOfVariables - 1;
            while (dataGridView1.ColumnCount < variablesCount)
            {
                String headerText = String.Format("x{0}", dataGridView1.Columns.Count + 1);
                dataGridView1.Columns.Add(headerText, headerText);
            }
            var i = 0;
            while (i < variablesCount)
            {
                dataGridView1.Columns[i].HeaderText = String.Format("x{0}", i + 1);
                i++;
            }



            while (dataGridView1.ColumnCount > variablesCount)
                dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount - 1);

            while (dataGridView1.RowCount < elementsCount)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].HeaderCell.Value = String.Format("{0}", index + 1);
                for (var j = 0; j < variablesCount; j++)
                {
                     dataGridView1[j, index].Value = 0;
                }
            }

            var k = 0;
            while (k < elementsCount)
            {
                dataGridView1.Rows[k].HeaderCell.Value = String.Format("{0}", k + 1);
                for (var j = 0; j < variablesCount; j++)
                {
                     dataGridView1[j, k].Value = 0;
                }
                k++;
            }


            while (dataGridView1.RowCount > elementsCount)
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Size = dataGridView1.PreferredSize;
        }

        private void Calculate(List<double> coordinates)
        {
            results.Add(Tuple.Create<List<double>, double>(coordinates, mainFunction.resolve(coordinates)));
        }

        public List<Tuple<List<double>, double>> results = new List<Tuple<List<double>, double>>();

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

        private void gridSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void CalculateOnGridForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calculateButton_Click_1(object sender, EventArgs e)
        {
            var coordinates = new List<double>();
            for (var i = 0; i < mainFunction.numberOfVariables - 1; i++)
            {
                coordinates.Add(Convert.ToDouble(dataGridView1[i, 0].Value));
            }
            ClearDataGrid();
            Calculate(coordinates);
            PopulateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                string path = openFileDialog.FileName;
                var parser = new CSVParser(path);
                var results = parser.coordinates;
                for (var i = 0; i < results.Count; i++)
                {
                    if (results[i].Count == mainFunction.numberOfVariables - 1)
                    {
                        Calculate(results[i]);
                    }
                }
            }
            PopulateDataGrid();
        }
    }
}