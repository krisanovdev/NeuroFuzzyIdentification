namespace NeuroFuzzyIdentification
{
    partial class TermsInput
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
            this.dataGridViewTermsCount = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelTermsGrids = new System.Windows.Forms.FlowLayoutPanel();
            this.gridsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermsCount)).BeginInit();
            this.flowLayoutPanelTermsGrids.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTermsCount
            // 
            this.dataGridViewTermsCount.AllowUserToAddRows = false;
            this.dataGridViewTermsCount.AllowUserToDeleteRows = false;
            this.dataGridViewTermsCount.AllowUserToResizeColumns = false;
            this.dataGridViewTermsCount.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTermsCount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTermsCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewTermsCount.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTermsCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 10.17801F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTermsCount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTermsCount.ColumnHeadersHeight = 40;
            this.dataGridViewTermsCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 10.17801F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "3";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTermsCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTermsCount.Location = new System.Drawing.Point(1, 19);
            this.dataGridViewTermsCount.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridViewTermsCount.MultiSelect = false;
            this.dataGridViewTermsCount.Name = "dataGridViewTermsCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTermsCount.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTermsCount.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewTermsCount.RowTemplate.Height = 40;
            this.dataGridViewTermsCount.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTermsCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewTermsCount.Size = new System.Drawing.Size(128, 26);
            this.dataGridViewTermsCount.TabIndex = 9;
            this.dataGridViewTermsCount.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTermsCount_CellValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кількість змінних: ";
            // 
            // flowLayoutPanelTermsGrids
            // 
            this.flowLayoutPanelTermsGrids.AutoSize = true;
            this.flowLayoutPanelTermsGrids.Controls.Add(this.label2);
            this.flowLayoutPanelTermsGrids.Controls.Add(this.dataGridViewTermsCount);
            this.flowLayoutPanelTermsGrids.Controls.Add(this.gridsPanel);
            this.flowLayoutPanelTermsGrids.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanelTermsGrids.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTermsGrids.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanelTermsGrids.Name = "flowLayoutPanelTermsGrids";
            this.flowLayoutPanelTermsGrids.Size = new System.Drawing.Size(708, 492);
            this.flowLayoutPanelTermsGrids.TabIndex = 11;
            this.flowLayoutPanelTermsGrids.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelTermsGrids_Paint);
            // 
            // gridsPanel
            // 
            this.gridsPanel.AutoSize = true;
            this.gridsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.gridsPanel.Location = new System.Drawing.Point(3, 49);
            this.gridsPanel.Name = "gridsPanel";
            this.gridsPanel.Size = new System.Drawing.Size(0, 0);
            this.gridsPanel.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.closeButton);
            this.flowLayoutPanel2.Controls.Add(this.saveButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(210, 34);
            this.flowLayoutPanel2.TabIndex = 12;
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
            // TermsInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(732, 747);
            this.Controls.Add(this.flowLayoutPanelTermsGrids);
            this.Name = "TermsInput";
            this.Text = "TermsInput";
            this.Load += new System.EventHandler(this.TermsInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermsCount)).EndInit();
            this.flowLayoutPanelTermsGrids.ResumeLayout(false);
            this.flowLayoutPanelTermsGrids.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTermsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTermsGrids;
        private System.Windows.Forms.FlowLayoutPanel gridsPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
    }
}