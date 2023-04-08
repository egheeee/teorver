using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace teorver
{
    public partial class Form1 : Form
    {
        int N = 1000;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var uniformData = GenerateUniformDistribution(N);
            DrawHistogram(uniformData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var normalData = GenerateNormalDistribution(N);
            DrawHistogram(normalData);
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
        }
        private List<double> GenerateUniformDistribution(int count)
        {
            Random r = new Random();
            List<double> uniformData = new List<double>();

            for (int i = 0; i < count; i++)
            {
                uniformData.Add(r.NextDouble());
            }

            return uniformData;
        }
        private void DrawHistogram(List<double> data)
        {
            int numberOfBins = 10; // Выберите количество интервалов для гистограммы
            double[] frequencies = new double[numberOfBins];
            double binWidth = 1.0 / numberOfBins;

            foreach (double value in data)
            {
                int binIndex = (int)(value / binWidth);
                frequencies[binIndex]++;
            }
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < numberOfBins; i++)
            {
                double x = i * binWidth + binWidth / 2.0;
                double y = frequencies[i] / (data.Count * binWidth);
                chart2.Series[0].Points.AddXY(x, y);
            }
        }
        private List<double> GenerateNormalDistribution(int count)
        {
            Random r = new Random();
            List<double> normalData = new List<double>();
            int n = 20;

            for (int i = 0; i < count; i++)
            {
                double sum = 0;

                for (int j = 0; j < n; j++)
                {
                    sum += r.NextDouble();
                }

                double normalValue = sum / n;
                normalData.Add(normalValue);
            }

            return normalData;
        }
    }
}
