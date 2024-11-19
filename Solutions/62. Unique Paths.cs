public class Solution
{
    public int UniquePaths(int m, int n, Dictionary<(int, int), int> cache = null)
    {
        cache ??= new Dictionary<(int, int), int>();

        var key = (m, n);

        if (cache.ContainsKey(key)) return cache[key];

        if (m == 1 && n == 1) return 1;
        if (m == 0 || n == 0) return 0;

        cache[key] = UniquePaths(m - 1, n, cache) + UniquePaths(m, n - 1, cache);

        return cache[key];
    }
}
