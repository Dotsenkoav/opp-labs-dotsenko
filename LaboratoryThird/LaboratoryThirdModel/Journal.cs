using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryThirdModel
{
    /// <summary>
    /// Класс описывающий издание журнала
    /// </summary>
    public class Journal : PublicationBase
    {
        /// <summary>
        /// Частота издания
        /// </summary>
        private string _frequency;

        /// <summary>
        /// Свойство частоты издания
        /// </summary>
        public string Frequency { get; set; }

        /// <summary>
        /// Получение информации о журнале по ГОСТ
        /// </summary>
        /// <returns>Строку с описанием журнала по ГОСТ</returns>
        public override string GetGOSTInformation()
        {
            var journalInformation = new StringBuilder();

            journalInformation.Append(Title);

            AppendIfNotEmpty(journalInformation, " : ", TitleInformation);

            journalInformation.Append($" / {Publisher} – {Place}," +
                $" {Year}– . – {TotalPages} с.");

            AppendIfNotEmpty(journalInformation, " – ", Frequency, ".");

            return journalInformation.ToString();
        }
    }
}
