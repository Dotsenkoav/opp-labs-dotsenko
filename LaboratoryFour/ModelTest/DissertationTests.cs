using LaboratoryThirdModel;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса Dissertation
    /// </summary>
    [TestFixture]
    public class DissertationTests : PublicationBaseChildTests<Book>
    {
        /// <summary>
        /// Проверка корректных данных для свойства AuthorFull
        /// </summary>
        [TestCase("Иванов Иван Иванович", TestName = "Полное имя")]
        [TestCase("Петров Петр", TestName = "Имя и фамилия")]
        [TestCase("Сидоров С.С.", TestName = "Имя с инициалами")]
        public void AuthorFullAssertionTest(string authorFull)
        {
            var dissertation = new Dissertation();
            dissertation.AuthorFull = authorFull;
            Assert.That(dissertation.AuthorFull, Is.EqualTo(authorFull));
        }

        /// <summary>
        /// Проверка некорректных данных для свойства AuthorFull
        /// </summary>
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        [TestCase(null, TestName = "Null значение")]
        public void AuthorFullNegativeTest(string? invalidAuthor)
        {
            var dissertation = new Dissertation();
            Assert.Throws<ArgumentException>(
                () => dissertation.AuthorFull = invalidAuthor);
        }

        /// <summary>
        /// Проверка корректных данных для свойства Speciality
        /// </summary>
        [TestCase("05.13.01 - Системный анализ",
            TestName = "Полная специальность")]
        [TestCase("01.01.01", TestName = "Код специальности")]
        [TestCase("Математическое моделирование",
            TestName = "Название специальности")]
        public void SpecialityAssertionTest(string speciality)
        {
            var dissertation = new Dissertation();
            dissertation.Speciality = speciality;
            Assert.That(dissertation.Speciality, Is.EqualTo(speciality));
        }

        /// <summary>
        /// Проверка некорректных данных для свойства Speciality
        /// </summary>
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        [TestCase(null, TestName = "Null значение")]
        public void SpecialityNegativeTest(string? invalidSpeciality)
        {
            var dissertation = new Dissertation();
            Assert.Throws<ArgumentException>(
                () => dissertation.Speciality = invalidSpeciality);
        }

        /// <summary>
        /// Проверка корректных данных для свойства Degree
        /// </summary>
        [TestCase("Кандидат наук", TestName = "Кандидат наук")]
        [TestCase("Доктор наук", TestName = "Доктор наук")]
        [TestCase("Любая степень", TestName = "Произвольная степень")]
        public void DegreeAssertionTest(string degree)
        {
            var dissertation = new Dissertation();
            dissertation.Degree = degree;
            Assert.That(dissertation.Degree, Is.EqualTo(degree));
        }

        /// <summary>
        /// Проверка некорректных данных для свойства Degree
        /// </summary>
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        [TestCase(null, TestName = "Null значение")]
        public void DegreeNegativeTest(string? invalidDegree)
        {
            var dissertation = new Dissertation();
            Assert.Throws<ArgumentException>(
                () => dissertation.Degree = invalidDegree);
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с полными данными
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " с полными данными")]
        public void GetGOSTInformationFullDataTest()
        {
            var dissertation = new Dissertation
            {
                AuthorFull = "Иванов Иван Иванович",
                Title = "Методы анализа данных",
                Speciality = "05.13.01",
                Degree = "Кандидат наук",
                Publisher = "МГУ",
                Place = "Москва",
                Year = 2023,
                TotalPages = 150
            };

            string result = dissertation.GetGOSTInformation();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain("Иванов, И. И"),
                    "Автор в заголовке не найден");
                Assert.That(result, Does.Contain("Методы анализа данных"),
                    "Заголовок не найден");
                Assert.That(result, Does.Contain("специальность 05.13.01"),
                    "Специальность не найдена");
                Assert.That(result, Does.Contain("Кандидат наук"),
                    "Степень не найдена");
                Assert.That(result, Does.Contain("Иванов Иван Иванович"),
                    "Автор в подзаголовке не найден");
                Assert.That(result, Does.Contain("МГУ"),
                    "Издательство не найдено");
                Assert.That(result, Does.Contain("Москва"),
                    "Место не найдено");
                Assert.That(result, Does.Contain("2023"),
                    "Год не найден");
                Assert.That(result, Does.Contain("150 с."),
                    "Страницы не найдены");
            });
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с минимальными данными
        /// </summary>
        [TestCase(TestName = "Проверка метода GetGOSTInformation()" +
            " с минимальными данными")]
        public void GetGOSTInformationMinimalDataTest()
        {
            var dissertation = new Dissertation
            {
                AuthorFull = "Петров",
                Title = "Простая диссертация",
                Speciality = "01.01.01",
                Degree = "Доктор наук",
                Publisher = "Наука",
                Place = "СПб",
                Year = 2024,
                TotalPages = 100
            };

            string result = dissertation.GetGOSTInformation();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.StartWith("Петров"),
                    "Автор не в начале");
                Assert.That(result, Does.Contain("Простая диссертация"),
                    "Заголовок не найден");
                Assert.That(result, Does.Contain("Доктор наук"),
                    "Степень не найдена");
                Assert.That(result, Does.Contain("100 с."),
                    "Страницы не найдены");
            });
        }

        /// <summary>
        /// Проверка, что возможные степени содержат ожидаемые значения
        /// </summary>
        [TestCase(TestName = "Проверка, что возможные степени содержат" +
            " ожидаемые значения")]
        public void PossibleDegreeTest()
        {
            var expectedDegrees = new[] { "Кандидат наук",
                "Доктор наук" };
            Assert.That(Dissertation.PossibleDegree,
                Is.EqualTo(expectedDegrees));
        }
    }
}
