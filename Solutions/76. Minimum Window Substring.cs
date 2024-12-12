//https://leetcode.com/problems/minimum-window-substring/solutions/6139641/easiest-to-grasp-add-trim-check/
public class Solution
{
    public string MinWindow(string s, string t)
    {
        var map = new Dictionary<char, int>();
        var mapSub = new Dictionary<char, int>();
        foreach (char c in t)  // t char, duplicates
        {
            if (!map.ContainsKey(c)) map[c] = 0;
            map[c]++;
            mapSub[c] = 0;
        }
        int L = 0;
        int R = int.MaxValue;
        int count = 0;
        int l = 0;

        for (int r = 0; r < s.Length; ++r)
        {
            if (mapSub.ContainsKey(s[r]))
            {
                mapSub[s[r]]++; // ignore count increase if in excess
                if (mapSub[s[r]] <= map[s[r]]) count++;
            }
            l = TrimL(s, l, map, mapSub);

            if (count >= t.Length && r - l < R - L)
            {
                R = r;
                L = l;
            }
        }
        return R == int.MaxValue ? "" : s.Substring(L, R - L + 1);
    }
    private int TrimL(string s, int l, Dictionary<char, int> map, Dictionary<char, int> mapSub)
    {
        while (l + 1 < s.Length)
        {
            if (!mapSub.ContainsKey(s[l]))
            {
                l++; // if char is irrelevant to t
                continue;
            }
            if (mapSub.ContainsKey(s[l]) && mapSub[s[l]] > map[s[l]])
            {
                mapSub[s[l]]--; // if char is in excess
                l++;
                continue;
            }
            break;
        }
        return l;
    }
}
