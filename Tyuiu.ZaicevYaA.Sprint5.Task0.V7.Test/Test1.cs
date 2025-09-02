using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task0.V7.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task0.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            string path = @"C:\Users\user\source\repos\Tyuiu.ZaicevYaA.Sprint5\Tyuiu.ZaicevYaA.Sprint5.Task0.V7\bin\Debug\OutPutFileTask0.txt";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            Assert.AreEqual(true, fileExists);
        }

        [TestMethod]
        public void ValidCalculation()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(4);

            string result;
            using (StreamReader reader = new StreamReader(path))
            {
                result = reader.ReadLine();
            }

            // Проверяем вычисление: -4^3 + 4*4^2 - 1.5*4 = -64 + 64 - 6 = -6
            Assert.AreEqual("-6", result);
        }
    }
}