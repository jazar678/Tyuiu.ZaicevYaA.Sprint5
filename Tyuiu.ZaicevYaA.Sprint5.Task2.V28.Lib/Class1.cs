using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task2.V28.Lib
{
    public class DataService : ISprint5Task2V28
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            // Создаем временный файл
            string tempFile = Path.GetTempFileName();

            // Обрабатываем матрицу и записываем в файл
            using (StreamWriter writer = new StreamWriter(tempFile, false, Encoding.Default))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    string[] lineValues = new string[cols];

                    for (int j = 0; j < cols; j++)
                    {
                        // Заменяем положительные элементы на 1, отрицательные на 0
                        if (matrix[i, j] > 0)
                            lineValues[j] = "1";
                        else
                            lineValues[j] = "0";
                    }

                    // Записываем строку с разделителем ";"
                    writer.WriteLine(string.Join(";", lineValues));
                }
            }

            return tempFile;
        }
    }
}
