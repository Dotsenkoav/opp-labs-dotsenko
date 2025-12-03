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
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _sex = sex;
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
    }
}
