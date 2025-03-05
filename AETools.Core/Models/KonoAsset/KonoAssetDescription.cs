namespace AETools.Core.Models.KonoAsset;

public class KonoAssetDescription
{
    public string name { get; set; } = "";
    public string creator { get; set; } = "";
    public string imageFilename { get; set; } = "";
    public string[] tags { get; set; } = Array.Empty<string>();
    public string? memo { get; set; } = null;
    public int? boothItemId { get; set; } = null;
    public string[] dependencies { get; set; } = Array.Empty<string>();
    public long createdAt { get; set; } = 0;
    public long publishedAt { get; set; } = 0;
}