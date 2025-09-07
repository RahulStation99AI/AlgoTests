using System;
using System.Collections.Generic;

// Find target sum in the array of integers. 
// Example array [3,1,2,4,5,9], target sum = 6
// Find optimal solution.

public class SubSumInArray
{
    public static List<int> RunTest()
    {
        // Test 1: Small array
        int target1 = 19;
        var arr1 = new int[] { 3, 1, 2, 4, 5, 15, 9, 10, 109, 19 };
        Console.WriteLine($"\nTest 1: Small array\nTesting SubArrays with array: [{string.Join(", ", arr1)}], sum: {target1}");
        var result1 = FindElementsForSubSum(arr1, target1);
        PrintResult(arr1, result1);

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

    private static List<int> FindElementsForSubSum(int[] arr, int target)
    {
        Console.WriteLine("\nFinding all possible combinations (ordered by length):");
        var allSolutions = new List<(List<int> indices, string display)>();

        // Find single numbers
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                var solution = new List<int> { i };
                var display = $"{arr[i]}({i}) = {target}";
                allSolutions.Add((solution, display));
            }
        }

        // Find pair sums (O(n) with dictionary)
        var numToIndex = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            int complement = target - arr[i];
            if (numToIndex.ContainsKey(complement))
            {
                var solution = new List<int> { numToIndex[complement], i };
                var display = $"{arr[numToIndex[complement]]}({numToIndex[complement]}) + {arr[i]}({i}) = {target}";
                allSolutions.Add((solution, display));
            }
            if (!numToIndex.ContainsKey(arr[i]))
                numToIndex[arr[i]] = i;
        }

        // Find triplet sums (O(n^2) with hash set)
        for (int i = 0; i < arr.Length - 2; i++)
        {
            var seenTriplet = new Dictionary<int, int>();
            int currentTarget = target - arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                int complement = currentTarget - arr[j];
                if (seenTriplet.ContainsKey(complement))
                {
                    var solution = new List<int> { i, seenTriplet[complement], j };
                    var display = $"{arr[i]}({i}) + {arr[seenTriplet[complement]]}({seenTriplet[complement]}) + {arr[j]}({j}) = {target}";
                    allSolutions.Add((solution, display));
                }
                if (!seenTriplet.ContainsKey(arr[j]))
                    seenTriplet[arr[j]] = j;
            }
        }

        // Find longer combinations
        var combinations = new List<List<int>>();
        FindAllSums(arr, target, 0, 0, new List<int>(), combinations);
        
        foreach (var combo in combinations)
        {
            if (combo.Count > 2)  // Skip single numbers and pairs as we already added them
            {
                var display = string.Join(" + ", combo.Select(idx => $"{arr[idx]}({idx})")) + $" = {target}";
                allSolutions.Add((combo, display));
            }
        }

        // Sort solutions by length and print them
        allSolutions = allSolutions.OrderBy(x => x.indices.Count).ToList();
        
        for (int i = 0; i < allSolutions.Count; i++)
        {
            Console.WriteLine($"Solution {i + 1} ({allSolutions[i].indices.Count} numbers): {allSolutions[i].display}");
        }

        if (allSolutions.Count == 0)
        {
            Console.WriteLine("\nNo solutions found");
            return new List<int>();
        }

        // Return the shortest combination (most optimal)
        var optimalSolution = allSolutions[0].indices;
        Console.WriteLine($"\nReturning optimal solution with {optimalSolution.Count} number(s)");
        return optimalSolution;
    }

    private static void FindAllSums(int[] arr, int target, int currentSum, int startIndex, 
                                  List<int> currentCombination, List<List<int>> allCombinations)
    {
        if (currentSum == target && currentCombination.Count > 0)
        {
            allCombinations.Add(new List<int>(currentCombination));
            return;
        }

        for (int i = startIndex; i < arr.Length; i++)
        {
            if (currentSum + arr[i] <= target)
            {
                currentCombination.Add(i);
                FindAllSums(arr, target, currentSum + arr[i], i + 1, currentCombination, allCombinations);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }

    private static bool FindSum(int[] arr, int target, int currentSum, int startIndex, 
                              List<int> currentCombination, List<int> result)
    {
        if (currentSum == target && currentCombination.Count > 0)
        {
            result.AddRange(currentCombination);
            return true;
        }

        for (int i = startIndex; i < arr.Length; i++)
        {
            if (currentSum + arr[i] <= target)
            {
                currentCombination.Add(i);
                if (FindSum(arr, target, currentSum + arr[i], i + 1, currentCombination, result))
                {
                    return true;
                }
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        return false;
    }
}
