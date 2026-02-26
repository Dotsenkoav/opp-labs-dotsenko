using LaboratoryThirdModel;

/// <summary>
/// Главный класс программы
/// </summary>
internal class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public static void Main()
    {
        TestSingeAuthorBook();
        TestFiveAuthorBook();
    }

    public static void TestSingeAuthorBook()
    {
        var book = new Book
        {
            Title = "Программирование на C#",
            TitleInfo = "учебное пособие для вузов",
            Place = "Томск",
            Publisher = "ТПУ",
            Year = 2026,
            TotalPages = 500
        };

        book.AddAuthors("Иванов, И.И.");

        Console.WriteLine(book.GetGOSTInfo());
    }

    public static void TestFiveAuthorBook()
    {
        var book = new Book
        {
            Title = "Программирование на python",
            TitleInfo = "учебное пособие для бакалавров",
            Place = "Новосибирск",
            Publisher = "СО РАН",
            Year = 2026,
            TotalPages = 700
        };

        book.AddAuthors("Иванов, И.И.", "Петров, П.П.", "Сидоров, С.С.", "Кузнецов, И.И.", "Соловьев, С.С.");

        Console.WriteLine(book.GetGOSTInfo());
    }
}