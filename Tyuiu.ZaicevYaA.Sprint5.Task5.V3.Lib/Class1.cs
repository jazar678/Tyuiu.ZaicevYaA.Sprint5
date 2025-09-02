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

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Убираем лишние пробелы
                        line = line.Trim();

                        if (!string.IsNullOrEmpty(line))
                        {
                            // Пытаемся распарсить число
                            if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                            {
                                // Проверяем, является ли число целым
                                if (Math.Abs(number % 1) < double.Epsilon)
                                {
                                    // Добавляем только целые числа
                                    sum += number;
                                }
                                // Вещественные числа игнорируем (не добавляем к сумме)
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