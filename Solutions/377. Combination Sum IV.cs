public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        int[] cache = new int[target];
        Array.Fill(cache, -1);

        return Traverse(nums, target, cache, 0);
    }

    private int Traverse(int[] nums, int target, int[] cache, int sum)
    {
        if (sum > target) return 0;
        if (sum == target) return 1;
        if (cache[sum] != -1) return cache[sum];

        int combinations = 0;

        foreach (int num in nums)
        {
            combinations += Traverse(nums, target, cache, sum + num);
        }

        cache[sum] = combinations;
        return combinations;
    }
}
