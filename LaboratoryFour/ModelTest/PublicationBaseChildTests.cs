using LaboratoryThirdModel;

namespace ModelTest
{
    public abstract class PublicationBaseChildTests<T> 
        where T : PublicationBase, new()
    {
        protected T CreatePublication() => new T();

        /// <summary>
        /// Проверка корректных данных для свойства Title
        /// </summary>
        [TestCase("Программирование",
            TestName = "Тест установки корректного заглавия")]
        [TestCase("C# Advanced",
            TestName = "Тест установки заглавия на латинице")]
        [TestCase("Программирование на C#",
            TestName = "Тест установки заглавия с пробелами")]
        public void TitleAssertionTest(string title)
        {
            var publication = CreatePublication();
            publication.Title = title;
            Assert.That(publication.Title, Is.EqualTo(title));
        }

        /// <summary>
        /// Проверка некорректных данных для свойства Title
        /// </summary>
        [TestCase("", TestName = "Тест на Empty в заглавии")]
        [TestCase("   ", TestName = "Тест на пробелы в заглавии")]
        [TestCase(null, TestName = "Тест на null заглавия")]
        public void TitleAssertionNegativeTest(string? invalidTitle)
        {
            var publication = CreatePublication();
            Assert.Throws<ArgumentException>(
                () => publication.Title = invalidTitle);
        }

        /// <summary>
        /// Проверка корректных данных для свойства Year
        /// </summary>
        [TestCase(1957, TestName = "Тест года издания 1957")]
        [TestCase(1305, TestName = "Тест года издания 1305")]
        [TestCase(2024, TestName = "Тест года издания 2024")]
        public void YearAssertionTest(int year)
        {
            var publication = CreatePublication();
            publication.Year = year;
            Assert.That(publication.Year, Is.EqualTo(year));
        }

        /// <summary>
        /// Проверка некорректных данных для свойства Year
        /// </summary>
        [TestCase(0, TestName = "Тест года издания 0")]
        [TestCase(-100, TestName = "Тест отрицательного года")]
        [TestCase(867, TestName = "Тест года меньше минимального (868)")]
        [TestCase(2027, TestName = "Тест года больше текущего")]
        public void YearAssertionNegativeTest(int year)
        {
            var publication = CreatePublication();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => publication.Year = year);
        }

        /// <summary>
        /// Проверка корректных данных свойства Place
        /// </summary>
        [TestCase("Москва", TestName = "Тест установки места издания")]
        [TestCase("Saint Petersburg",
            TestName = "Тест места издания на латинице")]
        [TestCase("New York", TestName = "Тест места издания с пробелами")]
        public void PlaceAssertionTest(string place)
        {
            var publication = CreatePublication();
            publication.Place = place;
            Assert.That(publication.Place, Is.EqualTo(place));
        }

        /// <summary>
        /// Проверка некорректных данных свойства Place
        /// </summary>
        [TestCase("", TestName = "Тест на Empty в месте издания")]
        [TestCase("   ", TestName = "Тест на пробелы в месте издания")]
        [TestCase(null, TestName = "Тест на null места издания")]
        public void PlaceAssertionNegativeTest(string? invalidPlace)
        {
            var publication = CreatePublication();
            Assert.Throws<ArgumentException>(
                () => publication.Place = invalidPlace);
        }

        /// <summary>
        /// Проверка корректных данных свойства Publisher
        /// </summary>
        [TestCase("Питер", TestName = "Тест установки издательства")]
        [TestCase("O'Reilly",
            TestName = "Тест издательства со спецсимволами")]
        [TestCase("Microsoft Press",
            TestName = "Тест издательства с пробелом")]
        public void PublisherAssertionTest(string publisher)
        {
            var publication = CreatePublication();
            publication.Publisher = publisher;
            Assert.That(publication.Publisher, Is.EqualTo(publisher));
        }

        /// <summary>
        /// Проверка некорректных данных свойства Publisher
        /// </summary>
        [TestCase("", TestName = "Тест на Empty в издательстве")]
        [TestCase("   ", TestName = "Тест на пробелы в издательстве")]
        [TestCase(null, TestName = "Тест на null издательства")]
        public void PublisherAssertionNegativeTest(string? invalidPublisher)
        {
            var publication = CreatePublication();
            Assert.Throws<ArgumentException>(
                () => publication.Publisher = invalidPublisher);
        }

        /// <summary>
        /// Проверка корректных данных свойства TotalPages
        /// </summary>
        [TestCase(100, TestName = "Тест количества страниц 100")]
        [TestCase(1, TestName = "Тест минимального количества страниц")]
        [TestCase(9999, TestName = "Тест большого количества страниц")]
        public void TotalPagesAssertionTest(int pages)
        {
            var publication = CreatePublication();
            publication.TotalPages = pages;
            Assert.That(publication.TotalPages, Is.EqualTo(pages));
        }

        /// <summary>
        /// Проверка некорректных данных свойства TotalPages
        /// </summary>
        [TestCase(0, TestName = "Тест нулевого количества страниц")]
        [TestCase(-100, TestName = "Тест отрицательного количества страниц")]
        public void TotalPagesAssertionNegativeTest(int pages)
        {
            var publication = CreatePublication();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => publication.TotalPages = pages);
        }
    }
}
