using LaboratoryThirdModel;
using System.Text.Json;
using System.Text;

namespace View.Services
{
    /// <summary>
    /// Класс для сериализации изданий
    /// </summary>
    public static class PublicationSerializer
    {
        /// <summary>
        /// Опции JSON сериализатора
        /// </summary>
        private static readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        /// <summary>
        /// Метод для сохранения файла
        /// </summary>
        /// <param name="publications">Список публикаций</param>
        /// <param name="path">Путь</param>
        public static void Save(List<IPublication> publications, string path)
        {
            var list = publications.Cast<IPublication>().ToList();
            File.WriteAllText(path, JsonSerializer.Serialize(list,
                _options));
        }

        /// <summary>
        /// Метод для загрузки публикации
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Список публикаций</returns>
        /// <exception cref="InvalidOperationException">
        /// Ошибка, при повреждении файла</exception>
        public static List<IPublication> Load(string path)
        {
            var json = File.ReadAllText(path);
            JsonDocument doc = JsonDocument.Parse(json);
            var result = new List<IPublication>();

            foreach (JsonElement elementJSON in
                doc.RootElement.EnumerateArray())
            {
                if (HasEmptyStrings(elementJSON))
                {
                    throw new InvalidOperationException("" +
                        "Файл поврежден: обнаружены пустые значения");
                }

                if (!HasValidYear(elementJSON))
                {
                    throw new InvalidOperationException($"Файл поврежден:" +
                        $" год издания должен быть от" +
                        $" {IPublication.MinYear} " +
                        $"до {DateTime.Now.Year}");
                }

                string typePublication = elementJSON
                    .GetProperty("$type").GetString();

                switch (typePublication)
                {
                    case "book":
                    {
                        result.Add(JsonSerializer.Deserialize<Book>
                            (elementJSON.GetRawText(), _options)!);
                        break;
                    }
                    case "journal":
                    {
                        result.Add(JsonSerializer.Deserialize<Journal>
                            (elementJSON.GetRawText(), _options)!);
                        break;
                    }
                    case "collection":
                    {
                        result.Add(JsonSerializer.Deserialize<Collection>
                            (elementJSON.GetRawText(), _options)!);
                        break;
                    }
                    case "dissertation":
                    {
                        result.Add(JsonSerializer.Deserialize<Dissertation>
                            (elementJSON.GetRawText(), _options)!);
                        break;
                    }
                    default:
                    {
                        throw new ArgumentException("Не найден" +
                            " тип публикации");
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Метод для проверки наличия строк
        /// </summary>
        /// <param name="element">Элемент JSON</param>
        /// <returns>true, если нет пустых строк, иначе false</returns>
        private static bool HasEmptyStrings(JsonElement element)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.Name == "$type") continue;

                if (property.Value.ValueKind == JsonValueKind.String &&
                    string.IsNullOrEmpty(property.Value.GetString()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод для валидации года
        /// </summary>
        /// <param name="element">Элемент JSON</param>
        /// <returns>true, если валидно, иначе false</returns>
        private static bool HasValidYear(JsonElement element)
        {
            if (!element.TryGetProperty("Year", out JsonElement yearElement))
            {
                return false;
            }

            if (yearElement.ValueKind != JsonValueKind.Number)
            {
                return false;
            }

            int year = yearElement.GetInt32();
            return year >= IPublication.MinYear 
                && year <= DateTime.Now.Year;
        }
    }
}