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
    public partial class RulesOutput : Form
    {
        public RulesOutput()
        {
            InitializeComponent();
        }

        private void RulesOutput_Load(object sender, EventArgs e)
        {

        }

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

        public RulesOutput(List<JustCalculateIt.Logic.Rule> rules, bool isCalculated)
        {
            InitializeComponent();
            this.initialRules = rules;
            if (isCalculated)
            {
                label2.Text = "Правила у базі знань після налаштування";
            }
            else
            {
                label2.Text = "Правила у базі знань до налаштування";
            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
