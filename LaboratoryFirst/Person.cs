using System.Text.RegularExpressions;

namespace LaboratoryFirst
{
    /// <summary>
    /// Класс, описывающий сущность человека 
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Пол человека
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// Женский пол
            /// </summary>
            Female,
            /// <summary>
            /// Мужской пол
            /// </summary>
            Male
        }

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
            PersonSex = sex;
        }

        /// <summary>
        /// Возвращает или задает имя человека
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Возвращает или задает фамилию человека
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Возвращает или задает возраст человека
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// Возвращает или задает пол человека
        /// </summary>
        public Sex PersonSex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// Выводит информацию о человеке
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"Имя: {FirstName}");
            Console.WriteLine($"Фамилия: {LastName}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine($"Пол: {PersonSex}");
        }

        /// <summary>
        /// Создает случайного человека
        /// </summary>
        /// <returns>Объект класса Person со случайными значениями полей</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = { "Иван", "Алексей", "Дмитрий", "Сергей", "Андрей" };
            string[] femaleNames = { "Анна", "Мария", "Елена", "Ольга", "Наталья" };
            string[] lastNames = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Васильев" };

            Sex sex = random.Next(2) == 0 ? Sex.Male : Sex.Female;
            string firstName = sex == Sex.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string lastName = lastNames[random.Next(lastNames.Length)];
            if(sex == Sex.Female) 
            {
                lastName += "а";
            }

            int age = random.Next(0, 123);

            return new Person(firstName, lastName, age, sex);
        }


        /// <summary>
        /// Метод считывания человека с клавиатуры
        /// </summary>
        /// <returns>Объект класса Person с введенными полями</returns>
        public static Person ReadFromConsole()
        {
            Console.Write("Введите имя: ");
            string firstName = ReadAndValidateName();

            Console.Write("Введите фамилию: ");
            string lastName = ReadAndValidateName();

            Console.Write("Введите возраст: ");
            int age = ReadAndValidateAge();

            Console.Write("Введите пол (M или F): ");
            Sex sex = ReadAndValidateSex();

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Метод считывания и проверки возраст
        /// </summary>
        /// <returns>Возраст, проверенный на правильность</returns>
        private static int ReadAndValidateAge()
        {
            while (true)
            {
                string inputAge = Console.ReadLine();

                if (int.TryParse(inputAge, out int age) && (age >= 0 && age < 123))
                {
                    return age;
                }

                Console.Write("Ошибка: возраст должен быть в диапазоне от 0 до 123. Повторите: ");
                continue;
            }
        }

        /// <summary>
        /// Метод преобразования в правильный регистр
        /// </summary>
        /// <param name="name">Имя/Фамилия человека</param>
        /// <returns>Строку имени с заглавной буквы</returns>
        private static string ToValidCase(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            System.Globalization.TextInfo textInfo =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(name.ToLower());
        }

        /// <summary>
        /// Метод проверки имени на содержание только английских и русских символов
        /// </summary>
        /// <param name="name">Имя/Фамилия человека</param>
        /// <returns>Булевое значение валидности имени</returns>
        private static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-zА-Яа-яЁё\s\-]+$");
        }

        /// <summary>
        /// Метод считывания и проверки имени/фамилии
        /// </summary>
        /// <returns>Отформатированный формат имени</returns>
        private static string ReadAndValidateName()
        {
            while (true)
            {
                string inputName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputName))
                {
                    Console.WriteLine($"Имя/Фамилия не могут быть пустым");
                    continue;
                }

                if (!IsValidName(inputName))
                {
                    Console.WriteLine("Имя/Фамилия должны содержать " +
                        "ТОЛЬКО русские и английские символы. Повторите: ");
                    continue;
                }

                return ToValidCase(inputName);
            }
        }

        /// <summary>
        /// Метод считывания и проверки пола человека
        /// </summary>
        /// <returns></returns>
        private static Sex ReadAndValidateSex()
        {
            while (true)
            {
                string inputSex = Console.ReadLine();
                if (char.TryParse(inputSex, out char sexChar))
                {
                    char sex = char.ToUpper(sexChar);

                    if (sex == 'M') return Sex.Male;
                    if (sex == 'F') return Sex.Female;
                }
                Console.Write("Ошибка: Неверно введен пол. Введите M или F: ");
                continue;
            }
        }
    }
}
