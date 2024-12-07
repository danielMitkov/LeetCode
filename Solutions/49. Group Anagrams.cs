//https://leetcode.com/problems/group-anagrams/solutions/6123603/a-normal-solution-you-can-come-up-with-in-an-interview/
public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            string sorted = new([.. strs[i].OrderBy(c => c)]);

            if (map.ContainsKey(sorted))
            {
                map[sorted].Add(strs[i]);
                continue;
            }

            map.Add(sorted, [strs[i]]);
        }

        return map.Values.ToList();
    }
}
