namespace AETools.Core.Helper;

public static class CalculationHelper
{
    /// <summary>
    /// 文字列の類似度を計算します。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static double CalculateSimilarity(string source, string target)
    {
        int maxLength = Math.Max(source.Length, target.Length);
        if (maxLength == 0) return 100.0;

        int distance = LevenshteinDistance(source, target);
        return (1.0 - (double)distance / maxLength) * 100;
    }

    private static int LevenshteinDistance(string s1, string s2)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int[,] dp = new int[len1 + 1, len2 + 1];

        for (int i = 0; i <= len1; i++) dp[i, 0] = i;
        for (int j = 0; j <= len2; j++) dp[0, j] = j;

        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                dp[i, j] = Math.Min(Math.Min(
                    dp[i - 1, j] + 1,      // 削除
                    dp[i, j - 1] + 1),     // 挿入
                    dp[i - 1, j - 1] + cost // 置換
                );
            }
        }

        return dp[len1, len2];
    }
}
