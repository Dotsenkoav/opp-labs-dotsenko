using System.Text;


namespace LaboratoryThirdModel
{
    /// <summary>
    /// Базовый класс издания
    /// </summary>
    public abstract class PublicationBase : IPublication
    {
        /// <summary>
        /// Заглавие издания
        /// </summary>
        private string _title;

        /// <summary>
        /// Сведения о заглавии
        /// </summary>
        private string _titleInformation;

        /// <summary>
        /// Год издания
        /// </summary>
        private int _year;

        /// <summary>
        /// Место издания
        /// </summary>
        private string _place;

        /// <summary>
        /// Издательство, учредитель, организация
        /// </summary>
        private string _publisher;

        /// <summary>
        /// Количество страниц
        /// </summary>
        private int _totalPages;

        /// <summary>
        /// Минимальный год издания
        /// </summary>
        public const int MinYear = 868;

        /// <summary>
        /// Свойство заглавия
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                ValidateString(value, nameof(Title));
                _title = value;
            }
        }

        /// <summary>
        /// Свойство сведений о заглавии
        /// </summary>
        public string TitleInformation { get; set; }

        /// <summary>
        /// Свойство года издания
        /// </summary>
        public int Year
        {
            get => _year;
            set
            {
                ValidateYear(value);
                _year = value;
            }
        }

        /// <summary>
        /// Свойство места издания
        /// </summary>
        public string Place
        {
            get => _place;
            set
            {
                ValidateString(value, nameof(Place));
                _place = value;
            }
        }

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
        /// Свойство количества страниц
        /// </summary>
        public int TotalPages
        {
            get => _totalPages;
            set
            {
                ValidateTotalPages(value);
                _totalPages = value;
            }
        }

        /// <summary>
        /// Абстрактный метод описывающий издание по ГОСТ
        /// </summary>
        /// <returns>Строку с описанием издания по ГОСТ</returns>
        public abstract string GetGOSTInformation();

        /// <summary>
        /// Метод валидации строки
        /// </summary>
        /// <param name="value">Строка для валидации</param>
        /// <param name="propertyName">nameof для строки</param>
        /// <exception cref="ArgumentException">
        /// Ошибка при пустой строке</exception>
        protected void ValidateString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{propertyName} " +
                    $"не может быть пустым");
            }
        }

        /// <summary>
        /// Метод валидации года издания
        /// </summary>
        /// <param name="year">Год издания</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Ошибка при выходе даты издания за диапазон</exception>
        protected void ValidateYear(int year)
        {
            if (year < MinYear || year > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException($"{nameof(Year)}" +
                    $" должен быть в диапазоне от {MinYear}" +
                    $" до {DateTime.Now.Year}");
            }
        }

        /// <summary>
        /// Метод валидации количества страниц
        /// </summary>
        /// <param name="totalPages">Кол-во страниц</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Ошибка при отрицательном кол-ве страниц</exception>
        protected void ValidateTotalPages(int totalPages)
        {
            if (totalPages <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(TotalPages)} должно быть больше нуля");
            }
        }

        /// <summary>
        /// Метод проверки на наличие заполненного атрибута
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="prefix"></param>
        /// <param name="value"></param>
        /// <param name="suffix"></param>
        protected static void AppendIfNotEmpty(StringBuilder stringBuilder,
            string prefix, string value, string suffix = "")
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                stringBuilder.Append($"{prefix}{value}{suffix}");
            }
        }
    }
}
