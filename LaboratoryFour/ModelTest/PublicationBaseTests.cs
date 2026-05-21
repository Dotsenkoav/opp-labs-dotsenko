using LaboratoryThirdModel;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса PublicationBase
    /// </summary>
    [TestFixture]
    public class PublicationBaseTests
    {
        /// <summary>
        /// Проверка метода ValidateString() корректными данными
        /// </summary>
        [TestCase(TestName = "Проверка метода ValidateString()" +
            " корректными данными")]
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
        [TestCase(TestName = "Проверка метода AppendIfNotEmpty()" +
            " корректными данными")]
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
                Assert.That(stringBuilder.ToString(), Is.EqualTo(expected));
            }
        }

        /// <summary>
        /// Проверка метода AppendIfNotEmpty() некорректными значениями
        /// </summary>
        [TestCase(TestName = "Проверка метода AppendIfNotEmpty()" +
            " некорректными значениями")]
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

            Assert.That(stringBuilder.ToString(), Is.EqualTo("start"));
        }

        /// <summary>
        /// Проверка класса PublicationBase со всеми свойствами
        /// </summary>
        [TestCase(TestName = "Проверка класса PublicationBase" +
            " со всеми свойствами")]
        public void AllPropertiesAssertionTest()
        {
            var publication = new Book();

            publication.Title = "Тестовое название";
            publication.TitleInformation = "Тестовое подзаголовок";
            publication.Year = 2023;
            publication.Place = "Санкт-Петербург";
            publication.Publisher = "ТестИздат";
            publication.TotalPages = 500;

            Assert.Multiple(() =>
            {
                Assert.That(publication.Title,
                    Is.EqualTo("Тестовое название"));
                Assert.That(publication.TitleInformation,
                    Is.EqualTo("Тестовое подзаголовок"));
                Assert.That(publication.Year, Is.EqualTo(2023));
                Assert.That(publication.Place,
                    Is.EqualTo("Санкт-Петербург"));
                Assert.That(publication.Publisher, Is.EqualTo("ТестИздат"));
                Assert.That(publication.TotalPages, Is.EqualTo(500));
            });
        }

        /// <summary>
        /// Проверка свойства GostInformation
        /// </summary>
        [TestCase(TestName = "Проверка свойства GostInformation")]
        public void GostInformationGetGOSTInformationResult()
        {
            var testPublication = new TestPublication();

            Assert.That(testPublication.GostInformation,
                Is.EqualTo(testPublication.GetGOSTInformation()));
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
