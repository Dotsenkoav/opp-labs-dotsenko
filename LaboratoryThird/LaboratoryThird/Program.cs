using LaboratoryThirdModel;

/// <summary>
/// Главный класс программы
/// </summary>
internal class Program
{
    /// <summary>
    /// Ширина линии разделителя
    /// </summary>
    private const int LineWidth = 60;

    /// <summary>
    /// Смещение для отображения номера
    /// </summary>
    private const int NumberOffset = 1;

    //TODO: RSDN +
    /// <summary>
    /// Список, для хранения всех изданий
    /// </summary>
    private static List<IPublication> _publications = new();

    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public static void Main()
    {
        MainMenu();
    }

    /// <summary>
    /// Метод описывающий главное меню программы
    /// </summary>
    private static void MainMenu()
    {
        Console.WriteLine("=== Библиотечная система ===");

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Добавить книгу");
            Console.WriteLine("2 - Добавить журнал");
            Console.WriteLine("3 - Добавить сборник");
            Console.WriteLine("4 - Добавить диссертацию");
            Console.WriteLine("5 - Показать все издания");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                {
                    _publications.Add(InputBook());
                    Console.WriteLine("Книга добавлена!\n");
                    break;
                }
                case "2":
                {
                    _publications.Add(InputJournal());
                    break;
                }
                case "3":
                {
                    _publications.Add(InputCollection());
                    Console.WriteLine("Сборник добавлен!\n");
                    break;
                }
                case "4":
                {
                    _publications.Add(InputDissertation());
                    Console.WriteLine("Диссертация добавлена!\n");
                    break;
                }
                case "5":
                {
                    ShowAllPublications();
                    break;
                }
                case "0":
                {
                    Console.WriteLine("До свидания!");
                    return;
                }
                default:
                {
                    Console.WriteLine("Неверный выбор. Повторите ввод.");
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Метод для получения действий для базового класса PublicationBase
    /// </summary>
    /// <typeparam name="T">Параметр типа (PublicationBase)</typeparam>
    /// <returns>Словарь действий</returns>
    private static Dictionary<string, Action<T>> GetBaseActions<T>()
        where T : PublicationBase
    {
        return new Dictionary<string, Action<T>>
        {
            //TODO: отступы +
            ["название"] = (publication) 
                => publication.Title = Console.ReadLine(),
            ["сведения о заглавии (enter, чтобы пропустить)"] = (publication)
                => publication.TitleInformation = Console.ReadLine(),
            ["место издания"] = (publication)
                => publication.Place = Console.ReadLine(),
            ["издательство/учредитель"] = (publication)
                => publication.Publisher = Console.ReadLine(),
            ["год издания"] = (publication)
                => publication.Year = ReadInteger("Год издания"),
            ["количество страниц"] = (publication)
                => publication.TotalPages = ReadInteger("Количество страниц")
        };
    }

    /// <summary>
    /// Метод дополнения списка действий для книги
    /// </summary>
    /// <returns>Дополненный словарь действий для книги</returns>
    private static Book InputBook()
    {
        var actions = GetBaseActions<Book>();

        actions["авторы (по одному, после каждого ввода нажимайте Enter," +
            " пустая строка - конец)"] = (book) =>
            {
                while (true)
                {
                    Console.Write($"Автор {book.Authors.Count
                        + NumberOffset}: ");
                    string author = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(author))
                        break;
                    book.AddAuthors(author.Trim());
                }
            };

        return CreatePublication(actions);
    }

    /// <summary>
    /// Метод дополнения списка действий для журнала
    /// </summary>
    /// <returns>Дополненный словарь действий для журнала</returns>
    private static Journal InputJournal()
    {
        var actions = GetBaseActions<Journal>();

        actions["частоту издания"] = (journal)
            => journal.Frequency = Console.ReadLine();

        return CreatePublication(actions);
    }

    /// <summary>
    /// Метод дополнения списка действий для сборника
    /// </summary>
    /// <returns>Дополненный словарь действий для сборника</returns>
    private static Collection InputCollection()
    {
        var actions = GetBaseActions<Collection>();

        actions["список редакционной коллегии"] = (collection)
            => collection.EditorialBoard = Console.ReadLine();
        actions["список ответственных редакторов"] = (collection)
            => collection.ResponsibleEditors = Console.ReadLine();

        return CreatePublication(actions);
    }

    /// <summary>
    /// Метод дополнения списка действий для диссертации
    /// </summary>
    /// <returns>Дополненный словарь действий для диссертации</returns>
    private static Dissertation InputDissertation()
    {
        var actions = GetBaseActions<Dissertation>();

        actions["полное имя автора, без сокращений"] = (dissertation)
            => dissertation.AuthorFull = Console.ReadLine();
        actions["специальность"] = (dissertation)
            => dissertation.Speciality = Console.ReadLine();
        actions["ученую степень диссертации"] = (dissertation)
            => dissertation.Degree = Console.ReadLine();

        return CreatePublication(actions);
    }

    /// <summary>
    /// Метод создания издания
    /// </summary>
    /// <typeparam name="T">Параметр типа (PublicationBase)</typeparam>
    /// <param name="actions">Действие</param>
    /// <returns>Экземпляр издания</returns>
    private static T CreatePublication<T>(Dictionary<string, Action<T>> actions)
    where T : PublicationBase, new()
    {
        T publication = new T();

        foreach (var item in actions)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {item.Key}: ");
                    item.Value(publication);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        return publication;
    }

    /// <summary>
    /// Метод для отображения списка всех изданий
    /// </summary>
    private static void ShowAllPublications()
    {
        if (_publications.Count == 0)
        {
            Console.WriteLine("\nСписок изданий пуст.");
            return;
        }

        Console.WriteLine("\n" + new string('=', LineWidth));
        Console.WriteLine("Список всех изданий");
        Console.WriteLine(new string('=', LineWidth));

        for (int i = 0; i < _publications.Count; i++)
        {
            Console.WriteLine($"\nИздание №{i + NumberOffset}");
            Console.WriteLine(new string('-', LineWidth));
            Console.WriteLine(_publications[i].GetGOSTInformation());
        }

        Console.WriteLine("\n" + new string('=', LineWidth));
        Console.WriteLine($"Всего изданий: {_publications.Count}");
        Console.WriteLine(new string('=', LineWidth));
    }

    /// <summary>
    /// Метод для проверки ввода на число
    /// </summary>
    /// <param name="fieldName">Поле</param>
    /// <returns>При успешном парсинге - число, иначе ошибку</returns>
    /// <exception cref="Exception">Ошибка, возникает,
    /// если ввели не число</exception>
    private static int ReadInteger(string fieldName)
    {
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;
        }
        else
        {
            throw new Exception($"{fieldName} должно быть числом");
        }
    }
}
