using LaboratoryThirdModel;
using System.Text.Json;

namespace View.Services
{
    public static class PublicationSerializer
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public static void Save(List<IPublication> publications, string path)
        {
            var list = publications.Cast<object>().ToList();
            File.WriteAllText(path, JsonSerializer.Serialize(list, _options));
        }

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
                    result.Add(JsonSerializer.Deserialize<Collection>(doc)!);
                else if (doc.TryGetProperty("AuthorFull", out _))
                    result.Add(JsonSerializer.Deserialize<Dissertation>(doc)!);
            }
            return result;
        }
    }
}
