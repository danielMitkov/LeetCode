//https://leetcode.com/problems/check-completeness-of-a-binary-tree/solutions/6164713/one-loop-explicit-code/
public class Solution
{
    public bool IsCompleteTree(TreeNode root)
    {
        var queue = new Queue<TreeNode>([root]);
        bool hasSeenNull = false;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null)
            {
                hasSeenNull = true;
                continue;
            }

            if (hasSeenNull && node != null)
            {
                return false;
            }

            if (node != null)
            {
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        return true;
    }
}
