using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task5.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();

            string path = @"C:\DataSprint5\InPutDataFileTask5V3.txt";

            // Если файл существует, тестируем на реальных данных
            if (File.Exists(path))
            {
                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Результат для реального файла: {result}");
                Assert.IsTrue(result >= 0); // Проверяем, что результат не отрицательный
            }
            else
            {
                // Создаем тестовый файл
                string tempPath = Path.GetTempPath();
                string testFilePath = Path.Combine(tempPath, "testFile.txt");

                string testData = "10 3.14159 25 7.888 100 2.71828 50 1.234567";
                File.WriteAllText(testFilePath, testData);

                double result = ds.LoadFromDataFile(testFilePath);

                // Ожидаемый результат: 10 + 3.142 + 25 + 7.888 + 100 + 2.718 + 50 + 1.235 = 200.983
                double expected = 10 + 3.142 + 25 + 7.888 + 100 + 2.718 + 50 + 1.235;

                Assert.AreEqual(expected, result, 0.001);

                // Очистка
                File.Delete(testFilePath);
            }
        }
    }
}