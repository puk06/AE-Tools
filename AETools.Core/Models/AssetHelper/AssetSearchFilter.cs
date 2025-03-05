namespace AETools.Core.Models.AssetHelper;

public class AssetSearchFilter
{
    public int boothId { get; set; }
    public string folderName { get; set; } = string.Empty;
    public int matchRate { get; set; } = 0;
}