using AETools.Core.Helper;
using System.Diagnostics;

namespace AETools.WinForm.SubForm;

public partial class ReacquisitionData : Form
{
    private string dataFolderPath = string.Empty;
    private static readonly HttpClient HttpClient = new();
    private const string BASE_FORM_TEXT = "データベース情報再取得ツール";

    public ReacquisitionData()
    {
        InitializeComponent();
    }

    private void ResetForm()
    {
        AvatarExplorerDataFolderSelectLabel.Text = "未選択";
        AvatarExplorerDataFolderSelectLabel.ForeColor = Color.Red;
        dataFolderPath = string.Empty;
    }

    private void OpenDataFolder_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dialog = new()
        {
            Description = "データフォルダを選択してください。",
            ShowNewFolderButton = false,
            UseDescriptionForTitle = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var path = dialog.SelectedPath;

            if (!File.Exists(path + "\\ItemsData.json") || !Directory.Exists(path + "\\Thumbnail"))
            {
                MessageBox.Show("選択されたフォルダには、ItemsData.json、Thumbnailのどちらかが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AvatarExplorerDataFolderSelectLabel.Text = "選択済み: " + Path.GetFileName(path);
            AvatarExplorerDataFolderSelectLabel.ForeColor = Color.Green;
            dataFolderPath = path;
        }
    }

    private async void ReacquisitionDataButton_Click(object sender, EventArgs e)
    {
        try
        {
            //すべてのデータの再取得を実行
            ReacquisitionDataButton.Enabled = false;

            if (string.IsNullOrEmpty(dataFolderPath))
            {
                MessageBox.Show("データフォルダまたはデータ出力先フォルダが選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReacquisitionDataButton.Enabled = true;
                return;
            }

            if (!Directory.Exists(dataFolderPath))
            {
                MessageBox.Show("選択されたフォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReacquisitionDataButton.Enabled = true;
                return;
            }

            var aEDatabaseFilePath = Path.Combine(dataFolderPath, "ItemsData.json");
            var aEDatabase = DatabaseHelper.LoadAEDatabase(aEDatabaseFilePath);
            if (aEDatabase == null)
            {
                MessageBox.Show("AvatarExplorerのデータの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReacquisitionDataButton.Enabled = true;
                return;
            }

            //データの再取得処理
            var totalItems = aEDatabase.Items.Length;
            DataReacquisitionProgressBar.Value = 0;

            var currentProgress = 0;
            foreach (var item in aEDatabase.Items)
            {
                var boothItem = await BoothHelper.GetBoothItemInfoAsync(item.BoothId);
                if (boothItem == null)
                {
                    currentProgress++;
                    DataReacquisitionProgressBar.Value = Math.Min((int)((double)currentProgress / totalItems * 100), 100);
                    Text = $"{BASE_FORM_TEXT} - {currentProgress}/{totalItems} ({DataReacquisitionProgressBar.Value}%)";
                    Task.Delay(4000).Wait();
                    continue;
                }

                item.Title = boothItem.Title;
                item.AuthorId = boothItem.AuthorId;
                item.AuthorImageUrl = boothItem.AuthorImageUrl;
                item.ThumbnailUrl = boothItem.ThumbnailUrl;

                //データの再取得処理
                if (!string.IsNullOrEmpty(boothItem.AuthorId))
                {
                    if (!Directory.Exists(Path.Combine(dataFolderPath, "AuthorImage")))
                    {
                        Directory.CreateDirectory(Path.Combine(dataFolderPath, "AuthorImage"));
                    }

                    var authorImagePath = Path.Combine(dataFolderPath, "AuthorImage", $"{boothItem.AuthorId}.png");
                    if (!File.Exists(authorImagePath))
                    {
                        if (!string.IsNullOrEmpty(boothItem.AuthorImageUrl))
                        {
                            try
                            {
                                var authorImageData = await HttpClient.GetByteArrayAsync(boothItem.AuthorImageUrl);
                                await File.WriteAllBytesAsync(authorImagePath, authorImageData);
                                item.AuthorImageFilePath = authorImagePath;
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        item.AuthorImageFilePath = authorImagePath;
                    }
                }

                currentProgress++;
                DataReacquisitionProgressBar.Value = Math.Min((int)((double)currentProgress / totalItems * 100), 100);
                Text = $"{BASE_FORM_TEXT} - {currentProgress}/{totalItems} ({DataReacquisitionProgressBar.Value}%)";
                Task.Delay(4000).Wait();
            }

            DatabaseHelper.SaveAEDatabase(aEDatabaseFilePath, aEDatabase.Items);
            MessageBox.Show("データの再取得が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReacquisitionDataButton.Enabled = true;
            DataReacquisitionProgressBar.Value = 0;
            Text = BASE_FORM_TEXT;
        }
        catch (Exception ex)
        {
            MessageBox.Show("データの再取得中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ReacquisitionDataButton.Enabled = true;
            DataReacquisitionProgressBar.Value = 0;
            Text = BASE_FORM_TEXT;
        }
    }

    private void ReacquisitionData_FormClosing(object sender, FormClosingEventArgs e)
    {
        ResetForm();
        Visible = false;
        e.Cancel = true;
    }
}
