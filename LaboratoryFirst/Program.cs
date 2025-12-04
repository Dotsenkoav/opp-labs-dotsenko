namespace LaboratoryFirst
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
            Console.WriteLine("Создание списков...");

            Person person1 = new Person("Андрей", "Доценко", 23, Person.Sex.Male);
            Person person2 = new Person("Иван", "Иванов", 30, Person.Sex.Male);
            Person person3 = new Person("Анна", "Петрова", 24, Person.Sex.Female);
            Person person4 = new Person("Дмитрий", "Кузнецов", 45, Person.Sex.Male);
            Person person5 = new Person("Мария", "Васильева", 18, Person.Sex.Female);
            Person person6 = new Person("Сергей", "Иванов", 34, Person.Sex.Male);

            PersonList firstPersonList = new PersonList(new Person[]
            {
                person1,
                person2,
                person3
            });

            PersonList secondPersonList = new PersonList(new Person[]
            {
                person4,
                person5,
                person6
            });

            Console.WriteLine("Списки созданы");
            WaitForKey();

            PrintList(firstPersonList, "Первый список");
            PrintList(secondPersonList, "Второй список");
            WaitForKey();

            Person person7 = new Person("Аркадий", "Сидоров", 40, Person.Sex.Male);
            firstPersonList.Add(person7);
            Console.WriteLine($"В первый список добавлен {person7.FirstName}");
            PrintList(firstPersonList, "Первый список");
            WaitForKey();

            Person copiedPerson = firstPersonList.FindByIndex(1);
            secondPersonList.Add(copiedPerson);
            Console.WriteLine($"Во второй список скопирован {copiedPerson.FirstName}");
            PrintList(firstPersonList, "Обновленный первый список");
            PrintList(secondPersonList, "Обновленный второй список");
            WaitForKey();

            firstPersonList.RemoveAt(1);
            Console.WriteLine("В первом списке удален второй человек");
            PrintList(firstPersonList, "Первый список после удаления");
            PrintList(secondPersonList, "Второй список");
            WaitForKey();

            secondPersonList.Clear();
            Console.WriteLine("Второй список очищен");
            PrintList(secondPersonList, "Очищенный список");
            WaitForKey();

            Console.WriteLine("Тестируем вывод описания человека");
            person1.PrintToConsole();
            WaitForKey();

            Console.WriteLine("Тестируем создание случайного пользователя");
            Person person8 = Person.GetRandomPerson();
            person8.PrintToConsole();
            WaitForKey();

            Console.WriteLine("Тестируем ввод пользователя");
            Person person9 = Person.ReadFromConsole();
            person9.PrintToConsole();
            WaitForKey();
        }

        /// <summary>
        /// Выводит список людей на экран
        /// </summary>
        /// <param name="list">Список для вывода</param>
        /// <param name="listName">Название списка</param>
        private static void PrintList(PersonList list, string listName)
        {
            Console.WriteLine(listName);

            for (int i = 0; i < list.Count; i++) 
            {
                Person person = list.FindByIndex(i);
                Console.WriteLine($"    {i + 1}. {person.FirstName}" +
                    $" {person.LastName}, {person.Age} лет, {person.PersonSex}");
            }
        }

        /// <summary>
        /// Метод для пауз между пунктами программы
        /// </summary>
        private static void WaitForKey()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}