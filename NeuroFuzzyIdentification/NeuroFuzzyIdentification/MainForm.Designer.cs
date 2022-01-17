namespace NeuroFuzzyIdentification
{
    partial class MainForm
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
            this.setDataSetButoon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.setTermsButton = new System.Windows.Forms.Button();
            this.setRulesButton = new System.Windows.Forms.Button();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.buttonBeforeResults = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setDataSetButoon
            // 
            this.setDataSetButoon.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setDataSetButoon.Location = new System.Drawing.Point(63, 58);
            this.setDataSetButoon.Name = "setDataSetButoon";
            this.setDataSetButoon.Size = new System.Drawing.Size(187, 40);
            this.setDataSetButoon.TabIndex = 0;
            this.setDataSetButoon.Text = "Задати вибірку";
            this.setDataSetButoon.UseVisualStyleBackColor = true;
            this.setDataSetButoon.Click += new System.EventHandler(this.setDataSetButoon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Нейролінгвістична ідентифікація функції";
            // 
            // setTermsButton
            // 
            this.setTermsButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.setTermsButton.Location = new System.Drawing.Point(63, 131);
            this.setTermsButton.Name = "setTermsButton";
            this.setTermsButton.Size = new System.Drawing.Size(187, 40);
            this.setTermsButton.TabIndex = 2;
            this.setTermsButton.Text = "Задати терми";
            this.setTermsButton.UseVisualStyleBackColor = true;
            this.setTermsButton.Click += new System.EventHandler(this.setTermsButton_Click);
            // 
            // setRulesButton
            // 
            this.setRulesButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.setRulesButton.Location = new System.Drawing.Point(63, 204);
            this.setRulesButton.Name = "setRulesButton";
            this.setRulesButton.Size = new System.Drawing.Size(187, 40);
            this.setRulesButton.TabIndex = 3;
            this.setRulesButton.Text = "База знань";
            this.setRulesButton.UseVisualStyleBackColor = true;
            this.setRulesButton.Click += new System.EventHandler(this.setRulesButton_Click);
            // 
            // loadFileButton
            // 
            this.loadFileButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.loadFileButton.Location = new System.Drawing.Point(97, 454);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(115, 34);
            this.loadFileButton.TabIndex = 4;
            this.loadFileButton.Text = "Завантажити";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // buttonBeforeResults
            // 
            this.buttonBeforeResults.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.buttonBeforeResults.Location = new System.Drawing.Point(63, 277);
            this.buttonBeforeResults.Name = "buttonBeforeResults";
            this.buttonBeforeResults.Size = new System.Drawing.Size(187, 45);
            this.buttonBeforeResults.TabIndex = 5;
            this.buttonBeforeResults.Text = "Результати до налаштування";
            this.buttonBeforeResults.UseVisualStyleBackColor = true;
            this.buttonBeforeResults.Click += new System.EventHandler(this.buttonBeforeResults_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.button2.Location = new System.Drawing.Point(63, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 45);
            this.button2.TabIndex = 6;
            this.button2.Text = "Результати після налаштування";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.button3.Location = new System.Drawing.Point(97, 494);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 34);
            this.button3.TabIndex = 7;
            this.button3.Text = "Зберегти";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 538);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonBeforeResults);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.setRulesButton);
            this.Controls.Add(this.setTermsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setDataSetButoon);
            this.Name = "MainForm";
            this.Text = "Нова задача";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setDataSetButoon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setTermsButton;
        private System.Windows.Forms.Button setRulesButton;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button buttonBeforeResults;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

