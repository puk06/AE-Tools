namespace AETools.WinForm.SubForm
{
    partial class ReacquisitionData
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
            AvatarExplorerDataFolderSelectLabel = new Label();
            OpenDataFolder = new Button();
            AvatarExplorerDataFolderLabel = new Label();
            DataReacquisitionProgressBar = new ProgressBar();
            ReacquisitionDataButton = new Button();
            SuspendLayout();
            // 
            // AvatarExplorerDataFolderSelectLabel
            // 
            AvatarExplorerDataFolderSelectLabel.AutoSize = true;
            AvatarExplorerDataFolderSelectLabel.Font = new Font("Yu Gothic UI", 14F);
            AvatarExplorerDataFolderSelectLabel.ForeColor = Color.IndianRed;
            AvatarExplorerDataFolderSelectLabel.Location = new Point(12, 37);
            AvatarExplorerDataFolderSelectLabel.Name = "AvatarExplorerDataFolderSelectLabel";
            AvatarExplorerDataFolderSelectLabel.Size = new Size(69, 25);
            AvatarExplorerDataFolderSelectLabel.TabIndex = 9;
            AvatarExplorerDataFolderSelectLabel.Text = "未選択";
            // 
            // OpenDataFolder
            // 
            OpenDataFolder.Font = new Font("Yu Gothic UI", 11F);
            OpenDataFolder.Location = new Point(262, 6);
            OpenDataFolder.Name = "OpenDataFolder";
            OpenDataFolder.Size = new Size(123, 30);
            OpenDataFolder.TabIndex = 8;
            OpenDataFolder.Text = "フォルダを開く";
            OpenDataFolder.UseVisualStyleBackColor = true;
            OpenDataFolder.Click += OpenDataFolder_Click;
            // 
            // AvatarExplorerDataFolderLabel
            // 
            AvatarExplorerDataFolderLabel.AutoSize = true;
            AvatarExplorerDataFolderLabel.Font = new Font("Yu Gothic UI", 13F);
            AvatarExplorerDataFolderLabel.Location = new Point(12, 9);
            AvatarExplorerDataFolderLabel.Name = "AvatarExplorerDataFolderLabel";
            AvatarExplorerDataFolderLabel.Size = new Size(225, 25);
            AvatarExplorerDataFolderLabel.TabIndex = 7;
            AvatarExplorerDataFolderLabel.Text = "Avatar Explorerデータフォルダ";
            // 
            // DataReacquisitionProgressBar
            // 
            DataReacquisitionProgressBar.Location = new Point(12, 79);
            DataReacquisitionProgressBar.Name = "DataReacquisitionProgressBar";
            DataReacquisitionProgressBar.Size = new Size(439, 23);
            DataReacquisitionProgressBar.TabIndex = 13;
            // 
            // ReacquisitionDataButton
            // 
            ReacquisitionDataButton.Font = new Font("Yu Gothic UI", 13F);
            ReacquisitionDataButton.Location = new Point(458, 71);
            ReacquisitionDataButton.Name = "ReacquisitionDataButton";
            ReacquisitionDataButton.Size = new Size(174, 38);
            ReacquisitionDataButton.TabIndex = 12;
            ReacquisitionDataButton.Text = "データ再取得を実行";
            ReacquisitionDataButton.UseVisualStyleBackColor = true;
            ReacquisitionDataButton.Click += ReacquisitionDataButton_Click;
            // 
            // ReacquisitionData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 118);
            Controls.Add(DataReacquisitionProgressBar);
            Controls.Add(ReacquisitionDataButton);
            Controls.Add(AvatarExplorerDataFolderSelectLabel);
            Controls.Add(OpenDataFolder);
            Controls.Add(AvatarExplorerDataFolderLabel);
            MaximizeBox = false;
            Name = "ReacquisitionData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "データベース情報再取得ツール";
            FormClosing += ReacquisitionData_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AvatarExplorerDataFolderSelectLabel;
        private Button OpenDataFolder;
        private Label AvatarExplorerDataFolderLabel;
        private ProgressBar DataReacquisitionProgressBar;
        private Button ReacquisitionDataButton;
    }
}