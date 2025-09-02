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
                // Проверяем существование файла
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Файл не найден: {path}");
                }

                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    // Пропускаем пустые строки
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Разделяем строку на отдельные значения
                    string[] values = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string value in values)
                    {
                        // Пытаемся распарсить число
                        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                        {
                            // Проверяем, является ли число целым
                            if (Math.Abs(number % 1) < double.Epsilon)
                            {
                                sum += number; // Целое число - добавляем как есть
                            }
                            else
                            {
                                // Вещественное число - округляем до 3 знаков
                                sum += Math.Round(number, 3);
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