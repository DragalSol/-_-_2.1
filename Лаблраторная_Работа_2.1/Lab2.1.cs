using System;
using System.IO;
using System.Linq;

/// <summary>
/// Класс для выполнения задачи лабораторной работы 2-1.
/// </summary>
class Lab2_1
{
    /// <summary>
    /// Главный метод программы.
    /// </summary>
    static void Main()
    {
        try
        {
            // Укажите путь к вашему текстовому файлу
            string filePath = "C:/Users/Гость1/Desktop/Текстовый документ.txt";

            // Загрузка предложений из файла
            string[] sentences = LoadSentences(filePath);

            if (sentences.Length >= 3)
            {
                // Выбор первых трех предложений, их обратное упорядочивание и вывод
                var firstThreeSentences = sentences.Take(3).Reverse();

                Console.WriteLine("Ваши три предложения в обратном порядке:");

                // Вывод предложений
                foreach (var sentence in firstThreeSentences)
                {
                    Console.WriteLine(sentence);
                }
            }
            else
            {
                Console.WriteLine("Файл содержит менее трех предложений. Невозможно выполнить задачу.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    /// <summary>
    /// Загружает предложения из текстового файла.
    /// </summary>
    /// <param name="filePath">Путь к текстовому файлу.</param>
    /// <returns>Массив строк, представляющих предложения.</returns>
    static string[] LoadSentences(string filePath)
    {
        // Чтение строк из файла
        var lines = File.ReadAllLines(filePath);

        // Разделение строк на предложения
        var sentences = lines.SelectMany(line => line.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                            .Select(sentence => sentence.Trim());

        return sentences.ToArray();
    }

    // Используем readonly, чтобы обозначить, что поле может быть установлено только во время выполнения.
    private static readonly char[] separators = { '.', '!', '?' };
}
