
namespace Alogs
{
    using System;
    using System.Collections.Generic;

    /*
     * Problem Description:
     * 
     */
    public class AtlassianCoding
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
            if (amount == 0) return 0;
            if (amount < 0) return int.MaxValue;
            if (memo.ContainsKey(amount)) return memo[amount];

            int min = int.MaxValue;
            foreach (int coin in coins)
            {
                int res = Helper(coins, amount - coin, memo);
                if (res != int.MaxValue)
                    min = Math.Min(min, res + 1);
            }

            memo[amount] = min;
            return min;
        }

        public static void Test()
        {
            int[] coins = { 1, 3, 4 };
            int amount = 6;

            int result = CodingProblem(coins, amount);
            Console.WriteLine("Backtracking result: " + result);
            // Output: 2 (3 + 3), whereas greedy would give 3 (4 + 1 + 1)
        }
    }
}