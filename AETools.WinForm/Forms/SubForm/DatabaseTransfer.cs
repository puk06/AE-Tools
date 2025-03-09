using AETools.Core.Helper;
using AETools.Core.Models.AvatarExplorer;
using AETools.Core.Models.KonoAsset;
using System.Text.Json;

namespace AETools.WinForm.SubForm;

public partial class DatabaseTransfer : Form
{
    private string dataFolderPath = string.Empty;
    private string dataOutputDestination = string.Empty;
    private const string BASE_FORM_TEXT = "データ移行支援ツール";

    public DatabaseTransfer()
    {
        InitializeComponent();
    }

    private void ResetForm()
    {
        AvatarExplorerDataFolderSelectLabel.Text = "未選択";
        AvatarExplorerDataFolderSelectLabel.ForeColor = Color.Red;
        DataDestinationFolderSelectLabel.Text = "未選択";
        DataDestinationFolderSelectLabel.ForeColor = Color.Red;
        dataFolderPath = string.Empty;
        dataOutputDestination = string.Empty;
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

    private void OpenDataDestinationFolderButton_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dialog = new()
        {
            Description = "データ出力先フォルダを選択してください。",
            ShowNewFolderButton = true,
            UseDescriptionForTitle = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var path = dialog.SelectedPath;
            DataDestinationFolderSelectLabel.Text = "選択済み: " + Path.GetFileName(path);
            DataDestinationFolderSelectLabel.ForeColor = Color.Green;
            dataOutputDestination = path;
        }
    }

    private void ConvertDataButton_Click(object sender, EventArgs e)
    {
        try
        {
            ConvertDataButton.Enabled = false;

            if (string.IsNullOrEmpty(dataFolderPath) || string.IsNullOrEmpty(dataOutputDestination))
            {
                MessageBox.Show("データフォルダまたはデータ出力先フォルダが選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConvertDataButton.Enabled = true;
                return;
            }

            if (!Directory.Exists(dataFolderPath) || !Directory.Exists(dataOutputDestination))
            {
                MessageBox.Show("選択されたフォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConvertDataButton.Enabled = true;
                return;
            }

            if (dataFolderPath == dataOutputDestination)
            {
                MessageBox.Show("データフォルダとデータ出力先フォルダが同じです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConvertDataButton.Enabled = true;
                return;
            }

            var confirmDialogResult = MessageBox.Show("この操作は、データフォルダ内のファイルをコピーし、新しいフォルダに貼り付けます。\nこの操作は、データフォルダ内のファイルをコピーするため、容量を多く消費します。続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDialogResult == DialogResult.No)
            {
                ConvertDataButton.Enabled = true;
                return;
            }

            if (Directory.Exists(dataOutputDestination) && Directory.GetFiles(dataOutputDestination).Length > 0)
            {
                var result = MessageBox.Show("データ出力先フォルダにある既存のデータは削除されます。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    ConvertDataButton.Enabled = true;
                    return;
                }
            }

            var aEDatabase = DatabaseHelper.LoadAEDatabase(Path.Combine(dataFolderPath, "ItemsData.json"));
            if (aEDatabase == null)
            {
                MessageBox.Show("AvatarExplorerのデータの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConvertDataButton.Enabled = true;
                return;
            }

            Directory.Delete(dataOutputDestination, true);

            var KonoAssetWearableDataBase = new KonoAssetWearableDatabase
            {
                version = 3,
                data = Array.Empty<KonoAssetWearableItem>()
            };
            var KonoAssetAvatarDataBase = new KonoAssetAvatarDatabase
            {
                version = 3,
                data = Array.Empty<KonoAssetAvatarItem>()
            };

            var currentTime = DateTime.Now;
            var totalItems = aEDatabase.Items.Length;

            DataTransferProgressBar.Value = 0;

            var currentProgress = 0;
            foreach (var itemData in aEDatabase.Items)
            {
                if (itemData == null) continue;

                var generatedID = Guid.NewGuid().ToString();
                var generatedThumbnailID = Guid.NewGuid().ToString();

                if (itemData.Type != AvatarExplorerItemType.Avatar)
                {
                    var KonoAssetData = DatabaseHelper.GenerateKonoAssetWearableDataFromAE(aEDatabase.Items, itemData, dataFolderPath, dataOutputDestination);
                    KonoAssetWearableDataBase.data = KonoAssetWearableDataBase.data.Append(KonoAssetData).ToArray();
                }
                else
                {
                    var KonoAssetData = DatabaseHelper.GenerateKonoAssetAvatarDataFromAE(itemData, dataFolderPath, dataOutputDestination);
                    KonoAssetAvatarDataBase.data = KonoAssetAvatarDataBase.data.Append(KonoAssetData).ToArray();
                }

                currentProgress++;
                DataTransferProgressBar.Value = Math.Min((int)((double)currentProgress / totalItems * 100), 100);
                Text = $"{BASE_FORM_TEXT} - {currentProgress}/{totalItems} ({DataTransferProgressBar.Value}%)";
            }

            var destinationFolder = Path.Combine(dataOutputDestination, "metadata");
            Directory.CreateDirectory(destinationFolder);

            var destinationBackupFolder = Path.Combine(dataOutputDestination, "metadata", "backups");
            Directory.CreateDirectory(destinationBackupFolder);

            File.WriteAllText(Path.Combine(destinationFolder, "avatarWearables.json"), JsonSerializer.Serialize(KonoAssetWearableDataBase, DatabaseHelper.JsonSerializerOptions));
            File.WriteAllText(Path.Combine(destinationFolder, "avatars.json"), JsonSerializer.Serialize(KonoAssetAvatarDataBase, DatabaseHelper.JsonSerializerOptions));

            MessageBox.Show("データの変換が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ConvertDataButton.Enabled = true;
            DataTransferProgressBar.Value = 0;
            Text = BASE_FORM_TEXT;
        }
        catch (Exception ex)
        {
            MessageBox.Show("データの変換中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ConvertDataButton.Enabled = true;
            DataTransferProgressBar.Value = 0;
            Text = BASE_FORM_TEXT;
        }
    }

    private void DatabaseTransfer_FormClosing(object sender, FormClosingEventArgs e)
    {
        ResetForm();
        Visible = false;
        e.Cancel = true;
    }
}
