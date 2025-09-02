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

            // Путь к файлу
            string path = @"C:\DataSprint5\InPutDataFileTask5V3.txt";

            try
            {
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
                Console.WriteLine("***************************************************************************");
                Console.WriteLine($"Файл: {path}");

                if (File.Exists(path))
                {
                    Console.WriteLine("Содержимое файла:");
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Файл не существует!");
                    return;
                }

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
                Console.WriteLine("***************************************************************************");

                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Сумма всех целых чисел в файле = {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}