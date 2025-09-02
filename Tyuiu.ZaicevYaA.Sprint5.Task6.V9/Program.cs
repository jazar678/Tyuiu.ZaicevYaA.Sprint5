using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task6.V9.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task6.V9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Создаем путь к файлу
            string path = Path.Combine(@"C:\DataSprint5\InPutDataFileTask6", "9.txt");

            Console.WriteLine($"Файл: {path}");
            Console.WriteLine("Данные находятся в файле!");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                int count = ds.LoadFromDataFile(path);
                Console.WriteLine($"Количество слов длиной 3 символа = {count}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Убедитесь, что файл существует по указанному пути.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}