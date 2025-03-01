public class Solution
{
    public int MaxArea(int[] lines)
    {
        int max = 0;
        int l = 0;
        int r = lines.Length - 1;

        while (l < r)
        {
            int left = lines[l];
            int right = lines[r];

            bool isLeftSmaller = left < right;
            int smaller = isLeftSmaller ? left : right;

            int area = smaller * (r - l);

            if (area > max)
            {
                max = area;
            }

            if (isLeftSmaller)
            {
                l++;
            }
            else
            {
                r--;
            }
        }

        return max;
    }
}
