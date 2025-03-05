using AETools.Core.Models.AvatarExplorer;

namespace AETools.Core.Helper;

public class AvatarExplorerItemTypeHelper
{
    /// <summary>
    /// カテゴリー名を取得します。
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="customCategory"></param>
    /// <returns></returns>
    public static string GetCategoryName(AvatarExplorerItemType itemType, string customCategory)
    {
        return itemType switch
        {
            AvatarExplorerItemType.Avatar => "アバター",
            AvatarExplorerItemType.Clothing => "衣装",
            AvatarExplorerItemType.Texture => "テクスチャ",
            AvatarExplorerItemType.Gimmick => "ギミック",
            AvatarExplorerItemType.Accessory => "アクセサリー",
            AvatarExplorerItemType.HairStyle => "髪型",
            AvatarExplorerItemType.Animation => "アニメーション",
            AvatarExplorerItemType.Tool => "ツール",
            AvatarExplorerItemType.Shader => "シェーダー",
            AvatarExplorerItemType.Custom => customCategory,
            _ => "不明"
        };
    }
}
