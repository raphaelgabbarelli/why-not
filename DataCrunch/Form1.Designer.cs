namespace DataCrunch
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbX = new System.Windows.Forms.ComboBox();
            this.cmbY = new System.Windows.Forms.ComboBox();
            this.lblXValue = new System.Windows.Forms.Label();
            this.lblYValue = new System.Windows.Forms.Label();
            this.lblYRaw = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(42, 57);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(998, 341);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(42, 420);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // cmbX
            // 
            this.cmbX.FormattingEnabled = true;
            this.cmbX.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z",
            "A",
            "B",
            "C",
            "time"});
            this.cmbX.Location = new System.Drawing.Point(222, 421);
            this.cmbX.Name = "cmbX";
            this.cmbX.Size = new System.Drawing.Size(121, 21);
            this.cmbX.TabIndex = 4;
            this.cmbX.SelectedValueChanged += new System.EventHandler(this.cmbX_SelectedValueChanged);
            // 
            // cmbY
            // 
            this.cmbY.FormattingEnabled = true;
            this.cmbY.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z",
            "A",
            "B",
            "C"});
            this.cmbY.Location = new System.Drawing.Point(375, 422);
            this.cmbY.Name = "cmbY";
            this.cmbY.Size = new System.Drawing.Size(121, 21);
            this.cmbY.TabIndex = 5;
            this.cmbY.SelectedValueChanged += new System.EventHandler(this.cmbY_SelectedValueChanged);
            // 
            // lblXValue
            // 
            this.lblXValue.AutoSize = true;
            this.lblXValue.Location = new System.Drawing.Point(222, 449);
            this.lblXValue.Name = "lblXValue";
            this.lblXValue.Size = new System.Drawing.Size(35, 13);
            this.lblXValue.TabIndex = 6;
            this.lblXValue.Text = "label3";
            // 
            // lblYValue
            // 
            this.lblYValue.AutoSize = true;
            this.lblYValue.Location = new System.Drawing.Point(375, 450);
            this.lblYValue.Name = "lblYValue";
            this.lblYValue.Size = new System.Drawing.Size(35, 13);
            this.lblYValue.TabIndex = 7;
            this.lblYValue.Text = "label3";
            // 
            // lblYRaw
            // 
            this.lblYRaw.AutoSize = true;
            this.lblYRaw.Location = new System.Drawing.Point(375, 474);
            this.lblYRaw.Name = "lblYRaw";
            this.lblYRaw.Size = new System.Drawing.Size(35, 13);
            this.lblYRaw.TabIndex = 8;
            this.lblYRaw.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 526);
            this.Controls.Add(this.lblYRaw);
            this.Controls.Add(this.lblYValue);
            this.Controls.Add(this.lblXValue);
            this.Controls.Add(this.cmbY);
            this.Controls.Add(this.cmbX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbX;
        private System.Windows.Forms.ComboBox cmbY;
        private System.Windows.Forms.Label lblXValue;
        private System.Windows.Forms.Label lblYValue;
        private System.Windows.Forms.Label lblYRaw;
    }
}

