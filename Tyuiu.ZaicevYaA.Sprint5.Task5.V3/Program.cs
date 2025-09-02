using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task5.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            // Создаем тестовый файл в временной директории
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "testData.txt");

            // Создаем тестовые данные
            string testData = "10 3.14159 25 7.888 100 2.71828 50 1.234567";
            File.WriteAllText(filePath, testData);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Файл: {filePath}");
            Console.WriteLine("Данные: 10 3.14159 25 7.888 100 2.71828 50 1.234567");
            Console.WriteLine();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            double result = ds.LoadFromDataFile(filePath);
            Console.WriteLine($"Сумма всех чисел (вещественные округлены до 3 знаков) = {result}");
            Console.WriteLine();

            // Очистка
            File.Delete(filePath);

            Console.ReadKey();
        }
    }
}