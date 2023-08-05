public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution
{

    public static TreeNode BuildTreeFromArray(int[] array, int fantomI = 0)
    {
        TreeNode root = new TreeNode(array[fantomI]);
        root.left = BuildTreeFromArray(array, ++fantomI);
        root.right = BuildTreeFromArray(array);

        return root;
    }
    public IList<TreeNode> GenerateTrees(int n)
    {
        List<TreeNode> Tree = new List<TreeNode>();
        int[] iList = new int[n - 1];
        int[] List_ = new int[n];
        for (int i = 1; i < n; i++)
            iList[i - 1] = i;
        for (int i = 1; i <= n; i++)
            List_[i - 1] = i;
        {
            TreeNode tNode = BuildTreeFromArray(List_);
            if (!Tree.Contains(tNode))
            {
                Tree.Add(tNode);
            }


        }
        for (int i = 0; iList.Sum() != 0; i++)
        {
            if (iList[i] != 0)
            {
                (List_[i], List_[i + 1]) = (List_[i + 1], List_[i]);
                {
                    TreeNode tNode = BuildTreeFromArray(List_);
                    if (!Tree.Contains(tNode))
                    {
                        Tree.Add(tNode);
                    }
                }
                iList[i] -= 1;
                for (int j = 1; j <= i; j++)
                    iList[j - 1] = j;
                i = -1;
            }
            else
            {
                continue;
            }
        }
        return Tree;
    }
}

class TestClass
{
    static void Main(string[] args)
    {

        Solution s = new Solution();
        s.GenerateTrees(3);
    }
}