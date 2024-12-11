public class Solution
{
    public int[][] Merge(int[][] pairs)
    {
        pairs = pairs.OrderBy(arr => arr[0]).ToArray(); // sort by the start number
        List<int[]> result = [];

        int i = 0;
        while (i < pairs.Length)
        {
            if (i == pairs.Length - 1 || pairs[i][1] < pairs[i + 1][0]) // if i is last, there no comparison OR if they don't overlap
            {
                result.Add(pairs[i]);
                i++;
                continue;
            }

            int[] current = [.. pairs[i]];
            int j = i + 1;
            while (j < pairs.Length && current[1] >= pairs[j][0]) // if there is next element && current end overlaps with next start
            {
                current[1] = Math.Max(current[1], pairs[j][1]); // update the end to whichever is bigger
                j++;
            }

            result.Add(current); // add the accumulated current
            i = j; // continue at the furthest reached element that is not joined
        }

        return result.ToArray();
    }
}
