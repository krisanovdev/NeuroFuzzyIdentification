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
namespace NeuroFuzzyIdentification
{
    public partial class RulesInput : Form
    {

        public List<JustCalculateIt.Logic.Rule> newValues;

        private List<JustCalculateIt.Logic.Rule> _initialRules = new List<JustCalculateIt.Logic.Rule>();

        public List<JustCalculateIt.Logic.Rule> initialRules
        {
            set
            {
               // MAKE COPY
                _initialRules = Extensions.Clone(value);
                newValues = Extensions.Clone(value);
                UpdateDataGridViewsRules();
            }
            get
            {
                return _initialRules;
            }
        }

        public int RulesCount
        {
            get
            {
                return newValues.Count;
            }
        }

        MainFunction mainFunction;
        MainForm delegateObj;
        public RulesInput(List<JustCalculateIt.Logic.Rule> rules, MainFunction mainFunction, MainForm mainForm)
        {
            InitializeComponent();
            this.initialRules = rules;
            this.mainFunction = mainFunction;
            this.delegateObj = mainForm;
        }

        private void generateRules()
        {
            var generatedRules = new List<JustCalculateIt.Logic.Rule>();
            var records = this.mainFunction.experimentalData;
            for (int i = 0; i < records.Count; i++)
            {
                var resultTerms = new List<Term>();
                for (int j = 0; j < records[i].Count; j++)
                {
                    var currentTerms = this.mainFunction.termsFunctions[j].ConvertAll(x =>
                     new Term(x, this.mainFunction.termsFunctions[j].IndexOf(x))
                    );
                    int maxTermIndex = 0;
                    double maxTermVal = 0;
                    for (int k = 0; k < currentTerms.Count; k++)
                    {
                        var value = currentTerms[k].calculate(records[i][j]);
                        if (value > maxTermVal)
                        {
                            maxTermVal = value;
                            maxTermIndex = k;
                        }
                    }
                    resultTerms.Add(currentTerms[maxTermIndex]);
                }
                var outputTerm = resultTerms.Last();
                resultTerms.Remove(outputTerm);
                var inputTerms = resultTerms.ConvertAll(x => x);
                var rule = new JustCalculateIt.Logic.Rule(inputTerms, outputTerm);
                generatedRules.Add(rule);
            }
            //this.initialRules = generatedRules;

            var distinct = new List<int>();
            for (int i = 0; i < generatedRules.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < distinct.Count; j++)
                {
                    if (generatedRules[i].Equals(generatedRules[distinct[j]]))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    distinct.Add(i);
                }
            }

            var distinctRules = distinct.ConvertAll(x => generatedRules[x]);
            this.initialRules = distinctRules;
        }

        private void UpdateDataGridViewsRules()
        {
            var columnsCount = 2;
            var elementsCount = RulesCount;
            while (dataGridViewRules.ColumnCount < columnsCount)
            {
                if (dataGridViewRules.ColumnCount == 0)
                {
                    String yHeaderText = "Правило";
                    dataGridViewRules.Columns.Add(yHeaderText, yHeaderText);
                }
                if (dataGridViewRules.ColumnCount == 1)
                {
                    String headerText = "Ваговий коефіцієнт";
                    dataGridViewRules.Columns.Add(headerText, headerText);
                }
            }


            var texts = new List<string>();
            for (int i = 0; i < newValues.Count; i++)
            {
                var curTerms = newValues[i].terms;
                var ruleText = "ЯКЩО ";
                for (int j = 0; j < curTerms.Count; j++)
                {
                    ruleText += "x" + j + " належить терму №" + (curTerms[j].index + 1);
                    if (j != curTerms.Count - 1)
                    {
                        ruleText += " ТА ";
                    }
                }
                ruleText += " ТО";
                ruleText += " y належить терму №" + (newValues[i].output.index + 1);
                texts.Add(ruleText);
            }

            while (dataGridViewRules.ColumnCount > columnsCount)
                dataGridViewRules.Columns.RemoveAt(dataGridViewRules.ColumnCount - 1);

            while (dataGridViewRules.RowCount < elementsCount)
            {
                var index = dataGridViewRules.Rows.Add();
                dataGridViewRules.Rows[index].HeaderCell.Value = String.Format("{0}", index + 1);
                dataGridViewRules[0, index].Value = texts[index];
                dataGridViewRules[1, index].Value = newValues[index].weightKoefficient;
            }
            while (dataGridViewRules.RowCount > elementsCount)
                dataGridViewRules.Rows.RemoveAt(dataGridViewRules.RowCount - 1);

            dataGridViewRules.Size = dataGridViewRules.PreferredSize;
        }

        private void RulesInput_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateRules();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.delegateObj.receivedRulesValues(this.initialRules);
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
