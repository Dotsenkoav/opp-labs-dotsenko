using System.Text;

namespace LaboratoryThirdModel
{
    /// <summary>
    /// Класс описывающий издание книги
    /// </summary>
    public class Book : PublicationBase
    {
        /// <summary>
        /// Максимальное число авторов для добавления перед заголовком
        /// </summary>
        private const int MaxAuthorsForTitle = 3;

        /// <summary>
        /// Минимальное число авторов для добавления перед заголовком
        /// </summary>
        private const int MinAuthorsForTitle = 1;

        /// <summary>
        /// Для проверки, если автор один
        /// </summary>
        private const int SingleAuthor = 1;

        /// <summary>
        /// Максимальное число авторов для добавления в полный список
        /// </summary>
        private const int MaxAuthorsForFullList = 3;

        /// <summary>
        /// Поле для хранения авторов
        /// </summary>
        private readonly List<string> _authors = new();

        /// <summary>
        /// Свойство для чтения авторов
        /// </summary>
        public IReadOnlyList<string> Authors => _authors;

        /// <summary>
        /// Метод для добавления авторов
        /// </summary>
        /// <param name="authors">Автор или массив авторов</param>
        /// <exception cref="ArgumentException">
        /// Ошибка при пустой передаче в метод</exception>
        public void AddAuthors(params string[] authors)
        {
            if (authors == null || authors.Length == 0)
            {
                throw new ArgumentException(
                    "Должен передаваться минимум один автор",
                    nameof(authors));
            }

            foreach (var author in authors)
            {
                ValidateString(author, nameof(author));
                _authors.Add(author);
            }
        }

        /// <summary>
        /// Метод получения информации о книге по ГОСТ
        /// </summary>
        /// <returns>Строку с информацией о книге по ГОСТ</returns>
        public override string GetGOSTInformation()
        {
            var bookInformation = new StringBuilder();

            int authorCount = _authors.Count;
            if (authorCount >= MinAuthorsForTitle
                && authorCount <= MaxAuthorsForTitle)
            {
                bookInformation.Append($"{_authors[0]} {Title}");
            }
            else
            {
                bookInformation.Append(Title);
            }

            AppendIfNotEmpty(bookInformation, " : ", TitleInformation);

            if (authorCount > 0)
            {
                bookInformation.Append(" / ");
                if (authorCount == SingleAuthor)
                {
                    bookInformation.Append(SwapAuthorFormat(_authors[0]));
                }
                else if (authorCount <= MaxAuthorsForFullList)
                {
                    var formattedAuthors = _authors.Select(SwapAuthorFormat);
                    bookInformation.Append(string.Join(", ",
                        formattedAuthors));
                }
                else
                {
                    var firstThree = _authors.Take(MaxAuthorsForFullList)
                        .Select(SwapAuthorFormat);
                    bookInformation.Append($"{string.Join(", ",
                        firstThree)} [и др.]");
                }
            }

            bookInformation.Append($" – {Place} : {Publisher}," +
                $" {Year} – {TotalPages} с.");

            return bookInformation.ToString();
        }

        /// <summary>
        /// Метод для форматирования авторов
        /// </summary>
        /// <param name="author">Автор</param>
        /// <returns>Сформатированного автора</returns>
        private string SwapAuthorFormat(string author)
        {
            var partsAuthor = author.Split(new[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries);

            return $"{string.Join(" ", partsAuthor.Skip(1))}" +
                $" {partsAuthor[0]}";
        }
    }
}
