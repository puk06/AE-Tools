namespace AETools.Core.Models.KonoAsset;

public class KonoAssetWearableDatabase
{
    public int version { get; set; } = 3;
    public KonoAssetWearableItem[] data { get; set; } = Array.Empty<KonoAssetWearableItem>();
}
