using LaboratoryThirdModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using View.Panels;

namespace View
{
    /// <summary>
    /// Форма для добавления нового издания
    /// </summary>
    public partial class AddPublicationForm : Form
    {
        /// <summary>
        /// Событие создания публикации для связи с MainForm
        /// </summary>
        public event EventHandler<PublicationBase>? PublicationCreated;

        /// <summary>
        /// Текущая используемая панель
        /// </summary>
        private PublicationParameterPanelBase? _currentParameterPanel;

        /// <summary>
        /// Метод инициализации компонентов формы
        /// </summary>
        public AddPublicationForm()
        {
            InitializeComponent();

            PublicationsComboBox.SelectedIndexChanged += (s, e) => UpdateParameterPanel();

            UpdateParameterPanel();
        }

        /// <summary>
        /// Метод для обновления панели
        /// </summary>
        private void UpdateParameterPanel()
        {
            string? selectedType = PublicationsComboBox.SelectedItem?.ToString();
            if (selectedType == null) return;

            ParametersGroupBox.Controls.Clear();
            _currentParameterPanel?.Dispose();

            _currentParameterPanel = CreateParameterPanel(selectedType);

            if (_currentParameterPanel != null)
            {
                ParametersGroupBox.Controls.Add(_currentParameterPanel);
                _currentParameterPanel.Dock = DockStyle.Top;
            }
        }

        /// <summary>
        /// Создание экземпляра панели
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private PublicationParameterPanelBase? CreateParameterPanel(string type)
        {
            return type switch
            {
                "Книга" => new BookParameterPanel(),
                "Сборник" => new CollectionParameterPanel(),
                "Журнал" => new JournalParameterPanel(),
                "Диссертация" => new DissertationParameterPanel(),
                _ => null
            };
        }

        /// <summary>
        /// Метод обработки нажатия кнопки "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPublicationButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFormFields();

                var publication = _currentParameterPanel!.CreatePublication();

                FillCommonFields(publication);

                PublicationCreated?.Invoke(this, publication);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Валидация заполнения формы
        /// </summary>
        /// <exception cref="ArgumentException">Ошибка,
        /// если не выбран тип публикации</exception>
        private void ValidateFormFields()
        {
            if (PublicationsComboBox.SelectedItem == null)
            {
                throw new ArgumentException("Выберите тип публикации");
            }

            string selectedType = PublicationsComboBox.SelectedItem.ToString();

            ValidateRequired(TitleTextBox.Text, "название издания");
            ValidateYear(YearTextBox.Text);
            ValidateRequired(PlaceTextBox.Text, "место издания");
            ValidateRequired(PublisherTextBox.Text, "издательство");
            ValidatePositiveInt(TotalPagesTextBox.Text, "Количество страниц");

        }


        /// <summary>
        /// Валидация полей, где требуются значения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="fieldName">Имя поля</param>
        /// <exception cref="ArgumentException">Ошибка,
        /// при пустом вводе</exception>
        private void ValidateRequired(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Введите {fieldName}");
            }
        }

        /// <summary>
        /// Валидация введенного года
        /// </summary>
        /// <param name="yearText">Год</param>
        /// <exception cref="ArgumentException">Ошибка,
        /// при некорректном вводе года</exception>
        private void ValidateYear(string yearText)
        {
            if (!int.TryParse(yearText, out int year) || year < 868 || year > DateTime.Now.Year)
            {
                throw new ArgumentException("Некорректный год издания (от 868 до текущего)");
            }
        }

        /// <summary>
        /// Валидация на положительные числа
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="fieldName">Название поля</param>
        /// <exception cref="ArgumentException">Ошибка,
        /// если число не положительное</exception>
        private void ValidatePositiveInt(string value, string fieldName)
        {
            if (!int.TryParse(value, out int intValue) || intValue <= 0)
            {
                throw new ArgumentException($"{fieldName} должно быть положительным числом");
            }
        }

        /// <summary>
        /// Метод заполнения полей класса из формы
        /// </summary>
        /// <param name="publication">Объект для заполнения</param>
        private void FillCommonFields(PublicationBase publication)
        {
            publication.Title = TitleTextBox.Text.Trim();
            publication.TitleInformation =
                TitleInformationTextBox.Text.Trim();
            publication.Year = int.Parse(YearTextBox.Text);
            publication.Place = PlaceTextBox.Text.Trim();
            publication.Publisher = PublisherTextBox.Text.Trim();
            publication.TotalPages = int.Parse(TotalPagesTextBox.Text);
        }

        private void FillRandomFields(Random random)
        {
            string[] titles = DataHelper.ReadFile("titles.txt");
            string[] places = DataHelper.ReadFile("places.txt");
            string[] publishers = DataHelper.ReadFile("publishers.txt");
            string[] titleInformations = DataHelper.ReadFile("titleInformations.txt");

            TitleTextBox.Text = titles[random.Next(titles.Length)];

            TitleInformationTextBox.Text = titleInformations[random.Next(titleInformations.Length)];

            PlaceTextBox.Text = places[random.Next(places.Length)];

            PublisherTextBox.Text = publishers[random.Next(publishers.Length)];

            //Const
            YearTextBox.Text = random.Next(2000, DateTime.Now.Year + 1).ToString();

            TotalPagesTextBox.Text = random.Next(50, 500).ToString();
        }

        private void RandomPublicationButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            if (_currentParameterPanel != null)
            {
                FillRandomFields(random);
                UpdateParameterPanel();
                _currentParameterPanel.FillRandomValue(random);
            }
            // Переделать
            else
            {
                throw new Exception("Сначала выберите тип издания");
            }
        }

        private void AddFormGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
