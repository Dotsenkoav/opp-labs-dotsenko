using LaboratoryThirdModel;
using System.Text.RegularExpressions;

namespace View.Panels
{
    /// <summary>
    /// Класс, для обработки панели издания книг
    /// </summary>
    public partial class BookParameterPanel 
        : PublicationParameterPanelBase
    {
        /// <summary>
        /// Конструктор для панели книги
        /// </summary>
        public BookParameterPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для очистки полей панели книги
        /// </summary>
        public override void ClearValues()
        {
            AuthorsTextBox.Clear();
            AuthorsListBox.Items.Clear();
        }

        /// <summary>
        /// Метод для валидации количества авторов
        /// </summary>
        /// <exception cref="ArgumentException">Ошибка,
        /// если нет авторов</exception>
        public override void ValidateFields()
        {
            ValidateListBox(AuthorsListBox, "авторов");
        }

        /// <summary>
        /// Метод для создания издания книги
        /// </summary>
        /// <returns>Объект класса Book</returns>
        public override PublicationBase CreatePublication()
        {
            var book = new Book();

            foreach (string author in AuthorsListBox.Items)
            {
                book.AddAuthors(author);
            }

            return book;
        }
        
        /// <summary>
        /// Метод для обработки нажатия клавиши Enter поля авторов
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргумент события</param>
        private void AuthorTextBox_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string authorName = AuthorsTextBox.Text.Trim();
                
                if (IsValidAuthor(authorName))
                {
                    AuthorsListBox.Items.Add(authorName);
                    AuthorsTextBox.Clear();
                }
            }
        }

        /// <summary>
        /// Метод для обработки двойного нажатия на элемент списка
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие</param>
        /// <param name="e">Аргумент события</param>
        private void AuthorsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (AuthorsListBox.SelectedItem != null)
            {
                AuthorsListBox.Items.Remove(AuthorsListBox.SelectedItem);
            }
        }

        #if DEBUG
        /// <summary>
        /// Метод для случайного заполнения полей книги
        /// </summary>
        /// <param name="random">Объект класса Random</param>
        public override void FillRandomValue(Random random)
        {
            const int MinimumRandomAuthors = 1;
            const int MaximumRandomAuthors = 6;

            string[] authors = DataHelper.ReadFile("authors.txt");

            AuthorsListBox.Items.Clear();

            int authorCount = random.Next(MinimumRandomAuthors,
                MaximumRandomAuthors);

            for (int i = 0; i < authorCount; i++)
            {
                string author = authors[random.Next(authors.Length)];
                AuthorsListBox.Items.Add(author);
            }
        }
        #endif

        /// <summary>
        /// Метод валидации ввода автора
        /// </summary>
        /// <param name="author">Автор</param>
        /// <returns>булевое значение, true - если соответствует формату,
        /// иначе false</returns>
        private bool IsValidAuthor(string author)
        {
            var pattern =
                new Regex(@"^[А-Яа-яёЁ]+\s+[А-Яа-яёЁ]\.([А-Яа-яёЁ]\.)?$");

            if (!pattern.IsMatch(author))
            {
                ShowWarning("Используйте формат:" +
                    " Фамилия И.О.\nПример: Иванов И.И.");
                return false;
            }
            return true;
        }
    }
}
