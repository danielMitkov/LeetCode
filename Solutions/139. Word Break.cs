//https://leetcode.com/problems/word-break/solutions/6082773/readable-1-millisecond-o-n-m-w/
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var cache = new Dictionary<int, bool>();
        return Traverse(s, 0, wordDict, cache);
    }

    private bool Traverse(string str, int strI, IList<string> words, Dictionary<int, bool> cache)
    {
        if (cache.ContainsKey(strI)) return cache[strI];
        if (strI == str.Length) return cache[strI] = true;

        foreach (string word in words)
        {
            if (strI + word.Length >= str.Length + 1) continue;

            string potencialWord = str.Substring(strI, word.Length);

            if (word.Equals(potencialWord) && Traverse(str, strI + word.Length, words, cache))
            {
                return cache[strI] = true;
            }
        }

        return cache[strI] = false;
    }
}
