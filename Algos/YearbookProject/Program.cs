using System;

/// <summary>
/// Main program class that runs various algorithm tests
/// </summary>
class Program 
{
   
    static void Main(string[] args) 
    {
        TestBST();

        
        //var sol = new Solution();
        Console.WriteLine(" Find Pair Sums ");
        PairSums.Test();
        
        Console.WriteLine(" FindSum of Nubers ");
        SubSumInArray.RunTest();
        
        Console.WriteLine("Running Algorithm Tests\n");

        // Test PassingYearbooks
        var yearBookResult = PassingYearbooks.RunTest();
        
        // Test SubArraysCount
        var subArrayResult = SubArraysCount.RunTest();

        Console.WriteLine("\nAll tests completed.");
    }

    static void TestBST()
    {
        TreeNode root = new TreeNode(10);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(15);
        root.Left.Right = new TreeNode(7);

        var iterator = new BSTIterator(root);

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
        // Output: 5 7 10 15
    }
}
