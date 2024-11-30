//https://leetcode.com/problems/house-robber/solutions/6097506/bottom-up-steps-to-figure-out/
public class Solution
{
    public int Rob(int[] nums)
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
