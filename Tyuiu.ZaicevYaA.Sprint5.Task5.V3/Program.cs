using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task5.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем путь к файлу (используем указанный путь C:\DataSpirit5\)
            string path = Path.Combine("C:", "DataSprint5", "InPutDataFileTask5V3.txt");

            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Файл: {path}");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Сумма всех чисел в файле = {result:F3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}