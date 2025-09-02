using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task6.V9.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task6.V9.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            // Создаем временный файл для тестирования
            string path = Path.GetTempFileName();

            // Записываем тестовые данные
            string testData = "Это тестовая строка с cat, dog и fox. Также 123 и abc!";
            File.WriteAllText(path, testData);

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            // Ожидаемый результат: cat, dog, fox, abc - 4 слова
            Assert.AreEqual(4, result);

            // Удаляем временный файл
            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundTest()
        {
            DataService ds = new DataService();
            ds.LoadFromDataFile("nonexistent_file.txt");
        }

        [TestMethod]
        public void EmptyFileTest()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "");

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            Assert.AreEqual(0, result);

            File.Delete(path);
        }
    }
}