using LaboratoryThirdModel;
using NUnit.Framework.Legacy;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса Dissertation
    /// </summary>
    [TestFixture]
    public class DissertationTests
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
            ClassicAssert.AreEqual(authorFull, dissertation.AuthorFull);
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
            ClassicAssert.AreEqual(speciality, dissertation.Speciality);
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
            ClassicAssert.AreEqual(degree, dissertation.Degree);
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
        [Test]
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

            ClassicAssert.IsTrue(result.Contains("Иванов, И. И"),
                "Автор в заголовке не найден"); 
            ClassicAssert.IsTrue(result.Contains("Методы анализа данных"),
                "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains("специальность 05.13.01"),
                "Специальность не найдена");
            ClassicAssert.IsTrue(result.Contains("Кандидат наук"),
                "Степень не найдена");
            ClassicAssert.IsTrue(result.Contains("Иванов Иван Иванович"),
                "Автор в подзаголовке не найден");
            ClassicAssert.IsTrue(result.Contains("МГУ"),
                "Издательство не найдено");
            ClassicAssert.IsTrue(result.Contains("Москва"),
                "Место не найдено");
            ClassicAssert.IsTrue(result.Contains("2023"),
                "Год не найден");
            ClassicAssert.IsTrue(result.Contains("150 с."), 
                "Страницы не найдены");
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с минимальными данными
        /// </summary>
        [Test]
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

            ClassicAssert.IsTrue(result.StartsWith("Петров"),
                "Автор не в начале");
            ClassicAssert.IsTrue(result.Contains("Простая диссертация"),
                "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains("Доктор наук"),
                "Степень не найдена");
            ClassicAssert.IsTrue(result.Contains("100 с."),
                "Страницы не найдены");
        }

        /// <summary>
        /// Проверка, что возможные степени содержат ожидаемые значения
        /// </summary>
        [Test]
        public void PossibleDegreeTest()
        {
            var expectedDegrees = new[] { "Кандидат наук", "Доктор наук" };

            ClassicAssert.AreEqual(expectedDegrees.Length,
                Dissertation.PossibleDegree.Length);

            for (int i = 0; i < expectedDegrees.Length; i++)
            {
                ClassicAssert.AreEqual(expectedDegrees[i],
                    Dissertation.PossibleDegree[i]);
            }
        }
    }
}
