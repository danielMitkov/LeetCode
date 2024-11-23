//https://leetcode.com/problems/invert-binary-tree/solutions/5849454/c-easy-traverse-and-swap/
public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;

        Traverse(root);
        return root;
    }

    private void Traverse(TreeNode node)
    {
        (node.left, node.right) = (node.right, node.left);

        if (node.left != null)
        {
            Traverse(node.left);
        }

        if (node.right != null)
        {
            Traverse(node.right);
        }
    }
}
