using System;

/// <summary>
/// Main program class that runs various algorithm tests
/// </summary>
class Program 
{
   
    static void Main(string[] args) 
    {
        var sol = new Solution();
        Console.WriteLine(" Find Pair Sums ");
        PairSums.Test();
        return;
        Console.WriteLine(" FindSum of Nubers ");
        SubSumInArray.RunTest();
        return;


        Console.WriteLine("Running Algorithm Tests\n");

        // Test PassingYearbooks
        var yearBookResult = PassingYearbooks.RunTest();
        
        // Test SubArraysCount
        var subArrayResult = SubArraysCount.RunTest();

        Console.WriteLine("\nAll tests completed.");
    }
}
