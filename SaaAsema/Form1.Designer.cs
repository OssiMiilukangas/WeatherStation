using System;

namespace SaaAsema
{
    partial class Form1
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
            this.lampotila = new System.Windows.Forms.Label();
            this.ilmankosteus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ilmankosteusAvg = new System.Windows.Forms.Label();
            this.lampotilaAvg = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ilmankosteusAvgFromDate = new System.Windows.Forms.Label();
            this.lampotilaAvgFromDate = new System.Windows.Forms.Label();
            this.ilmankosteusFromDate = new System.Windows.Forms.Label();
            this.lampotilaFromDate = new System.Windows.Forms.Label();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.dataHakuButton = new System.Windows.Forms.Button();
            this.yearLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lampotila
            // 
            this.lampotila.AutoSize = true;
            this.lampotila.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lampotila.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lampotila.Location = new System.Drawing.Point(6, 16);
            this.lampotila.Name = "lampotila";
            this.lampotila.Size = new System.Drawing.Size(55, 33);
            this.lampotila.TabIndex = 2;
            this.lampotila.Text = "0.0";
            // 
            // ilmankosteus
            // 
            this.ilmankosteus.AutoSize = true;
            this.ilmankosteus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilmankosteus.Location = new System.Drawing.Point(171, 16);
            this.ilmankosteus.Name = "ilmankosteus";
            this.ilmankosteus.Size = new System.Drawing.Size(55, 33);
            this.ilmankosteus.TabIndex = 3;
            this.ilmankosteus.Text = "0.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ilmankosteusAvg);
            this.groupBox1.Controls.Add(this.lampotilaAvg);
            this.groupBox1.Controls.Add(this.ilmankosteus);
            this.groupBox1.Controls.Add(this.lampotila);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 163);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todays Temperature and Humidity";
            // 
            // ilmankosteusAvg
            // 
            this.ilmankosteusAvg.AutoSize = true;
            this.ilmankosteusAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilmankosteusAvg.Location = new System.Drawing.Point(171, 99);
            this.ilmankosteusAvg.Name = "ilmankosteusAvg";
            this.ilmankosteusAvg.Size = new System.Drawing.Size(55, 33);
            this.ilmankosteusAvg.TabIndex = 6;
            this.ilmankosteusAvg.Text = "0.0";
            // 
            // lampotilaAvg
            // 
            this.lampotilaAvg.AutoSize = true;
            this.lampotilaAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lampotilaAvg.Location = new System.Drawing.Point(6, 99);
            this.lampotilaAvg.Name = "lampotilaAvg";
            this.lampotilaAvg.Size = new System.Drawing.Size(55, 33);
            this.lampotilaAvg.TabIndex = 5;
            this.lampotilaAvg.Text = "0.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ilmankosteusAvgFromDate);
            this.groupBox2.Controls.Add(this.lampotilaAvgFromDate);
            this.groupBox2.Controls.Add(this.ilmankosteusFromDate);
            this.groupBox2.Controls.Add(this.lampotilaFromDate);
            this.groupBox2.Location = new System.Drawing.Point(12, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 162);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data from selected date";
            // 
            // ilmankosteusAvgFromDate
            // 
            this.ilmankosteusAvgFromDate.AutoSize = true;
            this.ilmankosteusAvgFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilmankosteusAvgFromDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ilmankosteusAvgFromDate.Location = new System.Drawing.Point(171, 91);
            this.ilmankosteusAvgFromDate.Name = "ilmankosteusAvgFromDate";
            this.ilmankosteusAvgFromDate.Size = new System.Drawing.Size(55, 33);
            this.ilmankosteusAvgFromDate.TabIndex = 6;
            this.ilmankosteusAvgFromDate.Text = "0.0";
            // 
            // lampotilaAvgFromDate
            // 
            this.lampotilaAvgFromDate.AutoSize = true;
            this.lampotilaAvgFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lampotilaAvgFromDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lampotilaAvgFromDate.Location = new System.Drawing.Point(6, 91);
            this.lampotilaAvgFromDate.Name = "lampotilaAvgFromDate";
            this.lampotilaAvgFromDate.Size = new System.Drawing.Size(55, 33);
            this.lampotilaAvgFromDate.TabIndex = 5;
            this.lampotilaAvgFromDate.Text = "0.0";
            // 
            // ilmankosteusFromDate
            // 
            this.ilmankosteusFromDate.AutoSize = true;
            this.ilmankosteusFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilmankosteusFromDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ilmankosteusFromDate.Location = new System.Drawing.Point(171, 33);
            this.ilmankosteusFromDate.Name = "ilmankosteusFromDate";
            this.ilmankosteusFromDate.Size = new System.Drawing.Size(55, 33);
            this.ilmankosteusFromDate.TabIndex = 4;
            this.ilmankosteusFromDate.Text = "0.0";
            // 
            // lampotilaFromDate
            // 
            this.lampotilaFromDate.AutoSize = true;
            this.lampotilaFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lampotilaFromDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lampotilaFromDate.Location = new System.Drawing.Point(6, 33);
            this.lampotilaFromDate.Name = "lampotilaFromDate";
            this.lampotilaFromDate.Size = new System.Drawing.Size(55, 33);
            this.lampotilaFromDate.TabIndex = 3;
            this.lampotilaFromDate.Text = "0.0";
            // 
            // dayTextBox
            // 
            this.dayTextBox.Location = new System.Drawing.Point(12, 500);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(157, 20);
            this.dayTextBox.TabIndex = 7;
            // 
            // dataHakuButton
            // 
            this.dataHakuButton.Location = new System.Drawing.Point(189, 498);
            this.dataHakuButton.Name = "dataHakuButton";
            this.dataHakuButton.Size = new System.Drawing.Size(75, 23);
            this.dataHakuButton.TabIndex = 10;
            this.dataHakuButton.Text = "Get";
            this.dataHakuButton.UseVisualStyleBackColor = true;
            this.dataHakuButton.Click += new System.EventHandler(this.dataHakuButton_Click);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(12, 484);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(75, 13);
            this.yearLabel.TabIndex = 12;
            this.yearLabel.Text = "YYYY-MM-DD";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 807);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.dataHakuButton);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Label lampotila;
        private System.Windows.Forms.Label ilmankosteus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lampotilaAvg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lampotilaAvgFromDate;
        private System.Windows.Forms.Label ilmankosteusFromDate;
        private System.Windows.Forms.Label lampotilaFromDate;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.Button dataHakuButton;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label ilmankosteusAvg;
        private System.Windows.Forms.Label ilmankosteusAvgFromDate;
    }
}

