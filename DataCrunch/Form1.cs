using DataCrunch.Acquire;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataCrunch
{
    public partial class Form1 : Form
    {
        private ArduinoSampleParser sampleParser;
        private ComManager comManager;
        Series readsAccumulated;
        Series readsRaw;
        Series rowingSignals;
        Series zero;
        
        string X = "time";
        string Y = "X";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbTime.Checked = true;
            X = "time";
            rbYA.Checked = true;
            Y = "A";

            sampleParser = new ArduinoSampleParser();
            comManager = new ComManager("COM5",  sampleParser, UpdateChart);
            
            readsAccumulated = chart.Series.Add("readsXZ");
            readsAccumulated.ChartType = SeriesChartType.FastLine;
            readsAccumulated.Color = Color.Red;
            readsAccumulated.BorderWidth = 2;

            readsRaw = chart.Series.Add("readsRaw");
            readsRaw.ChartType = SeriesChartType.FastLine;
            readsRaw.Color = Color.Blue;
            readsRaw.BorderWidth = 1;

            rowingSignals = chart.Series.Add("rowingSignals");
            rowingSignals.ChartType = SeriesChartType.Point;
            rowingSignals.Color = Color.Blue;
            rowingSignals.BorderWidth = 3;

            AddChartLine(0);
            AddChartLine(3000);
            AddChartLine(-3000);

            chart.ChartAreas[0].AxisX.Minimum = MINX;
            chart.ChartAreas[0].AxisX.Maximum = MAXX;

            chart.ChartAreas[0].AxisY.Minimum = MINY;
            chart.ChartAreas[0].AxisY.Maximum = MAXY;

            //chart.ChartAreas[0].AxisY.IsLogarithmic = true;
        }

        private void AddChartLine(int Y)
        {
            zero = chart.Series.Add("zero" + Y);
            zero.ChartType = SeriesChartType.FastLine;
            zero.Color = Color.Black;
            zero.BorderWidth = 1;
            zero.Points.AddXY(MINX, Y);
            zero.Points.AddXY(MAXX, Y);
        }

        delegate void UpdateChartCallback(Sample sample, Sample raw, RowingSignal rowingSignal);

        const int MINX = -33000;
        const int MAXX = 33000;
        const int MINY = -33000;
        const int MAXY = 33000;
        const int X_STEP = 50;
        const int LINE_LENGTH_IN_SAMPLES = 250;
        int time = MINX;

        private void UpdateChart(Sample sample, Sample raw, RowingSignal rowingSignal)
        {
            if (chart.InvokeRequired)
            {
                try
                {
                    UpdateChartCallback d = new UpdateChartCallback(UpdateChart);
                    Invoke(d, new object[] { sample, raw, rowingSignal });
                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine(e.ToString()); // swallow the exception (this happens when killing the window)
                }
            }
            else
            {
                if (String.IsNullOrEmpty(X) || String.IsNullOrEmpty(Y))
                    return;


                double valueX = 0, valueY = 0;
                double rawX = 0, rawY = 0;

                switch (X)
                {
                    case "X":
                        valueX = sample.x;
                        rawX = raw.x;
                        break;
                    case "Y":
                        valueX = sample.y;
                        rawX = raw.y;
                        break;
                    case "Z":
                        valueX = sample.z;
                        rawX = raw.z;
                        break;
                    case "A":
                        valueX = sample.a;
                        rawX = raw.a;
                        break;
                    case "B":
                        valueX = sample.b;
                        rawX = raw.b;
                        break;
                    case "C":
                        valueX = sample.c;
                        rawX = raw.c;
                        break;
                    case "time":
                        if(time >= MAXX)
                        {
                            time = MINX;
                            rowingSignals.Points.Clear();
                        }
                        valueX = time;
                        rawX = time;
                        time += X_STEP;
                        break;
                    default: return;
                }

                switch (Y)
                {
                    case "X":
                        valueY = sample.x;
                        rawY = raw.x;
                        break;
                    case "Y":
                        valueY = sample.y;
                        rawY = raw.y;
                        break;
                    case "Z":
                        valueY = sample.z;
                        rawY = raw.z;
                        break;
                    case "A":
                        valueY = sample.a;
                        rawY = raw.a;
                        break;
                    case "B":
                        valueY = sample.b;
                        rawY = raw.b;
                        break;
                    case "C":
                        valueY = sample.c;
                        rawY = raw.c;
                        break;
                    default: return;
                }

                readsAccumulated.Points.AddXY(valueX, valueY);
                lblXValue.Text = valueX.ToString();
                lblYValue.Text = valueY.ToString();
                lblYRaw.Text = rawY.ToString();
                readsRaw.Points.AddXY(rawX, rawY);


                if (readsAccumulated.Points.Count > LINE_LENGTH_IN_SAMPLES)
                {
                    readsAccumulated.Points.RemoveAt(0);
                }

                if(readsRaw.Points.Count > LINE_LENGTH_IN_SAMPLES)
                {
                    readsRaw.Points.RemoveAt(0);
                }
                

                if(rowingSignal != null)
                {
                    rowingSignals.Points.AddXY(rawX, rawY);
                    if(rowingSignal.StrokeTime > 0)
                    {
                        lblStrokeRate.Text = rowingSignal.SmoothedStrokeRate.ToString("0.0");
                    }
                }
                
            }
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            readsAccumulated.Points.Clear();
        }
        
        
        private string SelectedAxis(string axis)
        {
            string selection = "";

            if (axis.ToUpper() == "X")
            {
                if (rbXX.Checked) return "X";
                if (rbXY.Checked) return "Y";
                if (rbXZ.Checked) return "Z";
                if (rbXA.Checked) return "A";
                if (rbXB.Checked) return "B";
                if (rbXC.Checked) return "C";
                if (rbTime.Checked) return "time";
            }
            else if(axis.ToUpper() == "Y")
            {
                if (rbYX.Checked) return "X";
                if (rbYY.Checked) return "Y";
                if (rbYZ.Checked) return "Z";
                if (rbYA.Checked) return "A";
                if (rbYB.Checked) return "B";
                if (rbYC.Checked) return "C";
            }
            return selection;
        }


        private void CheckedChanged(object sender, EventArgs e)
        {
            if (readsAccumulated != null)
            {
                readsAccumulated.Points.Clear(); 
            }
            if (readsRaw != null)
            {
                readsRaw.Points.Clear();
            }

            if(rowingSignals != null)
            {
                rowingSignals.Points.Clear();
            }

            time = MINX;

            X = SelectedAxis("X");
            Y = SelectedAxis("Y");
        }
    }
}
