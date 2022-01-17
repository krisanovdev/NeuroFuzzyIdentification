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
using JustCalculateIt.RAlgorithm;

namespace NeuroFuzzyIdentification
{

    
    public partial class MainForm : Form
    {

        private FileParser fp;
        private MainFunction mainFunction = MainFunction.defaultMainFunction();
        private bool isFileLoaded = false;
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Нова задача";
        }

        #region DataReceived

        public void receivedExperimentalDataValues(List<List<double>> values, int experimentalDataLength , int numberOfVariables)
        {
            var oldFunction = mainFunction;
    
            var newTermsFunctions = new List<List<MembershipFunction>>();
            if (experimentalDataLength < oldFunction.experimentalData.Count)
            {

            } else {
                if (experimentalDataLength > oldFunction.experimentalData.Count) {

                }
            }
            
            var newTermsNumbers = new List<int>();
            if (numberOfVariables < oldFunction.termsNumbers.Count)
            {
                mainFunction.termsFunctions.RemoveRange(oldFunction.experimentalData.Count, experimentalDataLength - oldFunction.experimentalData.Count);
                newTermsFunctions = mainFunction.termsFunctions.Clone();

                oldFunction.termsNumbers.RemoveRange(numberOfVariables, oldFunction.termsNumbers.Count - numberOfVariables);
                for (var i = 0; i < oldFunction.termsNumbers.Count; i++)
                {
                    newTermsNumbers.Add(oldFunction.termsNumbers[i]);
                }
            }
            else
            {
                for (var i = 0; i < oldFunction.termsNumbers.Count; i++)
                {
                    newTermsNumbers.Add(oldFunction.termsNumbers[i]);
                }
                for (var i = oldFunction.termsNumbers.Count; i < numberOfVariables; i++)
                {
                    newTermsNumbers.Add(3);
                }
                newTermsFunctions = Extensions.Clone(mainFunction.termsFunctions);
                for (int i = 0; i < (numberOfVariables - oldFunction.termsNumbers.Count); i++)
                {
                    var newList = new List<MembershipFunction>();
                    newTermsFunctions.Add(newList);
                    for (var j = 0; j < 3; j++)
                    {
                        var parameters = new List<double>();
                        parameters.Add(1);
                        parameters.Add(1);
                        var membershipFunction = new MembershipFunction(MembershipFunctionType.bell, parameters);
                        newList.Add(membershipFunction);
                    }
                }
            }

            var invalidateRules = new List<JustCalculateIt.Logic.Rule>();
            var updatedFunction = new MainFunction(experimentalDataLength, numberOfVariables, newTermsNumbers, newTermsFunctions, values, invalidateRules);
            this.mainFunction = updatedFunction;
        }

        public void receivedTermsValues(List<int> membershipFunctionsNumbers, List<List<MembershipFunction>> newMembershipFunctions)
        {
            var invalidateRules = new List<JustCalculateIt.Logic.Rule>();
            var newValues = newMembershipFunctions.Clone();
            var updatedFunction = new MainFunction(mainFunction.experimentalData.Count, mainFunction.numberOfVariables, membershipFunctionsNumbers, newValues, mainFunction.experimentalData, invalidateRules);
            this.mainFunction = updatedFunction;
        }
        public void receivedRulesValues(List<JustCalculateIt.Logic.Rule> rules)
        {
            this.mainFunction.rules = rules.Clone();
        }
        
        #endregion

