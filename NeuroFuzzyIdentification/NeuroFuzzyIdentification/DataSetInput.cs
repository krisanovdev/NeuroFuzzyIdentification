using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroFuzzyIdentification
{
    public partial class DataSetInput : Form
    {
        MainForm delegateObj;
        public DataSetInput(MainForm form)
        {
            InitializeComponent();
            UpdateDataGridViewDataSetValues();
            delegateObj = form;
        }

        public int NumberOfElementsCount
        {
            set
            {
                numberOfElementsNumericUpDown.Value = value;
                UpdateDataGridViewDataSetValues();
            }
            get
            {
                return (int)numberOfElementsNumericUpDown.Value;
            }
        }

        public int NumberOfVariablesCount
        {
            set
            {
                numberOfVariablesNumericUpDown1.Value = value;
                UpdateDataGridViewDataSetValues();
            }
            get
            {
                return (int)numberOfVariablesNumericUpDown1.Value;
            }
        }


        private List<List<double>> _initialValues;
        public List<List<double>> initialValues
        {
            set
            {
                NumberOfElementsCount = value.Count;
                NumberOfVariablesCount = value[0].Count;
                
                var deepCopy = new List<List<double>>();
                var deepCopy2 = new List<List<double>>();
                for (var i = 0; i < value.Count; i++)
                {
                    var newDataRecord = new List<Double>();
                    var newDataRecord2 = new List<Double>();
                    for (var j = 0; j < value[0].Count; j++)
                    {
                        newDataRecord.Add(value[i][j]);
                        newDataRecord2.Add(value[i][j]);
                    }
                    deepCopy.Add(newDataRecord);
                    deepCopy2.Add(newDataRecord2);
                }
                _initialValues = deepCopy;
                newValues = deepCopy2;
            }
            get
            {
                return _initialValues;
            }
        }

        private List<List<double>> _newValues = new  List<List<double>>();
        public List<List<double>> newValues
        {
            get
            {
                var results = new List<List<double>>();
                for (var i = 0; i < NumberOfElementsCount; i++)
                {
                    var newDataRecord = new List<Double>();
                    for (var j = 0; j < NumberOfVariablesCount; j++)
                    {
                        newDataRecord.Add(Convert.ToDouble(dataGridViewDataSet[j, i].Value));
                    }
                    results.Add(newDataRecord);
                }
                return results;
            }
            set
            {
                _newValues = value;
                UpdateDataGridViewDataSetValues();
            }
        }


        private void numberOfElementsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewDataSetValues();
        }

        private void numberOfVariablesNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewDataSetValues();
        }

        private void UpdateDataGridViewDataSetValues()
        {
            var elementsCount = NumberOfElementsCount;
            var variablesCount = NumberOfVariablesCount;
            while (dataGridViewDataSet.ColumnCount < variablesCount)
            {
                if (dataGridViewDataSet.ColumnCount == variablesCount - 1)
                {
                    String yHeaderText = "y";
                    dataGridViewDataSet.Columns.Add(yHeaderText, yHeaderText);
                }
                else
                {
                    String headerText = String.Format("x{0}", dataGridViewDataSet.Columns.Count + 1);
                    dataGridViewDataSet.Columns.Add(headerText, headerText);
                }
            }
            var i = 0;
            while (i < variablesCount - 1)
            {
                dataGridViewDataSet.Columns[i].HeaderText = String.Format("x{0}", i + 1);
                i++;
            }
            dataGridViewDataSet.Columns[i].HeaderText = "y";
           
            

            while (dataGridViewDataSet.ColumnCount > variablesCount)
                dataGridViewDataSet.Columns.RemoveAt(dataGridViewDataSet.ColumnCount - 1);

            while (dataGridViewDataSet.RowCount < elementsCount)
            {
                var index = dataGridViewDataSet.Rows.Add();
                dataGridViewDataSet.Rows[index].HeaderCell.Value = String.Format("{0}", index + 1);
                for (var j = 0; j < variablesCount; j++)
                {
                    try {
                        dataGridViewDataSet[j, index].Value = _newValues[j][index];;
                    }
                    catch {
                        dataGridViewDataSet[j, index].Value = 0; 
                    }
                }
            }

            var k = 0;
            while (k < elementsCount)
            {
                dataGridViewDataSet.Rows[k].HeaderCell.Value = String.Format("{0}", k + 1);
                for (var j = 0; j < variablesCount; j++)
                {
                    try
                    {
                        dataGridViewDataSet[j, k].Value = _newValues[k][j]; ;
                    }
                    catch
                    {
                        dataGridViewDataSet[j, k].Value = 0;
                    }
                }
                k++;
            }


            while (dataGridViewDataSet.RowCount > elementsCount)
                dataGridViewDataSet.Rows.RemoveAt(dataGridViewDataSet.RowCount - 1);

            foreach (DataGridViewColumn column in dataGridViewDataSet.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridViewDataSet.Size = dataGridViewDataSet.PreferredSize;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            delegateObj.receivedExperimentalDataValues(newValues, NumberOfElementsCount, NumberOfVariablesCount);
            this.Close(); 
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //delegateObj.receivedExperimentalDataValues(initialValues, initialValues.Count, initialValues[0].Count);
            this.Close();
        }

        private void DataSetInput_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewDataSet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDataSet.Size = dataGridViewDataSet.PreferredSize;
        }
    }
}
