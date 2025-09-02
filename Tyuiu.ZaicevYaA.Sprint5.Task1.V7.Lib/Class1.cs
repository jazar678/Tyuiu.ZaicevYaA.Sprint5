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
                for (int x = startValue; x <= stopValue; x++)
                {
                    double result = CalculateFunction(x);
                    // Записываем только числовые значения с двумя знаками после запятой
                    writer.WriteLine($"{result:F2}".Replace(",", ".")); // Используем точку как разделитель
                }
            }

            return path;
        }

        private double CalculateFunction(int x)
        {
            // Проверка деления на ноль
            if (Math.Abs(x + 1.2) < 0.0001)
            {
                return 0;
            }

            double sinX = Math.Sin(x);
            double term1 = sinX / (x + 1.2);
            double term2 = sinX * 2;
            double term3 = 2 * x;

            return term1 - term2 - term3;
        }
    }
}