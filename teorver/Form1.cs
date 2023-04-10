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
        private List<double> GenerateUniformDistribution(int N)
        {
            Random r = new Random();
            List<double> uniformData = new List<double>();

            for (int i = 0; i < N; i++)
            {
                uniformData.Add(r.NextDouble());
            }

            return uniformData;
        }
        private void DrawHistogram(List<double> data)
        {
            int numberOfInterval = 20; // Количество интервалов
            double[] frequencies = new double[numberOfInterval];// созданиче дин. массива, который хранит частоту каждого интервала
            double Width = 1.0 / numberOfInterval;//ширина каждого интервала

            foreach (double value in data)//цикл вычисления частот для каждого интервала
            {
                int binIndex = (int)(value / Width);
                frequencies[binIndex]++;//значение частоты для соотв. интервала +1
            }
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < numberOfInterval; i++)//цикл для отображения на гистограмме
            {
                double x = i * Width;
                double y = frequencies[i] / (data.Count * Width); //data.Count - общее кол-во элементов данных
                chart2.Series[0].Points.AddXY(x, y);
            }
        }
        private List<double> GenerateNormalDistribution(int N)
        {
            Random r = new Random();
            List<double> normalData = new List<double>();
            int n = 10;//задаем кол-во случайных чисел для аппроксимации нормального распределения с помощью ЦПТ

            for (int i = 0; i < N; i++)//генерация нормального распределения
            {
                double sum = 0;

                for (int j = 0; j < n; j++)
                {
                    sum += r.NextDouble();
                }

                double normalValue = sum / n;//получаем число с аппроксимированным нормальным распределением
                normalData.Add(normalValue);
            }

            return normalData;
        }
    }
}
