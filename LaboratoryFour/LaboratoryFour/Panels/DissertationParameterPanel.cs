using LaboratoryThirdModel;

namespace View.Panels
{
    /// <summary>
    /// Класс для обработки панели издания диссертации
    /// </summary>
    public partial class DissertationParameterPanel 
        : PublicationParameterPanelBase
    {
        /// <summary>
        /// Конструктор для панели диссертации
        /// </summary>
        public DissertationParameterPanel()
        {
            InitializeComponent();
            FillComboBox();
        }

        /// <summary>
        /// Метод заполнения выпадающего списка ученой степени
        /// </summary>
        private void FillComboBox()
        {
            DegreeComboBox.Items.AddRange(Dissertation.PossibleDegree);
        }

        /// <summary>
        /// Метод для очистки полей диссертации
        /// </summary>
        public override void ClearValues()
        {
            SpecialityTextBox.Clear();
            AuthorTextBox.Clear();
            DegreeComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Метод для валидации полей диссертации
        /// </summary>
        public override void ValidateFields()
        {
            ValidateTextBox(SpecialityTextBox, "специальности");
            ValidateTextBox(AuthorTextBox, "автора");
            ValidateComboBox(DegreeComboBox, "ученую степень");
        }

        /// <summary>
        /// Метод создания публикации
        /// </summary>
        /// <returns>Объект класса Dissertation</returns>
        public override PublicationBase CreatePublication()
        {
            return new Dissertation
            {
                AuthorFull = AuthorTextBox.Text,
                Speciality = SpecialityTextBox.Text,
                Degree = DegreeComboBox.Text
            };
        }

        /// <summary>
        /// Метод случайного заполнения полей диссертации
        /// </summary>
        /// <param name="random">Объект класса Random</param>
        public override void FillRandomValue(Random random)
        {
            string[] authorsDissertation =
                DataHelper.ReadFile("authors_dissertation.txt");

            string[] specialities =
                DataHelper.ReadFile("specialities.txt");

            AuthorTextBox.Text =
                authorsDissertation[random.Next(authorsDissertation.Length)];

            SpecialityTextBox.Text =
                specialities[random.Next(specialities.Length)];

            DegreeComboBox.SelectedIndex =
                random.Next(DegreeComboBox.Items.Count);
        }
    }
}
