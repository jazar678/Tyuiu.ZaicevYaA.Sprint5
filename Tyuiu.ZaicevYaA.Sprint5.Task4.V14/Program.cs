using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task4.V14.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task4.V14
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            // Создание пути к файлу
            string path = Path.Combine(@"C:\DataSprint5\", "InPutDataFileTask4V14.txt");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Файл: {path}");
            Console.WriteLine($"Существует файл: {File.Exists(path)}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"y = {result}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден! Убедитесь, что файл существует по указанному пути.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}