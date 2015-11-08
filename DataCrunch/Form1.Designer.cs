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
            this.lblXValue = new System.Windows.Forms.Label();
            this.lblYValue = new System.Windows.Forms.Label();
            this.lblYRaw = new System.Windows.Forms.Label();
            this.rbXX = new System.Windows.Forms.RadioButton();
            this.rbXY = new System.Windows.Forms.RadioButton();
            this.rbXZ = new System.Windows.Forms.RadioButton();
            this.rbXA = new System.Windows.Forms.RadioButton();
            this.rbXB = new System.Windows.Forms.RadioButton();
            this.rbXC = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.gbX = new System.Windows.Forms.GroupBox();
            this.gbY = new System.Windows.Forms.GroupBox();
            this.rbYX = new System.Windows.Forms.RadioButton();
            this.rbYY = new System.Windows.Forms.RadioButton();
            this.rbYC = new System.Windows.Forms.RadioButton();
            this.rbYZ = new System.Windows.Forms.RadioButton();
            this.rbYB = new System.Windows.Forms.RadioButton();
            this.rbYA = new System.Windows.Forms.RadioButton();
            this.lblStrokeRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.gbX.SuspendLayout();
            this.gbY.SuspendLayout();
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
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
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
            // lblXValue
            // 
            this.lblXValue.AutoSize = true;
            this.lblXValue.Location = new System.Drawing.Point(210, 602);
            this.lblXValue.Name = "lblXValue";
            this.lblXValue.Size = new System.Drawing.Size(35, 13);
            this.lblXValue.TabIndex = 6;
            this.lblXValue.Text = "label3";
            // 
            // lblYValue
            // 
            this.lblYValue.AutoSize = true;
            this.lblYValue.Location = new System.Drawing.Point(376, 578);
            this.lblYValue.Name = "lblYValue";
            this.lblYValue.Size = new System.Drawing.Size(35, 13);
            this.lblYValue.TabIndex = 7;
            this.lblYValue.Text = "label3";
            // 
            // lblYRaw
            // 
            this.lblYRaw.AutoSize = true;
            this.lblYRaw.Location = new System.Drawing.Point(376, 602);
            this.lblYRaw.Name = "lblYRaw";
            this.lblYRaw.Size = new System.Drawing.Size(35, 13);
            this.lblYRaw.TabIndex = 8;
            this.lblYRaw.Text = "label3";
            // 
            // rbXX
            // 
            this.rbXX.AutoSize = true;
            this.rbXX.Location = new System.Drawing.Point(14, 19);
            this.rbXX.Name = "rbXX";
            this.rbXX.Size = new System.Drawing.Size(32, 17);
            this.rbXX.TabIndex = 9;
            this.rbXX.Text = "X";
            this.rbXX.UseVisualStyleBackColor = true;
            this.rbXX.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbXY
            // 
            this.rbXY.AutoSize = true;
            this.rbXY.Location = new System.Drawing.Point(14, 41);
            this.rbXY.Name = "rbXY";
            this.rbXY.Size = new System.Drawing.Size(32, 17);
            this.rbXY.TabIndex = 10;
            this.rbXY.Text = "Y";
            this.rbXY.UseVisualStyleBackColor = true;
            this.rbXY.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbXZ
            // 
            this.rbXZ.AutoSize = true;
            this.rbXZ.Location = new System.Drawing.Point(14, 63);
            this.rbXZ.Name = "rbXZ";
            this.rbXZ.Size = new System.Drawing.Size(32, 17);
            this.rbXZ.TabIndex = 11;
            this.rbXZ.Text = "Z";
            this.rbXZ.UseVisualStyleBackColor = true;
            this.rbXZ.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbXA
            // 
            this.rbXA.AutoSize = true;
            this.rbXA.Location = new System.Drawing.Point(14, 85);
            this.rbXA.Name = "rbXA";
            this.rbXA.Size = new System.Drawing.Size(32, 17);
            this.rbXA.TabIndex = 12;
            this.rbXA.Text = "A";
            this.rbXA.UseVisualStyleBackColor = true;
            this.rbXA.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbXB
            // 
            this.rbXB.AutoSize = true;
            this.rbXB.Location = new System.Drawing.Point(14, 107);
            this.rbXB.Name = "rbXB";
            this.rbXB.Size = new System.Drawing.Size(32, 17);
            this.rbXB.TabIndex = 13;
            this.rbXB.Text = "B";
            this.rbXB.UseVisualStyleBackColor = true;
            this.rbXB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbXC
            // 
            this.rbXC.AutoSize = true;
            this.rbXC.Location = new System.Drawing.Point(14, 129);
            this.rbXC.Name = "rbXC";
            this.rbXC.Size = new System.Drawing.Size(32, 17);
            this.rbXC.TabIndex = 14;
            this.rbXC.Text = "C";
            this.rbXC.UseVisualStyleBackColor = true;
            this.rbXC.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Location = new System.Drawing.Point(14, 151);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(44, 17);
            this.rbTime.TabIndex = 15;
            this.rbTime.Text = "time";
            this.rbTime.UseVisualStyleBackColor = true;
            this.rbTime.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // gbX
            // 
            this.gbX.Controls.Add(this.rbXX);
            this.gbX.Controls.Add(this.rbTime);
            this.gbX.Controls.Add(this.rbXY);
            this.gbX.Controls.Add(this.rbXC);
            this.gbX.Controls.Add(this.rbXZ);
            this.gbX.Controls.Add(this.rbXB);
            this.gbX.Controls.Add(this.rbXA);
            this.gbX.Location = new System.Drawing.Point(213, 404);
            this.gbX.Name = "gbX";
            this.gbX.Size = new System.Drawing.Size(72, 180);
            this.gbX.TabIndex = 16;
            this.gbX.TabStop = false;
            this.gbX.Text = "X";
            // 
            // gbY
            // 
            this.gbY.Controls.Add(this.rbYX);
            this.gbY.Controls.Add(this.rbYY);
            this.gbY.Controls.Add(this.rbYC);
            this.gbY.Controls.Add(this.rbYZ);
            this.gbY.Controls.Add(this.rbYB);
            this.gbY.Controls.Add(this.rbYA);
            this.gbY.Location = new System.Drawing.Point(352, 404);
            this.gbY.Name = "gbY";
            this.gbY.Size = new System.Drawing.Size(72, 155);
            this.gbY.TabIndex = 17;
            this.gbY.TabStop = false;
            this.gbY.Text = "Y";
            // 
            // rbYX
            // 
            this.rbYX.AutoSize = true;
            this.rbYX.Location = new System.Drawing.Point(14, 19);
            this.rbYX.Name = "rbYX";
            this.rbYX.Size = new System.Drawing.Size(32, 17);
            this.rbYX.TabIndex = 9;
            this.rbYX.Text = "X";
            this.rbYX.UseVisualStyleBackColor = true;
            this.rbYX.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbYY
            // 
            this.rbYY.AutoSize = true;
            this.rbYY.Location = new System.Drawing.Point(14, 41);
            this.rbYY.Name = "rbYY";
            this.rbYY.Size = new System.Drawing.Size(32, 17);
            this.rbYY.TabIndex = 10;
            this.rbYY.Text = "Y";
            this.rbYY.UseVisualStyleBackColor = true;
            this.rbYY.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbYC
            // 
            this.rbYC.AutoSize = true;
            this.rbYC.Location = new System.Drawing.Point(14, 129);
            this.rbYC.Name = "rbYC";
            this.rbYC.Size = new System.Drawing.Size(32, 17);
            this.rbYC.TabIndex = 14;
            this.rbYC.Text = "C";
            this.rbYC.UseVisualStyleBackColor = true;
            this.rbYC.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbYZ
            // 
            this.rbYZ.AutoSize = true;
            this.rbYZ.Location = new System.Drawing.Point(14, 63);
            this.rbYZ.Name = "rbYZ";
            this.rbYZ.Size = new System.Drawing.Size(32, 17);
            this.rbYZ.TabIndex = 11;
            this.rbYZ.Text = "Z";
            this.rbYZ.UseVisualStyleBackColor = true;
            this.rbYZ.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbYB
            // 
            this.rbYB.AutoSize = true;
            this.rbYB.Location = new System.Drawing.Point(14, 107);
            this.rbYB.Name = "rbYB";
            this.rbYB.Size = new System.Drawing.Size(32, 17);
            this.rbYB.TabIndex = 13;
            this.rbYB.Text = "B";
            this.rbYB.UseVisualStyleBackColor = true;
            this.rbYB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbYA
            // 
            this.rbYA.AutoSize = true;
            this.rbYA.Location = new System.Drawing.Point(14, 85);
            this.rbYA.Name = "rbYA";
            this.rbYA.Size = new System.Drawing.Size(32, 17);
            this.rbYA.TabIndex = 12;
            this.rbYA.Text = "A";
            this.rbYA.UseVisualStyleBackColor = true;
            this.rbYA.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblStrokeRate
            // 
            this.lblStrokeRate.AutoSize = true;
            this.lblStrokeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrokeRate.Location = new System.Drawing.Point(743, 436);
            this.lblStrokeRate.Name = "lblStrokeRate";
            this.lblStrokeRate.Size = new System.Drawing.Size(136, 63);
            this.lblStrokeRate.TabIndex = 18;
            this.lblStrokeRate.Text = "00.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(885, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "spm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 628);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStrokeRate);
            this.Controls.Add(this.gbY);
            this.Controls.Add(this.gbX);
            this.Controls.Add(this.lblYRaw);
            this.Controls.Add(this.lblYValue);
            this.Controls.Add(this.lblXValue);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.gbX.ResumeLayout(false);
            this.gbX.PerformLayout();
            this.gbY.ResumeLayout(false);
            this.gbY.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblXValue;
        private System.Windows.Forms.Label lblYValue;
        private System.Windows.Forms.Label lblYRaw;
        private System.Windows.Forms.RadioButton rbXX;
        private System.Windows.Forms.RadioButton rbXY;
        private System.Windows.Forms.RadioButton rbXZ;
        private System.Windows.Forms.RadioButton rbXA;
        private System.Windows.Forms.RadioButton rbXB;
        private System.Windows.Forms.RadioButton rbXC;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.GroupBox gbX;
        private System.Windows.Forms.GroupBox gbY;
        private System.Windows.Forms.RadioButton rbYX;
        private System.Windows.Forms.RadioButton rbYY;
        private System.Windows.Forms.RadioButton rbYC;
        private System.Windows.Forms.RadioButton rbYZ;
        private System.Windows.Forms.RadioButton rbYB;
        private System.Windows.Forms.RadioButton rbYA;
        private System.Windows.Forms.Label lblStrokeRate;
        private System.Windows.Forms.Label label1;
    }
}

