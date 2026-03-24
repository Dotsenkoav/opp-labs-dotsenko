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

        public override void ValidateFields()
        {

        }

        /// <summary>
        /// Метод для создания экземпяра сборника
        /// </summary>
        /// <returns>Объект класса Collection</returns>
        public override PublicationBase CreatePublication()
        {
            var collection = new Collection();

            return collection;
        }

        /// <summary>
        /// Метод для случайного заполнения полей сборника
        /// </summary>
        /// <param name="random"></param>
        public override void FillRandomValue(Random random)
        {

        }
    }
}
