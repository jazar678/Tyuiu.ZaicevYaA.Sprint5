using System;
using System.IO;
using Tyuiu.ZaicevYaA.Sprint5.Task0.V7.Lib;

namespace Tyuiu.ZaicevYaA.Sprint5.Task0.V7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Зайцев Я.А. | ПКТб-24-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка файлов                                                  *");
            Console.WriteLine("* Задание #0                                                              *");
            Console.WriteLine("* Вариант #7                                                              *");
            Console.WriteLine("* Выполнил: Зайцев Ярослав Александрович | ПКТб-24-1                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение F(x) = -x^3 + 4x^2 - 3/2*x. Вычислить его значение при   *");
            Console.WriteLine("* x = 4, результат сохранить в файл OutPutFileTask0.txt и вывести на      *");
            Console.WriteLine("* консоль. Округлить до трех знаков после запятой.                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int x = 4;
            Console.WriteLine($"x = {x}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(x);

            // Читаем результат из файла
            string result;
            using (StreamReader reader = new StreamReader(path))
            {
                result = reader.ReadLine();
            }

            Console.WriteLine($"Результат: {result}");
            Console.WriteLine($"Файл сохранен по пути: {path}");

            Console.ReadKey();
        }
    }
}