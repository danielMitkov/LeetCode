//https://leetcode.com/problems/decode-ways/solutions/6098246/easy-solution-with-top-down-memo-in-o-n/
public class Solution
{
    public int NumDecodings(string s)
    {
        int[] nums = s.Select(c => (int)char.GetNumericValue(c)).ToArray();
        if (!CanDecode(nums)) return 0;

        int[] cache = Enumerable.Repeat(-1, nums.Length).ToArray();
        return Dfs(nums, cache, 0);
    }

    private bool CanDecode(int[] nums)
    {
        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] != 0) continue; // There must be a 1 or a 2 infront in order to use the 0
            if (i == 0 || (nums[i - 1] != 1 && nums[i - 1] != 2)) return false;
        }

        return true;
    }

    private int Dfs(int[] nums, int[] cache, int i)
    {
        if (i == nums.Length) return 1;
        if (cache[i] != -1) return cache[i];
        int ways = 0;

        if (nums[i] == 0) return ways;
        ways += Dfs(nums, cache, i + 1);

        if ((i + 1 < nums.Length) &&
           ((nums[i] == 1 && nums[i + 1] >= 0 && nums[i + 1] <= 9) ||
            (nums[i] == 2 && nums[i + 1] >= 0 && nums[i + 1] <= 6)))
        {
            ways += Dfs(nums, cache, i + 2); // The current digit + next forming a number must be in ranges 10-19 or 20-26
        }

        cache[i] = ways;
        return ways;
    }
}
