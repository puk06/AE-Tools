namespace AETools.WinForm.SubForm
{
    partial class DatabaseTransfer
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
            DataDestinationFolderSelectLabel = new Label();
            OpenDataDestinationFolderButton = new Button();
            DataDestinationFolderLabel = new Label();
            ConvertDataButton = new Button();
            DataTransferProgressBar = new ProgressBar();
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
            AvatarExplorerDataFolderSelectLabel.TabIndex = 6;
            AvatarExplorerDataFolderSelectLabel.Text = "未選択";
            // 
            // OpenDataFolder
            // 
            OpenDataFolder.Font = new Font("Yu Gothic UI", 11F);
            OpenDataFolder.Location = new Point(262, 6);
            OpenDataFolder.Name = "OpenDataFolder";
            OpenDataFolder.Size = new Size(123, 30);
            OpenDataFolder.TabIndex = 5;
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
            AvatarExplorerDataFolderLabel.TabIndex = 4;
            AvatarExplorerDataFolderLabel.Text = "Avatar Explorerデータフォルダ";
            // 
            // DataDestinationFolderSelectLabel
            // 
            DataDestinationFolderSelectLabel.AutoSize = true;
            DataDestinationFolderSelectLabel.Font = new Font("Yu Gothic UI", 14F);
            DataDestinationFolderSelectLabel.ForeColor = Color.IndianRed;
            DataDestinationFolderSelectLabel.Location = new Point(12, 111);
            DataDestinationFolderSelectLabel.Name = "DataDestinationFolderSelectLabel";
            DataDestinationFolderSelectLabel.Size = new Size(69, 25);
            DataDestinationFolderSelectLabel.TabIndex = 9;
            DataDestinationFolderSelectLabel.Text = "未選択";
            // 
            // OpenDataDestinationFolderButton
            // 
            OpenDataDestinationFolderButton.Font = new Font("Yu Gothic UI", 11F);
            OpenDataDestinationFolderButton.Location = new Point(262, 80);
            OpenDataDestinationFolderButton.Name = "OpenDataDestinationFolderButton";
            OpenDataDestinationFolderButton.Size = new Size(123, 30);
            OpenDataDestinationFolderButton.TabIndex = 8;
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
            DataDestinationFolderLabel.Size = new Size(244, 25);
            DataDestinationFolderLabel.TabIndex = 7;
            DataDestinationFolderLabel.Text = "KonoAssetデータ出力先フォルダ";
            // 
            // ConvertDataButton
            // 
            ConvertDataButton.Font = new Font("Yu Gothic UI", 13F);
            ConvertDataButton.Location = new Point(457, 171);
            ConvertDataButton.Name = "ConvertDataButton";
            ConvertDataButton.Size = new Size(174, 38);
            ConvertDataButton.TabIndex = 10;
            ConvertDataButton.Text = "データ移行を実行";
            ConvertDataButton.UseVisualStyleBackColor = true;
            ConvertDataButton.Click += ConvertDataButton_Click;
            // 
            // DataTransferProgressBar
            // 
            DataTransferProgressBar.Location = new Point(11, 179);
            DataTransferProgressBar.Name = "DataTransferProgressBar";
            DataTransferProgressBar.Size = new Size(439, 23);
            DataTransferProgressBar.TabIndex = 11;
            // 
            // DatabaseTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 221);
            Controls.Add(DataTransferProgressBar);
            Controls.Add(ConvertDataButton);
            Controls.Add(DataDestinationFolderSelectLabel);
            Controls.Add(OpenDataDestinationFolderButton);
            Controls.Add(DataDestinationFolderLabel);
            Controls.Add(AvatarExplorerDataFolderSelectLabel);
            Controls.Add(OpenDataFolder);
            Controls.Add(AvatarExplorerDataFolderLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DatabaseTransfer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "データ移行支援ツール";
            ResumeLayout(false);
            PerformLayout();
            this.FormClosing += DatabaseTransfer_FormClosing;
        }

        #endregion

        private Label AvatarExplorerDataFolderSelectLabel;
        private Button OpenDataFolder;
        private Label AvatarExplorerDataFolderLabel;
        private Label DataDestinationFolderSelectLabel;
        private Button OpenDataDestinationFolderButton;
        private Label DataDestinationFolderLabel;
        private Button ConvertDataButton;
        private ProgressBar DataTransferProgressBar;
    }
}