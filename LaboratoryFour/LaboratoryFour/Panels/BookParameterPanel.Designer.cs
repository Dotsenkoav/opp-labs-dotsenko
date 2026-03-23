namespace View.Panels
{
    partial class BookParameterPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Текстовое поле для ввода авторов
        /// </summary>
        private TextBox AuthorsTextBox;

        /// <summary>
        /// Надпись для текстового поля для ввода авторов
        /// </summary>
        private Label LabelForAuthors;

        /// <summary>
        /// Список авторов
        /// </summary>
        private ListBox AuthorsListBox;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            AuthorsTextBox = new TextBox();
            LabelForAuthors = new Label();
            AuthorsListBox = new ListBox();
            SuspendLayout();
            // 
            // AuthorsTextBox
            // 
            AuthorsTextBox.BackColor = Color.FromArgb(38, 38, 38);
            AuthorsTextBox.BorderStyle = BorderStyle.FixedSingle;
            AuthorsTextBox.ForeColor = Color.White;
            AuthorsTextBox.Location = new Point(13, 34);
            AuthorsTextBox.Name = "AuthorsTextBox";
            AuthorsTextBox.PlaceholderText = "Введите автора и нажмите Enter";
            AuthorsTextBox.Size = new Size(301, 23);
            AuthorsTextBox.TabIndex = 17;
            AuthorsTextBox.KeyPress += AuthorTextBox_KeyPress;
            // 
            // LabelForAuthors
            // 
            LabelForAuthors.AutoSize = true;
            LabelForAuthors.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForAuthors.ForeColor = Color.White;
            LabelForAuthors.ImageAlign = ContentAlignment.TopLeft;
            LabelForAuthors.Location = new Point(13, 10);
            LabelForAuthors.Name = "LabelForAuthors";
            LabelForAuthors.Size = new Size(64, 21);
            LabelForAuthors.TabIndex = 18;
            LabelForAuthors.Text = "Авторы";
            // 
            // AuthorsListBox
            // 
            AuthorsListBox.BackColor = Color.FromArgb(38, 38, 38);
            AuthorsListBox.BorderStyle = BorderStyle.None;
            AuthorsListBox.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AuthorsListBox.ForeColor = Color.White;
            AuthorsListBox.FormattingEnabled = true;
            AuthorsListBox.Location = new Point(13, 72);
            AuthorsListBox.Name = "AuthorsListBox";
            AuthorsListBox.Size = new Size(301, 80);
            AuthorsListBox.TabIndex = 19;
            AuthorsListBox.DoubleClick += AuthorsListBox_DoubleClick;
            // 
            // BookParameterPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(AuthorsListBox);
            Controls.Add(AuthorsTextBox);
            Controls.Add(LabelForAuthors);
            Name = "BookParameterPanel";
            Size = new Size(330, 178);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
