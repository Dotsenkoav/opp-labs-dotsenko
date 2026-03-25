using LaboratoryThirdModel;
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
            FillPublicationComboBox();
            PublicationsComboBox.SelectedIndexChanged += (s, e)
                => UpdateParameterPanel();
            UpdateParameterPanel();
        }

        /// <summary>
        /// Метод заполнения типов публикации
        /// </summary>
        private void FillPublicationComboBox()
        {
            PublicationsComboBox.Items.AddRange(new object[]
            { "Книга", "Сборник", "Журнал", "Диссертация" });
        }

        /// <summary>
        /// Метод для обновления панели
        /// </summary>
        private void UpdateParameterPanel()
        {
            string? selectedType
                = PublicationsComboBox.SelectedItem?.ToString();
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
        /// <param name="typePublication">Тип публикации</param>
        /// <returns>Панель требуемого типа</returns>
        private PublicationParameterPanelBase? CreateParameterPanel
            (string typePublication)
        {
            switch (typePublication)
            {
                case "Книга":
                {
                    return new BookParameterPanel();
                }
                case "Сборник":
                {
                    return new CollectionParameterPanel();
                }
                case "Журнал":
                {
                    return new JournalParameterPanel();
                }
                case "Диссертация":
                {
                    return new DissertationParameterPanel();
                }
                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод обработки нажатия кнопки "ОК"
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Параметры события</param>
        private void AddPublicationButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFormFields();
                _currentParameterPanel!.ValidateFields();

                var publication
                    = _currentParameterPanel!.CreatePublication();
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
        /// Метод обработки события случайной генерации издания
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Параметры события</param>
        /// <exception cref="Exception"></exception>
        private void RandomPublicationButton_Click(object sender,
            EventArgs e)
        {
            if (_currentParameterPanel == null)
            {
                MessageBox.Show("Сначала выберите тип издания",
                    "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var random = new Random();

            FillRandomFields(random);
            _currentParameterPanel.FillRandomValue(random);
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
                throw new ArgumentException("Выберите тип издания");
            }

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
            if (!int.TryParse(yearText, out int year)
                || year < PublicationBase.MinYear
                || year > DateTime.Now.Year)
            {
                throw new ArgumentException($"Некорректный год издания" +
                    $" (введите от {PublicationBase.MinYear} до текущего)");
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
                throw new ArgumentException($"{fieldName}" +
                    $" должно быть положительным числом");
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

        /// <summary>
        /// Метод заполнения случайными данными базовых полей
        /// </summary>
        /// <param name="random">Объект класса Random</param>
        private void FillRandomFields(Random random)
        {
            const int MinimalRandomPages = 50;
            const int MaximumRandomPages = 1000;

            string[] titles = DataHelper.ReadFile("titles.txt");
            string[] places = DataHelper.ReadFile("places.txt");
            string[] publishers = DataHelper.ReadFile("publishers.txt");
            string[] titleInformations 
                = DataHelper.ReadFile("titleInformations.txt");

            TitleTextBox.Text = titles[random.Next(titles.Length)];
            TitleInformationTextBox.Text 
                = titleInformations[random.Next(titleInformations.Length)];
            PlaceTextBox.Text = places[random.Next(places.Length)];
            PublisherTextBox.Text 
                = publishers[random.Next(publishers.Length)];

            YearTextBox.Text = random.Next(PublicationBase.MinYear,
                DateTime.Now.Year + 1).ToString();

            TotalPagesTextBox.Text = random.Next(MinimalRandomPages,
                MaximumRandomPages).ToString();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Параметры события</param>
        private void CancelPublicationButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
