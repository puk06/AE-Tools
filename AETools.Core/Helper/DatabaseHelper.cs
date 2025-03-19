using AETools.Core.Models.AvatarExplorer;
using AETools.Core.Models.KonoAsset;
using AETools.Core.Models.AssetHelper;
using System.Text.Json;
using System.Diagnostics;

namespace AETools.Core.Helper;

public class DatabaseHelper
{
    public static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    /// <summary>
    /// AvatarExplorerのデータベースを読み込みます。
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static AvatarExplorerDatabase? LoadAEDatabase(string path)
    {
        try
        {
            var items = JsonSerializer.Deserialize<AvatarExplorerItem[]>(File.ReadAllText(path));
            return items == null ? null : new AvatarExplorerDatabase { Items = items };
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// AvatarExplorerのデータベースを保存します。
    /// </summary>
    /// <param name="path"></param>
    /// <param name="data"></param>
    public static void SaveAEDatabase(string path, AvatarExplorerItem[] data)
    {
        var json = JsonSerializer.Serialize(data, JsonSerializerOptions);
        File.WriteAllText(path, json);
    }

    /// <summary>
    /// KonoAssetのデータベースを読み込みます。
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static KonoAssetWearableDatabase? LoadKADatabase(string path)
    {
        try
        {
            return JsonSerializer.Deserialize<KonoAssetWearableDatabase>(File.ReadAllText(path));
        }
        catch (Exception exeption)
        {
            Debug.WriteLine(exeption);
            return null;
        }
    }

    /// <summary>
    /// KonoAssetのデータベースを保存します。
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static AssetDatabase[]? LoadAssetDatabase(string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<AssetDatabase[]>(json);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// KonoAssetのアバターデータを作成、コピーします。
    /// </summary>
    /// <param name="avatarExplorerItem"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public static KonoAssetAvatarItem GenerateKonoAssetAvatarDataFromAE(AvatarExplorerItem avatarExplorerItem, string source, string destination)
    {
        var itemId = Guid.NewGuid().ToString();
        var thumbnailId = Guid.NewGuid().ToString();
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        var data = new KonoAssetAvatarItem
        {
            id = itemId,
            description = new KonoAssetDescription
            {
                name = avatarExplorerItem.Title,
                creator = avatarExplorerItem.AuthorName,
                imageFilename = thumbnailId + ".jpg",
                tags = Array.Empty<string>(),
                memo = string.IsNullOrWhiteSpace(avatarExplorerItem.ItemMemo) ? null : avatarExplorerItem.ItemMemo,
                boothItemId = avatarExplorerItem.BoothId == -1 ? null : avatarExplorerItem.BoothId,
                dependencies = Array.Empty<string>(),
                createdAt = currentTime,
                publishedAt = currentTime
            }
        };

        CopyDataForKonoAssetItem(itemId, thumbnailId, avatarExplorerItem, source, destination);

        return data;
    }

    /// <summary>
    /// KonoAssetのアイテムデータを作成、コピーします。
    /// </summary>
    /// <param name="items"></param>
    /// <param name="avatarExplorerItem"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public static KonoAssetWearableItem GenerateKonoAssetWearableDataFromAE(AvatarExplorerItem[] items, AvatarExplorerItem avatarExplorerItem, string source, string destination)
    {
        var itemId = Guid.NewGuid().ToString();
        var thumbnailId = Guid.NewGuid().ToString();
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        var data = new KonoAssetWearableItem
        {
            id = itemId,
            description = new KonoAssetDescription
            {
                name = avatarExplorerItem.Title,
                creator = avatarExplorerItem.AuthorName,
                imageFilename = thumbnailId + ".jpg",
                tags = Array.Empty<string>(),
                memo = string.IsNullOrWhiteSpace(avatarExplorerItem.ItemMemo) ? null : avatarExplorerItem.ItemMemo,
                boothItemId = avatarExplorerItem.BoothId == -1 ? null : avatarExplorerItem.BoothId,
                dependencies = Array.Empty<string>(),
                createdAt = currentTime,
                publishedAt = currentTime
            },
            category = AvatarExplorerItemTypeHelper.GetCategoryName(avatarExplorerItem.Type, avatarExplorerItem.CustomCategory),
            supportedAvatars = GetSupportedAvatarNameFromPath(items, avatarExplorerItem.SupportedAvatar),
        };

        CopyDataForKonoAssetItem(itemId, thumbnailId, avatarExplorerItem, source, destination);

        return data;
    }

    private static void CopyDataForKonoAssetItem(string itemId, string? thumbnailId, AvatarExplorerItem avatarExplorerItem, string source, string destination)
    {
        if (string.IsNullOrEmpty(destination)) return;

        var itemFolderPath = FixRelativePathForAE(avatarExplorerItem.ItemPath, source);
        var thumbnailPath = FixRelativePathForAE(avatarExplorerItem.ImagePath, source);

        //フォルダをコピーする
        if (!Directory.Exists(Path.Combine(itemFolderPath))) return;
        var folderName = Path.GetFileName(itemFolderPath);
        var destinationFolder = Path.Combine(destination, "data", itemId, folderName);
        if (!Directory.Exists(destinationFolder)) Directory.CreateDirectory(destinationFolder);
        FileSystemHelper.CopyDirectory(itemFolderPath, destinationFolder);

        //マテリアルパスがからじゃなければコピー
        if (!string.IsNullOrEmpty(avatarExplorerItem.MaterialPath))
        {
            var materialFolderPath = FixRelativePathForAE(avatarExplorerItem.MaterialPath, source);
            if (!Directory.Exists(Path.Combine(materialFolderPath))) return;
            var materialFolderName = Path.GetFileName(materialFolderPath);
            var destinationMaterialFolder = Path.Combine(destination, "data", itemId, folderName, materialFolderName);
            if (!Directory.Exists(destinationMaterialFolder)) Directory.CreateDirectory(destinationMaterialFolder);
            FileSystemHelper.CopyDirectory(materialFolderPath, destinationMaterialFolder);
        }

        //サムネイルをコピーする
        if (thumbnailId == null || !File.Exists(thumbnailPath)) return;
        if (!Directory.Exists(Path.Combine(destination, "images"))) Directory.CreateDirectory(Path.Combine(destination, "images"));
        File.Copy(thumbnailPath, Path.Combine(destination, "images", thumbnailId + ".jpg"));
    }

    private static string[] GetSupportedAvatarNameFromPath(AvatarExplorerItem[] items, string[] supportedAvatars)
    {
        var supportedAvatarNames = new List<string>();
        foreach (var avatar in supportedAvatars)
        {
            var avatarData = items.FirstOrDefault(x => x.ItemPath == avatar);
            if (avatarData != null)
            {
                supportedAvatarNames.Add(avatarData.Title.Replace(" ", ""));
            }
        }

        return supportedAvatarNames.ToArray();
    }

    public static string FixRelativePathForAE(string path, string dataFolderPath)
    {
        if (path.StartsWith("./Datas"))
        {
            return path.Replace("./Datas", dataFolderPath);
        }
        else if (path.StartsWith("Datas"))
        {
            return path.Replace("Datas", dataFolderPath);
        }
        else
        {
            return path;
        }
    }
}
