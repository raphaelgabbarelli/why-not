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
        Series zero;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            AddChartLine(0);
            AddChartLine(1000);
            AddChartLine(-1000);

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

        delegate void UpdateChartCallback(Sample sample, Sample raw);

        const int MINX = -33000;
        const int MAXX = 33000;
        const int MINY = -33000;
        const int MAXY = 33000;
        const int X_STEP = 100;
        const int LINE_LENGTH_IN_SAMPLES = 50;
        int time = MINX;

        private void UpdateChart(Sample sample, Sample raw)
        {
            if (chart.InvokeRequired)
            {
                UpdateChartCallback d = new UpdateChartCallback(UpdateChart);
                Invoke(d, new object[] { sample, raw });
            }
            else
            {
                if (cmbX.SelectedItem == null || cmbY.SelectedItem == null)
                    return;


                double valueX = 0, valueY = 0;
                double rawX = 0, rawY = 0;

                switch (cmbX.SelectedItem.ToString())
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
                        }
                        valueX = time;
                        rawX = time;
                        time += X_STEP;
                        break;
                    default: return;
                }

                switch (cmbY.SelectedItem.ToString())
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
                
            }
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            readsAccumulated.Points.Clear();
        }

        private void cmbX_SelectedValueChanged(object sender, EventArgs e)
        {
            readsAccumulated.Points.Clear();
            readsRaw.Points.Clear();
            time = MINX;
        }

        private void cmbY_SelectedValueChanged(object sender, EventArgs e)
        {
            readsAccumulated.Points.Clear();
            readsRaw.Points.Clear();
            time = MINX;
        }
    }
}
