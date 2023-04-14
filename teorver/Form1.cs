/*using System;
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
}*/ //конец 1 лабы
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
        int N = 10000;
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
            int numberOfBins = 20; // Выберите количество интервалов для гистограммы
            double[] frequencies = new double[numberOfBins];
            double min = data.Min();
            double max = data.Max();
            double binWidth = (max - min) / numberOfBins;

            foreach (double value in data)
            {
                int binIndex = (int)((value - min) / binWidth);
                binIndex = Math.Min(binIndex, numberOfBins - 1); // Добавьте эту строку, чтобы избежать выхода за границы массива
                frequencies[binIndex]++;
            }

            chart2.Series[0].Points.Clear();
            for (int i = 0; i < numberOfBins; i++)
            {
                double x = min + i * binWidth + binWidth / 2.0;
                double y = frequencies[i] / (data.Count * binWidth);
                chart2.Series[0].Points.AddXY(x, y);
            }
        }

        /*private void DrawHistogram(List<double> data)
        {
            int numberOfInterval = 20; // Количество интервалов
            double[] frequencies = new double[numberOfInterval];// созданиче дин. массива, который хранит частоту каждого интервала
            double Width = 1.0 / numberOfInterval;//ширина каждого интервала

            foreach (double value in data)//цикл вычисления частот для каждого интервала
            {
                int Index = (int)(value / Width);
                frequencies[Index]++;//значение частоты для соотв. интервала +1
            }
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < numberOfInterval; i++)//цикл для отображения на гистограмме
            {
                double x = i * Width;
                double y = frequencies[i] / (data.Count * Width); //data.Count - общее кол-во элементов данных
                chart2.Series[0].Points.AddXY(x, y);
            }
        }*/
        private List<double> GenerateNormalDistribution(int N)
        {
            Random r = new Random();
            List<double> normalData = new List<double>();
            int n = 20;//задаем кол-во случайных чисел для аппроксимации нормального распределения с помощью ЦПТ

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
        private List<double> GenerateExponentialDistribution(int count, double lambda)
        {
            Random r = new Random();
            List<double> exponentialData = new List<double>();

            for (int i = 0; i < count; i++)
            {
                double uniformValue = r.NextDouble();
                double exponentialValue = -Math.Log(1 - uniformValue) / lambda;
                exponentialData.Add(exponentialValue);
            }

            return exponentialData;
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            double lambda = 1.0; // Задайте значение параметра lambda
            var exponentialData = GenerateExponentialDistribution(N, lambda);
            DrawHistogram(exponentialData);
            double mean = CalculateMean(exponentialData);
            double mode = CalculateMode(exponentialData);
            double median = CalculateMedian(exponentialData);
            double variance = CalculateVariance(exponentialData);
            Console.WriteLine($"Mean: {mean}");
            Console.WriteLine($"Mode: {mode}");
            Console.WriteLine($"Median: {median}");
            Console.WriteLine($"Variance: {variance}");
        }
        private double CalculateMean(List<double> data)
        {
            return data.Average();
        }

        private double CalculateMode(List<double> data)
        {
            return data.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
        }

        private double CalculateMedian(List<double> data)
        {
            int count = data.Count();
            var sortedData = data.OrderBy(x => x).ToList();
            return count % 2 == 0 ? (sortedData[count / 2 - 1] + sortedData[count / 2]) / 2 : sortedData[count / 2];
        }

        private double CalculateVariance(List<double> data)
        {
            double mean = CalculateMean(data);
            return data.Select(x => (x - mean) * (x - mean)).Sum() / (data.Count() - 1);
        }
        


    }
}

