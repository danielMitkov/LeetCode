public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int slowI = 0;
        int fastI = 0;
        bool haveMet = false;

        while (true)
        {
            slowI = nums[slowI];
            fastI = nums[fastI];

            if (!haveMet) fastI = nums[fastI];

            if (haveMet && slowI == fastI) return slowI;

            if (!haveMet && nums[slowI] == nums[fastI])
            {
                haveMet = true;
                slowI = 0;
            }
        }
    }
}
