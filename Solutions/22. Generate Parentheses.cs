public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();
        RECCURSION(result, n, 0, 0, "");
        return result;
    }
    private void RECCURSION(List<string> result, int n, int openCount, int closedCount, string seq)
    {
        if (seq.Length == n * 2)
        {
            result.Add(seq);
            return;
        }
        if (openCount < n)
        {
            RECCURSION(result, n, openCount + 1, closedCount, seq + "(");
        }
        if (closedCount < openCount)
        {
            RECCURSION(result, n, openCount, closedCount + 1, seq + ")");
        }
    }
}
