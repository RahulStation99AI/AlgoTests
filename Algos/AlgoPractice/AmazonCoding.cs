using Alogs;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algos
{
    public static  class AmazonCoding
    {

         //       Solution B: Hash Map Optimization(C#)
        // Time Complexity: O(n)
        // Space Complexity: O(n)
        // Explanation: We use a dictionary to store numbers and their indices.
        // For each number, we check if the complement (target - current number) exists.
        // This reduces the time complexity by avoiding nested loops.
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (seen.ContainsKey(complement))
                {
                    return new int[] { seen[complement], i };
                }
                seen[nums[i]] = i;
            }
            throw new ArgumentException("No two sum solution");
        }


       /* Problem 2: Valid Parentheses
Description: Given a string containing just the characters(, ), {, }, [and], determine if the input string is valid.An input string is valid if:
	• Open brackets are closed by the same type of brackets.
	• Open brackets are closed in the correct order.
Solution A: Stack Approach (C#)
       */
// Time Complexity: O(n)
// Space Complexity: O(n)
// Explanation: We use a stack to keep track of opening brackets.
// When we encounter a closing bracket, we check if it matches the last opening bracket.
// If all brackets match correctly, the string is valid.
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> mapping = new Dictionary<char, char>() { { ')', '(' }, { '}', '{' }, { ']', '[' } };
            foreach (char c in s)
            {
                if (mapping.ContainsKey(c))
                {
                    char top = stack.Count > 0 ? stack.Pop() : '#';
                    if (mapping[c] != top)
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }

        /* Problem 3: Maximum Subarray
 Description: Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.
 Solution A: Kadane’s Algorithm (C#) */
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Explanation: We iterate through the array, keeping track of the current subarray sum.
        // If the current sum becomes negative, we reset it to the current element.
        // We keep track of the maximum sum found so far.
        public static int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }

        /* Problem 4: Merge Two Sorted Lists
 Description: Merge two sorted linked lists and return it as a new sorted list.The new list should be made by splicing together the nodes of the first two lists.
 Solution A: Iterative Approach (C#) */
        // Time Complexity: O(n + m)
        // Space Complexity: O(1)
        // Explanation: We use a dummy node to build the merged list.
        // We compare nodes from both lists and append the smaller one.
        // When one list is exhausted, we append the remaining nodes from the other list.
        // Time Complexity: O(n + m)
        // Space Complexity: O(1)
        // Explanation: We use a dummy node to build the merged list.
        // We compare nodes from both lists and append the smaller one.
        // When one list is exhausted, we append the remaining nodes from the other list.
        public static LinkedList<int> MergeTwoLists(LinkedList<int> l1, LinkedList<int> l2)
        {
            LinkedList<int> mergedList = new LinkedList<int>();
            var current1 = l1.First;
            var current2 = l2.First;
            while (current1 != null && current2 != null)
            {
                if (current1.Value < current2.Value)
                {
                    mergedList.AddLast(current1.Value);
                    current1 = current1.Next;
                }
                else
                {
                    mergedList.AddLast(current2.Value);
                    current2 = current2.Next;
                }
            }

            mergedList.AddLast(current1?.Value);
            mergedList.AddLast(current2?.Value);
            return mergedList;
        }

        /* Problem 5: Climbing Stairs
 Description: You are climbing a staircase.It takes n steps to reach the top.Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
 Solution A: Dynamic Programming (C#)*/
        // Time Complexity: O(n)
        // Space Complexity: O(n)
        // Explanation: We use an array to store the number of ways to reach each step.
        // The number of ways to reach step i is the sum of ways to reach steps i-1 and i-2.
        public static int ClimbStairs(int n)
        {
            if (n <= 2) return n;
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        /*
        Problem 6: Product of Array Except Self
        Description: Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
Solution A: Without Division(C#)*/
// Time Complexity: O(n)
// Space Complexity: O(1) (excluding output array)
// Explanation: We use two passes to calculate the product of all elements to the left and right of each index.
// We first fill the output array with the product of all elements to the left.
// Then we multiply by the product of all elements to the right in a second pass.
public static int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];
            answer[0] = 1;
            for (int i = 1; i < n; i++)
            {
                answer[i] = nums[i - 1] * answer[i - 1];
            }
            int R = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                answer[i] = answer[i] * R;
                R *= nums[i];
            }
            return answer;
        }

       /* Problem 7: Top K Frequent Elements
Description: Given an integer array nums and an integer k, return the k most frequent elements.
Solution A: Using Dictionary and Min-Heap(C#)*/
// Time Complexity: O(n log k)
// Space Complexity: O(n)
// Explanation: We count the frequency of each element using a dictionary.
// Then we use a min-heap (priority queue) to keep track of the top k elements.
// This approach is efficient when k is much smaller than n.
public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                counts[num] = counts.GetValueOrDefault(num, 0) + 1;
            }

            //Min Heap based on frequency
            SortedSet<(int freq, int num)> heap = new SortedSet<(int, int)>();
            foreach (var pair in counts)
            {
                heap.Add((pair.Value, pair.Key));
                if (heap.Count > k)
                {
                    heap.Remove(heap.Min); // Remove the element with the lowest frequency
                }
            }

            int[] result = new int[k];
            int i = 0;
            foreach (var item in heap)
            {
                result[i++] = item.num;
            }
            return result;
        }


    }
}
