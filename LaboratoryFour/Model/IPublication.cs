
namespace LaboratoryThirdModel
{
    /// <summary>
    /// Интерфейс для издания
    /// </summary>
    public interface IPublication
    {
        /// <summary>
        /// Заглавие
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Сведение о заглавии
        /// </summary>
        string TitleInformation { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        int Year { get; set; }

        /// <summary>
        /// Место издания
        /// </summary>
        string Place { get; set; }

        /// <summary>
        /// Издательство, учредитель, организация
        /// </summary>
        string Publisher { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        int TotalPages { get; set; }

        /// <summary>
        /// Свойство для получения информации по ГОСТ
        /// </summary>
        string GostInformation { get; }

        /// <summary>
        /// Метод формирования описания по ГОСТ
        /// </summary>
        /// <returns>Строку с информацие об издании</returns>
        string GetGOSTInformation();
    }
}
