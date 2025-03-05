using AETools.Core.Helper;
using AETools.Core.Models.AssetHelper;

namespace AETools.WinForm.SubForm;

public partial class AssetHelper : Form
{
    private AssetDatabase[] assetDatabases = Array.Empty<AssetDatabase>();

    public AssetHelper()
    {
        InitializeComponent();
        FolderNameTextBox.Enabled = false;
    }

    private void ResetForm()
    {
        assetDatabases = Array.Empty<AssetDatabase>();
        DataBaseFileLabel.Text = "未選択";
        DataBaseFileLabel.ForeColor = Color.Red;
        FolderNameTextBox.Text = string.Empty;
        FolderNameTextBox.Enabled = false;
        SuggestedBoothItemList.Items.Clear();
        AllowDrop = false;
    }

    private void OpenDatabaseFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new()
        {
            Filter = "Asset Database|*.json"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var path = dialog.FileName;
            var data = DatabaseHelper.LoadAssetDatabase(path);
            if (data == null)
            {
                MessageBox.Show("データベースの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            assetDatabases = data;
            DataBaseFileLabel.Text = "選択済み: " + Path.GetFileName(path) + " (" + data.Length + "個のデータ)";
            DataBaseFileLabel.ForeColor = Color.Green;
            FolderNameTextBox.Enabled = true;
            AllowDrop = true;
        }
    }

    private void FolderNameTextBox_TextChanged(object sender, EventArgs e)
    {
        SuggestedBoothItemList.Items.Clear();

        var folderName = FolderNameTextBox.Text;
        if (string.IsNullOrWhiteSpace(folderName)) return;

        var folderNameHasExtension = folderName.EndsWith(".zip");

        var list = new List<AssetSearchFilter>();
        foreach (var database in assetDatabases)
        {
            var bestMatch = 0;
            foreach (var item in database.files)
            {
                var fileName = folderNameHasExtension ? item : Path.GetFileNameWithoutExtension(item);

                var matchRate = (int)CalculationHelper.CalculateSimilarity(folderName, fileName);
                if (matchRate > bestMatch) bestMatch = matchRate;
            }

            list.Add(new AssetSearchFilter
            {
                boothId = database.id,
                folderName = database.title,
                matchRate = bestMatch
            });
        }

        list = list.OrderByDescending(x => x.matchRate).ToList();
        foreach (var item in list)
        {
            SuggestedBoothItemList.Items.Add(item.boothId + " - " + item.folderName + " (一致率: " + item.matchRate + "%)");
        }
    }

    private void AssetHelper_DragDrop(object sender, DragEventArgs e)
    {
        var files = (string[]?)e.Data?.GetData(DataFormats.FileDrop);
        if (files == null || files.Length == 0) return;

        var folderName = Path.GetFileName(files[0]);
        if (string.IsNullOrWhiteSpace(folderName)) return;

        FolderNameTextBox.Text = folderName;
    }

    private void AssetHelper_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Copy;

    private void AssetHelper_FormClosing(object sender, FormClosingEventArgs e)
    {
        ResetForm();
        Visible = false;
        e.Cancel = true;
    }
}