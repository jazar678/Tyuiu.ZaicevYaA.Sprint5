using System;
using System.IO;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZaicevYaA.Sprint5.Task6.V9.Lib
{
    public class DataService : ISprint5Task6V9
    {
        public int LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string content = File.ReadAllText(path);

            // Используем регулярное выражение для поиска слов длиной 3 символа
            // \b - граница слова, [a-zA-Zа-яА-Я] - буквы (английские и русские), {3} - ровно 3 символа
            MatchCollection matches = Regex.Matches(content, @"\b[a-zA-Zа-яА-Я]{3}\b");

            return matches.Count;
        }
    }
}