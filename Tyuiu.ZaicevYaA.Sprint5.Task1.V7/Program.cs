using System;
using System.Globalization;
using Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task1.V7
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            int startValue = -5;
            int stopValue = 5;

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Начало диапазона: {startValue}");
            Console.WriteLine($"Конец диапазона: {stopValue}");
            Console.WriteLine($"Шаг: 1");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string res = ds.SaveToFileTextData(startValue, stopValue);

            // Вывод результатов в консоль
            for (int x = startValue; x <= stopValue; x++)
            {
                double result = CalculateFunction(x);
                string formattedResult = FormatResult(result);
                Console.WriteLine(formattedResult);
            }

            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Создан!");
            Console.ReadKey();
        }

        private static string FormatResult(double result)
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

        private static double CalculateFunction(int x)
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