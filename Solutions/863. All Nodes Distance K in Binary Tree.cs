//https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/solutions/6175162/simple-build-graph-search-graph/
public class Solution
{
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        var graph = new Dictionary<int, List<int>>();
        BuildGraph(root, -1, graph);

        var result = new List<int>();
        var visited = new HashSet<int>();
        SearchGraph(target.val, k, graph, result, visited);
        return result;
    }

    private void BuildGraph(TreeNode node, int parent, Dictionary<int, List<int>> graph)
    {
        if (node == null) return;

        var edges = new List<int>();
        if (node.left != null) edges.Add(node.left.val);
        if (node.right != null) edges.Add(node.right.val);

        graph.Add(node.val, edges);
        if (parent != -1) graph[node.val].Add(parent);

        BuildGraph(node.left, node.val, graph);
        BuildGraph(node.right, node.val, graph);
    }

    private void SearchGraph(int key, int k, Dictionary<int, List<int>> graph, List<int> result, HashSet<int> visited)
    {
        if (k == 0) result.Add(key);

        visited.Add(key);
        var edges = graph[key];

        foreach (int edge in edges)
        {
            if (visited.Contains(edge)) continue;
            SearchGraph(edge, k - 1, graph, result, visited);
        }
    }
}
