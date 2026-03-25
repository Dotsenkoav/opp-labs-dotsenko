using LaboratoryThirdModel;

namespace View.Panels
{
    /// <summary>
    /// Абстрактный класс для панели параметров изданий
    /// </summary>
    public abstract partial class PublicationParameterPanelBase : UserControl
    {
        /// <summary>
        /// Конструктор базового класса панели параметров изданий
        /// </summary>
        public PublicationParameterPanelBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Абстрактный метод очистки значений параметров
        /// </summary>
        public abstract void ClearValues();

        /// <summary>
        /// Абстрактный метод заполнения параметров случайными значениями
        /// </summary>
        /// <param name="random">Экземпляр класса Random</param>
        public abstract void FillRandomValue(Random random);

        /// <summary>
        /// Абстрактный метод создания издания
        /// </summary>
        /// <returns>Объект класса издания</returns>
        public abstract PublicationBase CreatePublication();

        /// <summary>
        /// Абстрактный метод для валидации полей параметров
        /// </summary>
        public abstract void ValidateFields();

        /// <summary>
        /// Метод проверки текстбоксов
        /// </summary>
        /// <param name="textBox">Значение</param>
        /// <param name="propertyName">название поля</param>
        /// <exception cref="ArgumentException">Ошибка,
        /// при пустом поле</exception>
        protected void ValidateTextBox(TextBox textBox, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                throw new ArgumentException($"Поле {propertyName} " +
                    $"не может быть пустым");
            }
        }

        /// <summary>
        /// Метод валидации ComboBox
        /// </summary>
        /// <param name="comboBox">Объект ComboBox</param>
        /// <param name="propertyName">Название ComboBox</param>
        /// <exception cref="ArgumentException">Ошибка,
        /// если не выбран элемент ComboBox</exception>
        protected void ValidateComboBox(ComboBox comboBox,
            string propertyName)
        {
            if (comboBox.SelectedIndex == -1)
            {
                throw new ArgumentException($"Выберите {propertyName}");
            }
        }

        /// <summary>
        /// Метод валидации ListBox
        /// </summary>
        /// <param name="listBox">Объект ListBox</param>
        /// <param name="propertyName">Название ListBox</param>
        /// <exception cref="ArgumentException">Ошибка,
        /// если ListBox пуст</exception>
        protected void ValidateListBox(ListBox listBox,
            string propertyName)
        {
            if (listBox.Items.Count == 0)
            {
                throw new ArgumentException($"Выберите {propertyName}");
            }
        }

        /// <summary>
        /// Метод для отображения предупреждения
        /// </summary>
        /// <param name="message"></param>
        protected void ShowWarning(string message)
        {
            MessageBox.Show(message, "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
