using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма для добавления нового издания
    /// </summary>
    partial class AddPublicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Общий контейнер для ввода
        /// </summary>
        private GroupBox AddFormGroupBox;

        /// <summary>
        /// Выпадающий список выбора издания
        /// </summary>
        private ComboBox PublicationsComboBox;

        /// <summary>
        /// Надпись для выбора издания
        /// </summary>
        private Label LabelForChoosePublication;

        /// <summary>
        /// Надпись для поля ввода названия
        /// </summary>
        private Label LabelForTitle;

        /// <summary>
        /// Текстовое поле для названия
        /// </summary>
        private TextBox TitleTextBox;

        /// <summary>
        /// Надпись для поля ввода года
        /// </summary>
        private Label LabelForYear;

        /// <summary>
        /// Текстовое поле для ввода места издания
        /// </summary>
        private TextBox PlaceTextBox;

        /// <summary>
        /// Текстовое поле для ввода года
        /// </summary>
        private TextBox YearTextBox;

        /// <summary>
        /// Кнопка для добавления публикации
        /// </summary>
        private Button AddPublicationButton;

        /// <summary>
        /// Надпись для сведений о заглавии
        /// </summary>
        private Label LabelForTitleInformation;

        /// <summary>
        /// Текстовое поле для сведений о заглавии
        /// </summary>
        private TextBox TitleInformationTextBox;

        /// <summary>
        /// Надпись для ввода издательства
        /// </summary>
        private Label LabelForPublisher;

        /// <summary>
        /// Текстовое поле для ввода издательства
        /// </summary>
        private TextBox PublisherTextBox;

        /// <summary>
        /// Надпись для места издательства
        /// </summary>
        private Label LabelForPlace;

        /// <summary>
        /// Надпись для ввода количества страниц
        /// </summary>
        private Label LabelForTotalPages;

        /// <summary>
        /// Текстовое поле количества страница
        /// </summary>
        private TextBox TotalPagesTextBox;

        /// <summary>
        /// Контейнер для параметров конкретного издания
        /// </summary>
        private GroupBox ParametersGroupBox;

        /// <summary>
        /// Кнопка отмена добавления издания
        /// </summary>
        private Button CancelPublicationButton;

        /// <summary>
        /// Кнопка рандомной генерации издания
        /// </summary>
        private Button RandomPublicationButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources
        /// should be disposed; otherwise, false.</param>
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
                = new System.ComponentModel
                .ComponentResourceManager(typeof(AddPublicationForm));
            AddFormGroupBox = new GroupBox();
            ParametersGroupBox = new GroupBox();
            TotalPagesTextBox = new TextBox();
            LabelForTotalPages = new Label();
            LabelForPublisher = new Label();
            PublisherTextBox = new TextBox();
            LabelForPlace = new Label();
            LabelForTitleInformation = new Label();
            TitleInformationTextBox = new TextBox();
            LabelForYear = new Label();
            PlaceTextBox = new TextBox();
            YearTextBox = new TextBox();
            LabelForTitle = new Label();
            TitleTextBox = new TextBox();
            LabelForChoosePublication = new Label();
            PublicationsComboBox = new ComboBox();
            AddPublicationButton = new Button();
            CancelPublicationButton = new Button();
            RandomPublicationButton = new Button();
            AddFormGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // AddFormGroupBox
            // 
            AddFormGroupBox.BackColor = Color.FromArgb(30, 30, 30);
            AddFormGroupBox.Controls.Add(ParametersGroupBox);
            AddFormGroupBox.Controls.Add(TotalPagesTextBox);
            AddFormGroupBox.Controls.Add(LabelForTotalPages);
            AddFormGroupBox.Controls.Add(LabelForPublisher);
            AddFormGroupBox.Controls.Add(PublisherTextBox);
            AddFormGroupBox.Controls.Add(LabelForPlace);
            AddFormGroupBox.Controls.Add(LabelForTitleInformation);
            AddFormGroupBox.Controls.Add(TitleInformationTextBox);
            AddFormGroupBox.Controls.Add(LabelForYear);
            AddFormGroupBox.Controls.Add(PlaceTextBox);
            AddFormGroupBox.Controls.Add(YearTextBox);
            AddFormGroupBox.Controls.Add(LabelForTitle);
            AddFormGroupBox.Controls.Add(TitleTextBox);
            AddFormGroupBox.Controls.Add(LabelForChoosePublication);
            AddFormGroupBox.Controls.Add(PublicationsComboBox);
            AddFormGroupBox.FlatStyle = FlatStyle.Flat;
            AddFormGroupBox.Location = new Point(12, 12);
            AddFormGroupBox.Name = "AddFormGroupBox";
            AddFormGroupBox.Size = new Size(342, 605);
            AddFormGroupBox.TabIndex = 0;
            AddFormGroupBox.TabStop = false;
            // 
            // ParametersGroupBox
            // 
            ParametersGroupBox.Font = new Font("Cascadia Code", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            ParametersGroupBox.ForeColor = Color.White;
            ParametersGroupBox.Location = new Point(6, 395);
            ParametersGroupBox.Name = "ParametersGroupBox";
            ParametersGroupBox.Padding = new Padding(0);
            ParametersGroupBox.Size = new Size(330, 204);
            ParametersGroupBox.TabIndex = 18;
            ParametersGroupBox.TabStop = false;
            ParametersGroupBox.Text = "Параметры издания";
            // 
            // TotalPagesTextBox
            // 
            TotalPagesTextBox.BackColor = Color.FromArgb(38, 38, 38);
            TotalPagesTextBox.BorderStyle = BorderStyle.FixedSingle;
            TotalPagesTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            TotalPagesTextBox.ForeColor = Color.White;
            TotalPagesTextBox.Location = new Point(17, 355);
            TotalPagesTextBox.Name = "TotalPagesTextBox";
            TotalPagesTextBox.PlaceholderText = "Введите кол-во страниц...";
            TotalPagesTextBox.Size = new Size(301, 23);
            TotalPagesTextBox.TabIndex = 14;
            // 
            // LabelForTotalPages
            // 
            LabelForTotalPages.AutoSize = true;
            LabelForTotalPages.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForTotalPages.ForeColor = Color.White;
            LabelForTotalPages.ImageAlign = ContentAlignment.TopLeft;
            LabelForTotalPages.Location = new Point(17, 331);
            LabelForTotalPages.Name = "LabelForTotalPages";
            LabelForTotalPages.Size = new Size(136, 21);
            LabelForTotalPages.TabIndex = 13;
            LabelForTotalPages.Text = "Кол-во страниц";
            // 
            // LabelForPublisher
            // 
            LabelForPublisher.AutoSize = true;
            LabelForPublisher.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForPublisher.ForeColor = Color.White;
            LabelForPublisher.ImageAlign = ContentAlignment.TopLeft;
            LabelForPublisher.Location = new Point(17, 281);
            LabelForPublisher.Name = "LabelForPublisher";
            LabelForPublisher.Size = new Size(118, 21);
            LabelForPublisher.TabIndex = 12;
            LabelForPublisher.Text = "Издательство";
            // 
            // PublisherTextBox
            // 
            PublisherTextBox.BackColor = Color.FromArgb(38, 38, 38);
            PublisherTextBox.BorderStyle = BorderStyle.FixedSingle;
            PublisherTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            PublisherTextBox.ForeColor = Color.White;
            PublisherTextBox.Location = new Point(17, 305);
            PublisherTextBox.Name = "PublisherTextBox";
            PublisherTextBox.PlaceholderText = "Введите издательство...";
            PublisherTextBox.Size = new Size(301, 23);
            PublisherTextBox.TabIndex = 11;
            // 
            // LabelForPlace
            // 
            LabelForPlace.AutoSize = true;
            LabelForPlace.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForPlace.ForeColor = Color.White;
            LabelForPlace.ImageAlign = ContentAlignment.TopLeft;
            LabelForPlace.Location = new Point(17, 231);
            LabelForPlace.Name = "LabelForPlace";
            LabelForPlace.Size = new Size(127, 21);
            LabelForPlace.TabIndex = 10;
            LabelForPlace.Text = "Место издания";
            // 
            // LabelForTitleInformation
            // 
            LabelForTitleInformation.AutoSize = true;
            LabelForTitleInformation.Font = new Font("Cascadia Code",
                12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForTitleInformation.ForeColor = Color.White;
            LabelForTitleInformation.ImageAlign = ContentAlignment.TopLeft;
            LabelForTitleInformation.Location = new Point(17, 131);
            LabelForTitleInformation.Name = "LabelForTitleInformation";
            LabelForTitleInformation.Size = new Size(181, 21);
            LabelForTitleInformation.TabIndex = 9;
            LabelForTitleInformation.Text = "Сведения о заглавии";
            // 
            // TitleInformationTextBox
            // 
            TitleInformationTextBox.BackColor = Color.FromArgb(38, 38, 38);
            TitleInformationTextBox.BorderStyle = BorderStyle.FixedSingle;
            TitleInformationTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            TitleInformationTextBox.ForeColor = Color.White;
            TitleInformationTextBox.Location = new Point(17, 155);
            TitleInformationTextBox.Name = "TitleInformationTextBox";
            TitleInformationTextBox.PlaceholderText = "Введите" +
                " сведения о заглавии...";
            TitleInformationTextBox.Size = new Size(301, 23);
            TitleInformationTextBox.TabIndex = 8;
            // 
            // LabelForYear
            // 
            LabelForYear.AutoSize = true;
            LabelForYear.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelForYear.ForeColor = Color.White;
            LabelForYear.ImageAlign = ContentAlignment.TopLeft;
            LabelForYear.Location = new Point(17, 181);
            LabelForYear.Name = "LabelForYear";
            LabelForYear.Size = new Size(109, 21);
            LabelForYear.TabIndex = 7;
            LabelForYear.Text = "Год издания";
            // 
            // PlaceTextBox
            // 
            PlaceTextBox.BackColor = Color.FromArgb(38, 38, 38);
            PlaceTextBox.BorderStyle = BorderStyle.FixedSingle;
            PlaceTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            PlaceTextBox.ForeColor = Color.White;
            PlaceTextBox.Location = new Point(17, 255);
            PlaceTextBox.Name = "PlaceTextBox";
            PlaceTextBox.PlaceholderText = "Введите место издания...";
            PlaceTextBox.Size = new Size(301, 23);
            PlaceTextBox.TabIndex = 6;
            // 
            // YearTextBox
            // 
            YearTextBox.BackColor = Color.FromArgb(38, 38, 38);
            YearTextBox.BorderStyle = BorderStyle.FixedSingle;
            YearTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            YearTextBox.ForeColor = Color.White;
            YearTextBox.Location = new Point(17, 205);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.PlaceholderText = "Введите год издания...";
            YearTextBox.Size = new Size(301, 23);
            YearTextBox.TabIndex = 5;
            // 
            // LabelForTitle
            // 
            LabelForTitle.AutoSize = true;
            LabelForTitle.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelForTitle.ForeColor = Color.White;
            LabelForTitle.Location = new Point(17, 81);
            LabelForTitle.Name = "LabelForTitle";
            LabelForTitle.Size = new Size(82, 21);
            LabelForTitle.TabIndex = 3;
            LabelForTitle.Text = "Название";
            // 
            // TitleTextBox
            // 
            TitleTextBox.BackColor = Color.FromArgb(38, 38, 38);
            TitleTextBox.BorderStyle = BorderStyle.FixedSingle;
            TitleTextBox.Font = new Font("Consolas", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            TitleTextBox.ForeColor = Color.White;
            TitleTextBox.Location = new Point(17, 105);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.PlaceholderText = "Введите название...";
            TitleTextBox.Size = new Size(301, 23);
            TitleTextBox.TabIndex = 2;
            // 
            // LabelForChoosePublication
            // 
            LabelForChoosePublication.AutoSize = true;
            LabelForChoosePublication.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForChoosePublication.ForeColor = Color.White;
            LabelForChoosePublication.Location = new Point(17, 26);
            LabelForChoosePublication.Name = "LabelForChoosePublication";
            LabelForChoosePublication.Size = new Size(127, 21);
            LabelForChoosePublication.TabIndex = 1;
            LabelForChoosePublication.Text = "Выбор издания";
            // 
            // PublicationsComboBox
            // 
            PublicationsComboBox.BackColor = Color.FromArgb(38, 38, 38);
            PublicationsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PublicationsComboBox.FlatStyle = FlatStyle.Flat;
            PublicationsComboBox.Font = new Font("Cascadia Code", 9.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            PublicationsComboBox.ForeColor = Color.White;
            PublicationsComboBox.FormattingEnabled = true;
            PublicationsComboBox.Location = new Point(17, 50);
            PublicationsComboBox.Name = "PublicationsComboBox";
            PublicationsComboBox.Size = new Size(301, 25);
            PublicationsComboBox.TabIndex = 0;
            // 
            // AddPublicationButton
            // 
            AddPublicationButton.BackColor = Color.FromArgb(39, 174, 96);
            AddPublicationButton.Cursor = Cursors.Hand;
            AddPublicationButton.FlatAppearance.BorderColor 
                = Color.FromArgb(64, 64, 64);
            AddPublicationButton.FlatStyle = FlatStyle.Flat;
            AddPublicationButton.Font = new Font("Leelawadee", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            AddPublicationButton.ForeColor = Color.Transparent;
            AddPublicationButton.Location = new Point(18, 668);
            AddPublicationButton.Name = "AddPublicationButton";
            AddPublicationButton.Size = new Size(127, 30);
            AddPublicationButton.TabIndex = 1;
            AddPublicationButton.Text = "ОК";
            AddPublicationButton.UseVisualStyleBackColor = false;
            AddPublicationButton.Click += AddPublicationButton_Click;
            // 
            // CancelPublicationButton
            // 
            CancelPublicationButton.BackColor = Color.FromArgb(39, 174, 96);
            CancelPublicationButton.Cursor = Cursors.Hand;
            CancelPublicationButton.FlatAppearance.BorderColor 
                = Color.FromArgb(64, 64, 64);
            CancelPublicationButton.FlatStyle = FlatStyle.Flat;
            CancelPublicationButton.Font = new Font("Leelawadee", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelPublicationButton.ForeColor = Color.Transparent;
            CancelPublicationButton.Location = new Point(221, 667);
            CancelPublicationButton.Name = "CancelPublicationButton";
            CancelPublicationButton.Size = new Size(127, 30);
            CancelPublicationButton.TabIndex = 2;
            CancelPublicationButton.Text = "Отмена";
            CancelPublicationButton.UseVisualStyleBackColor = false;
            CancelPublicationButton.Click += CancelPublicationButton_Click;
            // 
            // RandomPublicationButton
            // 
            RandomPublicationButton.BackColor = Color.FromArgb(39, 174, 96);
            RandomPublicationButton.Cursor = Cursors.Hand;
            RandomPublicationButton.FlatAppearance.BorderColor 
                = Color.FromArgb(64, 64, 64);
            RandomPublicationButton.FlatStyle = FlatStyle.Flat;
            RandomPublicationButton.Font = new Font("Leelawadee", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            RandomPublicationButton.ForeColor = Color.Transparent;
            RandomPublicationButton.Location = new Point(18, 623);
            RandomPublicationButton.Name = "RandomPublicationButton";
            RandomPublicationButton.Size = new Size(330, 30);
            RandomPublicationButton.TabIndex = 3;
            RandomPublicationButton.Text = "Случайное издание";
            RandomPublicationButton.UseVisualStyleBackColor = false;
            RandomPublicationButton.Click += RandomPublicationButton_Click;
            // 
            // AddPublicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(366, 709);
            Controls.Add(RandomPublicationButton);
            Controls.Add(CancelPublicationButton);
            Controls.Add(AddPublicationButton);
            Controls.Add(AddFormGroupBox);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(382, 748);
            MinimumSize = new Size(382, 748);
            Name = "AddPublicationForm";
            Text = "Добавление издания";
            AddFormGroupBox.ResumeLayout(false);
            AddFormGroupBox.PerformLayout();
            ResumeLayout(false);
        }
    }
}