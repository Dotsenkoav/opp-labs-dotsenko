namespace View.Panels
{
    /// <summary>
    /// Часть класса, описывающая дизайн панели издания сборника
    /// </summary>
    partial class CollectionParameterPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Надпись для текстового поля редакционной коллегии
        /// </summary>
        private Label LabelForEditorialBoard;

        /// <summary>
        /// Текстовое поле редакционной коллегии
        /// </summary>
        private TextBox EditorialBoardTextBox;

        /// <summary>
        /// Надпись для текстового поля ответственных редакторов
        /// </summary>
        private Label LabelForResponsibleEditors;
        
        /// <summary>
        /// Текстовое поле для ввода ответственных редакторов
        /// </summary>
        private TextBox ResponsibleEditorsTextBox;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если
        /// управляемый ресурс должен быть удален; иначе ложно.</param>
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
            LabelForEditorialBoard = new Label();
            EditorialBoardTextBox = new TextBox();
            LabelForResponsibleEditors = new Label();
            ResponsibleEditorsTextBox = new TextBox();
            SuspendLayout();
            // 
            // LabelForEditorialBoard
            // 
            LabelForEditorialBoard.AutoSize = true;
            LabelForEditorialBoard.Font = new Font("Cascadia Code",
                12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForEditorialBoard.ForeColor = Color.White;
            LabelForEditorialBoard.ImageAlign = ContentAlignment.TopLeft;
            LabelForEditorialBoard.Location = new Point(13, 10);
            LabelForEditorialBoard.Name = "LabelForEditorialBoard";
            LabelForEditorialBoard.Size = new Size(199, 21);
            LabelForEditorialBoard.TabIndex = 19;
            LabelForEditorialBoard.Text = "Редакционная коллегия";
            // 
            // EditorialBoardTextBox
            // 
            EditorialBoardTextBox.BackColor = Color.FromArgb(38, 38, 38);
            EditorialBoardTextBox.BorderStyle = BorderStyle.FixedSingle;
            EditorialBoardTextBox.ForeColor = Color.White;
            EditorialBoardTextBox.Location = new Point(13, 34);
            EditorialBoardTextBox.Name = "EditorialBoardTextBox";
            EditorialBoardTextBox.PlaceholderText = "Введите" +
                " редакционную коллегию...";
            EditorialBoardTextBox.Size = new Size(301, 23);
            EditorialBoardTextBox.TabIndex = 20;
            // 
            // LabelForResponsibleEditors
            // 
            LabelForResponsibleEditors.AutoSize = true;
            LabelForResponsibleEditors.Font = new Font("Cascadia Code",
                12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForResponsibleEditors.ForeColor = Color.White;
            LabelForResponsibleEditors.ImageAlign = ContentAlignment.TopLeft;
            LabelForResponsibleEditors.Location = new Point(13, 60);
            LabelForResponsibleEditors.Name = "LabelForResponsibleEditors";
            LabelForResponsibleEditors.Size = new Size(217, 21);
            LabelForResponsibleEditors.TabIndex = 21;
            LabelForResponsibleEditors.Text = "Ответственные редакторы";
            // 
            // ResponsibleEditorsTextBox
            // 
            ResponsibleEditorsTextBox.BackColor = Color.FromArgb(38, 38, 38);
            ResponsibleEditorsTextBox.BorderStyle = BorderStyle.FixedSingle;
            ResponsibleEditorsTextBox.ForeColor = Color.White;
            ResponsibleEditorsTextBox.Location = new Point(13, 84);
            ResponsibleEditorsTextBox.Name = "ResponsibleEditorsTextBox";
            ResponsibleEditorsTextBox.PlaceholderText = "Введите" +
                " ответственных редакторов...";
            ResponsibleEditorsTextBox.Size = new Size(301, 23);
            ResponsibleEditorsTextBox.TabIndex = 22;
            // 
            // CollectionParameterPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(ResponsibleEditorsTextBox);
            Controls.Add(LabelForResponsibleEditors);
            Controls.Add(EditorialBoardTextBox);
            Controls.Add(LabelForEditorialBoard);
            Name = "CollectionParameterPanel";
            Size = new Size(330, 178);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
