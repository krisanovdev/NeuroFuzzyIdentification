namespace NeuroFuzzyIdentification
{
    partial class DataSetInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numberOfElementsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfVariablesNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewDataSet = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfElementsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfVariablesNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataSet)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberOfElementsNumericUpDown
            // 
            this.numberOfElementsNumericUpDown.Location = new System.Drawing.Point(6, 21);
            this.numberOfElementsNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.numberOfElementsNumericUpDown.Name = "numberOfElementsNumericUpDown";
            this.numberOfElementsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.numberOfElementsNumericUpDown.TabIndex = 0;
            this.numberOfElementsNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberOfElementsNumericUpDown.ValueChanged += new System.EventHandler(this.numberOfElementsNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кількість елементів вибірки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кількість змінних";
            // 
            // numberOfVariablesNumericUpDown1
            // 
            this.numberOfVariablesNumericUpDown1.Location = new System.Drawing.Point(6, 65);
            this.numberOfVariablesNumericUpDown1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.numberOfVariablesNumericUpDown1.Name = "numberOfVariablesNumericUpDown1";
            this.numberOfVariablesNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numberOfVariablesNumericUpDown1.TabIndex = 2;
            this.numberOfVariablesNumericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberOfVariablesNumericUpDown1.ValueChanged += new System.EventHandler(this.numberOfVariablesNumericUpDown1_ValueChanged);
            // 
            // dataGridViewDataSet
            // 
            this.dataGridViewDataSet.AllowUserToAddRows = false;
            this.dataGridViewDataSet.AllowUserToDeleteRows = false;
            this.dataGridViewDataSet.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewDataSet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDataSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDataSet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 10.17801F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDataSet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDataSet.ColumnHeadersHeight = 40;
            this.dataGridViewDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 10.17801F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDataSet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDataSet.Location = new System.Drawing.Point(1, 89);
            this.dataGridViewDataSet.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridViewDataSet.MultiSelect = false;
            this.dataGridViewDataSet.Name = "dataGridViewDataSet";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDataSet.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDataSet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewDataSet.RowTemplate.Height = 40;
            this.dataGridViewDataSet.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDataSet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewDataSet.Size = new System.Drawing.Size(307, 26);
            this.dataGridViewDataSet.TabIndex = 8;
            this.dataGridViewDataSet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDataSet_CellValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(108, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 28);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Зберегти";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(3, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(99, 28);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Відмінити";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.numberOfElementsNumericUpDown);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.numberOfVariablesNumericUpDown1);
            this.flowLayoutPanel1.Controls.Add(this.dataGridViewDataSet);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(309, 156);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.closeButton);
            this.flowLayoutPanel2.Controls.Add(this.saveButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 119);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(210, 34);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // DataSetInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(563, 501);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DataSetInput";
            this.Text = "DataSetInput";
            this.Load += new System.EventHandler(this.DataSetInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numberOfElementsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfVariablesNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataSet)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numberOfElementsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberOfVariablesNumericUpDown1;
        private System.Windows.Forms.DataGridView dataGridViewDataSet;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}