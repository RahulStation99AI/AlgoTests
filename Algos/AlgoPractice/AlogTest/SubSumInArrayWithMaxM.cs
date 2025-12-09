namespace Alogs
{

    using System;
    using System.Collections.Generic;


    /*
    Subarrays with Given Sum and Bounded Maximum
    Given an integer array nums and integers k and M, count the number of contiguous subarrays whose sum equals k and whose maximum element is at most M.

    Example

    Input

    nums = [2, -1, 2, 1, -2, 3]
    k = 3
    M = 2
     */

    public class SubSumInArrayWithMaxM
    {
        public static long RunTest()
        {
            // Test 1: Small array
            long target1 = 19;
            long maxElement1 = 15;
            var arr1 = new int[] { 3, -4, 15, 4, -5, 15, 99, 10, 9, 19 };

            var result1 = countSubarraysWithSumAndMaxAtMost(arr1, target1, maxElement1);
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            target1 = 19;
            maxElement1 = 19;
            arr1 = new int[] { 3, -4, 15, 4, -5, 15, 9, -5, 9, 19 };
            result1 = countSubarraysWithSumAndMaxAtMost(arr1, target1, maxElement1);
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            target1 = 24;
            maxElement1 = 15;
            arr1 = new int[] { 3, -4, 15, 4, -5, 15, 10, 5, 9, 19 };
            result1 = countSubarraysWithSumAndMaxAtMost(arr1, target1, maxElement1);
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            target1 = 24;
            maxElement1 = 150;
            arr1 = new int[] { 13, -4, 15, 4, 5, 15, 9, 5, 9, 19 };
            result1 = countSubarraysWithSumAndMaxAtMost(arr1, target1, maxElement1);
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            /*
        // Test 2: Empty array
        int target2 = 10;
        var arr2 = new int[] { };
        Console.WriteLine($"\nTest 2: Empty array\nTesting SubArrays with array: [{string.Join(", ", arr2)}], sum: {target2}");
        var result2 = FindElementsForSubSum(arr2, target2);
        PrintResult(arr2, result2);

        // Test 3: Large array (1000 elements, with a known solution)
        int target3 = 1234;
        var arr3 = new int[1000];
        var rand = new Random(42);
        for (int i = 0; i < arr3.Length; i++) arr3[i] = rand.Next(1, 100);
        // Insert a known solution at the end
        arr3[997] = 400; arr3[998] = 500; arr3[999] = 334; // 400+500+334=1234
        Console.WriteLine($"\nTest 3: Large array (1000 elements)\nTesting SubArrays with array: [first 20: {string.Join(", ", arr3[..20])} ...], sum: {target3}");
        var result3 = FindElementsForSubSum(arr3, target3);
        PrintResult(arr3, result3);
        */
            return result1; // Return the first test's result for compatibility
        }

        private static void PrintResult(int[] arr, List<int> result)
        {
            if (result.Count > 0)
            {
                Console.WriteLine("Found indices and their values:");
                foreach (int index in result)
                {
                    Console.WriteLine($"Index {index}: {arr[index]}");
                }
            }
            else
            {
                Console.WriteLine("No solution found for this test case.");
            }
        }

        private static long countSubarraysWithSumAndMaxAtMost(int[] nums, long targetSum, long maxElementValue)
        {
            if(nums == null || nums.Length == 0) return 0;

            long count = 0; // total valid subarrays
            int n = nums.Length;

            int start = 0;
            while (start < n)
            {
                // Skip invalid elements (greater than M)
                while (start < n && nums[start] > maxElementValue) 
                    start++;
                if (start >= n) break;

                // Find contiguous segment where all elements ≤ M
                int end = start;
                while (end < n && nums[end] <= maxElementValue)
                    end++;

                // Use prefix sum hashmap to count subarrays with sum = targetSum
                Dictionary<long, List<int>> prefixSumIndices = new Dictionary<long, List<int>>();
                prefixSumIndices[0] = new List<int> { start - 1 }; // base case: empty prefix before segment
                long currentSum = 0;

                for (int i = start; i < end; i++)
                {
                    currentSum += nums[i];

                    // If currentSum - targetSum exists, we found subarray(s)
                    /*
                        - Maintain a map from prefix sum → list of indices where that sum occurred.
                        - When we find currentSum - targetSum in the dictionary, we know that the subarray between the stored index+1 and the current index is valid.
                        - Collect those subarrays (start and end indices, or the actual slice of the array).
                        - We check currentSum - targetSum because prefix sums work by subtracting an earlier sum from the current sum to isolate the subarray in between. 
                        If that earlier sum exists in our dictionary, the difference equals the target, meaning we’ve found a valid subarray.
                     */
                    if (prefixSumIndices.ContainsKey(currentSum - targetSum))
                    {
                        foreach (var prevIndex in prefixSumIndices[currentSum - targetSum])
                        {
                            int subStart = prevIndex + 1;
                            int subEnd = i;

                            // Verify actual sum before printing
                            long actualSum = 0;
                            for (int j = subStart; j <= subEnd; j++) actualSum += nums[j];

                            if (actualSum == targetSum)
                            {
                                count++;
                                var subArray = nums[subStart..(subEnd + 1)];
                                Console.WriteLine($"Subarray found (indices {subStart}-{subEnd}): [{string.Join(", ", subArray)}]");
                            }
                        }
                    }

                    // Update prefix sum indices
                    if (!prefixSumIndices.ContainsKey(currentSum))
                        prefixSumIndices[currentSum] = new List<int>();
                    prefixSumIndices[currentSum].Add(i);
                }

                // Move to next segment
                start = end;
            }

            Console.WriteLine($"Total subarrays with sum {targetSum} and max element ≤ {maxElementValue}: {count}");
            return count;
        }


    }
}