using System.Globalization;
using System.Text.RegularExpressions;

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
            var (firstPersonList, secondPersonList) = InitializeObjects();

            var testDictionary = new Dictionary<string, Action>
            {
                ["Вывод содержимого каждого списка"] = () => 
                    TestPrintList(firstPersonList, secondPersonList),
                ["Добавление нового человека"] = () => 
                    TestAddPerson(firstPersonList),
                ["Копирование человека"] = () => 
                    TestCopyPerson(firstPersonList, secondPersonList),
                ["Удаление человека"] = () => 
                    TestRemovePerson(firstPersonList, secondPersonList),
                ["Очиска списка"] = () => 
                    TestClearList(secondPersonList),
                ["Генерация случайного человека"] = () =>
                    TestGeneratePerson(),
                ["Ввод нового пользователя"] = () =>
                    TestInputPerson()
            };

            StartTesting(testDictionary);
        }

        /// <summary>
        /// Метод для инициализации экземпляров PersonList
        /// </summary>
        /// <returns>Два объекта класса PersonList</returns>
        public static (PersonList firstList, PersonList secondList)
            InitializeObjects()
        {
            Console.WriteLine("Создание списков...");

            Person person1 = new Person("Андрей", "Доценко", 23, Sex.Male);
            Person person2 = new Person("Иван", "Иванов", 30, Sex.Male);
            Person person3 = new Person("Анна", "Петрова", 24, Sex.Female);
            Person person4 = new Person("Дмитрий", "Кузнецов", 45, Sex.Male);
            Person person5 = new Person("Мария", "Васильева", 18, Sex.Female);
            Person person6 = new Person("Сергей", "Иванов", 34, Sex.Male);

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

            return (firstPersonList, secondPersonList);
        }

        /// <summary>
        /// Метод, запускающий тест функционала
        /// </summary>
        /// <param name="testDictionary">Словарь, хранящий лямбда-выражения</param>
        public static void StartTesting(Dictionary<string, Action> testDictionary)
        {
            foreach (var test in testDictionary)
            {
                Console.WriteLine($"==={test.Key}===");
                test.Value();
                WaitForKey();
            }
        }

        /// <summary>
        /// Метод теста вывода списков
        /// </summary>
        /// <param name="firstPersonList">Первый список</param>
        /// <param name="secondPersonList">Второй список</param>
        public static void TestPrintList(PersonList firstPersonList, 
            PersonList secondPersonList)
        {
            PrintList(firstPersonList, "Первый список");
            PrintList(secondPersonList, "Второй список");
        }

        /// <summary>
        /// Метод теста добавления человека в первый список
        /// </summary>
        /// <param name="firstPersonList">Первый список</param>
        public static void TestAddPerson(PersonList firstPersonList)
        {
            Person person7 = new Person("Аркадий", "Сидоров", 40, Sex.Male);
            firstPersonList.Add(person7);
            Console.WriteLine($"В первый список добавлен {person7.FirstName}");
            PrintList(firstPersonList, "Первый список");
        }

        /// <summary>
        /// Метод теста копирования человека из первого списка во второй
        /// </summary>
        /// <param name="firstPersonList">Первый список</param>
        /// <param name="secondPersonList">Второй список</param>
        public static void TestCopyPerson(PersonList firstPersonList, 
            PersonList secondPersonList)
        {
            Person copiedPerson = firstPersonList.FindByIndex(1);
            secondPersonList.Add(copiedPerson);
            Console.WriteLine($"Во второй список скопирован" +
                $" {copiedPerson.FirstName}");
            PrintList(firstPersonList, "Первый список");
            PrintList(secondPersonList, "Обновленный второй список");
        }

        /// <summary>
        /// Метод теста удаления человека из первого списка
        /// </summary>
        /// <param name="firstPersonList">Первый список</param>
        /// <param name="secondPersonList">Второй список</param>
        public static void TestRemovePerson(PersonList firstPersonList, 
            PersonList secondPersonList)
        {
            firstPersonList.RemoveAt(1);
            Console.WriteLine("В первом списке удален второй человек");
            PrintList(firstPersonList, "Первый список после удаления");
            PrintList(secondPersonList, "Второй список");
        }

        /// <summary>
        /// Тест очистки списка
        /// </summary>
        /// <param name="secondPersonList">Первый список</param>
        public static void TestClearList(PersonList secondPersonList)
        {
            secondPersonList.Clear();
            PrintList(secondPersonList, "Очищенный список");
        }

        /// <summary>
        /// Тестирование генерации человека
        /// </summary>
        public static void TestGeneratePerson()
        {
            Person person = Person.GetRandomPerson();
            person.PrintPerson();
        }

        /// <summary>
        /// Тестирование ввода человека с клавиатуры
        /// </summary>
        public static void TestInputPerson()
        {
            Person person = InputFromConsole();
            person.PrintPerson();
        }

        /// <summary>
        /// Метод ввода пользователя с клавиатуры
        /// </summary>
        /// <returns>Объект класса Person</returns>
        /// <exception cref="Exception">Возникает, если пол введен
        /// в некорректном формате </exception>
        public static Person InputFromConsole()
        {
            Person person = new Person();

            var inputDictionary = new Dictionary<string, Action>()
            {
                {
                    "имя",
                    new Action(() =>
                        {
                            string input = Console.ReadLine();
                            ValidateName(input);
                            person.FirstName = CheckRegister(input);
                        })
                },
                {
                    "фамилию",
                    new Action(() =>
                        {
                            string input = Console.ReadLine();
                            ValidateName(input);
                            person.LastName = CheckRegister(input);
                        })
                },
                {
                    "возраст",
                    new Action(() =>
                        {
                            if (int.TryParse(Console.ReadLine(), out int age))
                            {
                                person.Age = age;
                            }
                            else
                            {
                                throw new Exception(
                                    "Введенная строка не может быть " +
                                    "конвертирована в число!");
                            }
                        })
                },
                {
                    "пол",
                    new Action(() =>
                        {
                            Console.Write("(1 - мужской, 2 - женский): ");

                            string inputNumber = Console.ReadLine();

                            switch (inputNumber) 
                            {
                                case "1":
                                {
                                    person.Sex = Sex.Male;
                                    break;
                                }
                                case "2":
                                {
                                    person.Sex = Sex.Female;
                                    break;
                                }
                                default:
                                {
                                    throw new Exception("Неккоретный ввод." +
                                        " Введите цифру 1(М) или 2(Ж)");
                                }
                            }
                        })
                }
            };

            foreach (var actionHandler in inputDictionary)
            {
                ActionHandler(actionHandler.Value, actionHandler.Key);
            }

            return person;
        }

        /// <summary>
        /// Метод, проверящий символы имени/фамилии
        /// </summary>
        /// <param name="name">Имя/Фамилия</param>
        /// <exception cref="Exception">
        /// Возникает, если имя/фамилия не содержит нужные символы</exception>
        public static void ValidateName(string name)
        {
            const string russianCheck = @"^[а-яА-ЯёЁ\s\-]+$";
            const string englishCheck = @"^[a-zA-Z\s\-]+$";

            bool isValid = Regex.IsMatch(name, russianCheck) ||
                Regex.IsMatch(name, englishCheck);

            if (!isValid)
                throw new Exception($"Имя/Фамилия могут содержать только" +
                    $" русские/английские буквы, пробелы и дефисы!");
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
        /// Метод, выполняющий действия в оболочке try и while
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="enteredValue">Введенная строка</param>
        public static void ActionHandler(Action action, string enteredValue)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Пожалуйста, " +
                        $"введите {enteredValue} человека: ");
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
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
                Console.Write($"     {i + 1}. ");
                person.PrintPerson();
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