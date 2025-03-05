﻿namespace AETools.Core.Models.AvatarExplorer;

public class AvatarExplorerItem
{
    public string Title { get; set; } = "";
    public string AuthorName { get; set; } = "";
    public string ItemMemo { get; set; } = "";
    public string AuthorId { get; set; } = "";
    public int BoothId { get; set; } = -1;
    public string ItemPath { get; set; } = "";
    public string MaterialPath { get; set; } = "";
    public string ThumbnailUrl { get; set; } = "";
    public string ImagePath { get; set; } = "";
    public string AuthorImageUrl { get; set; } = "";
    public string AuthorImageFilePath { get; set; } = "";
    public AvatarExplorerItemType Type { get; set; }
    public string CustomCategory { get; set; } = "";
    public string[] SupportedAvatar { get; set; } = Array.Empty<string>();
    public string CreatedDate { get; set; } = "";
    public string UpdatedDate { get; set; } = "";
}

