using LaboratoryThirdModel;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса Book
    /// </summary>
    [TestFixture]
    public class BookTests : PublicationBaseChildTests<Book>
    {
        /// <summary>
        /// Проверка метода AddAuthors() с одним автором
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation" +
            " с одним автором")]
        public void AddAuthorsSingleAuthorAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.");

            Assert.That(book.Authors.Count, Is.EqualTo(1));
            Assert.That(book.Authors[0], Is.EqualTo("Иванов И.И."));
        }

        /// <summary>
        /// Проверка метода AddAuthors() с двумя авторами
        /// </summary>
        [TestCase(TestName = "Проверка метода AddAuthors()" +
            " с двумя авторами")]
        public void AddAuthorsTwoAuthorsAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.", "Петров П.П.");

            Assert.That(book.Authors.Count, Is.EqualTo(2));
            Assert.That(book.Authors[0], Is.EqualTo("Иванов И.И."));
            Assert.That(book.Authors[1], Is.EqualTo("Петров П.П."));
        }

        /// <summary>
        /// Проверка метода AddAuthors() с тремя авторами
        /// </summary>
        [TestCase(TestName = "Проверка метода AddAuthors()" +
            " с тремя авторами")]
        public void AddAuthorsThreeAuthorsAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.", "Петров П.П.", "Сидоров С.С.");

            Assert.That(book.Authors.Count, Is.EqualTo(3));
            Assert.That(book.Authors[0], Is.EqualTo("Иванов И.И."));
            Assert.That(book.Authors[1], Is.EqualTo("Петров П.П."));
            Assert.That(book.Authors[2], Is.EqualTo("Сидоров С.С."));
        }

        /// <summary>
        /// Проверка метода AddAuthors() с некорректными данными
        /// </summary>
        [TestCase(TestName = "Проверка метода AddAuthors()" +
            " с некорректными данными")]
        public void AddAuthorsAssertionNegativeTest()
        {
            var book = new Book();

            Assert.Throws<ArgumentException>(() => book.AddAuthors(null));
            Assert.Throws<ArgumentException>(() 
                => book.AddAuthors(new string[0]));
        }

        /// <summary>
        /// Проверка метода AddAuthors() с некорректным автором
        /// </summary>
        [TestCase("", TestName = "Добавление пустого автора")]
        [TestCase("   ", TestName = "Добавление автора из пробелов")]
        [TestCase(null, TestName = "Добавление null автора")]
        public void AddAuthorsInvalidAuthorNegativeTest(
            string? invalidAuthor)
        {
            var book = new Book();
            Assert.Throws<ArgumentException>(() 
                => book.AddAuthors(invalidAuthor));
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с одним автором
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " с одним автором")]
        public void GetGOSTInformationOneAuthorAssertionTest()
        {
            var book = new Book
            {
                Title = "Программирование на C#",
                TitleInformation = "учебное пособие",
                Place = "Москва",
                Publisher = "Питер",
                Year = 2023,
                TotalPages = 500
            };
            book.AddAuthors("Иванов Иван Иванович");

            string result = book.GetGOSTInformation();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain("Программирование на C#"),
                    "Заголовок не найден");
                Assert.That(result, Does.Contain("учебное пособие"),
                    "Подзаголовок не найден");
                Assert.That(result, Does.Contain("Москва"),
                    "Место не найдено");
                Assert.That(result, Does.Contain("Питер"),
                    "Издательство не найдено");
                Assert.That(result, Does.Contain("2023"),
                    "Год не найден");
                Assert.That(result, Does.Contain("500 с."),
                    "Страницы не найдены");
            });
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с двумя авторами
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " с двумя авторами")]
        public void GetGOSTInformationTwoAuthorsAssertionTest()
        {
            var book = new Book
            {
                Title = "Программирование",
                Place = "Санкт-Петербург",
                Publisher = "БХВ",
                Year = 2022,
                TotalPages = 300
            };
            book.AddAuthors("Иванов Иван Иванович", "Петров Петр Петрович");

            string result = book.GetGOSTInformation();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain("Программирование"),
                    "Заголовок не найден");
                Assert.That(result, Does.Contain("Санкт-Петербург"),
                    "Место не найдено");
                Assert.That(result, Does.Contain("БХВ"),
                    "Издательство не найдено");
                Assert.That(result, Does.Contain("2022"),
                    "Год не найден");
            });
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с тремя авторами
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " с тремя авторами")]
        public void GetGOSTInformationThreeAuthorsAssertionTest()
        {
            var book = new Book
            {
                Title = "Алгоритмы и структуры данных",
                Place = "Москва",
                Publisher = "Вильямс",
                Year = 2023,
                TotalPages = 400
            };
            book.AddAuthors("Иванов Иван Иванович",
                "Петров Петр Петрович", "Сидоров Сидор Сидорович");

            string result = book.GetGOSTInformation();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain
                    ("Алгоритмы и структуры данных"), "Заголовок не найден");
                Assert.That(result, Does.Contain
                    ("Москва"), "Место не найдено");
            });
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с четырьмя и более авторами
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " с четырьмя и более авторами")]
        public void GetGOSTInformationFourAuthorsAssertionTest()
        {
            var book = new Book
            {
                Title = "Современное программирование",
                Place = "Москва",
                Publisher = "Наука",
                Year = 2024,
                TotalPages = 400
            };
            book.AddAuthors("Иванов И.И.", "Петров П.П.",
                "Сидоров С.С.", "Козлов К.К.");

            string result = book.GetGOSTInformation();

            Assert.That(result, Does.Contain("[и др.]"));
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() без авторов
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " без авторов")]
        public void GetGOSTInformationNoAuthorsAssertionTest()
        {
            var book = new Book
            {
                Title = "Тестовая книга",
                Place = "Москва",
                Publisher = "Тест",
                Year = 2024,
                TotalPages = 100
            };

            string result = book.GetGOSTInformation();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.StartWith("Тестовая книга"));
                Assert.That(result, Does.Not.Contain(" / "));
            });
        }

        /// <summary>
        /// Проверка свойства Authors (только для чтения)
        /// </summary>
        [TestCase(TestName = "Проверка свойства Authors" +
            " (только для чтения)")]
        public void AuthorsReadOnlyAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.");

            Assert.Multiple(() =>
            {
                Assert.That(book.Authors, Is.Not.Null);
                Assert.That(book.Authors.Count, Is.EqualTo(1));
            });
        }
    }
}
