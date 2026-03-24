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
