namespace AETools.WinForm.SubForm
{
    partial class OrganizeFolder
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
            DataOrganizeProgressBar = new ProgressBar();
            OrganizeFolderButton = new Button();
            DataDestinationFolderSelectLabel = new Label();
            OpenDataDestinationFolderButton = new Button();
            DataDestinationFolderLabel = new Label();
            AvatarExplorerDataFolderSelectLabel = new Label();
            OpenDataFolder = new Button();
            AvatarExplorerDataFolderLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // DataOrganizeProgressBar
            // 
            DataOrganizeProgressBar.Location = new Point(11, 179);
            DataOrganizeProgressBar.Name = "DataOrganizeProgressBar";
            DataOrganizeProgressBar.Size = new Size(439, 23);
            DataOrganizeProgressBar.TabIndex = 19;
            // 
            // OrganizeFolderButton
            // 
            OrganizeFolderButton.Font = new Font("Yu Gothic UI", 13F);
            OrganizeFolderButton.Location = new Point(457, 171);
            OrganizeFolderButton.Name = "OrganizeFolderButton";
            OrganizeFolderButton.Size = new Size(174, 38);
            OrganizeFolderButton.TabIndex = 18;
            OrganizeFolderButton.Text = "データ整理を実行";
            OrganizeFolderButton.UseVisualStyleBackColor = true;
            OrganizeFolderButton.Click += OrganizeFolderButton_Click;
            // 
            // DataDestinationFolderSelectLabel
            // 
            DataDestinationFolderSelectLabel.AutoSize = true;
            DataDestinationFolderSelectLabel.Font = new Font("Yu Gothic UI", 14F);
            DataDestinationFolderSelectLabel.ForeColor = Color.IndianRed;
            DataDestinationFolderSelectLabel.Location = new Point(12, 111);
            DataDestinationFolderSelectLabel.Name = "DataDestinationFolderSelectLabel";
            DataDestinationFolderSelectLabel.Size = new Size(69, 25);
            DataDestinationFolderSelectLabel.TabIndex = 17;
            DataDestinationFolderSelectLabel.Text = "未選択";
            // 
            // OpenDataDestinationFolderButton
            // 
            OpenDataDestinationFolderButton.Font = new Font("Yu Gothic UI", 11F);
            OpenDataDestinationFolderButton.Location = new Point(262, 80);
            OpenDataDestinationFolderButton.Name = "OpenDataDestinationFolderButton";
            OpenDataDestinationFolderButton.Size = new Size(123, 30);
            OpenDataDestinationFolderButton.TabIndex = 16;
            OpenDataDestinationFolderButton.Text = "フォルダを開く";
            OpenDataDestinationFolderButton.UseVisualStyleBackColor = true;
            OpenDataDestinationFolderButton.Click += OpenDataDestinationFolderButton_Click;
            // 
            // DataDestinationFolderLabel
            // 
            DataDestinationFolderLabel.AutoSize = true;
            DataDestinationFolderLabel.Font = new Font("Yu Gothic UI", 13F);
            DataDestinationFolderLabel.Location = new Point(12, 83);
            DataDestinationFolderLabel.Name = "DataDestinationFolderLabel";
            DataDestinationFolderLabel.Size = new Size(172, 25);
            DataDestinationFolderLabel.TabIndex = 15;
            DataDestinationFolderLabel.Text = "フォルダ出力先フォルダ";
            // 
            // AvatarExplorerDataFolderSelectLabel
            // 
            AvatarExplorerDataFolderSelectLabel.AutoSize = true;
            AvatarExplorerDataFolderSelectLabel.Font = new Font("Yu Gothic UI", 14F);
            AvatarExplorerDataFolderSelectLabel.ForeColor = Color.IndianRed;
            AvatarExplorerDataFolderSelectLabel.Location = new Point(12, 37);
            AvatarExplorerDataFolderSelectLabel.Name = "AvatarExplorerDataFolderSelectLabel";
            AvatarExplorerDataFolderSelectLabel.Size = new Size(69, 25);
            AvatarExplorerDataFolderSelectLabel.TabIndex = 14;
            AvatarExplorerDataFolderSelectLabel.Text = "未選択";
            // 
            // OpenDataFolder
            // 
            OpenDataFolder.Font = new Font("Yu Gothic UI", 11F);
            OpenDataFolder.Location = new Point(262, 6);
            OpenDataFolder.Name = "OpenDataFolder";
            OpenDataFolder.Size = new Size(123, 30);
            OpenDataFolder.TabIndex = 13;
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
            AvatarExplorerDataFolderLabel.TabIndex = 12;
            AvatarExplorerDataFolderLabel.Text = "Avatar Explorerデータフォルダ";
            // 
            // OrganizeFolder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 221);
            Controls.Add(DataOrganizeProgressBar);
            Controls.Add(OrganizeFolderButton);
            Controls.Add(DataDestinationFolderSelectLabel);
            Controls.Add(OpenDataDestinationFolderButton);
            Controls.Add(DataDestinationFolderLabel);
            Controls.Add(AvatarExplorerDataFolderSelectLabel);
            Controls.Add(OpenDataFolder);
            Controls.Add(AvatarExplorerDataFolderLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "OrganizeFolder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OrganizeFolder";
            FormClosing += OrganizeFolder_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar DataOrganizeProgressBar;
        private Button OrganizeFolderButton;
        private Label DataDestinationFolderSelectLabel;
        private Button OpenDataDestinationFolderButton;
        private Label DataDestinationFolderLabel;
        private Label AvatarExplorerDataFolderSelectLabel;
        private Button OpenDataFolder;
        private Label AvatarExplorerDataFolderLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}