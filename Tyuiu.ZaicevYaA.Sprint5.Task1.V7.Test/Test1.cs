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
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            Assert.AreEqual(true, fileExists);
        }

        [TestMethod]
        public void ValidDivisionByZeroCheck()
        {
            DataService ds = new DataService();

            // Проверяем точку, где знаменатель близок к нулю (x = -1.2)
            // Поскольку x - целое число, проверяем x = -1
            double result = ds.CalculateFunction(-1);

            // x = -1: -1 + 1.2 = 0.2 ≠ 0, должно быть нормальное вычисление
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void ValidFunctionCalculation()
        {
            DataService ds = new DataService();

            // Проверяем вычисление для x = 0
            double result = ds.CalculateFunction(0);
            // F(0) = sin(0)/(0+1.2) - sin(0)*2 - 2*0 = 0/1.2 - 0 - 0 = 0
            Assert.AreEqual(0, result);

            // Проверяем вычисление для x = 1
            result = ds.CalculateFunction(1);
            // F(1) = sin(1)/(1+1.2) - sin(1)*2 - 2*1
            double expected = Math.Sin(1) / 2.2 - Math.Sin(1) * 2 - 2;
            expected = Math.Round(expected, 2);
            Assert.AreEqual(expected, result);
        }
    }
}