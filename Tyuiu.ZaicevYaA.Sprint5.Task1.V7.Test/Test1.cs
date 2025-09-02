using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            string path = @"C:\Users\user\source\repos\Tyuiu.ZaicevYaA.Sprint5\Tyuiu.ZaicevYaA.Sprint5.Task1.V7\bin\Debug\OutPutFileTask1.txt";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            Assert.AreEqual(true, fileExists);
        }

        [TestMethod]
        public void ValidCalculateFunction()
        {
            DataService ds = new DataService();

            // Тест деления на ноль (x = -1.2, но так как x целое, проверяем x = -1)
            double result1 = ds.CalculateFunction(-1); // x + 1.2 = 0.2 ≠ 0
            double result2 = ds.CalculateFunction(-2); // x + 1.2 = -0.8 ≠ 0

            Assert.AreNotEqual(0, result1);
            Assert.AreNotEqual(0, result2);
        }
    }
}