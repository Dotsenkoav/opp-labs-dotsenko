using LaboratorySecondPersonModel;

namespace LaboratorySecond
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу (Тестирование классов)
        /// </summary>
        /// <param name="args">Аргументы запуска программы</param>
        public static void Main(string[] args)
        {
            PersonList persons = new PersonList();

            var testDictionary = new Dictionary<string, Action>
            {
                ["Случайная генерация списка людей"] = () =>
                    TestFillList(persons),
                ["Вывод списка людей на экран"] = () =>
                    TestOutputPersons(persons),
                ["Определение типа четвертого человека в списке"] = () =>
                    TestTypePerson(persons),
            };

            StartTesting(testDictionary);
        }

        /// <summary>
        /// Метод для тестирования заполнения списка случайными людьми
        /// </summary>
        /// <param name="persons">Список для заполнения</param>
        public static void TestFillList(PersonList persons)
        {
            Random random = new Random();

            for (int i = 0; i < 7; i++)
            {
                if (random.Next(2) == 0)
                {
                    persons.Add(PersonGenerator.GetRandomAdult());
                }
                else
                {
                    persons.Add(PersonGenerator.GetRandomChild());
                }
            }
        }

        /// <summary>
        /// Метод тестирования вывода списка людей
        /// </summary>
        /// <param name="persons">Список для заполнения</param>
        public static void TestOutputPersons(PersonList persons)
        {
            persons.PrintAll();
        }

        public static void TestTypePerson(PersonList persons)
        {
            var fourthPerson = persons.FindByIndex(3);
            Console.WriteLine($"Тип четверого человека:" +
                $" {fourthPerson.GetType()}");

            if (fourthPerson is Adult adult)
            {
                Console.Write($"{adult.FirstName} {adult.LastName}: ");
                Console.WriteLine(adult.VacationRequest());
            }

            if (fourthPerson is Child child)
            {
                Console.Write($"{child.FirstName} {child.LastName}: ");
                Console.WriteLine(child.DontWantSchool());
            }
        }

        /// <summary>
        /// Метод, запускающий тест функционала
        /// </summary>
        /// <param name="testDictionary">Словарь, 
        /// хранящий лямбда-выражения</param>
        public static void StartTesting(Dictionary<string,
            Action> testDictionary)
        {
            foreach (var test in testDictionary)
            {
                Console.WriteLine($"==={test.Key}===");
                test.Value();
                WaitForKey();
            }
        }

        /// <summary>
        /// Метод для паузы между пунктами программы
        /// </summary>
        private static void WaitForKey()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
            Console.WriteLine();
        }

    }
}