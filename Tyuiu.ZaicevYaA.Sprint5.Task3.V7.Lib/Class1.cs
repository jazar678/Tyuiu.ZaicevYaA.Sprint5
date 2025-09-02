using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task3.V7.Lib
{
    public class Class1 : ISprint5Task3V7
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем значение функции
            double result = 1.6 * Math.Pow(x, 3) - 2.1 * Math.Pow(x, 2) + 7 * x;

            // Округляем до трёх знаков после запятой
            result = Math.Round(result, 3);

            // Создаем временный файл
            string tempFilePath = Path.GetTempFileName();

            // Переименовываем файл в нужное имя
            string outputFilePath = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Если файл уже существует, удаляем его
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            // Переименовываем временный файл
            File.Move(tempFilePath, outputFilePath);

            // Записываем результат в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
            {
                writer.Write(result);
            }

            // Выводим результат на консоль
            Console.WriteLine($"F({x}) = {result.ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Результат сохранен в файл: {outputFilePath}");

            return outputFilePath;
        }
    }
}