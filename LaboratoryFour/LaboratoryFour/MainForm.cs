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
            AddColumn("GostInformation", "Библиографическая запись", 404);
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

        /// <summary>
        /// Событие при нажатии кнопки добавления издания
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
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
                СallMessageBox("Выберите издание для удаления", "Ошибка");
            }
            else
            {
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
                        var itemTable = (PublicationBase)rowTable
                            .DataBoundItem;
                        itemsToRemove.Add(itemTable);
                    }

                    foreach (var itemTable in itemsToRemove)
                    {
                        _publications.Remove(itemTable);
                    }

                    RefreshDataGridView();
                }
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

        /// <summary>
        /// Метод обработки нажатия кнопки загрузки
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
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
                    _publications 
                        = PublicationSerializer.Load(dialog.FileName);
                    RefreshDataGridView();
                    СallMessageBox($"Загружено {_publications.Count}" +
                        $" изданий", "Уведомление");
                }
                catch (Exception ex)
                {
                    СallMessageBox(ex.Message, "Ошибка");
                }
            }
        }

        /// <summary>
        /// Метод обработки нажатия кнопки сохранения
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргументы события</param>
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
                    PublicationSerializer.Save(_publications, 
                        dialog.FileName);
                    СallMessageBox("Файл успешно сохранен", "Уведомление");
                }
                catch (Exception ex)
                {
                    СallMessageBox(ex.Message, "Ошибка");
                }
            }
        }

        //TODO: RSDN +
        /// <summary>
        /// Метод для вызова MessageBox
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="typeMessage">Тип сообщения</param>
        private void СallMessageBox(string message, string typeMessage)
        {
            switch (typeMessage)
            {
                case "Уведомление":
                {
                    MessageBox.Show(message, "Уведомление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                }
                case "Ошибка":
                {
                    MessageBox.Show($"Ошибка: {message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                }
            }
        }
    }
}
