using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Lib
{
    public class DataService : ISprint5Task5V3
    {
        public double LoadFromDataFile(string path)
        {
            double sum = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (!string.IsNullOrEmpty(line))
                    {
                        // Заменяем запятую на точку для корректного парсинга
                        string normalizedLine = line.Replace(',', '.');

                        if (double.TryParse(normalizedLine, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                        {
                            // Проверяем, является ли число целым
                            if (Math.Abs(number % 1) < 0.000001)
                            {
                                sum += number;
                            }
                        }
                    }
                }
            }

            return sum;
        }
    }
}