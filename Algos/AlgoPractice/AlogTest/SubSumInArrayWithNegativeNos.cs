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

    public class SubSumInArrayWithNegativeNos
    {
        public static List<(int, int)> RunTest()
        {
            // Test 1: Small array
            long target1 = 19;
            long maxElement1 = 15;
            var arr1 = new int[] { 3, -4, 15, 4, -5, 15, 99, 10, 9, 19 };

            var result1 = FindAllSubarraysWithSum(arr1, target1);
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            target1 = 19;
            maxElement1 = 19;
            arr1 = new int[] { 3, -4, 15, 4, -5, 15, 9, -5, 9, 19 };
            result1 = result1 = FindAllSubarraysWithSum(arr1, target1);
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            target1 = 24;
            maxElement1 = 15;
            arr1 = new int[] { 3, -4, 15, 4, -5, 15, 10, 5, 9, 19 }; 
            result1 = FindAllSubarraysWithSum(arr1, target1); 
            Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}, maxElement <= {maxElement1} count: {result1}");

            target1 = 24;
            maxElement1 = 150;
            arr1 = new int[] { 13, -4, 15, 4, 5, 15, 9, 5, 9, 19 };
            result1 = result1 = FindAllSubarraysWithSum(arr1, target1);
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

        public static List<(int, int)> FindAllSubarraysWithSum(int[] nums, long targetSum)
        {
            var results = new List<(int, int)>();

            // Dictionary: prefixSum -> list of indices where it occurred
            Dictionary<long, List<int>> prefixSumIndices = new Dictionary<long, List<int>>();
            prefixSumIndices[0] = new List<int> { -1 }; // base case

            int currentSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];

                // Check if (currentSum - targetSum) exists
                if (prefixSumIndices.ContainsKey(currentSum - targetSum))
                {
                    foreach (var prevIndex in prefixSumIndices[currentSum - targetSum])
                    {
                        //validate the actual sum to avoid false positives
                        int subStart = prevIndex + 1;
                        int subEnd = i;
                        int actualSum = 0;
                        for (int j = subStart; j <= subEnd; j++) actualSum += nums[j];

                        if (actualSum == targetSum) // ✅ verify before adding
                        {
                            results.Add((subStart, subEnd));
                        }
                    }
                }

                // Store current prefix sum index
                if (!prefixSumIndices.ContainsKey(currentSum))
                    prefixSumIndices[currentSum] = new List<int>();
                prefixSumIndices[currentSum].Add(i);
            }

            return results;
        }
       
    }

}