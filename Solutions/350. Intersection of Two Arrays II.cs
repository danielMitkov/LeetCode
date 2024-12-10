//https://leetcode.com/problems/intersection-of-two-arrays-ii/solutions/6133294/easy-to-understand-hashset/
public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums1.Length < nums2.Length)
        {
            return GetIntersection(nums1, nums2);
        }

        return GetIntersection(nums2, nums1);
    }

    private int[] GetIntersection(int[] numsSmaller, int[] numsBigger)
    {
        //                       num, amount of duplicates
        var map = new Dictionary<int, int>();

        foreach (int num in numsSmaller)
        {
            if (!map.ContainsKey(num))
            {
                map.Add(num, 1);
                continue;
            }

            map[num] += 1;
        }

        var result = new List<int>();

        foreach (int num in numsBigger)
        {
            if (map.ContainsKey(num) && map[num] > 0)
            {
                result.Add(num);
                map[num]--;
            }
        }

        return result.ToArray();
    }
}
