namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            PublicationsGroupBox = new GroupBox();
            PublicationsDataGridView = new DataGridView();
            AddPublicationsButton = new Button();
            RemovePublicationsButton = new Button();
            SearchButton = new Button();
            DownloadButton = new Button();
            SaveButton = new Button();
            PublicationsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PublicationsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // PublicationsGroupBox
            // 
            PublicationsGroupBox.Controls.Add(PublicationsDataGridView);
            PublicationsGroupBox.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PublicationsGroupBox.ForeColor = SystemColors.ButtonHighlight;
            PublicationsGroupBox.Location = new Point(16, 13);
            PublicationsGroupBox.Margin = new Padding(4, 3, 4, 3);
            PublicationsGroupBox.Name = "PublicationsGroupBox";
            PublicationsGroupBox.Padding = new Padding(4, 3, 4, 3);
            PublicationsGroupBox.Size = new Size(1065, 480);
            PublicationsGroupBox.TabIndex = 0;
            PublicationsGroupBox.TabStop = false;
            PublicationsGroupBox.Text = "Список изданий";
            // 
            // PublicationsDataGridView
            // 
            PublicationsDataGridView.AllowUserToAddRows = false;
            PublicationsDataGridView.AllowUserToDeleteRows = false;
            PublicationsDataGridView.AllowUserToResizeColumns = false;
            PublicationsDataGridView.AllowUserToResizeRows = false;
            PublicationsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            PublicationsDataGridView.BackgroundColor = Color.FromArgb(38, 38, 38);
            PublicationsDataGridView.BorderStyle = BorderStyle.None;
            PublicationsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(65, 64, 72);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(65, 64, 72);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            PublicationsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            PublicationsDataGridView.ColumnHeadersHeight = 25;
            PublicationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(38, 38, 38);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(39, 174, 96);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            PublicationsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            PublicationsDataGridView.EnableHeadersVisualStyles = false;
            PublicationsDataGridView.GridColor = Color.DimGray;
            PublicationsDataGridView.Location = new Point(7, 24);
            PublicationsDataGridView.Name = "PublicationsDataGridView";
            PublicationsDataGridView.ReadOnly = true;
            PublicationsDataGridView.RowHeadersVisible = false;
            PublicationsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PublicationsDataGridView.Size = new Size(1051, 450);
            PublicationsDataGridView.TabIndex = 0;
            // 
            // AddPublicationsButton
            // 
            AddPublicationsButton.BackColor = Color.FromArgb(39, 174, 96);
            AddPublicationsButton.Cursor = Cursors.Hand;
            AddPublicationsButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            AddPublicationsButton.FlatStyle = FlatStyle.Flat;
            AddPublicationsButton.ForeColor = Color.White;
            AddPublicationsButton.Location = new Point(94, 511);
            AddPublicationsButton.Margin = new Padding(4, 3, 4, 3);
            AddPublicationsButton.Name = "AddPublicationsButton";
            AddPublicationsButton.Size = new Size(116, 41);
            AddPublicationsButton.TabIndex = 1;
            AddPublicationsButton.Text = "Добавить";
            AddPublicationsButton.UseVisualStyleBackColor = false;
            AddPublicationsButton.Click += AddPublicationsButton_Click;
            // 
            // RemovePublicationsButton
            // 
            RemovePublicationsButton.BackColor = Color.FromArgb(39, 174, 96);
            RemovePublicationsButton.Cursor = Cursors.Hand;
            RemovePublicationsButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            RemovePublicationsButton.FlatStyle = FlatStyle.Flat;
            RemovePublicationsButton.ForeColor = Color.White;
            RemovePublicationsButton.Location = new Point(233, 511);
            RemovePublicationsButton.Margin = new Padding(4, 3, 4, 3);
            RemovePublicationsButton.Name = "RemovePublicationsButton";
            RemovePublicationsButton.Size = new Size(116, 41);
            RemovePublicationsButton.TabIndex = 2;
            RemovePublicationsButton.Text = "Удалить";
            RemovePublicationsButton.UseVisualStyleBackColor = false;
            RemovePublicationsButton.Click += RemovePublicationButton_Click;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(39, 174, 96);
            SearchButton.Cursor = Cursors.Hand;
            SearchButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(408, 511);
            SearchButton.Margin = new Padding(4, 3, 4, 3);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(254, 41);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // DownloadButton
            // 
            DownloadButton.BackColor = Color.FromArgb(39, 174, 96);
            DownloadButton.Cursor = Cursors.Hand;
            DownloadButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            DownloadButton.FlatStyle = FlatStyle.Flat;
            DownloadButton.ForeColor = Color.White;
            DownloadButton.Location = new Point(730, 511);
            DownloadButton.Margin = new Padding(4, 3, 4, 3);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(116, 41);
            DownloadButton.TabIndex = 4;
            DownloadButton.Text = "Загрузить";
            DownloadButton.UseVisualStyleBackColor = false;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.FromArgb(39, 174, 96);
            SaveButton.Cursor = Cursors.Hand;
            SaveButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(869, 511);
            SaveButton.Margin = new Padding(4, 3, 4, 3);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(116, 41);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1094, 564);
            Controls.Add(SaveButton);
            Controls.Add(DownloadButton);
            Controls.Add(SearchButton);
            Controls.Add(RemovePublicationsButton);
            Controls.Add(AddPublicationsButton);
            Controls.Add(PublicationsGroupBox);
            Font = new Font("Bookman Old Style", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Библиотечный контроль";
            PublicationsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PublicationsDataGridView).EndInit();
            ResumeLayout(false);
        }

        private GroupBox PublicationsGroupBox;
        private DataGridView PublicationsDataGridView;
        private Button AddPublicationsButton;
        private Button RemovePublicationsButton;
        private Button SearchButton;
        private Button DownloadButton;
        private Button SaveButton;
    }
}