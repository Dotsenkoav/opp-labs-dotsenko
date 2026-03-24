namespace View
{
    /// <summary>
    /// Класс, работающий с файлами
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// Метод для считывания файла
        /// </summary>
        /// <param name="file">Название файла</param>
        /// <param name="defaultPath">Путь до файла</param>
        /// <returns>Список из строк файла</returns>
        public static string[] ReadFile(string file,
            string defaultPath = "Data/")
        {
            string fullPath = Path.GetFullPath(Path.Combine(defaultPath,
                file));

            if (!File.Exists(fullPath))
            {
                return Array.Empty<string>();
            }

            return File.ReadAllLines(fullPath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToArray();
        }
    }
}
