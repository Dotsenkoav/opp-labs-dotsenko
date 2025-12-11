using System;

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
                _firstName = value;
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
                _lastName = value;
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
    }
}
