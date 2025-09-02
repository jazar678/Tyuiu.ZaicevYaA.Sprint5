using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task2.V28.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task2.V28
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Исходная матрица 3x3
            int[,] matrix = new int[3, 3]
            {
                { -5, -2, -5 },
                { 3, 1, -3 },
                { 9, -2, -9 }
            };

            // Вывод исходной матрицы
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            // Создаем экземпляр сервиса и обрабатываем данные
            DataService ds = new DataService();
            string outputFile = ds.SaveToFileTextData(matrix);

            // Читаем результат из файла и выводим на консоль
            string[] resultLines = File.ReadAllLines(outputFile);

            Console.WriteLine("Преобразованная матрица:");
            foreach (string line in resultLines)
            {
                string[] values = line.Split(';');
                foreach (string value in values)
                {
                    Console.Write($"{value,4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Файл сохранен: {outputFile}");

            // Очистка временного файла (опционально)
            File.Delete(outputFile);

            Console.ReadKey();
        }
    }
}