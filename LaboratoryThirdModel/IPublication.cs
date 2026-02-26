using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Год издания
        /// </summary>
        int Year { get; set; }

        /// <summary>
        /// Место издания
        /// </summary>
        string Place { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        int TotalPages { get; set; }

        /// <summary>
        /// Метод формирования описания по ГОСТ
        /// </summary>
        /// <returns>Строку с информацие об издании</returns>
        string GetGOSTInfo();
    }
}
