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

                        // Пропускаем пустые строки
                        if (string.IsNullOrEmpty(line))
                            continue;

                        // Проверяем, является ли строка целым числом
                        // Целое число не должно содержать запятых или точек
                        if (!line.Contains(',') && !line.Contains('.'))
                        {
                            // Пытаемся распарсить как целое число (включая отрицательные)
                            if (int.TryParse(line, NumberStyles.Integer, CultureInfo.InvariantCulture, out int integerNumber))
                            {
                                sum += integerNumber;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                throw;
            }

            return sum;
        }
    }
}