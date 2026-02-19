using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LaboratoryFirst
{
    /// <summary>
    /// Класс, описывающий сущность человека 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Фамилия человека
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол человека
        /// </summary>
        private Sex _sex;

        /// <summary>
        /// Паттерн регулярки ru
        /// </summary>
        private const string _russianCheck = @"^[а-яА-ЯёЁ\s\-]+$";

        /// <summary>
        /// Паттерн регулярки en
        /// </summary>
        private const string _englishCheck = @"^[a-zA-Z\s\-]+$";

        /// <summary>
        /// Минимальный возраст человека
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        public const int MaxAge = 123;


        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="firstName">Имя человека</param>
        /// <param name="lastName">Фамилия человека</param>
        /// <param name="age">Возраст человека</param>
        /// <param name="sex">Пол человека</param>
        public Person(string firstName, string lastName, int age, Sex sex)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public Person() : this("Андрей", "Иванов", 18, Sex.Male) { }

        /// <summary>
        /// Возвращает или задает имя человека
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(FirstName)}" +
                        $" не может быть пустым!");
                }

                if (!IsValidName(value))
                {
                    throw new Exception($"{nameof(value)} может содержать" +
                        $" только русские/английские символы, пробел и -");
                }
                _firstName = CheckRegister(value);
            }
        }

        /// <summary>
        /// Возвращает или задает фамилию человека
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(LastName)}" +
                        $" не может быть пустым!");
                }

                if (!IsValidFullname(_firstName, value))
                {
                    throw new Exception($"{nameof(LastName)} " +
                        $"и {nameof(FirstName)} должны быть на " +
                        $"одном языке и могут содержать только пробелы и -");
                }
                _lastName = CheckRegister(value);
            }
        }

        /// <summary>
        /// Возвращает или задает возраст человека
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception($"{nameof(Age)} " +
                        $" не может быть меньше {MinAge} или больше {MaxAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Возвращает или задает пол человека
        /// </summary>
        public Sex Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// Метод, преобразования регистра в правильный формат
        /// </summary>
        /// <param name="name">Имя/Фамилия для проверки</param>
        /// <returns>Строка в правильном регистре</returns>
        public static string CheckRegister(string name)
        {
            TextInfo txt = CultureInfo.CurrentCulture.TextInfo;
            return txt.ToTitleCase(name.ToLower());
        }

        /// <summary>
        /// Метод проверки имени или фамилии
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>true - если подходит, иначе false</returns>
        private bool IsValidName(string name)
        {
            return (Regex.IsMatch(name, _russianCheck)
                || Regex.IsMatch(name, _englishCheck));
        }

        /// <summary>
        /// Метод проверки имени и фамилии
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="lastname">Фамилия</param>
        /// <returns>true - если на одном языке, иначе false </returns>
        private bool IsValidFullname(string name, string lastname)
        {
            return (Regex.IsMatch(name, _russianCheck) &&
                Regex.IsMatch(lastname, _russianCheck))
                || (Regex.IsMatch(name, _englishCheck) &&
                Regex.IsMatch(lastname, _englishCheck));
        }
    }
}
