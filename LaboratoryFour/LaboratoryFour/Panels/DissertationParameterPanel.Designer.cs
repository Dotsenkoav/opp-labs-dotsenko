namespace View.Panels
{
    partial class DissertationParameterPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            SpecialityTextBox = new TextBox();
            LabelForSpeciality = new Label();
            AuthorTextBox = new TextBox();
            LabelForAuthor = new Label();
            LabelForDegree = new Label();
            DegreeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // SpecialityTextBox
            // 
            SpecialityTextBox.BackColor = Color.FromArgb(38, 38, 38);
            SpecialityTextBox.BorderStyle = BorderStyle.FixedSingle;
            SpecialityTextBox.ForeColor = Color.White;
            SpecialityTextBox.Location = new Point(13, 84);
            SpecialityTextBox.Name = "SpecialityTextBox";
            SpecialityTextBox.PlaceholderText = "Введите специальность...";
            SpecialityTextBox.Size = new Size(301, 23);
            SpecialityTextBox.TabIndex = 26;
            // 
            // LabelForSpeciality
            // 
            LabelForSpeciality.AutoSize = true;
            LabelForSpeciality.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForSpeciality.ForeColor = Color.White;
            LabelForSpeciality.ImageAlign = ContentAlignment.TopLeft;
            LabelForSpeciality.Location = new Point(13, 60);
            LabelForSpeciality.Name = "LabelForSpeciality";
            LabelForSpeciality.Size = new Size(127, 21);
            LabelForSpeciality.TabIndex = 25;
            LabelForSpeciality.Text = "Специальность";
            // 
            // AuthorTextBox
            // 
            AuthorTextBox.BackColor = Color.FromArgb(38, 38, 38);
            AuthorTextBox.BorderStyle = BorderStyle.FixedSingle;
            AuthorTextBox.ForeColor = Color.White;
            AuthorTextBox.Location = new Point(13, 34);
            AuthorTextBox.Name = "AuthorTextBox";
            AuthorTextBox.PlaceholderText = "Введите автора в формате Фамилия Имя Отчество...";
            AuthorTextBox.Size = new Size(301, 23);
            AuthorTextBox.TabIndex = 24;
            // 
            // LabelForAuthor
            // 
            LabelForAuthor.AutoSize = true;
            LabelForAuthor.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForAuthor.ForeColor = Color.White;
            LabelForAuthor.ImageAlign = ContentAlignment.TopLeft;
            LabelForAuthor.Location = new Point(13, 10);
            LabelForAuthor.Name = "LabelForAuthor";
            LabelForAuthor.Size = new Size(55, 21);
            LabelForAuthor.TabIndex = 23;
            LabelForAuthor.Text = "Автор";
            // 
            // LabelForDegree
            // 
            LabelForDegree.AutoSize = true;
            LabelForDegree.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForDegree.ForeColor = Color.White;
            LabelForDegree.ImageAlign = ContentAlignment.TopLeft;
            LabelForDegree.Location = new Point(13, 110);
            LabelForDegree.Name = "LabelForDegree";
            LabelForDegree.Size = new Size(136, 21);
            LabelForDegree.TabIndex = 27;
            LabelForDegree.Text = "Ученая степень";
            // 
            // DegreeComboBox
            // 
            DegreeComboBox.BackColor = Color.FromArgb(38, 38, 38);
            DegreeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DegreeComboBox.FlatStyle = FlatStyle.Flat;
            DegreeComboBox.ForeColor = Color.White;
            DegreeComboBox.FormattingEnabled = true;
            DegreeComboBox.Items.AddRange(new object[] { "Книга", "Сборник", "Журнал", "Диссертация" });
            DegreeComboBox.Location = new Point(13, 134);
            DegreeComboBox.Name = "DegreeComboBox";
            DegreeComboBox.Size = new Size(301, 23);
            DegreeComboBox.TabIndex = 28;
            // 
            // DissertationParameterPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(DegreeComboBox);
            Controls.Add(LabelForDegree);
            Controls.Add(SpecialityTextBox);
            Controls.Add(LabelForSpeciality);
            Controls.Add(AuthorTextBox);
            Controls.Add(LabelForAuthor);
            Name = "DissertationParameterPanel";
            Size = new Size(330, 178);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SpecialityTextBox;
        private Label LabelForSpeciality;
        private TextBox AuthorTextBox;
        private Label LabelForAuthor;
        private Label LabelForDegree;
        private ComboBox DegreeComboBox;
    }
}
