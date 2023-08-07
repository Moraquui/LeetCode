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

public class Solution
{
    public static bool Equals_(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null)
        {
            return true;
        }
        if (t1 == null || t2 == null)
        {
            return false;
        }
        return t1.val == t2.val && Equals_(t1.left, t2.left) && Equals_(t1.right, t2.right);
    }
    public static TreeNode BuildTreeFromArray(int[] array)
    {
        TreeNode root = new TreeNode(array[0]);
        int[] array_ = array.Where((x) => x > array[0]).ToArray();
        int[] array1_ = array.Where((x) => x < array[0]).ToArray();
        if (array1_.Length >= 1)
        {
            root.left = BuildTreeFromArray(array1_);
        }
        if (array_.Length >= 1)
        {
            root.right = BuildTreeFromArray(array_);
        }


        return root;
    }
    public static List<List<T>> GetAllElementCombinations<T>(T[] arr)
    {
        List<List<T>> result = new List<List<T>>();
        GenerateElementCombinations(arr, new List<T>(), result);
        return result;
    }

    private static void GenerateElementCombinations<T>(T[] arr, List<T> current, List<List<T>> result)
    {
        if (current.Count == arr.Length)
        {
            result.Add(new List<T>(current));
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (!current.Contains(arr[i]))
            {
                current.Add(arr[i]);
                GenerateElementCombinations(arr, current, result);
                current.Remove(arr[i]);
            }
        }
    }
    public IList<TreeNode> GenerateTrees(int n)
    {
        List<TreeNode> Tree = new List<TreeNode>();
        int[] iList = new int[n];
        int[] List_ = new int[n];
        for (int i = 1; i < n; i++)
            iList[i] = i;
        for (int i = 1; i <= n; i++)
            List_[i - 1] = i;

        List<List<int>> combinations = GetAllElementCombinations(List_);
        combinations.ForEach(yy => {
            TreeNode y = BuildTreeFromArray(yy.ToArray());
            if (!(Tree.Where((x) => Equals_(x, y)).Count() >= 1))
            {
                Tree.Add(y);
            }
        });
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