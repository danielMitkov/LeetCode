class Solution {

    private int globalBest = -1000;

    public int maxPathSum(TreeNode root) {

        globalBest = root.val;
        Traverse(root);
        return globalBest;
    }

    private int Traverse(TreeNode node) {

        if (node == null) return -1000; // marks nulls(outside constraints)
        if (node.left == null && node.right == null) return node.val; // little optimization(unnecessary)

        int sumLeft = Traverse(node.left);
        int sumRight = Traverse(node.right);

        int[] sums = new int[6];
        sums[0] = node.val;
        sums[1] = node.val + sumLeft;
        sums[2] = node.val + sumRight;
        sums[3] = sumLeft;
        sums[4] = sumRight;
        sums[5] = sumLeft + node.val + sumRight;

        int maxSum = Max(sums);
        // record best answer so far
        if (maxSum > globalBest) globalBest = maxSum;

        // delete the impassable sums(important)
        sums[3] = -1000;
        sums[4] = -1000;
        sums[5] = -1000;

        // return adjusted best sum
        return Max(sums);
    }

    private int Max(int[] arr) {

        int max = arr[0];
        for (int i = 1; i < arr.length; i++) {

            if (arr[i] > max) max = arr[i];
        }

        return max;
    }
}
