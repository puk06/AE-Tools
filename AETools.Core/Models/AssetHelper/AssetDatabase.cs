namespace AETools.Core.Models.AssetHelper;

public class AssetDatabase
{
    public string title { get; set; } = string.Empty;
    public int id { get; set; }
    public string[] files { get; set; } = Array.Empty<string>();
}

