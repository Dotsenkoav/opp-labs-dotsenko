using LaboratoryThirdModel;
using View.Services;

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

            PublicationsDataGridView.Columns.Clear();

            AddColumn("Title", "Название", 200);
            AddColumn("Year", "Год", 60);
            AddColumn("Place", "Место издания", 120);
            AddColumn("Publisher", "Издательство", 150);
            AddColumn("TotalPages", "Стр.", 100);
            AddColumn("GostInformation", "Библиографическая запись", 418);
        }

        /// <summary>
        /// Метод фабрика для колонок 
        /// </summary>
        /// <param name="propertyName">Название свойства</param>
        /// <param name="headerText">Заголовок колонки</param>
        /// <param name="width">Ширина колонки</param>
        private void AddColumn(string propertyName,
            string headerText, int width)
        {
            PublicationsDataGridView.Columns.Add(
                new DataGridViewTextBoxColumn
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

        /// <summary>
        /// Метод добавления издания
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="publication">Объект издания</param>
        private void OnPublicationCreated(object? sender,
            PublicationBase publication)
        {
            if (publication != null)
            {
                _publications.Add(publication);
                RefreshDataGridView();
            }
        }

        /// <summary>
        /// Метод перезагрузки информации в таблице
        /// </summary>
        private void RefreshDataGridView()
        {
            PublicationsDataGridView.DataSource = null;
            PublicationsDataGridView.DataSource = _publications;
        }

        /// <summary>
        /// Метод обработки нажатия кнопки "Удалить"
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
        private void RemovePublicationButton_Click(object sender,
            EventArgs e)
        {
            RemoveSelectedPublications();
        }

        /// <summary>
        /// Метод удаления выбранных публикаций
        /// </summary>
        private void RemoveSelectedPublications()
        {
            int countChooseElement
                = PublicationsDataGridView.SelectedRows.Count;

            if (countChooseElement == 0)
            {
                MessageBox.Show("Выберите издания для удаления",
                    "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить " +
                $"{countChooseElement} выбранных изданий?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var itemsToRemove = new List<PublicationBase>();

                foreach (DataGridViewRow rowTable
                    in PublicationsDataGridView.SelectedRows)
                {
                    var itemTable = (PublicationBase)rowTable.DataBoundItem;
                    itemsToRemove.Add(itemTable);
                }

                foreach (var itemTable in itemsToRemove)
                {
                    _publications.Remove(itemTable);
                }

                RefreshDataGridView();
            }
        }

        /// <summary>
        /// Метод обработки нажатия кнопки "Поиск"
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchPublicationForm(_publications);

            searchForm.PublicationsSelected += (s, filteredList) =>
            {
                PublicationsDataGridView.DataSource = null;
                PublicationsDataGridView.DataSource = filteredList;
            };
            searchForm.ShowDialog();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Библиотечные файлы (*.lib)|*.lib",
                DefaultExt = "lib"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _publications = PublicationSerializer.Load(dialog.FileName);
                    RefreshDataGridView();
                    MessageBox.Show($"Загружено {_publications.Count} изданий.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Библиотечные файлы (*.lib)|*.lib",
                DefaultExt = "lib"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PublicationSerializer.Save(_publications, dialog.FileName);
                    MessageBox.Show("Сохранено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
