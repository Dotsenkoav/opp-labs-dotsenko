using System;

namespace LaboratoryFirst
{
    /// <summary>
    /// Класс, описывающий сущность человека 
    /// </summary>
    internal class Person
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
        public Person() : this( "Неизвестно", "Неизвестно", 0, Sex.Male ) { }

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
                    throw new ArgumentOutOfRangeException($"{nameof(Age)} " +
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
        /// Выводит информацию о человеке
        /// </summary>
        public void PrintPerson()
        {
            Console.WriteLine($"{FirstName} {LastName}," +
                $" возраст: {Age}, {GetSex()}");
        }

        /// <summary>
        /// Метод получения пола
        /// </summary>
        /// <returns></returns>
        private string GetSex()
        {
            return Sex == Sex.Male ? "Мужской" : "Женский";
        }

        /// <summary>
        /// Создает случайного человека
        /// </summary>
        /// <returns>Объект класса Person со случайными значениями полей</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = ReadFile("Data/male_names.txt");
            string[] femaleNames = ReadFile("Data/female_names.txt");
            string[] lastNames = ReadFile("Data/lastnames.txt");

            Sex sex = random.Next(2) == 0 ? Sex.Male : Sex.Female;
            string firstName = sex == Sex.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string lastName = lastNames[random.Next(lastNames.Length)];
            if(sex == Sex.Female) 
            {
                lastName += "а";
            }

            int age = random.Next(MinAge, MaxAge + 1);

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Метод считывания строк в файле
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Массив слов</returns>
        private static string[] ReadFile(string path)
        {
            if (!File.Exists(path))
                return Array.Empty<string>();

            return File.ReadAllLines(path)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();
        }
    }
}
