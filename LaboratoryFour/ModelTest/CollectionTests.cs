using NUnit.Framework.Legacy;
using LaboratoryThirdModel;

namespace ModelTest
{
    /// <summary>
    /// Класс для проведения тестов класса Collection
    /// </summary>
    [TestFixture]
    public class CollectionTests
    {
        /// <summary>
        /// Проверка корректных данных для свойства EditorialBoard
        /// </summary>
        [TestCase("Иванов И.И., Петров П.П.",
            TestName = "Установка редакционной коллегии из двух человек")]
        [TestCase("Сидоров С.С.",
            TestName = "Установка редакционной коллегии из одного человека")]
        [TestCase("Иванов И.И., Петров П.П., Сидоров С.С., Козлов К.К.",
            TestName = "Установка редакционной коллегии из четырёх человек")]
        public void EditorialBoardAssertionTest(string editorialBoard)
        {
            var collection = new Collection();
            collection.EditorialBoard = editorialBoard;
            ClassicAssert.AreEqual(editorialBoard, collection.EditorialBoard);
        }

        /// <summary>
        /// Проверка некорректных данных для свойства EditorialBoard
        /// </summary>
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        [TestCase(null, TestName = "Null значение")]
        public void EditorialBoardNegativeTest(string? invalidBoard)
        {
            var collection = new Collection();
            Assert.Throws<ArgumentException>(() 
                => collection.EditorialBoard = invalidBoard);
        }

        /// <summary>
        /// Проверка корректных данных для свойства ResponsibleEditors
        /// </summary>
        [TestCase("Иванов И.И.",
            TestName = "Установка одного ответственного редактора")]
        [TestCase("Петров П.П., Сидоров С.С.",
            TestName = "Установка двух ответственных редакторов")]
        public void ResponsibleEditorsAssertionTest(
            string responsibleEditors)
        {
            var collection = new Collection();
            collection.ResponsibleEditors = responsibleEditors;
            ClassicAssert.AreEqual(responsibleEditors,
                collection.ResponsibleEditors);
        }

        /// <summary>
        /// Проверка некорректных данных для свойства ResponsibleEditors
        /// </summary>
        [TestCase("", TestName = "Пустая строка")]
        [TestCase("   ", TestName = "Строка из пробелов")]
        [TestCase(null, TestName = "Null значение")]
        public void ResponsibleEditorsNegativeTest(string? invalidEditors)
        {
            var collection = new Collection();
            Assert.Throws<ArgumentException>(() 
                => collection.ResponsibleEditors = invalidEditors);
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с полными данными
        /// </summary>
        [Test]
        public void GetGOSTInformationFullDataTest()
        {
            var collection = new Collection
            {
                Title = "Актуальные проблемы информатики",
                TitleInformation = "сборник статей",
                EditorialBoard = "Иванов И.И., Петров П.П.",
                ResponsibleEditors = "Сидоров С.С.",
                Place = "Москва",
                Publisher = "МГУ",
                Year = 2023,
                TotalPages = 250
            };

            string result = collection.GetGOSTInformation();

            ClassicAssert.IsTrue(result.Contains(
                "Актуальные проблемы информатики"), "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains(
                "сборник статей"), "Подзаголовок не найден");
            ClassicAssert.IsTrue(result.Contains(
                "Иванов И.И., Петров П.П."), "Редколлегия не найдена");
            ClassicAssert.IsTrue(result.Contains(
                "Сидоров С.С."), "Ответственный редактор не найден");
            ClassicAssert.IsTrue(result.Contains(
                "Москва"), "Место не найдено");
            ClassicAssert.IsTrue(result.Contains(
                "МГУ"), "Издательство не найдено");
            ClassicAssert.IsTrue(result.Contains(
                "2023"), "Год не найден");
            ClassicAssert.IsTrue(result.Contains(
                "250 с."), "Страницы не найдены");
        }

        /// <summary>
        /// Проверка метода GetGOSTInformation() с минимальными данными
        /// </summary>
        [Test]
        public void GetGOSTInformationMinimalDataTest()
        {
            var collection = new Collection
            {
                Title = "Минимальный сборник",
                EditorialBoard = "Редактор А.А.",
                ResponsibleEditors = "Отв. ред. Б.Б.",
                Place = "Минск",
                Publisher = "Изд-во",
                Year = 2024,
                TotalPages = 50
            };

            string result = collection.GetGOSTInformation();

            ClassicAssert.IsTrue(result.Contains
                ("Минимальный сборник"), "Заголовок не найден");
            ClassicAssert.IsTrue(result.Contains
                ("Редактор А.А."), "Редколлегия не найдена");
            ClassicAssert.IsTrue(result.Contains
                ("Отв. ред. Б.Б."), "Ответственный редактор не найден");
            ClassicAssert.IsTrue(result.Contains
                ("50 с."), "Страницы не найдены");
        }
    }
}
