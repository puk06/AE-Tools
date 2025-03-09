namespace AETools.Core.Helper;

public class FileSystemHelper
{
    /// <summary>
    /// ディレクトリをコピーします。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    public static void CopyDirectory(string source, string destination)
    {
        DirectoryInfo sourceInfo = new(source);
        DirectoryInfo destinationInfo = new(destination);

        if (!destinationInfo.Exists)
        {
            destinationInfo.Create();
        }

        foreach (FileInfo file in sourceInfo.GetFiles())
        {
            file.CopyTo(Path.Combine(destination, file.Name), true);
        }

        foreach (DirectoryInfo directory in sourceInfo.GetDirectories())
        {
            CopyDirectory(directory.FullName, Path.Combine(destination, directory.Name));
        }
    }
}