        private void setDataSetButoon_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count > 1)
            {
                foreach (Form frm in fc)
                {
                    if (!(frm is MainForm))
                    {
                        // TODO: Show POPUP WITH WARNING
                        frm.Focus();
                        break;
                    }
                }
            }
            else {
                var formDataSet = new DataSetInput(this);
                formDataSet.NumberOfVariablesCount = mainFunction.numberOfVariables;
                formDataSet.initialValues = mainFunction.experimentalData;
                formDataSet.Show();
            }
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                string path = openFileDialog.FileName;
                this.fp = new FileParser(path);
                this.mainFunction = new MainFunction(fp.numberOfRecords, fp.mathRecords[0].Count, fp.numberOfTerms, fp.termsFunctions, fp.mathRecords, fp.rules);
                this.Text = path;
                generateRules();
            }
        }

        private void generateRules()
        {
            var generatedRules = new List<JustCalculateIt.Logic.Rule>();
            var records = this.fp.mathRecords;
            for (int i = 0; i < records.Count; i++)
            {
                var resultTerms = new List<Term>();
                for (int j = 0; j < records[i].Count; j++)
                {
                    var currentTerms = this.fp.termsFunctions[j].ConvertAll(x =>
                     new Term(x, this.fp.termsFunctions[j].IndexOf(x))
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
            this.mainFunction.rules.AddRange(generatedRules);

            //this.initialRules = generatedRules;

            var distinct = new List<int>();
            for (int i = 0; i < this.mainFunction.rules.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < distinct.Count; j++)
                {
                    if (this.mainFunction.rules[i].Equals(this.mainFunction.rules[distinct[j]]))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    distinct.Add(i);
                }
            }

            var distinctRules = distinct.ConvertAll(x => this.mainFunction.rules[x]);
            this.mainFunction.rules = distinctRules;
        }

        private void setTermsButton_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count > 1)
            {
                foreach (Form frm in fc)
                {
                    if (!(frm is MainForm))
                    {
                        // TODO: Show POPUP WITH WARNING
                        frm.Focus();
                        break;
                    }
                }
            }
            else
            {
                var formTerms = new TermsInput(this.mainFunction.numberOfVariables, this, this.mainFunction);
                var functions = mainFunction.termsFunctions.Clone();
                formTerms.initialTerms = functions;
                formTerms.updateView();
                // TODO: Add params if there is ready functions
                formTerms.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void setRulesButton_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count > 1)
            {
                foreach (Form frm in fc)
                {
                    if (!(frm is MainForm))
                    {
                        // TODO: Show POPUP WITH WARNING
                        frm.Focus();
                        break;
                    }
                }
            }
            else
            {
                var formRules = new RulesInput(mainFunction.rules.Clone(), mainFunction, this);
                // TODO: Add params if there is ready functions
                formRules.Show();
            }
        }

        private void buttonBeforeResults_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.Text = "Результати до налаштування";
            resultsForm.mainFunction = mainFunction;
            resultsForm.isCalculated = false;
            resultsForm.calcDeviation();
            resultsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var task = new JustCalculateIt.RAlgorithm.Task();
            task.InitialVector = this.mainFunction.paramsVector();
            task.IsMaximizationTask = false;
            var count = 0;
            //derivativesStream.WriteLine("b1, c1, b2, c2, ..., b[n], c[n], w1, w2, ..., w[m]");
            task.Subgradient = vector =>
            {


                count++;
                //derivativesStream.WriteLine(count);
                //derivativesStream.WriteLine(vector);
                var subg = Subgradient.CalcSubgradient(vector, this.mainFunction);
                //derivativesStream.WriteLine(subg.ToString());
                return subg;

            };
            var options = new JustCalculateIt.RAlgorithm.Solver.Options();
            //options.InitialStep = 0.1;
            var resultVector = Solver.Solve(task, options, null);
            //using (StreamWriter writetext = new StreamWriter("AfterConfiguration_Params.txt"))
            //{
            //    writetext.WriteLine(resultVector.IterationNumber);
            //    writetext.WriteLine(resultVector.Vector.ToString());
            //}


            var afterMainFunction = Subgradient.mainFunction;
            var resultsForm = new ResultsForm();
            resultsForm.Text = "Результати після налаштування";
            resultsForm.mainFunction = afterMainFunction;
            resultsForm.isCalculated = true;
            resultsForm.calcDeviation();
            resultsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовый файл (.txt) | *.txt";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileParser.Save(saveDialog.FileName, mainFunction);
            }
        }
    }

    static class Extensions
    {
        public static List<List<T>> Clone<T>(this List<List<T>> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (List<T>)item.Clone()).ToList();
        }
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
