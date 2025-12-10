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
                    throw new Exception($"{nameof(FirstName)} не может быть пустым!");
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
                    throw new Exception($"{nameof(LastName)} не может быть пустым!");
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
                const int minAge = 0;
                const int maxAge = 123;

                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"{nameof(Age)} не может быть меньше " +
                        $"{minAge} или больше {maxAge}!");
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
        public void PrintToConsole()
        {
            Console.WriteLine($"Имя: {FirstName}");
            Console.WriteLine($"Фамилия: {LastName}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine($"Пол: {Sex}");
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
    }
}
