namespace RememberThis.Services;

public static class Tokenizer
{
    public static double CompareStrings(string str1, string str2)
    {
        var tokens1 = str1.Split().ToList();
        var tokens2 = str2.Split().ToList();
        
        var commonWordsCount = tokens1.Count(word => tokens2.Contains(word));
        return (double) commonWordsCount / Math.Max(tokens1.Count, tokens2.Count);
    }
}