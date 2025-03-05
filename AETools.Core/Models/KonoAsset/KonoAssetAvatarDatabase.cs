namespace AETools.Core.Models.KonoAsset;

public class KonoAssetAvatarDatabase
{
    public int version { get; set; } = 3;
    public KonoAssetAvatarItem[] data { get; set; } = Array.Empty<KonoAssetAvatarItem>();
}
