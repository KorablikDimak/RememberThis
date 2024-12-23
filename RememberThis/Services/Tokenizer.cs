namespace RememberThis.Services;

public static class Tokenizer
{
    public static double CompareStrings(string str1, string str2)
    {
        var tokens1 = str1.Split().Where(token => token.Length != 0).ToList();
        var tokens2 = str2.Split().Where(token => token.Length != 0).ToList();
        
        var commonWordsCount = tokens1.Count(word => tokens2.Contains(word));
        return (double) commonWordsCount / Math.Max(tokens1.Count, tokens2.Count);
    }
}