using System.Text.RegularExpressions;

namespace LaboratorySecondPersonModel
{
    /// <summary>
    /// Класс описывающий сущность родителя
    /// </summary>
    internal class Adult : PersonBase
    {
        /// <summary>
        /// Номер паспорта
        /// </summary>
        private string _passportNumber;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        private string _passportSeries;

        /// <summary>
        /// Партнер родителя
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _placeOfJob;

        /// <summary>
        /// Паттерн на цифры в паспорте
        /// </summary>
        private const string _passportCheck = @"^\d+$";

        /// <summary>
        /// Количество цифр в номере паспорта
        /// </summary>
        public const int QuantitySeriesDigits = 4;

        /// <summary>
        /// Количество цифр в серии паспорта
        /// </summary>
        public const int QuantityPassportDigits = 6;

        /// <summary>
        /// Конструктор класса Adult
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        /// <param name="passportNum">Номер паспорта</param>
        /// <param name="passportSeries">Серия паспорта</param>
        /// <param name="partner">Партнер класса Adult</param>
        /// <param name="placeOfJob">Место работы</param>
        public Adult(string firstName, string lastName, int age, Sex sex,
            string passportNum, string passportSeries, Adult partner,
            string placeOfJob)
            : base(firstName, lastName, age, sex)
        {
            PassportNumber = passportNum;
            PassportSeries = passportSeries;
            Partner = partner;
            PlaceOfJob = placeOfJob;
        }

        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public Adult() : this("Андрей", "Михайлов", 18, Sex.Male,
            "", "", null, null)
        { }

        /// <summary>
        /// Свойство, возвращает или задает номер паспорта
        /// </summary>
        public string PassportNumber
        {
            get { return _passportNumber; }
            set
            { 
                if (string.IsNullOrEmpty(value))
                {
                    _passportNumber = value;
                    return;
                }

                if (value.Length == QuantityPassportDigits
                    && IsPassportValid(value))
                {
                    _passportNumber = value;
                }
                else
                {
                    throw new ArgumentException
                        ($"Номер паспорт должен состоять из " +
                        $"{QuantityPassportDigits} цифр");
                }
            }
        }

        /// <summary>
        /// Свойство, возвращает или задает серию паспорта
        /// </summary>
        public string PassportSeries
        {
            get { return _passportSeries; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _passportSeries = value;
                    return;
                }

                if (value.Length == QuantitySeriesDigits
                    && IsPassportValid(value))
                {
                    _passportSeries = value;
                }
                else
                {
                    throw new ArgumentException
                        ($"Серия паспорта должна состоять из " +
                        $"{QuantitySeriesDigits} цифр");
                }
            }
        }

        /// <summary>
        /// Свойство, возвращает или задает партнера
        /// </summary>
        public Adult Partner
        {
            get { return _partner; }
            set
            {
                if (_partner == value) return;

                if (_partner != null)
                {
                    Adult oldPartner = _partner;
                    _partner = null;
                    oldPartner._partner = null;
                }

                if (value != null && value.Sex == Sex)
                {
                    throw new ArgumentException("Партнер должен " +
                        "быть противоположного пола.");
                }

                if (value != null && value._partner != null && value._partner != this)
                {
                    Adult oldPartner = value._partner;
                    value._partner = null;
                    oldPartner._partner = null;
                }

                if (value != null)
                {
                    value._partner = this;
                }

                _partner = value;
            }
        }

        /// <summary>
        /// Свойство, возвращает или задает место работы
        /// </summary>
        public string PlaceOfJob
        {
            get { return _placeOfJob; }
            set
            {
                _placeOfJob = string.IsNullOrWhiteSpace(value) ? 
                    "безработный" : value;
            }
        }

        /// <summary>
        /// Метод получения информации о Adult
        /// </summary>
        /// <returns>Строку с информацией о взрослом</returns>
        public override string GetInfo()
        {
            string partnerInfo;

            if (Partner == null)
            {
                partnerInfo = "Не состоит в браке";
            }
            else
            {
                partnerInfo = $"{Partner.FirstName} {Partner.LastName}";
            }

            return base.GetInfo() +
                $", серия паспорта: {PassportSeries}," +
                $" номер паспорта: {PassportNumber}," +
                $" партнёр: {partnerInfo}," +
                $" место работы: {PlaceOfJob}";
        }

        /// <summary>
        /// Метод проверки номера и серии паспорта на цифры
        /// </summary>
        /// <param name="passport">номер или серия паспорта</param>
        /// <returns>Булевое значение соответствие номера или серии</returns>
        public bool IsPassportValid(string passport)
        {
            if (string.IsNullOrEmpty(passport)) return false;

            return Regex.IsMatch(passport, _passportCheck);
        }
    }
}
