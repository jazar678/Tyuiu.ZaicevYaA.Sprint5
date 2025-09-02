using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Lib
{
    public class DataService : ISprint5Task1V7
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.GetTempFileName();

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Табулирование функции F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2x");
                writer.WriteLine("+----------+----------+");
                writer.WriteLine("|    x     |   f(x)   |");
                writer.WriteLine("+----------+----------+");

                for (int x = startValue; x <= stopValue; x++)
                {
                    double result = CalculateFunction(x);
                    writer.WriteLine($"| {x,8} | {result,8:F2} |");
                }

                writer.WriteLine("+----------+----------+");
            }

            return path;
        }

        private double CalculateFunction(int x)
        {
            try
            {
                // Проверка деления на ноль
                if (Math.Abs(x + 1.2) < 0.0001) // Проверка на близкое к нулю значение
                {
                    return 0;
                }

                double numerator = Math.Sin(x);
                double denominator = x + 1.2;
                double term1 = numerator / denominator;
                double term2 = Math.Sin(x) * 2;
                double term3 = 2 * x;

                double result = term1 - term2 - term3;
                return Math.Round(result, 2);
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
    }
}