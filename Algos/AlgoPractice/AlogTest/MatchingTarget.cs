using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.
If target is not found in the array, return [-1, -1].
 
Example 1:
Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]
Example 2:
Input: nums = [5,7,7,8,10], target = 8
Output: [3,3]
Example 3:
Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]
Example 4:
Input: nums = [], target = 0
Output: [-1,-1]


*/


namespace Algos.AlogTest
{
    public static class MatchingTarget
    {

        static int[] FindMatching(int[] arr, int target)
        {
            int start = -1, end = -1;
            int curCount = 0, maxCount = 0;
            int curStart = -1, curEnd = -1;
            var result = new List<int>() { start, end };

            if (arr.Length == 0)
            {
                return result.ToArray();

            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > target)
                {
                    break;
                }

                if (arr[i] == target)
                {
                    curCount++;
                    maxCount = Math.Max(maxCount, curCount);
                    if (curCount == 1)
                    {
                        curStart = i;
                        curEnd = i;

                    }
                    else
                    {
                        curEnd = i;
                    }

                    if (maxCount <= curCount)
                    {
                        start = curStart;
                        end = curEnd;
                    }
                }
                else
                {
                    curCount = 0;
                }
            }

            result = new List<int>() { start, end };
            return result.ToArray();
        }
  

    public static int[] Test()
    {
        var nums = new List<int>() { 5, 7, 7, 8, 8, 10 };
        int target = 8;

        var result = FindMatching(nums.ToArray(), target);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            nums = new List<int>() { 5, 7, 7, 8, 8, 10 };
            target = 6;
            result = FindMatching(nums.ToArray(), target);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            return result;
    }

    }
}
