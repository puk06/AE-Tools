using AETools.Core.Models.AvatarExplorer;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace AETools.Core.Helper;

public class BoothHelper
{
    private static readonly HttpClient HttpClient = new();

    /// <summary>
    ///　Boothのアイテム情報を取得します。
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static async Task<AvatarExplorerItem?> GetBoothItemInfoAsync(int id)
    {
        try
        {
            var url = $"https://booth.pm/ja/items/{id.ToString()}.json";
            var response = await HttpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            var title = json["name"]?.ToString() ?? "";
            var author = json["shop"]?["name"]?.ToString() ?? "";
            var authorUrl = json["shop"]?["url"]?.ToString() ?? "";
            var imageUrl = json["images"]?.Count() > 0 ? json["images"]?[0]?["original"]?.ToString() ?? "" : "";
            var authorIcon = json["shop"]?["thumbnail_url"]?.ToString() ?? "";
            var authorId = GetAuthorId(authorUrl);
            var category = json["category"]?["name"]?.ToString() ?? "";

            return new AvatarExplorerItem
            {
                Title = title,
                AuthorName = author,
                ThumbnailUrl = imageUrl,
                AuthorImageUrl = authorIcon,
                AuthorId = authorId
            };
        }
        catch
        {
            return null;
        }
    }

    private static string GetAuthorId(string url)
    {
        var match = Regex.Match(url, @"https://(.*)\.booth\.pm/");
        return match.Success ? match.Groups[1].Value : "";
    }
}
