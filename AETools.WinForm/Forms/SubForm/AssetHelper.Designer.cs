namespace AETools.WinForm.SubForm
{
    partial class AssetHelper
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
            AssetDatabaseFileLabel = new Label();
            OpenDatabaseFile = new Button();
            DataBaseFileLabel = new Label();
            FolderNameLabel = new Label();
            FolderNameTextBox = new TextBox();
            SuggestedBoothItemList = new ListBox();
            SuggestedBoothItemLabel = new Label();
            SuspendLayout();
            // 
            // AssetDatabaseFileLabel
            // 
            AssetDatabaseFileLabel.AutoSize = true;
            AssetDatabaseFileLabel.Font = new Font("Yu Gothic UI", 13F);
            AssetDatabaseFileLabel.Location = new Point(12, 9);
            AssetDatabaseFileLabel.Name = "AssetDatabaseFileLabel";
            AssetDatabaseFileLabel.Size = new Size(197, 25);
            AssetDatabaseFileLabel.TabIndex = 0;
            AssetDatabaseFileLabel.Text = "アセットデータベースファイル";
            // 
            // OpenDatabaseFile
            // 
            OpenDatabaseFile.Font = new Font("Yu Gothic UI", 11F);
            OpenDatabaseFile.Location = new Point(215, 6);
            OpenDatabaseFile.Name = "OpenDatabaseFile";
            OpenDatabaseFile.Size = new Size(123, 30);
            OpenDatabaseFile.TabIndex = 1;
            OpenDatabaseFile.Text = "ファイルを開く";
            OpenDatabaseFile.UseVisualStyleBackColor = true;
            OpenDatabaseFile.Click += OpenDatabaseFile_Click;
            // 
            // DataBaseFileLabel
            // 
            DataBaseFileLabel.AutoSize = true;
            DataBaseFileLabel.Font = new Font("Yu Gothic UI", 14F);
            DataBaseFileLabel.ForeColor = Color.IndianRed;
            DataBaseFileLabel.Location = new Point(12, 37);
            DataBaseFileLabel.Name = "DataBaseFileLabel";
            DataBaseFileLabel.Size = new Size(69, 25);
            DataBaseFileLabel.TabIndex = 3;
            DataBaseFileLabel.Text = "未選択";
            // 
            // FolderNameLabel
            // 
            FolderNameLabel.AutoSize = true;
            FolderNameLabel.Font = new Font("Yu Gothic UI", 13F);
            FolderNameLabel.Location = new Point(12, 89);
            FolderNameLabel.Name = "FolderNameLabel";
            FolderNameLabel.Size = new Size(261, 25);
            FolderNameLabel.TabIndex = 4;
            FolderNameLabel.Text = "フォルダー名 (D＆Dで入力できます)";
            // 
            // FolderNameTextBox
            // 
            FolderNameTextBox.Font = new Font("Yu Gothic UI", 13F);
            FolderNameTextBox.Location = new Point(16, 123);
            FolderNameTextBox.Name = "FolderNameTextBox";
            FolderNameTextBox.Size = new Size(772, 31);
            FolderNameTextBox.TabIndex = 5;
            FolderNameTextBox.TextChanged += FolderNameTextBox_TextChanged;
            // 
            // SuggestedBoothItemList
            // 
            SuggestedBoothItemList.Font = new Font("Yu Gothic UI", 12F);
            SuggestedBoothItemList.FormattingEnabled = true;
            SuggestedBoothItemList.HorizontalScrollbar = true;
            SuggestedBoothItemList.ItemHeight = 21;
            SuggestedBoothItemList.Location = new Point(16, 202);
            SuggestedBoothItemList.Name = "SuggestedBoothItemList";
            SuggestedBoothItemList.Size = new Size(772, 235);
            SuggestedBoothItemList.TabIndex = 6;
            SuggestedBoothItemList.SelectedIndexChanged += SuggestedBoothItemList_SelectedIndexChanged;
            // 
            // SuggestedBoothItemLabel
            // 
            SuggestedBoothItemLabel.AutoSize = true;
            SuggestedBoothItemLabel.Font = new Font("Yu Gothic UI", 13F);
            SuggestedBoothItemLabel.Location = new Point(12, 174);
            SuggestedBoothItemLabel.Name = "SuggestedBoothItemLabel";
            SuggestedBoothItemLabel.Size = new Size(166, 25);
            SuggestedBoothItemLabel.TabIndex = 7;
            SuggestedBoothItemLabel.Text = "Boothアイテムの候補";
            // 
            // AssetHelper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SuggestedBoothItemLabel);
            Controls.Add(SuggestedBoothItemList);
            Controls.Add(FolderNameTextBox);
            Controls.Add(FolderNameLabel);
            Controls.Add(DataBaseFileLabel);
            Controls.Add(OpenDatabaseFile);
            Controls.Add(AssetDatabaseFileLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AssetHelper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "アセット登録支援ツール";
            FormClosing += AssetHelper_FormClosing;
            DragDrop += AssetHelper_DragDrop;
            DragEnter += AssetHelper_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AssetDatabaseFileLabel;
        private Button OpenDatabaseFile;
        private Label DataBaseFileLabel;
        private Label FolderNameLabel;
        private TextBox FolderNameTextBox;
        private ListBox SuggestedBoothItemList;
        private Label SuggestedBoothItemLabel;
    }
}