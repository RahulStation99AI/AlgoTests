
public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int val)
    {
        Val = val;
    }
}

public class BSTIterator
{
    private TreeNode current;

    public BSTIterator(TreeNode root)
    {
        current = root;
    }

    public bool HasNext()
    {
        return current != null;
    }

    public int Next()
    {
        int result = -1;

        while (current != null)
        {
            if (current.Left == null)
            {
                result = current.Val;
                current = current.Right;
                break;
            }
            else
            {
                TreeNode predecessor = current.Left;
                while (predecessor.Right != null && predecessor.Right != current)
                {
                    predecessor = predecessor.Right;
                }

                if (predecessor.Right == null)
                {
                    predecessor.Right = current;
                    current = current.Left;
                }
                else
                {
                    predecessor.Right = null;
                    result = current.Val;
                    current = current.Right;
                    break;
                }
            }
        }

        return result;
    }

   

}