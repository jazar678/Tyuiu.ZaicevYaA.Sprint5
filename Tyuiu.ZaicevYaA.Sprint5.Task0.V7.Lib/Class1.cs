using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task0.V7.Lib
{
    public class DataService : ISprint5Task0V7
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем значение функции
            double result = -Math.Pow(x, 3) + 4 * Math.Pow(x, 2) - (3.0 / 2) * x;

            // Округляем до трех знаков после запятой
            result = Math.Round(result, 3);

            // Создаем временный файл
            string path = Path.GetTempFileName();

            // Записываем результат в файл
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(result);
            }

            return path;
        }
    }
}