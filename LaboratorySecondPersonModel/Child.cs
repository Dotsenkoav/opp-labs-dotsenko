namespace LaboratorySecondPersonModel
{
    /// <summary>
    /// Класс описывающий сущность ребенка
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Мама
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Папа
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Место учебы
        /// </summary>
        private string _placeOfStudy;

        /// <summary>
        /// Максимальный возраст ребёнка
        /// </summary>
        public override int MaxAge { get; } = 17;

        /// <summary>
        /// Конструктор класса Child
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        /// <param name="mother">Мать (объект класса Adult)</param>
        /// <param name="father">Отец (объект класса Adult)</param>
        /// <param name="placeOfStudy">Место учёбы</param>
        public Child(string firstName, string lastName, int age, Sex sex,
            Adult mother, Adult father, string placeOfStudy)
            : base(firstName, lastName, age, sex)
        {
            Mother = mother;
            Father = father;
            PlaceOfStudy = placeOfStudy;
        }

        /// <summary>
        /// Конструктор класса Child по умолчанию
        /// </summary>
        public Child() : this("Иван", "Семёнов", 12, Sex.Male,
            null, null, "СО ЕЭС")
        { }

        /// <summary>
        /// Свойство, возвращает или задает мать
        /// </summary>
        public Adult Mother
        {
            get { return _mother; }
            set 
            { 
                if (value != null && value.Sex == Sex.Male)
                {
                    throw new ArgumentException
                        ("Мать должна быть женского пола");
                }
                _mother = value;
            }
        }

        /// <summary>
        /// Свойство, возвращает или задает отца
        /// </summary>
        public Adult Father
        {
            get { return _father; }
            set
            {
                if (value != null && value.Sex == Sex.Female)
                {
                    throw new ArgumentException
                        ("Отец должен быть мужского пола");
                }
                _father = value;
            }
        }

        /// <summary>
        /// Свойство, возвращает или задает место учебы
        /// </summary>
        public string PlaceOfStudy
        {
            get { return _placeOfStudy; }
            set
            {
                _placeOfStudy = string.IsNullOrWhiteSpace(value) ?
                    "не учится" : value;
            }
        }

        /// <summary>
        /// Метод получения информации о ребёнке
        /// </summary>
        /// <returns>Строку с информацией об объекте Child</returns>
        public override string GetInfo()
        {
            string motherInfo = Mother == null 
                ? "Мать отсутствует" 
                : $"{Mother.FirstName} {Mother.LastName}";
            string fatherInfo = Father == null ?
                "Отец отсутствует" : $"{Father.FirstName} {Father.LastName}";

            return $"Ребёнок: " + 
                base.GetInfo() + $", мать: {motherInfo}" +
                $", отец: {fatherInfo}" +
                $", место учёбы: {PlaceOfStudy}";
        }

        /// <summary>
        /// Метод для приветствия ребёнка
        /// </summary>
        /// <returns>Строка приветствия ребёнка</returns>
        public string DontWantSchool()
        {
            return "Не хочу идти в школу!";
        }
    }
}
