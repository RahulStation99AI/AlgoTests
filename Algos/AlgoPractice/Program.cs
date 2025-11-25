using System;

using Algos;
using Algos.Tree;

using Alogs;

/// <summary>
/// Main program class that runs various algorithm tests
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        FindTargetInRotateArray.Test();
        SubSumInArrayWithMaxM.RunTest();
        return;

        BST.Test();

        //AtlassianCoding.Test();

        return;

        CoinChangeBacktrack.Test();
                
        LongestPalindromeFinder.Test();

       IntervalMerger.Test();

        Console.WriteLine(" Running Given an array height[] of non-negative integers, each representing the height of a vertical line at that index, find the two lines that together with the x-axis form a container that holds the most water.\n");
        TwoPointers.Test();
        Console.WriteLine(" Binary Search Tree Iterator ");
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
