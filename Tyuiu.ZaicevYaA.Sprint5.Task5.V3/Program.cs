using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task5.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем временный файл с тестовыми данными
            string tempFilePath = Path.GetTempFileName();

            try
            {
                // Записываем тестовые данные в файл (пример, который должен дать сумму 35)
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    writer.WriteLine("10");      // целое - добавляем
                    writer.WriteLine("3.14159"); // вещественное - игнорируем
                    writer.WriteLine("15");      // целое - добавляем
                    writer.WriteLine("7.888");   // вещественное - игнорируем
                    writer.WriteLine("10");      // целое - добавляем
                    writer.WriteLine("2.71828"); // вещественное - игнорируем
                    // Итого: 10 + 15 + 10 = 35
                }

                Console.WriteLine("Файл создан: " + tempFilePath);
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(File.ReadAllText(tempFilePath));

                // Вычисляем сумму
                DataService ds = new DataService();
                double result = ds.LoadFromDataFile(tempFilePath);

                Console.WriteLine("Результат: " + result);
             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                // Удаляем временный файл
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }

            Console.ReadKey();
        }
    }
}