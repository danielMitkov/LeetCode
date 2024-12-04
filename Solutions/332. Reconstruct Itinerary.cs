//https://leetcode.com/problems/reconstruct-itinerary/solutions/6112908/nlogn-backtracking/
public class Solution
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var map = new Dictionary<string, List<string>>();

        tickets = tickets.OrderByDescending(pair => pair[1]).ToList();

        foreach (var pair in tickets)
        {
            string key = pair[0];
            string value = pair[1];

            if (!map.ContainsKey(key))
            {
                map.Add(key, new List<string>() { value });
                continue;
            }

            map[key].Add(value);
        }

        IList<string> result = new List<string>();
        string jfk = "JFK";
        Dfs(result, map, jfk);

        result = result.Reverse().ToList();
        return result;
    }

    private void Dfs(IList<string> result, Dictionary<string, List<string>> map, string ticket)
    {
        while (map.ContainsKey(ticket))
        {
            List<string> destinations = map[ticket];
            if (destinations.Count == 0) break;

            string nextDest = destinations[destinations.Count - 1];
            destinations.RemoveAt(destinations.Count - 1);

            Dfs(result, map, nextDest);
        }

        result.Add(ticket);
    }
}
