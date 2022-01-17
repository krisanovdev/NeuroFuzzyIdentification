namespace NeuroFuzzyIdentification
{
    partial class ResultsForm
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
            this.viewTermsButton = new System.Windows.Forms.Button();
            this.viewBaseButton = new System.Windows.Forms.Button();
            this.compareButton = new System.Windows.Forms.Button();
            this.calculateOnGridButton = new System.Windows.Forms.Button();
            this.viewSurfaceButton = new System.Windows.Forms.Button();
            this.deviationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // viewTermsButton
            // 
            this.viewTermsButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewTermsButton.Location = new System.Drawing.Point(56, 38);
            this.viewTermsButton.Name = "viewTermsButton";
            this.viewTermsButton.Size = new System.Drawing.Size(187, 40);
            this.viewTermsButton.TabIndex = 1;
            this.viewTermsButton.Text = "Переглянути терми";
            this.viewTermsButton.UseVisualStyleBackColor = true;
            this.viewTermsButton.Click += new System.EventHandler(this.viewTermsButton_Click);
            // 
            // viewBaseButton
            // 
            this.viewBaseButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewBaseButton.Location = new System.Drawing.Point(56, 84);
            this.viewBaseButton.Name = "viewBaseButton";
            this.viewBaseButton.Size = new System.Drawing.Size(187, 40);
            this.viewBaseButton.TabIndex = 2;
            this.viewBaseButton.Text = "Переглянути базу знань";
            this.viewBaseButton.UseVisualStyleBackColor = true;
            this.viewBaseButton.Click += new System.EventHandler(this.viewBaseButton_Click);
            // 
            // compareButton
            // 
            this.compareButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compareButton.Location = new System.Drawing.Point(56, 130);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(187, 40);
            this.compareButton.TabIndex = 3;
            this.compareButton.Text = "Порівняти з еталоном";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // calculateOnGridButton
            // 
            this.calculateOnGridButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateOnGridButton.Location = new System.Drawing.Point(56, 176);
            this.calculateOnGridButton.Name = "calculateOnGridButton";
            this.calculateOnGridButton.Size = new System.Drawing.Size(187, 40);
            this.calculateOnGridButton.TabIndex = 4;
            this.calculateOnGridButton.Text = "Побудувати на сітці";
            this.calculateOnGridButton.UseVisualStyleBackColor = true;
            this.calculateOnGridButton.Click += new System.EventHandler(this.calculateOnGridButton_Click);
            // 
            // viewSurfaceButton
            // 
            this.viewSurfaceButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewSurfaceButton.Location = new System.Drawing.Point(56, 268);
            this.viewSurfaceButton.Name = "viewSurfaceButton";
            this.viewSurfaceButton.Size = new System.Drawing.Size(187, 40);
            this.viewSurfaceButton.TabIndex = 5;
            this.viewSurfaceButton.Text = "Побудувати поверхню";
            this.viewSurfaceButton.UseVisualStyleBackColor = true;
            this.viewSurfaceButton.Click += new System.EventHandler(this.viewSurfaceButton_Click);
            // 
            // deviationLabel
            // 
            this.deviationLabel.AutoSize = true;
            this.deviationLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviationLabel.Location = new System.Drawing.Point(69, 372);
            this.deviationLabel.Name = "deviationLabel";
            this.deviationLabel.Size = new System.Drawing.Size(154, 36);
            this.deviationLabel.TabIndex = 11;
            this.deviationLabel.Text = "Середньоквадратичний \r\nухил: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Модель";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(56, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 40);
            this.button1.TabIndex = 13;
            this.button1.Text = "Побудувати в точці";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(154, 314);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 14;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(154, 340);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(69, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Змінна 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(69, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Змінна 2:";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 433);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviationLabel);
            this.Controls.Add(this.viewSurfaceButton);
            this.Controls.Add(this.calculateOnGridButton);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.viewBaseButton);
            this.Controls.Add(this.viewTermsButton);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewTermsButton;
        private System.Windows.Forms.Button viewBaseButton;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Button calculateOnGridButton;
        private System.Windows.Forms.Button viewSurfaceButton;
        private System.Windows.Forms.Label deviationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}