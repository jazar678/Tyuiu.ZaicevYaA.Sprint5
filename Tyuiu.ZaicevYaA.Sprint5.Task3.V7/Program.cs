using System;
using Tyuiu.ZaicevYaA.Sprint5.Task3.V7.Lib;

class Program
{
    static void Main()
    {
        Class1 calculator = new Class1();
        string filePath = calculator.SaveToFileTextData(2);

        // Чтение из файла для проверки
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            double resultFromFile = reader.ReadDouble();
            Console.WriteLine($"Прочитано из файла: {resultFromFile:F3}");
        }

        Console.ReadKey();
    }
}