using LaboratoryThirdModel;

namespace View.Panels
{
    public partial class BookParameterPanel : PublicationParameterPanel
    {
        private string[] _authors = Array.Empty<string>();

        private const string AuthorsFile = "authors.txt";

        public BookParameterPanel()
        {
            InitializeComponent();
        }
    
        public override void ClearValues()
        {
            AuthorsTextBox.Clear();
            AuthorsListBox.Items.Clear();
        }

        public override void FillRandomValue(Random random)
        {
            _authors = ReadFile(AuthorsFile);
            AuthorsListBox.Items.Clear();

            int authorCount = random.Next(6);

            for (int i = 0; i < authorCount; i++)
            {
                string author = _authors[random.Next(_authors.Length)];
                AuthorsListBox.Items.Add(author);
            }
        }

        public override PublicationBase CreatePublication()
        {
            var book = new Book();

            foreach (string author in AuthorsListBox.Items)
            {
                book.AddAuthors(author);
            }

            return book;
        }
            
        private void AuthorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string authorName = AuthorsTextBox.Text.Trim();
                {
                    AuthorsListBox.Items.Add(authorName);
                    AuthorsTextBox.Clear();
                }
            }
        }

        private void AuthorsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (AuthorsListBox.SelectedItems != null)
            {
                AuthorsListBox.Items.Remove(AuthorsListBox.SelectedItem);
            }
        }

        private static string[] ReadFile(string file,
            string defaultPath = "Data/")
        {
            string fullPath = Path.GetFullPath(Path.Combine(defaultPath, file));

            Console.Write(fullPath);
            if (!File.Exists(fullPath))
            {
                return Array.Empty<string>();
            }

            return File.ReadAllLines(fullPath)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();
        }
    }
}
