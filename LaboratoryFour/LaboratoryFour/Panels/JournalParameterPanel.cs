using LaboratoryThirdModel;

namespace View.Panels
{
    /// <summary>
    /// Класс для обработки панели издания журнала
    /// </summary>
    public partial class JournalParameterPanel 
        : PublicationParameterPanelBase
    {
        /// <summary>
        /// Конструктор для панели журнала
        /// </summary>
        public JournalParameterPanel()
        {
            InitializeComponent();
            FrequencyComboBox.Items.AddRange(Journal.PossibleFrequencies);
        }
        
        /// <summary>
        /// Метод для очистки полей панели журнала
        /// </summary>
        public override void ClearValues()
        {
            FrequencyComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Метод проверки полей журнала
        /// </summary>
        public override void ValidateFields()
        {
            ValidateComboBox(FrequencyComboBox, "частоту издания");
        }

        /// <summary>
        /// Метод для создания издания журнала
        /// </summary>
        /// <returns>Объект класса Journal</returns>
        public override PublicationBase CreatePublication()
        {
            return new Journal
            {
                Frequency = FrequencyComboBox.Text
            };
        }

        /// <summary>
        /// Метод для случайного заполнения полей журнала
        /// </summary>
        /// <param name="random">Объект класса Random</param>
        public override void FillRandomValue(Random random)
        {
            FrequencyComboBox.SelectedIndex =
                random.Next(Journal.PossibleFrequencies.Length);
        }
    }
}
