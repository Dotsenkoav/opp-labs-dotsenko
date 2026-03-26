namespace View
{
    /// <summary>
    /// Класс для формы поиска издания
    /// </summary>
    partial class SearchPublicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Кнопки отмены поиска
        /// </summary>
        private Button CancelSearchButton;

        /// <summary>
        /// Кнопка поиска
        /// </summary>
        private Button SearchButton;

        /// <summary>
        /// Кнопка сброса фильтра
        /// </summary>
        private Button ResetButton;

        /// <summary>
        /// Контейнер для полей поиска
        /// </summary>
        private GroupBox SearchParametersGroupBox;

        /// <summary>
        /// Текстовое поле для названия
        /// </summary>
        private TextBox TitleTextBox;

        /// <summary>
        /// Текстовое поле для издательства
        /// </summary>
        private TextBox PublisherTextBox;

        /// <summary>
        /// Текстовое поле для места издательства
        /// </summary>
        private TextBox PlaceTextBox;

        /// <summary>
        /// Текстовое поле для года издания
        /// </summary>
        private TextBox YearTextBox;

        /// <summary>
        /// Надпись для ввода издательства
        /// </summary>
        private Label LabelForPublisher;

        /// <summary>
        /// Надпись для ввода места издательства
        /// </summary>
        private Label LabelForPlace;

        /// <summary>
        /// Надпись для года издания
        /// </summary>
        private Label LabelForYear;

        /// <summary>
        /// Надпись для названия
        /// </summary>
        private Label LabelForTitle;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should
        /// be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources 
                = new System.ComponentModel.ComponentResourceManager
                (typeof(SearchPublicationForm));
            CancelSearchButton = new Button();
            SearchButton = new Button();
            ResetButton = new Button();
            SearchParametersGroupBox = new GroupBox();
            LabelForPublisher = new Label();
            LabelForPlace = new Label();
            LabelForYear = new Label();
            LabelForTitle = new Label();
            PublisherTextBox = new TextBox();
            PlaceTextBox = new TextBox();
            YearTextBox = new TextBox();
            TitleTextBox = new TextBox();
            SearchParametersGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CancelSearchButton
            // 
            CancelSearchButton.BackColor = Color.FromArgb(39, 174, 96);
            CancelSearchButton.Cursor = Cursors.Hand;
            CancelSearchButton.FlatAppearance.BorderColor 
                = Color.FromArgb(64, 64, 64);
            CancelSearchButton.FlatStyle = FlatStyle.Flat;
            CancelSearchButton.Font = new Font("Leelawadee", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelSearchButton.ForeColor = Color.Transparent;
            CancelSearchButton.Location = new Point(215, 339);
            CancelSearchButton.Name = "CancelSearchButton";
            CancelSearchButton.Size = new Size(127, 30);
            CancelSearchButton.TabIndex = 3;
            CancelSearchButton.Text = "Отмена";
            CancelSearchButton.UseVisualStyleBackColor = false;
            CancelSearchButton.Click += CancelSearchButton_Click;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(39, 174, 96);
            SearchButton.Cursor = Cursors.Hand;
            SearchButton.FlatAppearance.BorderColor 
                = Color.FromArgb(64, 64, 64);
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Font = new Font("Leelawadee", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchButton.ForeColor = Color.Transparent;
            SearchButton.Location = new Point(12, 292);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(330, 30);
            SearchButton.TabIndex = 4;
            SearchButton.Text = "Поиск издания";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.BackColor = Color.FromArgb(39, 174, 96);
            ResetButton.Cursor = Cursors.Hand;
            ResetButton.FlatAppearance.BorderColor 
                = Color.FromArgb(64, 64, 64);
            ResetButton.FlatStyle = FlatStyle.Flat;
            ResetButton.Font = new Font("Leelawadee", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            ResetButton.ForeColor = Color.Transparent;
            ResetButton.Location = new Point(12, 339);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(127, 30);
            ResetButton.TabIndex = 5;
            ResetButton.Text = "Сброс";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // SearchParametersGroupBox
            // 
            SearchParametersGroupBox.Controls.Add(LabelForPublisher);
            SearchParametersGroupBox.Controls.Add(LabelForPlace);
            SearchParametersGroupBox.Controls.Add(LabelForYear);
            SearchParametersGroupBox.Controls.Add(LabelForTitle);
            SearchParametersGroupBox.Controls.Add(PublisherTextBox);
            SearchParametersGroupBox.Controls.Add(PlaceTextBox);
            SearchParametersGroupBox.Controls.Add(YearTextBox);
            SearchParametersGroupBox.Controls.Add(TitleTextBox);
            SearchParametersGroupBox.Font = new Font("Segoe UI Semibold",
                9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            SearchParametersGroupBox.ForeColor = Color.White;
            SearchParametersGroupBox.Location = new Point(12, 18);
            SearchParametersGroupBox.Name = "SearchParametersGroupBox";
            SearchParametersGroupBox.Size = new Size(330, 258);
            SearchParametersGroupBox.TabIndex = 6;
            SearchParametersGroupBox.TabStop = false;
            SearchParametersGroupBox.Text = "Параметры поиска";
            // 
            // LabelForPublisher
            // 
            LabelForPublisher.AutoSize = true;
            LabelForPublisher.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelForPublisher.ForeColor = Color.White;
            LabelForPublisher.Location = new Point(17, 178);
            LabelForPublisher.Name = "LabelForPublisher";
            LabelForPublisher.Size = new Size(118, 21);
            LabelForPublisher.TabIndex = 10;
            LabelForPublisher.Text = "Издательство";
            // 
            // LabelForPlace
            // 
            LabelForPlace.AutoSize = true;
            LabelForPlace.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelForPlace.ForeColor = Color.White;
            LabelForPlace.Location = new Point(17, 128);
            LabelForPlace.Name = "LabelForPlace";
            LabelForPlace.Size = new Size(136, 21);
            LabelForPlace.TabIndex = 9;
            LabelForPlace.Text = "Место издания:";
            // 
            // LabelForYear
            // 
            LabelForYear.AutoSize = true;
            LabelForYear.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelForYear.ForeColor = Color.White;
            LabelForYear.Location = new Point(17, 78);
            LabelForYear.Name = "LabelForYear";
            LabelForYear.Size = new Size(46, 21);
            LabelForYear.TabIndex = 8;
            LabelForYear.Text = "Год:";
            // 
            // LabelForTitle
            // 
            LabelForTitle.AutoSize = true;
            LabelForTitle.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelForTitle.ForeColor = Color.White;
            LabelForTitle.Location = new Point(17, 28);
            LabelForTitle.Name = "LabelForTitle";
            LabelForTitle.Size = new Size(91, 21);
            LabelForTitle.TabIndex = 7;
            LabelForTitle.Text = "Название:";
            // 
            // PublisherTextBox
            // 
            PublisherTextBox.BackColor = Color.FromArgb(38, 38, 38);
            PublisherTextBox.BorderStyle = BorderStyle.FixedSingle;
            PublisherTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            PublisherTextBox.ForeColor = Color.White;
            PublisherTextBox.Location = new Point(17, 202);
            PublisherTextBox.Name = "PublisherTextBox";
            PublisherTextBox.PlaceholderText = "Введите название...";
            PublisherTextBox.Size = new Size(290, 23);
            PublisherTextBox.TabIndex = 6;
            // 
            // PlaceTextBox
            // 
            PlaceTextBox.BackColor = Color.FromArgb(38, 38, 38);
            PlaceTextBox.BorderStyle = BorderStyle.FixedSingle;
            PlaceTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            PlaceTextBox.ForeColor = Color.White;
            PlaceTextBox.Location = new Point(17, 152);
            PlaceTextBox.Name = "PlaceTextBox";
            PlaceTextBox.PlaceholderText = "Введите название...";
            PlaceTextBox.Size = new Size(290, 23);
            PlaceTextBox.TabIndex = 5;
            // 
            // YearTextBox
            // 
            YearTextBox.BackColor = Color.FromArgb(38, 38, 38);
            YearTextBox.BorderStyle = BorderStyle.FixedSingle;
            YearTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            YearTextBox.ForeColor = Color.White;
            YearTextBox.Location = new Point(17, 102);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.PlaceholderText = "Введите название...";
            YearTextBox.Size = new Size(290, 23);
            YearTextBox.TabIndex = 4;
            // 
            // TitleTextBox
            // 
            TitleTextBox.BackColor = Color.FromArgb(38, 38, 38);
            TitleTextBox.BorderStyle = BorderStyle.FixedSingle;
            TitleTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            TitleTextBox.ForeColor = Color.White;
            TitleTextBox.Location = new Point(17, 52);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.PlaceholderText = "Название для поиска";
            TitleTextBox.Size = new Size(290, 23);
            TitleTextBox.TabIndex = 3;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(356, 379);
            Controls.Add(SearchParametersGroupBox);
            Controls.Add(ResetButton);
            Controls.Add(SearchButton);
            Controls.Add(CancelSearchButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SearchForm";
            Text = "Поиск издания";
            SearchParametersGroupBox.ResumeLayout(false);
            SearchParametersGroupBox.PerformLayout();
            ResumeLayout(false);
        }
    }
}