using System;
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
            Console.WriteLine("   x   |   F(x)   ");
            Console.WriteLine("-------------------");

            for (int x = startValue; x <= stopValue; x++)
            {
                double result = CalculateFunction(x);
                Console.WriteLine($"{x,6} | {result,8:F2}");
            }

            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Создан!");
            Console.ReadKey();
        }

        private static double CalculateFunction(int x)
        {
            // Проверка деления на ноль
            if (Math.Abs(x + 1.2) < 0.0001)
            {
                return 0;
            }

            double numerator = Math.Sin(x);
            double denominator = x + 1.2;
            double term1 = numerator / denominator;
            double term2 = Math.Sin(x) * 2;
            double term3 = 2 * x;

            return term1 - term2 - term3;
        }
    }
}