//https://leetcode.com/problems/house-robber-ii/solutions/6097704/how-i-solved-it/
public class Solution
{
    public int Rob(int[] nums) // Second to Last, First to Before Last
    {
        if (nums.Length == 1) return nums[0];
        return Math.Max(Robbery(nums.Skip(1).ToArray()), Robbery(nums.SkipLast(1).ToArray()));
    }

    private int Robbery(int[] nums)
    {
        int[] dp = nums.ToArray(); // Copy the nums array values

        for (int i = nums.Length - 1; i >= 0; i--) // Create a sequence starting from every I element included
        {
            for (int j = i + 2; j <= i + 3 && j < nums.Length; j++) // Go to the right of I element 2 and 3 steps
            {
                dp[i] = Math.Max(dp[i], nums[i] + dp[j]); // Take either the previous sequence or the new sequence
            }
        }

        return Math.Max(dp[0], nums.Length > 1 ? dp[1] : 0); // Take the first or second element if it exists
    }
}
