namespace View.Panels
{
    /// <summary>
    /// Часть класса, описывающая дизайн панели издания журнала
    /// </summary>
    partial class JournalParameterPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Надпись для выпадающего списка частоты издания
        /// </summary>
        private Label LabelForFrequency;

        /// <summary>
        /// Выпадающий список частоты издания
        /// </summary>
        private ComboBox FrequencyComboBox;

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
            LabelForFrequency = new Label();
            FrequencyComboBox = new ComboBox();
            SuspendLayout();
            // 
            // LabelForFrequency
            // 
            LabelForFrequency.AutoSize = true;
            LabelForFrequency.Font = new Font("Cascadia Code", 12F,
                FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelForFrequency.ForeColor = Color.White;
            LabelForFrequency.ImageAlign = ContentAlignment.TopLeft;
            LabelForFrequency.Location = new Point(13, 10);
            LabelForFrequency.Name = "LabelForFrequency";
            LabelForFrequency.Size = new Size(145, 21);
            LabelForFrequency.TabIndex = 25;
            LabelForFrequency.Text = "Частота издания";
            // 
            // FrequencyComboBox
            // 
            FrequencyComboBox.BackColor = Color.FromArgb(38, 38, 38);
            FrequencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FrequencyComboBox.FlatStyle = FlatStyle.Flat;
            FrequencyComboBox.ForeColor = Color.White;
            FrequencyComboBox.FormattingEnabled = true;
            FrequencyComboBox.Location = new Point(13, 34);
            FrequencyComboBox.Name = "FrequencyComboBox";
            FrequencyComboBox.Size = new Size(301, 23);
            FrequencyComboBox.TabIndex = 26;
            // 
            // JournalParameterPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(FrequencyComboBox);
            Controls.Add(LabelForFrequency);
            Name = "JournalParameterPanel";
            Size = new Size(330, 178);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
