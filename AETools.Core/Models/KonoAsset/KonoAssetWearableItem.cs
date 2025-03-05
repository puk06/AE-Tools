namespace AETools.Core.Models.KonoAsset;

public class KonoAssetWearableItem
{
    public string id { get; set; } = string.Empty;
    public KonoAssetDescription description { get; set; } = new KonoAssetDescription();
    public string category { get; set; } = "";
    public string[] supportedAvatars { get; set; } = Array.Empty<string>();
}