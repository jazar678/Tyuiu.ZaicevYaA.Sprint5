using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task1.V7.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task1.V7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Зайцев Я.А. | ПКТб-24-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Табулирование функции                                             *");
            Console.WriteLine("* Задание #1                                                              *");
            Console.WriteLine("* Вариант #7                                                              *");
            Console.WriteLine("* Выполнил: Зайцев Ярослав Александрович | ПКТб-24-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дана функция: F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2x                     *");
            Console.WriteLine("* Произвести табулирование f(x) на диапазоне [-5; 5] с шагом 1.           *");
            Console.WriteLine("* При делении на ноль вернуть значение 0. Результат сохранить в файл и    *");
            Console.WriteLine("* вывести на консоль в таблицу. Округлить до двух знаков после запятой.   *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int startValue = -5;
            int stopValue = 5;

            Console.WriteLine($"Старт шага = {startValue}");
            Console.WriteLine($"Конец шага = {stopValue}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(startValue, stopValue);

            // Читаем и выводим содержимое файла на консоль
            Console.WriteLine("Табулирование функции F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2x");
            Console.WriteLine("+----------+----------+");
            Console.WriteLine("|    x     |   f(x)   |");
            Console.WriteLine("+----------+----------+");

            using (StreamReader reader = new StreamReader(path))
            {
                // Пропускаем первые 4 строки (заголовки)
                for (int i = 0; i < 4; i++)
                {
                    reader.ReadLine();
                }

                // Выводим таблицу с результатами
                string line;
                while ((line = reader.ReadLine()) != null && line != "+----------+----------+")
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("+----------+----------+");
            Console.WriteLine($"Файл сохранен по пути: {path}");

            Console.ReadKey();
        }
    }
}