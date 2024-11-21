public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        return Traverse(root, 0);
    }

    private int Traverse(TreeNode node, int depth)
    {
        if (node == null) return depth;

        depth++;

        int depthLeft = Traverse(node.left, depth);
        int depthRigth = Traverse(node.right, depth);

        return Math.Max(depthLeft, depthRigth);
    }
}
