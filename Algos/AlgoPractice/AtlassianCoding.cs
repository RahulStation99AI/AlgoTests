
namespace Alogs
{
    using System;
    using System.Collections.Generic;

    /*
     * Problem Description:
     * 
     */
    public static class AtlassianCoding
    {

        /*
                Desription: 

                Steps:

                Edge Case:

                Error Handling:

        */
        public static int CodingProblem(int[] coins, int amount)
        {
            int result = Helper(coins, amount, new Dictionary<int, int>());
            return result == int.MaxValue ? -1 : result;
        }

        private static int Helper(int[] coins, int amount, Dictionary<int, int> memo)
        {
            int min = -1;

            return min;
        }

        public static void Test()
        {
            int[] coins = { 1, 3, 4 };
            int amount = 6;

            int result = CodingProblem(coins, amount);
            Console.WriteLine("Backtracking result: " + result);

            PrintResults();
            // Output: 2 (3 + 3), whereas greedy would give 3 (4 + 1 + 1)
        }

        public static void PrintResults()
        { 
        
        }
    }
}