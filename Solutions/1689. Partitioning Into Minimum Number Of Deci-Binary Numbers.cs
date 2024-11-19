public class Solution
{
    public int MinPartitions(string n)
    {
        int[] digits = n.Select(c => (int)char.GetNumericValue(c)).ToArray();

        int result = 0;

        while (digits.Any(d => d > 0))
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] > 0)
                {
                    digits[i]--;
                }
            }
            result++;
        }
        return result;
    }
}
