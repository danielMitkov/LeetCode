public class Solution
{
    public string LongestPalindrome(string s)
    {
        char[] chars = s.ToCharArray();
        int globalL = 0;
        int globalR = 0;
        int globalLength = 0;

        for (int i = 0; i < chars.Length; ++i)
        {
            int l = i;
            int r = i;

            var coords = CreatePalindrome(chars, l, r);
            int length = 1 + coords.rightI - coords.leftI;

            if (r + 1 < chars.Length && chars[l] == chars[r + 1])
            {
                var coords2 = CreatePalindrome(chars, l, r + 1);
                int length2 = 1 + coords2.rightI - coords2.leftI;

                if (length2 > length)
                {
                    length = length2;
                    coords = coords2;
                }
            }

            if (length > globalLength)
            {
                globalL = coords.leftI;
                globalR = coords.rightI;
                globalLength = length;
            }
        }

        var strBuilder = new StringBuilder();

        for (int j = globalL; j <= globalR; ++j)
        {
            strBuilder.Append(chars[j]);
        }

        string result = strBuilder.ToString();
        return result;
    }

    private (int leftI, int rightI) CreatePalindrome(char[] chars, int l, int r)
    {
        while (true)
        {
            l--;
            r++;

            if (l < 0 || r == chars.Length || chars[l] != chars[r]) // if invalid
            {
                l++; // backtrack to valid range
                r--;
                break;
            }
        }

        return (l, r);
    }
}
