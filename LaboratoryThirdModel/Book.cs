using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryThirdModel
{
    /// <summary>
    /// Класс описывающий издание книги
    /// </summary>
    public class Book : PublicationBase
    {
        /// <summary>
        /// Поле для хранения авторов
        /// </summary>
        private readonly List<string> _authors = new();

        /// <summary>
        /// Издательство
        /// </summary>
        private string _publisher;

        /// <summary>
        /// Информация о заглавии
        /// </summary>
        private string _titleInfo;

        /// <summary>
        /// Свойство для чтения авторов
        /// </summary>
        public IReadOnlyList<string> Authors => _authors;

        /// <summary>
        /// Свойство издательства
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set
            {
                ValidateString(value, nameof(Publisher));
                _publisher = value;
            }
        }

        /// <summary>
        /// Авто-свойство информации о заглавии
        /// </summary>
        public string TitleInfo { get; set; }

        /// <summary>
        /// Мето для добавления авторов
        /// </summary>
        /// <param name="authors">Автор или массив авторов</param>
        /// <exception cref="ArgumentException">
        /// Ошибка при пустой передаче в метод</exception>
        public void AddAuthors(params string[] authors)
        {
            if (authors == null || authors.Length == 0)
                //TODO: {}
                throw new ArgumentException(
                    "Должен передаваться минимум один автор",
                    nameof(authors));

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
        public override string GetGOSTInfo()
        {
            var publicationInfo = new StringBuilder();

            int authorCount = _authors.Count;
            //TODO: magic (to const)
            if (authorCount >= 1 && authorCount <= 3)
            {
                publicationInfo.Append($"{_authors[0]} {Title}");
            }
            else
            {
                publicationInfo.Append(Title);
            }

            if (!string.IsNullOrWhiteSpace(TitleInfo))
            {
                publicationInfo.Append($" : {TitleInfo}");
            }

            if (authorCount > 0)
            {
                publicationInfo.Append(" / ");
                //TODO: magic (to const)
                if (authorCount == 1)
                {
                    publicationInfo.Append(SwapAuthorFormat(_authors[0]));
                }
                //TODO: magic (to const)
                else if (authorCount <= 3)
                {
                    var formattedAuthors = _authors.Select(SwapAuthorFormat);
                    publicationInfo.Append(string.Join(", ", formattedAuthors));
                }
                else
                {
                    var firstThree = _authors.Take(3).Select(SwapAuthorFormat);
                    //TODO: RSDN
                    publicationInfo.Append($"{string.Join(", ", firstThree)} [и др.]");
                }
            }

            publicationInfo.Append($" – {Place} : {Publisher}, {Year}");

            publicationInfo.Append($" – {TotalPages} с.");

            return publicationInfo.ToString();
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
