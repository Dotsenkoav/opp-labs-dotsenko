using LaboratoryThirdModel;
using NUnit.Framework.Legacy;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса Book
    /// </summary>
    [TestFixture]
    public class BookTests
    {
        /// <summary>
        /// Проверка метода AddAuthors() с корректными данными
        /// </summary>
        [Test]
        public void AddAuthorsSingleAuthorAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.");

            ClassicAssert.AreEqual(1, book.Authors.Count);
            ClassicAssert.AreEqual("Иванов И.И.", book.Authors[0]);
        }

        [Test]
        public void AddAuthorsTwoAuthorsAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.", "Петров П.П.");

            ClassicAssert.AreEqual(2, book.Authors.Count);
            ClassicAssert.AreEqual("Иванов И.И.", book.Authors[0]);
            ClassicAssert.AreEqual("Петров П.П.", book.Authors[1]);
        }

        [Test]
        public void AddAuthorsThreeAuthorsAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.", "Петров П.П.", "Сидоров С.С.");

            ClassicAssert.AreEqual(3, book.Authors.Count);
            ClassicAssert.AreEqual("Иванов И.И.", book.Authors[0]);
            ClassicAssert.AreEqual("Петров П.П.", book.Authors[1]);
            ClassicAssert.AreEqual("Сидоров С.С.", book.Authors[2]);
        }

        /// <summary>
        /// Проверка метода AddAuthors() с некорректными данными
        /// </summary>
        [Test]
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
        [Test]
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

            ClassicAssert.IsTrue(result.Contains("Программирование на C#"),
                "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains("учебное пособие"),
                "Подзаголовок не найден");
            ClassicAssert.IsTrue(result.Contains("Москва"),
                "Место не найдено");
            ClassicAssert.IsTrue(result.Contains("Питер"),
                "Издательство не найдено");
            ClassicAssert.IsTrue(result.Contains("2023"),
                "Год не найден");
            ClassicAssert.IsTrue(result.Contains("500 с."),
                "Страницы не найдены");
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с двумя авторами
        /// </summary>
        [Test]
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

            ClassicAssert.IsTrue(result.Contains("Программирование"),
                "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains("Санкт-Петербург"),
                "Место не найдено");
            ClassicAssert.IsTrue(result.Contains("БХВ"),
                "Издательство не найдено");
            ClassicAssert.IsTrue(result.Contains("2022"),
                "Год не найден");
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с тремя авторами
        /// </summary>
        [Test]
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

            ClassicAssert.IsTrue(result.Contains(
                "Алгоритмы и структуры данных"), "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains(
                "Москва"), "Место не найдено");
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с четырьмя и более авторами
        /// </summary>
        [Test]
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

            ClassicAssert.IsTrue(result.Contains("[и др.]"));
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() без авторов
        /// </summary>
        [Test]
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

            ClassicAssert.IsTrue(result.StartsWith("Тестовая книга"));
            ClassicAssert.IsFalse(result.Contains(" / "));
        }

        /// <summary>
        /// Проверка свойства Authors (только для чтения)
        /// </summary>
        [Test]
        public void AuthorsReadOnlyAssertionTest()
        {
            var book = new Book();
            book.AddAuthors("Иванов И.И.");

            ClassicAssert.IsNotNull(book.Authors);
            ClassicAssert.AreEqual(1, book.Authors.Count);
        }
    }
}
