
//Search a 2D Matrix

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int start = 0;
        int end = matrix[0].Length * matrix.Length - 1;
        int middle = end/2;
        while(start <= end)
        {
            Console.WriteLine('s');
            middle = (end+start) / 2;
            int first = middle / matrix[0].Length;
            int second = middle % matrix[0].Length;
            if (matrix[first][second] == target)
            {
                return true;
            }
            else if(matrix[first][second] > target)
            {
                end = middle-1;
            }
            else
            {
                start = middle+1;
            }
        }
        
        
        return false;
    }
}

class TestClass
{
    static void Main(string[] args)
    {
       
        Solution s = new Solution();
        int[][] array3D = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 4, 6 }, new int[] { 7, 8, 9 } } ;
        for (int i = -1; i < 11; i++)
        {
            Console.Write(s.SearchMatrix(array3D, i));
            Console.WriteLine(" - " + i);
        }
        
    }
}