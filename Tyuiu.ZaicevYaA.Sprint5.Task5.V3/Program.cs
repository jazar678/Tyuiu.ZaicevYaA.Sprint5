using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task5.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            // Создаем временный файл с тестовыми данными
            string tempFile = Path.GetTempFileName();
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                writer.WriteLine("10 20.5678 30 40.123456 50");
                writer.WriteLine("15.999 25 35.5 45 55.123");
            }

            Console.WriteLine($"Файл: {tempFile}");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(tempFile);

            Console.WriteLine($"Сумма всех чисел (вещественные округлены до 3 знаков) = {result}");
            Console.WriteLine("***************************************************************************");

            // Удаляем временный файл
            File.Delete(tempFile);

            Console.ReadKey();
        }
    }
}