using AETools.Core.Helper;
using AETools.Core.Models.AvatarExplorer;

namespace AETools.WinForm.SubForm;

public partial class OrganizeFolder : Form
{
    private string dataFolderPath = string.Empty;
    private string dataOutputDestination = string.Empty;
    private const string BASE_FORM_TEXT = "データ整理支援ツール";

    public OrganizeFolder()
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
                MessageBox.Show("選択されたフォルダには、ItemsData.json、Thumbnailフォルダのどちらかが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void OrganizeFolderButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrganizeFolderButton.Enabled = false;

            if (string.IsNullOrEmpty(dataFolderPath) || string.IsNullOrEmpty(dataOutputDestination))
            {
                MessageBox.Show("データフォルダまたはデータ出力先フォルダが選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OrganizeFolderButton.Enabled = true;
                return;
            }

            if (!Directory.Exists(dataFolderPath) || !Directory.Exists(dataOutputDestination))
            {
                MessageBox.Show("選択されたフォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OrganizeFolderButton.Enabled = true;
                return;
            }

            if (Directory.Exists(dataOutputDestination) && Directory.GetFiles(dataOutputDestination).Length > 0)
            {
                var result = MessageBox.Show("データ出力先フォルダにある既存のデータは削除されます。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    OrganizeFolderButton.Enabled = true;
                    return;
                }
            }

            var confirmDialogResult = MessageBox.Show("この操作は、データフォルダ内のファイルをコピーし、新しいフォルダに貼り付けます。\nこの操作は、データフォルダ内のファイルをコピーするため、容量を多く消費します。続行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmDialogResult == DialogResult.No)
            {
                OrganizeFolderButton.Enabled = true;
                return;
            }

            var aEDatabase = DatabaseHelper.LoadAEDatabase(Path.Combine(dataFolderPath, "ItemsData.json"));
            if (aEDatabase == null)
            {
                MessageBox.Show("AvatarExplorerのデータの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OrganizeFolderButton.Enabled = true;
                return;
            }

            if (Directory.Exists(dataOutputDestination)) Directory.Delete(dataOutputDestination, true);
            Directory.CreateDirectory(dataOutputDestination);

            OrganizeAvatarExplorerItems(aEDatabase.Items, dataFolderPath, dataOutputDestination);

            MessageBox.Show("データの整理が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var result2 = MessageBox.Show("今回作成したフォルダを元に新しいデータベースを作成しますか？\nもし作成するなら、現在Avatar Explorerを起動中の場合は閉じることをおすすめします！", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result2 == DialogResult.Yes)
            {
                try
                {
                    var oldPath = Path.Combine(dataFolderPath, "ItemsData.json");
                    var newPath = Path.Combine(dataFolderPath, "ItemsData.json.old");
                    File.Move(oldPath, newPath);

                    DatabaseHelper.SaveAEDatabase(oldPath, aEDatabase.Items);
                    MessageBox.Show("選択されたDatasフォルダ内に新しいデータベースを作成しました。\n元々のファイルはItemsData.json.oldに改名してあります。戻したい場合は、ItemsData.jsonを削除し、ItemsData.json.oldをItemsData.jsonに改名してください。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新しいデータベースの作成に失敗しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            OrganizeFolderButton.Enabled = true;
            DataOrganizeProgressBar.Value = 0;
            Text = BASE_FORM_TEXT;
        }
        catch (Exception ex)
        {
            MessageBox.Show("データの整理中にエラーが発生しました。\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            OrganizeFolderButton.Enabled = true;
            DataOrganizeProgressBar.Value = 0;
            Text = BASE_FORM_TEXT;
        }
    }

    private void OrganizeAvatarExplorerItems(AvatarExplorerItem[] items, string source, string destination)
    {
        var totalItems = items.Length;

        var currentProgress = 0;
        foreach (var item in items)
        {
            var itemFolderPath = item.ItemPath.Replace("./Datas", dataFolderPath);
            var thumbnailPath = item.ImagePath.Replace("./Datas", dataFolderPath);

            if (!Directory.Exists(Path.Combine(itemFolderPath))) continue;
            var folderName = Path.GetFileName(itemFolderPath);
            var dataOutputDestinationFolder = Path.Combine(dataOutputDestination, AvatarExplorerItemTypeHelper.GetCategoryName(item.Type, item.CustomCategory), folderName);

            if (!Directory.Exists(dataOutputDestinationFolder)) Directory.CreateDirectory(dataOutputDestinationFolder);
            item.ItemPath = dataOutputDestinationFolder;
            FileSystemHelper.CopyDirectory(itemFolderPath, dataOutputDestinationFolder);

            if (!string.IsNullOrEmpty(item.MaterialPath))
            {
                var materialFolderPath = item.MaterialPath.Replace("./Datas", dataFolderPath);
                if (!Directory.Exists(Path.Combine(materialFolderPath))) continue;

                var materialFolderName = Path.GetFileName(materialFolderPath);
                var dataOutputDestinationMaterialFolder = Path.Combine(dataOutputDestination, AvatarExplorerItemTypeHelper.GetCategoryName(item.Type, item.CustomCategory), folderName, materialFolderName);

                if (!Directory.Exists(dataOutputDestinationMaterialFolder)) Directory.CreateDirectory(dataOutputDestinationMaterialFolder);
                item.MaterialPath = dataOutputDestinationMaterialFolder;
                FileSystemHelper.CopyDirectory(materialFolderPath, dataOutputDestinationMaterialFolder);
            }

            currentProgress++;
            DataOrganizeProgressBar.Value = (int)((double)currentProgress / totalItems * 100);
            Text = $"{BASE_FORM_TEXT} - {currentProgress}/{totalItems} ({DataOrganizeProgressBar.Value}%)";
        }
    }

    private void OrganizeFolder_FormClosing(object sender, FormClosingEventArgs e)
    {
        ResetForm();
        Visible = false;
        e.Cancel = true;
    }
}
