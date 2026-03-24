using LaboratoryThirdModel;

namespace View
{
    /// <summary>
    /// Главная форма для управления библиотекой изданий
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список изданий
        /// </summary>
        private List<IPublication> _publications = new List<IPublication>();

        /// <summary>
        /// Инициализация главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        /// <summary>
        /// Метод для инициализации DataGridView
        /// </summary>
        private void InitializeDataGridView()
        {
            PublicationsDataGridView.AutoGenerateColumns = false;
            PublicationsDataGridView.ForeColor = Color.Black;

            AddColumn("Title", "Название", 200);
            AddColumn("Year", "Год", 60);
            AddColumn("Place", "Место издания", 120);
            AddColumn("Publisher", "Издательство", 150);
            AddColumn("TotalPages", "Стр.", 50);
            AddColumn("GostInformation", "Библиографическая запись", 300);
        }

        /// <summary>
        /// Метод фабрика для колонок 
        /// </summary>
        /// <param name="propertyName">Название свойства</param>
        /// <param name="headerText">Заголовок колонки</param>
        /// <param name="width">Ширина колонки</param>
        private void AddColumn(string propertyName, string headerText, int width)
        {
            PublicationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Width = width,
                ReadOnly = true
            });
        }

        private void AddPublicationsButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddPublicationForm();
            addForm.PublicationCreated += OnPublicationCreated;
            addForm.ShowDialog();
        }

        private void OnPublicationCreated(object? sender, PublicationBase publication)
        {
            if (publication != null)
            {
                _publications.Add(publication);
                RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            PublicationsDataGridView.DataSource = null;
            PublicationsDataGridView.DataSource = _publications;
        }
    }
}
