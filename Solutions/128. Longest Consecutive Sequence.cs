//https://leetcode.com/problems/longest-consecutive-sequence/solutions/6130376/easy-to-read-o-n-solution/
public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        //                         num, sequence length
        var cache = new Dictionary<int, int>();
        var set = new HashSet<int>(nums);
        int result = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            if (!set.Contains(nums[i])) continue;
            int length = 0;
            int n = nums[i];

            while (true)
            {
                if (cache.ContainsKey(n))
                {
                    length += cache[n];
                    break;
                }

                if (!set.Contains(n)) break;
                length++;
                set.Remove(n);
                n++;
            }

            cache[nums[i]] = length;
            if (length > result) result = length;
        }

        return result;
    }
}
