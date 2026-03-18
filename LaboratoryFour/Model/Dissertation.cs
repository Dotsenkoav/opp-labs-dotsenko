using System.Text;

namespace LaboratoryThirdModel
{
    /// <summary>
    /// Класс издания диссертации
    /// </summary>
    public class Dissertation : PublicationBase
    {
        /// <summary>
        /// Минимальное количество частей имени
        /// </summary>
        private const int MinNameParts = 2;

        /// <summary>
        /// Индекс фамилии в массиве частей имени
        /// </summary>
        private const int LastNameIndex = 0;

        /// <summary>
        /// Индекс первого инициала
        /// </summary>
        private const int FirstInitialIndex = 1;

        /// <summary>
        /// Полное имя автора
        /// </summary>
        private string _authorFull;

        /// <summary>
        /// Специальность
        /// </summary>
        private string _speciality;

        /// <summary>
        /// Ученая степень
        /// </summary>
        private string _degree;

        /// <summary>
        /// Свойство автора
        /// </summary>
        public string AuthorFull
        {
            get => _authorFull;
            set
            {
                ValidateString(value, nameof(AuthorFull));
                _authorFull = value;
            }
        }

        /// <summary>
        /// Свойство специальности
        /// </summary>
        public string Speciality
        {
            get => _speciality;
            set
            {
                ValidateString(value, nameof(Speciality));
                _speciality = value;
            }
        }

        /// <summary>
        /// Свойство ученой степени
        /// </summary>
        public string Degree
        {
            get => _degree;
            set
            {
                ValidateString(value, nameof(Degree));
                _degree = value;
            }
        }

        /// <summary>
        /// Получение информации о диссертации по ГОСТ
        /// </summary>
        /// <returns>Строку с информацией о диссертации по ГОСТ</returns>
        public override string GetGOSTInformation()
        {
            var dissertationInformation = new StringBuilder();

            dissertationInformation.Append($"{GetAuthorForHeader()}" +
                $" {Title} : специальность {Speciality} : {Degree}" +
                $" / {AuthorFull}  ; {Publisher}  – {Place}, {Year}" +
                $" – {TotalPages} с.");

            return dissertationInformation.ToString();
        }

        /// <summary>
        /// Метод форматирования автора для заголовка
        /// </summary>
        /// <returns>Строку с форматированным автором</returns>
        private string GetAuthorForHeader()
        {
            string[] parts = AuthorFull.Split(' ');

            if (parts.Length < MinNameParts)
                return AuthorFull;

            string lastName = parts[LastNameIndex];
            string initials = "";

            for (int i = FirstInitialIndex; i < parts.Length; i++)
            {
                if (i > FirstInitialIndex)
                    initials += " ";
                initials += parts[i][0] + ".";
            }

            return $"{lastName}, {initials}";
        }
    }
}
