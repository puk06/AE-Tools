using AETools.WinForm.SubForm;

namespace AETools.WinForm.MainForm;

public partial class Main : Form
{
    private DatabaseTransfer databaseTransfer = new();
    private OrganizeFolder organizeFolder = new();
    private AssetHelper assetHelper = new();


    public Main()
    {
        InitializeComponent();
    }

    private void DatabaseTransfer_Click(object sender, EventArgs e)
    {
        databaseTransfer.Visible = true;
    }

    private void OrganizeFolder_Click(object sender, EventArgs e)
    {
        organizeFolder.Visible = true;
    }

    private void AssetHelper_Click(object sender, EventArgs e)
    {
        assetHelper.Visible = true;
    }
}

