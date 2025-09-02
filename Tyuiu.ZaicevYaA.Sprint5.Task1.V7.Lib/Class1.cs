using System;
using System.IO;
using System.Text;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Lib
{
    public class DataService : ISprint5Task1V7
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int x = startValue; x <= stopValue; x++)
                {
                    double result = CalculateFunction(x);

                    // Форматируем с запятой и убираем лишние нули
                    string formattedResult = FormatResult(result);
                    writer.WriteLine(formattedResult);
                }
            }

            return path;
        }

        private string FormatResult(double result)
        {
            // Округляем до двух знаков
            result = Math.Round(result, 2);

            // Преобразуем в строку с запятой
            string resultStr = result.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"));

            // Убираем лишние нули после запятой
            if (resultStr.Contains(","))
            {
                resultStr = resultStr.TrimEnd('0');
                if (resultStr.EndsWith(","))
                {
                    resultStr = resultStr.TrimEnd(',');
                }
            }

            return resultStr;
        }

        private double CalculateFunction(int x)
        {
            // Проверка деления на ноль
            if (Math.Abs(x + 1.2) < 0.0001)
            {
                return 0;
            }

            double sinX = Math.Sin(x);
            double term1 = sinX / (x + 1.2);
            double term2 = sinX * 2;
            double term3 = 2 * x;

            return term1 - term2 - term3;
        }
    }
}