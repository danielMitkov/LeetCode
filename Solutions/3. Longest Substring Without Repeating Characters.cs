//https://leetcode.com/problems/longest-substring-without-repeating-characters/solutions/6123925/sliding-window-hashset/
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s == string.Empty) return 0;
        var set = new HashSet<char>() { s[0] };
        int i = 1;
        int len = 1;
        int leftI = 0;
        int rigthI = 0;

        while (i < s.Length)
        {
            if (!set.Contains(s[i]))
            {
                set.Add(s[i]);
                if (set.Count > len) len = set.Count;
                rigthI++;
                i++;
                continue;
            }

            set.Remove(s[leftI]);
            leftI++;
        }

        return len;
    }
}
