using LaboratoryThirdModel;

namespace View.Panels
{
    /// <summary>
    /// Класс для обработки панели издания сборника
    /// </summary>
    public partial class CollectionParameterPanel 
        : PublicationParameterPanelBase
    {
        /// <summary>
        /// Конструктор для панели сборника
        /// </summary>
        public CollectionParameterPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для очистки полей сборника
        /// </summary>
        public override void ClearValues()
        {
            EditorialBoardTextBox.Clear();
            ResponsibleEditorsTextBox.Clear();
        }

        /// <summary>
        /// Метод проверки полей сборника
        /// </summary>
        public override void ValidateFields()
        {
            ValidateTextBox(EditorialBoardTextBox,
                "редакционной коллегии");
            ValidateTextBox(ResponsibleEditorsTextBox,
                "ответственных редакторов");
        }

        /// <summary>
        /// Метод для создания экземпяра сборника
        /// </summary>
        /// <returns>Объект класса Collection</returns>
        public override PublicationBase CreatePublication()
        {
            return new Collection
            {
                EditorialBoard = EditorialBoardTextBox.Text,
                ResponsibleEditors = ResponsibleEditorsTextBox.Text
            };
        }

        /// <summary>
        /// Метод для случайного заполнения полей сборника
        /// </summary>
        /// <param name="random"></param>
        public override void FillRandomValue(Random random)
        {
            string[] editorialBoards = DataHelper.ReadFile
                ("editorial_boards.txt");

            string[] responsbileEditors = DataHelper.ReadFile
                ("responsible_editors.txt");

            EditorialBoardTextBox.Text =
                editorialBoards[random.Next(editorialBoards.Length)];

            ResponsibleEditorsTextBox.Text =
                responsbileEditors[random.Next(responsbileEditors.Length)];
        }
    }
}
