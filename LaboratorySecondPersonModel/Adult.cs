using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorySecondPersonModel
{
    /// <summary>
    /// Класс описывающий сущность родителя
    /// </summary>
    internal class Adult : PersonBase
    {
        /// <summary>
        /// Номер паспорта
        /// </summary>
        private string _passportNumber;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        private string _passportSeries;

        /// <summary>
        /// Партнер родителя
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _placeOfJob;
    }
}
