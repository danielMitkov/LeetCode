//https://leetcode.com/problems/clone-graph/solutions/6225239/understandable-recursion/
public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;

        var firstCopy = new Node(node.val);
        var visited = new HashSet<int>();
        var copies = new Dictionary<int, Node>();

        copies.Add(firstCopy.val, firstCopy);
        Dfs(node, firstCopy, visited, copies);
        return firstCopy;
    }

    private void Dfs(Node parent, Node parentCopy, HashSet<int> visited, Dictionary<int, Node> copies)
    {
        if (visited.Contains(parent.val)) return;
        visited.Add(parent.val);

        for (int i = 0; i < parent.neighbors.Count; ++i)
        {
            Node child = parent.neighbors[i];
            Node childCopy;

            if (copies.ContainsKey(child.val)) // if copy already made
            {
                childCopy = copies[child.val]; // get the copy(object) already made
            }
            else
            {
                childCopy = new Node(child.val); // create new copy
                copies.Add(childCopy.val, childCopy); // remember copy object reference
            }

            parentCopy.neighbors.Add(childCopy);
            Dfs(child, childCopy, visited, copies); // can be extracted below for simplicity
        }

        //for (int i = 0; i < parentCopy.neighbors.Count; ++i)
        //{
        //    Dfs(parent.neighbors[i], parentCopy.neighbors[i], visited, copies);
        //}
    }
}
