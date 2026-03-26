using LaboratoryThirdModel;
using System.Text.Json;

namespace View.Services
{
    /// <summary>
    /// Класс сериализатор
    /// </summary>
    public static class PublicationSerializer
    {
        /// <summary>
        /// Опции сериализации
        /// </summary>
        private static readonly JsonSerializerOptions _options 
            = new() { WriteIndented = true };

        /// <summary>
        /// Метод сохранения
        /// </summary>
        /// <param name="publications">Список изданий</param>
        /// <param name="path">Путь до файла</param>
        public static void Save(List<IPublication> publications, string path)
        {
            var list = publications.Cast<object>().ToList();
            File.WriteAllText(path,
                JsonSerializer.Serialize(list, _options));
        }

        /// <summary>
        /// Метод загрузки
        /// </summary>
        /// <param name="path">Путь до файла</param>
        /// <returns>Список изданий</returns>
        public static List<IPublication> Load(string path)
        {
            var json = File.ReadAllText(path);
            var docs = JsonDocument.Parse(json).RootElement.EnumerateArray();
            var result = new List<IPublication>();

            foreach (var doc in docs)
            {
                if (doc.TryGetProperty("Authors", out _))
                    result.Add(JsonSerializer.Deserialize<Book>(doc)!);
                else if (doc.TryGetProperty("Frequency", out _))
                    result.Add(JsonSerializer.Deserialize<Journal>(doc)!);
                else if (doc.TryGetProperty("EditorialBoard", out _))
                    result
                        .Add(JsonSerializer.Deserialize<Collection>(doc)!);
                else if (doc.TryGetProperty("AuthorFull", out _))
                    result
                        .Add(JsonSerializer.Deserialize<Dissertation>(doc)!);
            }
            return result;
        }
    }
}
