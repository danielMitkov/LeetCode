//https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/solutions/6125733/only-2-variables-proper-solution-o-n-o-1/
public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int l = 0;
        int r = 0;

        while (r < haystack.Length)
        {
            if (haystack[r] == needle[r - l])
            {
                r++;
                if (r - l == needle.Length) return l;
                continue;
            }

            l++;
            r = l;
        }

        return -1;
    }
}
