using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Lib
{
    public class DataService : ISprint5Task1V7
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine("Табулирование функции F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2x");
                writer.WriteLine("Диапазон: [" + startValue + "; " + stopValue + "]");
                writer.WriteLine("Шаг: 1");
                writer.WriteLine("====================");
                writer.WriteLine("   x   |   F(x)   ");
                writer.WriteLine("-------------------");

                for (int x = startValue; x <= stopValue; x++)
                {
                    double result = CalculateFunction(x);
                    writer.WriteLine($"{x,6} | {result,8:F2}");
                }
            }

            return path;
        }

        private double CalculateFunction(int x)
        {
            // Проверка деления на ноль
            if (Math.Abs(x + 1.2) < 0.0001) // Используем эпсилон для сравнения с плавающей точкой
            {
                return 0;
            }

            double numerator = Math.Sin(x);
            double denominator = x + 1.2;
            double term1 = numerator / denominator;
            double term2 = Math.Sin(x) * 2;
            double term3 = 2 * x;

            return term1 - term2 - term3;
        }
    }
}