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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            PublicationsGroupBox = new GroupBox();
            PublicationsDataGridView = new DataGridView();
            AddPublicationsButton = new Button();
            PublicationsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PublicationsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // PublicationsGroupBox
            // 
            PublicationsGroupBox.Controls.Add(PublicationsDataGridView);
            PublicationsGroupBox.ForeColor = SystemColors.ButtonHighlight;
            PublicationsGroupBox.Location = new Point(16, 13);
            PublicationsGroupBox.Margin = new Padding(4, 3, 4, 3);
            PublicationsGroupBox.Name = "PublicationsGroupBox";
            PublicationsGroupBox.Padding = new Padding(4, 3, 4, 3);
            PublicationsGroupBox.Size = new Size(906, 392);
            PublicationsGroupBox.TabIndex = 0;
            PublicationsGroupBox.TabStop = false;
            PublicationsGroupBox.Text = "Список изданий";
            // 
            // PublicationsDataGridView
            // 
            PublicationsDataGridView.BackgroundColor = Color.FromArgb(38, 38, 38);
            PublicationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PublicationsDataGridView.Location = new Point(8, 22);
            PublicationsDataGridView.Margin = new Padding(4, 3, 4, 3);
            PublicationsDataGridView.Name = "PublicationsDataGridView";
            PublicationsDataGridView.Size = new Size(890, 361);
            PublicationsDataGridView.TabIndex = 0;
            // 
            // AddPublicationsButton
            // 
            AddPublicationsButton.BackColor = Color.FromArgb(39, 174, 96);
            AddPublicationsButton.Cursor = Cursors.Hand;
            AddPublicationsButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            AddPublicationsButton.FlatStyle = FlatStyle.Flat;
            AddPublicationsButton.Location = new Point(23, 419);
            AddPublicationsButton.Margin = new Padding(4, 3, 4, 3);
            AddPublicationsButton.Name = "AddPublicationsButton";
            AddPublicationsButton.Size = new Size(116, 41);
            AddPublicationsButton.TabIndex = 1;
            AddPublicationsButton.Text = "Добавить";
            AddPublicationsButton.UseVisualStyleBackColor = false;
            AddPublicationsButton.Click += AddPublicationsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(935, 488);
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

        #endregion

        private GroupBox PublicationsGroupBox;
        private DataGridView PublicationsDataGridView;
        private Button AddPublicationsButton;
    }
}