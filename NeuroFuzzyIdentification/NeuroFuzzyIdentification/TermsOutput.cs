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
    public partial class TermsOutput : Form
    {
        public TermsOutput()
        {
            InitializeComponent();
        }

        private void TermsOutput_Load(object sender, EventArgs e)
        {

        }

        private int _variablesCount = 3;
        private int VariablesCount
        {
            set
            {
                _variablesCount = value;
                UpdateDataGridViewTermsCount();
            }
            get
            {
                return _variablesCount;
            }
        }

        private int[] TermsCount
        {
            set
            {
                var variablesCount = VariablesCount;
                this.label2.Text = "Кількість змінних: " + Convert.ToString(variablesCount);
                for (int variable = 0; variable < variablesCount; ++variable)
                    dataGridViewTermsCount[0, variable].Value = value[variable];
            }
            get
            {
                var variablesCount = VariablesCount;
                var result = new int[variablesCount];
                for (int variable = 0; variable < variablesCount; ++variable)
                {
                    result[variable] = Convert.ToInt32(dataGridViewTermsCount[0, variable].Value ?? 0);

                }
                return result;
            }
        }

        MainForm delegateObj;
        MainFunction mainFunction;
        public TermsOutput(int variablesCount, MainFunction mainFunction)
        {
            InitializeComponent();
            this.VariablesCount = variablesCount;
            this.mainFunction = mainFunction;
            UpdateDataGridViewTermsCount();
            UpdateDataGridViewsTermsParams();
        }


        private List<List<MembershipFunction>> _initialTerms = new List<List<MembershipFunction>>();

        public List<List<MembershipFunction>> initialTerms
        {
            set
            {
               // MAKE COPY
                VariablesCount = value.Count;
                TermsCount = value.Select(x => x.Count).ToArray();
                _initialTerms = Extensions.Clone(value);
                UpdateDataGridViewsTermsParams();
            }
            get
            {
                return _initialTerms;
            }
        }

        public List<List<MembershipFunction>> newValues
        {
            get
            {
                // TODO: IMPLEMENT CREATING FROM DATAGRIDVIEWS
                var newMembershipFunctions = new List<List<MembershipFunction>>();
                for (var i = 0; i < termsParamsGridViews.Count; i++)
                {
                    var grid = termsParamsGridViews[i];
                    var list = new List<MembershipFunction>();
                    newMembershipFunctions.Add(list);
                    for (var j = 0; j < grid.RowCount; j++)
                    {
                        MembershipFunctionType membershipType;
                        int parametersNumber;
                        var cell = (DataGridViewComboBoxCell)grid[0, j];
                        var type = grid[0, j].Value.ToString();
                        membershipType = (MembershipFunctionType)cell.Items.IndexOf(cell.Value);
                        parametersNumber = membershipType.parametersCount();
                        var parameters = new List<double>();
                        for (var k = 1; k < parametersNumber + 1; k++)
                        {
                            var param = Convert.ToDouble(grid[k, j].Value);
                            parameters.Add(param);
                        }
                        list.Add(new MembershipFunction(membershipType, parameters));
                    }
                }
                return newMembershipFunctions;
            }
        }

        private void TermsInput_Load(object sender, EventArgs e)
        {

        }

        private void UpdateDataGridViewTermsCount()
        {
            var variablesCount = VariablesCount;
            while (dataGridViewTermsCount.ColumnCount < 1)
            {
                String yHeaderText = "Кількість термів";
                dataGridViewTermsCount.Columns.Add(yHeaderText, yHeaderText);
            }


            var defaultValue = new Object[1];
            defaultValue[0] = 3;
            while (dataGridViewTermsCount.ColumnCount > variablesCount)
                dataGridViewTermsCount.Columns.RemoveAt(dataGridViewTermsCount.ColumnCount - 1);

            while (dataGridViewTermsCount.RowCount < variablesCount)
            {
                var index = dataGridViewTermsCount.Rows.Add();
                if (index == variablesCount - 1)
                {
                    dataGridViewTermsCount.Rows[index].HeaderCell.Value = "y";
                    dataGridViewTermsCount.Rows[index].SetValues(defaultValue);
                }
                else
                {
                    dataGridViewTermsCount.Rows[index].HeaderCell.Value = String.Format("х{0}", index + 1);
                }
            }
            var i = 0;
            while (i < variablesCount - 1)
            {
                dataGridViewTermsCount.Rows[i].HeaderCell.Value = String.Format("x{0}", i + 1);
                i++;
            }
            dataGridViewTermsCount.Rows[i].HeaderCell.Value = "y";
            while (dataGridViewTermsCount.RowCount > variablesCount)
                dataGridViewTermsCount.Rows.RemoveAt(dataGridViewTermsCount.RowCount - 1);
            foreach (DataGridViewColumn column in dataGridViewTermsCount.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewTermsCount.Size = dataGridViewTermsCount.PreferredSize;
        }

        private Button formattedButton()
        {
            var newButton = new Button();
            newButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            newButton.Location = new System.Drawing.Point(417, 680);
            newButton.Name = "button1";
            newButton.Size = new System.Drawing.Size(303, 33);
            newButton.TabIndex = 11;
            newButton.Text = "Побудувати графік функцій приналежності";
            newButton.UseVisualStyleBackColor = true;
            newButton.Margin = new Padding(8, 0, 0, 8);
            return newButton;
        }

        private FlowLayoutPanel formattedPanel()
        {
            var newPanel = new FlowLayoutPanel();
            newPanel.AutoSize = true;
            newPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            newPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            newPanel.Margin = new Padding(0, 16, 0, 0);
            return newPanel;
        }
        private Label formattedLabel()
        {
            var newLabel = new Label();
            newLabel.AutoSize = true;
            newLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            newLabel.Location = new System.Drawing.Point(426, 577);
            newLabel.Name = "label1";
            newLabel.Size = new System.Drawing.Size(124, 18);
            newLabel.TabIndex = 10;
            newLabel.Text = "Кількість змінних: ";
            newLabel.Margin = new Padding(8, 8, 0, 0);
            return newLabel;
        }
        private DataGridView formattedGridView()
        {
            var dataGrid = new DataGridView();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 10.17801F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGrid.ColumnHeadersHeight = 40;
            dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 10.17801F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "3";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            dataGrid.Location = new System.Drawing.Point(1, 19);
            dataGrid.Margin = new System.Windows.Forms.Padding(1);
            dataGrid.MultiSelect = false;
            dataGrid.Name = "dataGridViewTermsCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGrid.RowTemplate.Height = 40;
            dataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            dataGrid.Size = new System.Drawing.Size(128, 26);
            dataGrid.TabIndex = 9;
            dataGrid.Margin = new Padding(8, 8, 8, 0);
            dataGrid.ReadOnly = true;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            return dataGrid;
        }

        private List<DataGridView> termsParamsGridViews = new List<DataGridView>();


        void BuildFunctionButtonHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var i = (int)button.Tag;
            var variables = mainFunction.variables;
            var functions = variables[i].terms.ConvertAll(x => x.membershipFunction.membershipFunction).ToList();
            Graphic graphic = new Graphic();
            graphic.functions = functions;
            var minMax = mainFunction.findMinMaxFor(i);
            graphic.leftBound = minMax.Item1;
            graphic.rightBound = minMax.Item2;
            graphic.Show();
            var name = "";
            var variableName = "";
            if (i == variables.Count - 1)
            {
                name = "Функція приналежності для термів змінної y";
                variableName = "y";
            }
            else
            {
                name = "Функція приналежності для термів змінної x" + (i + 1);
                variableName = "x" + (i + 1);
            }
            graphic.build(name, variableName);
        }
        private void UpdateDataGridViewsTermsParams()
        {
            if (initialTerms.Count > 0)
            {
                var termsCountArray = TermsCount;
                var dataGrids = this.termsParamsGridViews;
                var curNumberOfGrids = dataGrids.Count;
                // Adding new grids
                if (curNumberOfGrids < termsCountArray.Length)
                {
                    for (var i = curNumberOfGrids; i < termsCountArray.Length; i++)
                    {
                        var panel = this.formattedPanel();
                        gridsPanel.Controls.Add(panel);


                        var variableLabel = this.formattedLabel();
                        variableLabel.Text = "Терми змінної " + ((i == termsCountArray.Length - 1) ? "y" : ("x" + Convert.ToString(i)));
                        panel.Controls.Add(variableLabel);


                        var newGrid = this.formattedGridView();
                        termsParamsGridViews.Add(newGrid);
                        panel.Controls.Add(newGrid);

                        var button = this.formattedButton();
                        button.Tag = i;
                        button.Click += new EventHandler(this.BuildFunctionButtonHandler);
                        panel.Controls.Add(button);
                        
                    }
                }
                else
                {
                    //for (var i = termsCountArray.Length; i < curNumberOfGrids; i++)
                    //{
                    //    var curGridView = termsParamsGridViews[i];
                    //    if (gridsPanel.Controls.Contains(curGridView))
                    //    {
                    //        gridsPanel.Controls.Remove(curGridView);
                    //        termsParamsGridViews.Remove(curGridView);
                    //        curGridView.Dispose();
                    //    }
                    //}
                }


                if (curNumberOfGrids < termsCountArray.Length)
                {
                    for (var i = curNumberOfGrids; i < termsCountArray.Length; i++)
                    {
                        var curGrid = termsParamsGridViews[i];
                        var curTerms = initialTerms[i];

                        var maxCount = 0;
                        for (var j = 0; j < TermsCount[i]; j++)
                        {
                            var paramsCount = curTerms[j].parameters.Count;
                            if (paramsCount > maxCount)
                            {
                                maxCount = paramsCount;
                            }
                        }
                        for (var j = 0; j < maxCount; j++)
                        {

                        }

                        while (curGrid.ColumnCount < maxCount + 1)
                        {
                            if (curGrid.ColumnCount == 0)
                            {
                                String yHeaderText = "Тип функції";
                                var column = new DataGridViewComboBoxColumn();
                                column.HeaderText = yHeaderText;
                                column.Name = yHeaderText;
                                column.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                var types = Enum.GetValues(typeof(MembershipFunctionType)).Cast<MembershipFunctionType>();
                                column.Items.AddRange(types.Select(type => type.DisplayName()).ToArray());
                                curGrid.Columns.Add(column);
                            }
                            else
                            {
                                String headerText = String.Format("param{0}", curGrid.Columns.Count);
                                curGrid.Columns.Add(headerText, headerText);
                            }
                        }

                        // Add rows
                        while (curGrid.RowCount < TermsCount[i])
                        {
                            var index = curGrid.Rows.Add();
                            curGrid.Rows[index].HeaderCell.Value = String.Format("{0}", index + 1);

                            var termParams = curTerms[index].parameters;
                            curGrid[0, index].Value = curTerms[index].type.DisplayName();
                            for (var k = 1; k <= maxCount; k++)
                            {
                                // TODO: ADD TYPE SELECTION
                                if (k <= termParams.Count)
                                {
                                    curGrid[k, index].Value = termParams[k - 1];
                                    curGrid[k, index].ReadOnly = false;
                                }
                                else
                                {
                                    curGrid[k, index].Value = 0;
                                    curGrid[k, index].ReadOnly = true;
                                }
                            }
                        }
                        foreach (DataGridViewColumn column in curGrid.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        curGrid.Size = curGrid.PreferredSize;
                        // set values for added row
                        for (var j = 0; j < TermsCount[i]; j++)
                        {


                        }
                    }
                }
                else
                {
                }
                //for (var i = 0; i < VariablesCount; i++)
                //{
                //    var curTerms = 
                //}

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var termsCount = TermsCount;
            var termsCountList = new List<int>();
            for (var i = 0; i < termsCount.Length; i++) {
                termsCountList.Add(termsCount[i]);
            }
            delegateObj.receivedTermsValues(termsCountList, newValues);
            this.Close(); 
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //var initialTermsNumbers = initialTerms.Select(x => x.Count).ToList();
            //delegateObj.receivedTermsValues(initialTermsNumbers, initialTerms);
            this.Close();
        }
    }
}
