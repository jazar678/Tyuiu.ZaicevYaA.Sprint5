using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task7.V25.Lib
{
    public class DataService : ISprint5Task7V25
    {
        public string LoadDataAndSave(string path)
        {
            string tempFile = Path.GetTempFileName();

            try
            {
                // Читаем содержимое файла
                string content = File.ReadAllText(path, Encoding.UTF8);

                // Удаляем английские слова (слова, состоящие из латинских букв)
                // Используем более точное регулярное выражение
                string pattern = @"\b[a-zA-Z]+\b";
                string result = Regex.Replace(content, pattern, "");

                // Убираем лишние пробелы, которые могли образоваться после удаления слов
                result = Regex.Replace(result, @"\s+", " ");
                result = result.Trim();

                // Сохраняем результат во временный файл
                File.WriteAllText(tempFile, result, Encoding.UTF8);

                return tempFile;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обработке файла: {ex.Message}");
            }
        }
    }
}