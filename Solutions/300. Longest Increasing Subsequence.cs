public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        // store the LIS starting from each index
        int[] dp = new int[nums.Length];

        // each element is an LIS of at least 1 (itself)
        Array.Fill(dp, 1);

        int lis = 0;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            int numI = nums[i];

            for (int j = i + 1; j < nums.Length; j++)
            {
                int numJ = nums[j];

                if (numJ > numI)
                {// combine the sequences number I(1 element) + dp[j] amount of elements
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
                }
            }

            lis = Math.Max(lis, dp[i]);
        }

        return lis;
    }
}
