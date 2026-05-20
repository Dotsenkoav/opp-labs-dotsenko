using LaboratoryThirdModel;
using NUnit.Framework.Legacy;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса Journal
    /// </summary>
    [TestFixture]
    public class JournalTests
    {
        /// <summary>
        /// Проверка корректных данных для свойства Frequency
        /// </summary>
        [TestCase("Ежедневный", TestName = "Ежедневный")]
        [TestCase("Еженедельный", TestName = "Еженедельный")]
        [TestCase("Ежемесячный", TestName = "Ежемесячный")]
        [TestCase("Ежеквартальный", TestName = "Ежеквартальный")]
        [TestCase("Полугодовой", TestName = "Полугодовой")]
        [TestCase("Годовой", TestName = "Годовой")]
        [TestCase("С прочей периодичностью",
            TestName = "С прочей периодичностью")]
        [TestCase("С неопределенной периодичностью",
            TestName = "С неопределенной периодичностью")]
        [TestCase("Любая другая частота",
            TestName = "Произвольная частота")]
        public void FrequencyAssertionTest(string frequency)
        {
            var journal = new Journal();
            journal.Frequency = frequency;
            ClassicAssert.AreEqual(frequency, journal.Frequency);
        }

        /// <summary>
        /// Проверка, что свойство Frequency
        /// может принимать null и пустые строки
        /// </summary>
        [TestCase(null, TestName = "Null значение")]
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        public void FrequencyNullableTest(string? frequency)
        {
            var journal = new Journal();
            journal.Frequency = frequency;
            ClassicAssert.AreEqual(frequency, journal.Frequency);
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с полными данными
        /// </summary>
        [Test]
        public void GetGOSTInformationFullDataTest()
        {
            var journal = new Journal
            {
                Title = "Наука и жизнь",
                TitleInformation = "научно-популярный журнал",
                Publisher = "Наука",
                Place = "Москва",
                Year = 2023,
                TotalPages = 96,
                Frequency = "Ежемесячный"
            };

            string result = journal.GetGOSTInformation();

            ClassicAssert.IsTrue(result.Contains("Наука и жизнь"),
                "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains("научно-популярный журнал"),
                "Подзаголовок не найден");
            ClassicAssert.IsTrue(result.Contains("Наука"),
                "Издательство не найдено");
            ClassicAssert.IsTrue(result.Contains("Москва"),
                "Место не найдено");
            ClassicAssert.IsTrue(result.Contains("2023"),
                "Год не найден");
            ClassicAssert.IsTrue(result.Contains("96 с."),
                "Страницы не найдены");
            ClassicAssert.IsTrue(result.Contains("Ежемесячный"),
                "Частота не найдена");
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с минимальными данными
        /// </summary>
        [Test]
        public void GetGOSTInformationMinimalDataTest()
        {
            var journal = new Journal
            {
                Title = "Минимальный журнал",
                Publisher = "МинИздат",
                Place = "Минск",
                Year = 2025,
                TotalPages = 30
            };

            string result = journal.GetGOSTInformation();

            ClassicAssert.IsTrue(result.Contains("Минимальный журнал"),
                "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains("МинИздат"),
                "Издательство не найдено");
            ClassicAssert.IsTrue(result.Contains("Минск"),
                "Место не найдено");
            ClassicAssert.IsTrue(result.Contains("2025"),
                "Год не найден");
            ClassicAssert.IsTrue(result.Contains("30 с."),
                "Страницы не найдены");
        }

        /// <summary>
        /// Проверка статического массива возможных частот
        /// </summary>
        [Test]
        public void PossibleFrequenciesTest()
        {
            var expectedFrequencies = new[]
            {
                "Ежедневный",
                "Еженедельный",
                "Ежемесячный",
                "Ежеквартальный",
                "Полугодовой",
                "Годовой",
                "С прочей периодичностью",
                "С неопределенной периодичностью"
            };

            ClassicAssert.AreEqual(expectedFrequencies.Length,
                Journal.PossibleFrequencies.Length);

            for (int i = 0; i < expectedFrequencies.Length; i++)
            {
                ClassicAssert.AreEqual(expectedFrequencies[i],
                    Journal.PossibleFrequencies[i]);
            }
        }
    }
}
