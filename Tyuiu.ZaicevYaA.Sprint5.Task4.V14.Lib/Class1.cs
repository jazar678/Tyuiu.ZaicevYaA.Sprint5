using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task4.V14.Lib
{
    public class DataService : ISprint5Task4V14
    {
        public double LoadFromDataFile(string path)
        {
            // Чтение значения из файла
            string fileContent = File.ReadAllText(path);

            // Преобразование строки в вещественное число
            double x = double.Parse(fileContent, CultureInfo.InvariantCulture);

            // Вычисление значения по формуле: y = sin(x³) + 2/x
            double y = Math.Sin(Math.Pow(x, 3)) + (2.0 / x);

            // Округление до трёх знаков после запятой
            return Math.Round(y, 3);
        }
    }
}