using LaboratoryThirdModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс формы, отвечающий за поиск издания
    /// </summary>
    public partial class SearchPublicationForm : Form
    {
        /// <summary>
        /// Исходный список изданий для поиска
        /// </summary>
        private List<IPublication> _sourcePublications;

        /// <summary>
        /// Событие выбора изданий для MainForm
        /// </summary>
        public event EventHandler<List<IPublication>>? PublicationsSelected;

        /// <summary>
        /// Конструктор формы для поиска издания
        /// </summary>
        /// <param name="source">Список для поиска</param>
        public SearchPublicationForm(List<IPublication> source)
        {
            _sourcePublications = source;
            InitializeComponent();
            FormClosing += SearchForm_FormClosing;
        }

        /// <summary>
        /// Метод обработки закрытия формы
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Параметры события</param>
        private void SearchForm_FormClosing(object? sender,
            FormClosingEventArgs e)
        {
            PublicationsSelected?.Invoke(this, _sourcePublications);
        }

        /// <summary>
        /// Метод для обработки кнопки поиска
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Параметры события</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var query = new
            {
                Title = TitleTextBox.Text?.Trim(),
                Year = YearTextBox.Text?.Trim(),
                Place = PlaceTextBox.Text?.Trim(),
                Publisher = PublisherTextBox.Text?.Trim()
            };

            if (IsEmptyQuery(query))
            {
                MessageBox.Show("Введите хотя бы одно значение для поиска.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var filtered = _sourcePublications.Where(publication =>
                Matches(publication.Title, query.Title) &&
                Matches(publication.Year.ToString(), query.Year) &&
                Matches(publication.Place, query.Place) &&
                Matches(publication.Publisher, query.Publisher)).ToList();

            PublicationsSelected?.Invoke(this, filtered);
        }

        /// <summary>
        /// Метод проверки запроса на пустые поля
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Булевое значение, true - если запрос пуст,
        /// иначе false</returns>
        private bool IsEmptyQuery(dynamic query)
        {
            return string.IsNullOrEmpty(query.Title) &&
                   string.IsNullOrEmpty(query.Year) &&
                   string.IsNullOrEmpty(query.Place) &&
                   string.IsNullOrEmpty(query.Publisher);
        }

        /// <summary>
        /// Метод проверки
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="query">Запрос</param>
        /// <returns>Булевое</returns>
        private bool Matches(string value, string query)
        {
            return string.IsNullOrEmpty(query) ||
                   value.Contains(query, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Метод обработки нажатия кнопки "Сбросить"
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            TitleTextBox.Clear();
            YearTextBox.Clear();
            PlaceTextBox.Clear();
            PublisherTextBox.Clear();
        }

        /// <summary>
        /// Метод обработки нажатия кнопки "Отмена"
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
        private void CancelSearchButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
