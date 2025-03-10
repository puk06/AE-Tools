namespace AETools.WinForm.MainForm
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            DatabaseTransfer = new Button();
            OrganizeFolder = new Button();
            AssetHelper = new Button();
            ReacquisitionData = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 16F);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(197, 30);
            label1.TabIndex = 0;
            label1.Text = "AE Tools by ぷこるふ";
            // 
            // DatabaseTransfer
            // 
            DatabaseTransfer.Font = new Font("Yu Gothic UI", 11F);
            DatabaseTransfer.Location = new Point(12, 55);
            DatabaseTransfer.Name = "DatabaseTransfer";
            DatabaseTransfer.Size = new Size(352, 51);
            DatabaseTransfer.TabIndex = 3;
            DatabaseTransfer.Text = "Avatar Explorer ⇒ KonoAssetへのデータ移行";
            DatabaseTransfer.UseVisualStyleBackColor = true;
            DatabaseTransfer.Click += DatabaseTransfer_Click;
            // 
            // OrganizeFolder
            // 
            OrganizeFolder.Font = new Font("Yu Gothic UI", 13F);
            OrganizeFolder.Location = new Point(12, 112);
            OrganizeFolder.Name = "OrganizeFolder";
            OrganizeFolder.Size = new Size(352, 51);
            OrganizeFolder.TabIndex = 4;
            OrganizeFolder.Text = "データベースを使ったフォルダ整理";
            OrganizeFolder.UseVisualStyleBackColor = true;
            OrganizeFolder.Click += OrganizeFolder_Click;
            // 
            // AssetHelper
            // 
            AssetHelper.Font = new Font("Yu Gothic UI", 13F);
            AssetHelper.Location = new Point(12, 169);
            AssetHelper.Name = "AssetHelper";
            AssetHelper.Size = new Size(352, 51);
            AssetHelper.TabIndex = 5;
            AssetHelper.Text = "アセット登録支援ツール";
            AssetHelper.UseVisualStyleBackColor = true;
            AssetHelper.Click += AssetHelper_Click;
            // 
            // ReacquisitionData
            // 
            ReacquisitionData.Font = new Font("Yu Gothic UI", 13F);
            ReacquisitionData.Location = new Point(12, 226);
            ReacquisitionData.Name = "ReacquisitionData";
            ReacquisitionData.Size = new Size(352, 51);
            ReacquisitionData.TabIndex = 6;
            ReacquisitionData.Text = "データベース情報再取得ツール";
            ReacquisitionData.UseVisualStyleBackColor = true;
            ReacquisitionData.Click += ReacquisitionData_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 450);
            Controls.Add(ReacquisitionData);
            Controls.Add(AssetHelper);
            Controls.Add(OrganizeFolder);
            Controls.Add(DatabaseTransfer);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AE Tools by ぷこるふ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button DatabaseTransfer;
        private Button OrganizeFolder;
        private Button AssetHelper;
        private Button ReacquisitionData;
    }
}
