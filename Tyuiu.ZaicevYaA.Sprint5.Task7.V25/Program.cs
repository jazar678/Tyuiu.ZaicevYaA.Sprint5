using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task7.V25.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task7.V25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Создаем тестовую папку и файл
            string tempPath = Path.GetTempPath();
            string inputFile = Path.Combine(tempPath, "InPutDataFileTask7V25.txt");
            string outputFile = Path.Combine(tempPath, "OutPutDataFileTask7V25.txt");

            // Создаем тестовые данные
            string testContent = "Hello мир World 123 Привет Test данные Data 456";
            File.WriteAllText(inputFile, testContent, System.Text.Encoding.UTF8);

            Console.WriteLine($"Входной файл: {inputFile}");
            Console.WriteLine("Содержимое входного файла:");
            Console.WriteLine(testContent);
            Console.WriteLine();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                string resultFile = ds.LoadDataAndSave(inputFile);

                // Копируем результат в выходной файл
                File.Copy(resultFile, outputFile, true);

                string resultContent = File.ReadAllText(outputFile, System.Text.Encoding.UTF8);

                Console.WriteLine($"Выходной файл: {outputFile}");
                Console.WriteLine("Содержимое выходного файла:");
                Console.WriteLine(resultContent);

                // Удаляем временные файлы
                File.Delete(resultFile);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}