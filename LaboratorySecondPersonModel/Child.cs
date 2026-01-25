using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorySecondPersonModel
{
    /// <summary>
    /// Класс описывающий сущность ребенка
    /// </summary>
    internal class Child : PersonBase
    {
        /// <summary>
        /// Мама
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Папа
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Место учебы
        /// </summary>
        private string _placeOfStuty;

    }
}
