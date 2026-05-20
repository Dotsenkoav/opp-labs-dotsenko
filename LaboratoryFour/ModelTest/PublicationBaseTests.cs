using LaboratoryThirdModel;
using NUnit.Framework.Legacy;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса PublicationBase
    /// </summary>
    [TestFixture]
    public class PublicationBaseTests
    {
        /// <summary>
        /// Проверка корректных данных для свойства Title
        /// </summary>
        /// <param name="title">Заголовок</param>
        [TestCase("Программирование", 
            TestName = "Тест установки корректного заглавия")]
        [TestCase("C# Advanced", 
            TestName = "Тест установки заглавия на латинице")]
        [TestCase("Программирование на C#", 
            TestName = "Тест установки заглавия с пробелами")]
        public void TitleAssertionTest(string title)
        {
            var publication = new Book();
            publication.Title = title;
            ClassicAssert.AreEqual(title, publication.Title);
        }

        /// <summary>
        /// Проверка некорректных данных для свойства Title
        /// </summary>
        /// <param name="invalidTitle">Некорректный заголовок</param>
        [TestCase("", TestName = "Тест на Empty в заглавии")]
        [TestCase("   ", TestName = "Тест на пробелы в заглавии")]
        [TestCase(null, TestName ="Тест на null заглавия")]
        public void TitleAssertionNegativeTest(string? invalidTitle)
        {
            var publication = new Book();
            Assert.Throws<ArgumentException>(
                () => publication.Title = invalidTitle);
        }

        /// <summary>
        /// Проверка корректных данных для свойства TitleInformation
        /// </summary>
        /// <param name="titleInfo">Информация о заглавии</param>
        [TestCase("Учебное пособие",
            TestName = "Тест установки сведений о заглавии")]
        [TestCase("", TestName = "Тест пустых сведений о заглавии")]
        public void TitleInformationAssertionTest(string titleInfo)
        {
            var publication = new Book();
            publication.TitleInformation = titleInfo;
            ClassicAssert.AreEqual(titleInfo, publication.TitleInformation);
        }

        /// <summary>
        /// Проверка корректных данных для свойства Year
        /// </summary>
        /// <param name="year">год издания</param>
        [TestCase(1957, TestName = "Тест года издания 1957")]
        [TestCase(1305, TestName = "Тест года издания 1305")]
        [TestCase(2024, TestName = "Тест года издания 2024")]
        public void YearAssertionTest(int year)
        {
            var publication = new Book();
            publication.Year = year;
            ClassicAssert.AreEqual(year, publication.Year);
        }

        /// <summary>
        /// Проверка некорректных данных для свойства Year
        /// </summary>
        /// <param name="year">год издания</param>
        [TestCase(0, TestName = "Тест года издания 0")]
        [TestCase(-100, TestName = "Тест отрицательного года")]
        [TestCase(867, TestName = "Тест года меньше минимального (868)")]
        [TestCase(2027, TestName = "Тест года больше текущего")]
        public void YearAssertionNegativeTest(int year)
        {
            var publication = new Book();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => publication.Year = year);
        }

        /// <summary>
        /// Проверка корректных данных свойства Place
        /// </summary>
        /// <param name="place">Место издания</param>
        [TestCase("Москва", TestName = "Тест установки места издания")]
        [TestCase("Saint Petersburg",
            TestName = "Тест места издания на латинице")]
        [TestCase("New York", TestName = "Тест места издания с пробелами")]
        public void PlaceAssertionTest(string place)
        {
            var publication = new Book();
            publication.Place = place;
            ClassicAssert.AreEqual(place, publication.Place);
        }

        /// <summary>
        /// Проверка некорректных данных свойства Place
        /// </summary>
        /// <param name="invalidPlace">Место издания</param>
        [TestCase("", TestName = "Тест на Empty в месте издания")]
        [TestCase("   ", TestName = "Тест на пробелы в месте издания")]
        [TestCase(null, TestName = "Тест на null места издания")]
        public void PlaceAssertionNegativeTest(string? invalidPlace)
        {
            var publication = new Book();
            Assert.Throws<ArgumentException>(
                () => publication.Place = invalidPlace);
        }

        /// <summary>
        /// Проверка корректных данных свойства Publisher
        /// </summary>
        /// <param name="publisher">Издательство</param>
        [TestCase("Питер", TestName = "Тест установки издательства")]
        [TestCase("O'Reilly", 
            TestName = "Тест издательства со спецсимволами")]
        [TestCase("Microsoft Press", 
            TestName = "Тест издательства с пробелом")]
        public void PublisherAssertionTest(string publisher)
        {
            var publication = new Book();
            publication.Publisher = publisher;
            ClassicAssert.AreEqual(publisher, publication.Publisher);
        }

        /// <summary>
        /// Проверка некорректных данных свойства Publisher
        /// </summary>
        /// <param name="invalidPublisher">Издательство</param>
        [TestCase("", TestName = "Тест на Empty в издательстве")]
        [TestCase("   ", TestName = "Тест на пробелы в издательстве")]
        [TestCase(null, TestName = "Тест на null издательства")]
        public void PublisherAssertionNegativeTest(string? invalidPublisher)
        {
            var publication = new Book();
            Assert.Throws<ArgumentException>(
                () => publication.Publisher = invalidPublisher);
        }

        /// <summary>
        /// Проверка корректных данных свойства TotalPages
        /// </summary>
        /// <param name="pages">Количество страниц</param>
        [TestCase(100, TestName = "Тест количества страниц 100")]
        [TestCase(1, TestName = "Тест минимального количества страниц")]
        [TestCase(9999, TestName = "Тест большого количества страниц")]
        public void TotalPagesAssertionTest(int pages)
        {
            var publication = new Book();
            publication.TotalPages = pages;
            ClassicAssert.AreEqual(pages, publication.TotalPages);
        }

        /// <summary>
        /// Проверка некорректных данных свойства TotalPages
        /// </summary>
        /// <param name="pages">Количество страниц</param>
        [TestCase(0, TestName = "Тест нулевого количества страниц")]
        [TestCase(-100, TestName = "Тест отрицательного количества страниц")]
        public void TotalPagesAssertionNegativeTest(int pages)
        {
            var publication = new Book();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => publication.TotalPages = pages);
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation()
        /// </summary>
        [Test]
        public void GetGOSTInformationAssertionTest()
        {
            var book = new Book
            {
                Title = "Тестовая книга",
                Place = "Москва",
                Publisher = "Тест",
                Year = 2024,
                TotalPages = 100
            };
            book.AddAuthors("Тестов Т.Т.");

            string gostInfo = book.GostInformation;
            string expected = book.GetGOSTInformation();

            ClassicAssert.AreEqual(expected, gostInfo);
        }

        /// <summary>
        /// Проверка метода ValidateString() корректными данными
        /// </summary>
        [Test]
        public void ValidateStringAssertionTest()
        {
            var testPublication = new TestPublication();

            Assert.DoesNotThrow(
                () => testPublication.TestValidateString(
                    "Корректная строка",
                    "TestField"));
            Assert.DoesNotThrow(
                () => testPublication.TestValidateString("A", "TestField"));
            Assert.DoesNotThrow(
                () => testPublication.TestValidateString(
                    "Очень длинная строка с пробелами и символами!!!",
                    "TestField"));
        }

        /// <summary>
        /// Проверка метода ValidateString() некорректными данными
        /// </summary>
        /// <param name="invalidValue">Некорректное значение</param>
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        [TestCase(null, TestName = "Проверка null в методе ValidateString")]
        public void ValidateStringAssertionNegativeTest(string? invalidValue)
        {
            var testPublication = new TestPublication();
            Assert.Throws<ArgumentException>(
                () => testPublication.TestValidateString(
                    invalidValue, "TestField"));
        }

        /// <summary>
        /// Проверка метода ValidateYear() корректными данными
        /// </summary>
        /// <param name="year">Год издания</param>
        [TestCase(868, TestName = "Минимальный год")]
        [TestCase(1500, TestName = "Средний год")]
        [TestCase(2026, TestName = "Текущий год")]
        public void ValidateYearAssertionTest(int year)
        {
            var testPublication = new TestPublication();
            Assert.DoesNotThrow(
                () => testPublication.TestValidateYear(year));
        }

        /// <summary>
        /// Проверка метода ValidateYear() некорректными данными
        /// </summary>
        /// <param name="year">Некорректный год издания</param>
        [TestCase(867, TestName = "Год меньше минимального")]
        [TestCase(2027, TestName = "Год больше текущего")]
        [TestCase(100, TestName = "Слишком маленький год")]
        public void ValidateYearAssertionNegativeTest(int year)
        {
            var testPublication = new TestPublication();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testPublication.TestValidateYear(year));
        }

        /// <summary>
        /// Проверка метода ValidateTotalPages() корректными данными
        /// </summary>
        /// <param name="pages">Количество страниц</param>
        [TestCase(1, TestName = "Минимальное количество страниц")]
        [TestCase(100, TestName = "Среднее количество страниц")]
        [TestCase(10000, TestName = "Большое количество страниц")]
        public void ValidateTotalPagesAssertionTest(int pages)
        {
            var testPublication = new TestPublication();
            Assert.DoesNotThrow(
                () => testPublication.TestValidateTotalPages(pages));
        }

        /// <summary>
        /// Проверка метода ValidateTotalPages() некорректными данными
        /// </summary>
        /// <param name="pages">Количество страниц</param>
        [TestCase(0, TestName = "Ноль страниц")]
        [TestCase(-1, TestName = "Отрицательное количество страниц")]
        [TestCase(-100, TestName = "Большое отрицательное число")]
        public void ValidateTotalPagesAssertionNegativeTest(int pages)
        {
            var testPublication = new TestPublication();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testPublication.TestValidateTotalPages(pages));
        }

        /// <summary>
        /// Проверка метода AppendIfNotEmpty() корректными данными
        /// </summary>
        [Test]
        public void AppendIfNotEmptyAssertionTest()
        {
            var testPublication = new TestPublication();

            var testData = new (string Prefix, string Value,
                string Suffix, string Expected)[]
            {
                ("prefix ", "value", " suffix", "prefix value suffix"),
                ("", "value", "", "value"),
                (">>>", "value", "", ">>>value")
            };

            foreach (var (prefix, value, suffix, expected) in testData)
            {
                var stringBuilder = new System.Text.StringBuilder();
                testPublication.TestAppendIfNotEmpty(stringBuilder,
                    prefix, value, suffix);
                ClassicAssert.AreEqual(expected, stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Проверка метода AppendIfNotEmpty() некорректными значениями
        /// </summary>
        [Test]
        public void AppendIfNotEmptyNegativeTest()
        {
            var testPublication = new TestPublication();
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("start");
            testPublication.TestAppendIfNotEmpty(stringBuilder,
                "prefix ", "", " suffix");
            testPublication.TestAppendIfNotEmpty(stringBuilder,
                "prefix ", "   ", " suffix");
            testPublication.TestAppendIfNotEmpty(stringBuilder,
                "prefix ", null, " suffix");

            ClassicAssert.AreEqual("start", stringBuilder.ToString());
        }

        /// <summary>
        /// Проверка класса PublicationBase со всеми свойствами
        /// </summary>
        [Test]
        public void AllPropertiesAssertionTest()
        {
            var publication = new Book();

            publication.Title = "Тестовое название";
            publication.TitleInformation = "Тестовое подзаголовок";
            publication.Year = 2023;
            publication.Place = "Санкт-Петербург";
            publication.Publisher = "ТестИздат";
            publication.TotalPages = 500;

            ClassicAssert.AreEqual(
                "Тестовое название", publication.Title);
            ClassicAssert.AreEqual("Тестовое подзаголовок",
                publication.TitleInformation);
            ClassicAssert.AreEqual(2023, publication.Year);
            ClassicAssert.AreEqual("Санкт-Петербург", publication.Place);
            ClassicAssert.AreEqual("ТестИздат", publication.Publisher);
            ClassicAssert.AreEqual(500, publication.TotalPages);
        }

        /// <summary>
        /// Вспомогательный класс для тестирования
        /// защищенных методов PublicationBase
        /// </summary>
        public class TestPublication : PublicationBase
        {
            /// <summary>
            /// Метод получения информации по ГОСТ
            /// </summary>
            /// <returns>Строку для теста</returns>
            public override string GetGOSTInformation()
            {
                return "Test GOST Information";
            }

            /// <summary>
            /// Метод тестирования валидации строки
            /// </summary>
            /// <param name="value">Значение</param>
            /// <param name="propertyName">Свойство</param>
            public void TestValidateString(string value,
                string propertyName)
            {
                ValidateString(value, propertyName);
            }

            /// <summary>
            /// Метод тестирования валидации года
            /// </summary>
            /// <param name="year">Год издания</param>
            public void TestValidateYear(int year)
            {
                ValidateYear(year);
            }

            /// <summary>
            /// Метод тестирования количества страниц
            /// </summary>
            /// <param name="totalPages">Количество страниц</param>
            public void TestValidateTotalPages(int totalPages)
            {
                ValidateTotalPages(totalPages);
            }

            /// <summary>
            /// Метод тестирования AppendIfNotEmpty
            /// </summary>
            /// <param name="stringBuilder">Конструкция
            /// stringBuilder</param>
            /// <param name="prefix">Префикс</param>
            /// <param name="value">Значение</param>
            /// <param name="suffix">Суффикс</param>
            public void TestAppendIfNotEmpty(
                System.Text.StringBuilder stringBuilder,
                string prefix, string value, string suffix = "")
            {
                AppendIfNotEmpty(stringBuilder, prefix, value, suffix);
            }
        }
    }
}
