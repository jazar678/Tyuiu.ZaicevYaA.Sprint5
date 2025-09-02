using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task7.V25.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task7.V25.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask7V25.txt";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void ValidRemoveEnglishWords()
        {
            // Создаем временный файл с тестовыми данными
            string tempFile = Path.GetTempFileName();
            string testContent = "Hello мир World 123 Привет Test данные Data 456";
            File.WriteAllText(tempFile, testContent, System.Text.Encoding.UTF8);

            DataService ds = new DataService();
            string resultFile = ds.LoadDataAndSave(tempFile);

            string resultContent = File.ReadAllText(resultFile, System.Text.Encoding.UTF8);
            string expected = " мир  123 Привет  данные  456";

            // Удаляем временные файлы
            File.Delete(tempFile);
            File.Delete(resultFile);

            Assert.AreEqual(expected, resultContent);
        }
    }
}