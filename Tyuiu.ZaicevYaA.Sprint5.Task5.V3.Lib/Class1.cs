using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

usinusing System;
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

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Разделяем строку по пробелам и обрабатываем каждое значение
                        string[] values = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string value in values)
                        {
                            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                            {
                                // Если число целое, добавляем как есть
                                if (number == Math.Floor(number))
                                {
                                    sum += number;
                                }
                                else
                                {
                                    // Если вещественное, округляем до 3 знаков
                                    sum += Math.Round(number, 3);
                                }
                            }
                        }
                    }
                }

                return sum;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
}