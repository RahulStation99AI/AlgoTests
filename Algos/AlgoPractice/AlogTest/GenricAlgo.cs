
namespace Alogs
{

    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public Solution()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 3, 8, 9, 10 };
            var result = hasDuplicate(nums);
            Console.WriteLine($"Has Duplicates: {result}");
        }

        public bool hasDuplicate(int[] nums)
        {
            HashSet<int> numsColl = new HashSet<int>();

            foreach (var num in nums)
            {
                if (numsColl.Contains(num))
                {
                    Console.WriteLine($"Duplicate found: {num}");
                    return true;
                }

                numsColl.Add(num);
            }

            return false;
        }
    }
}