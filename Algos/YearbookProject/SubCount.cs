using System;
using System.Collections.Generic;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
public class SubArraysCount {
  public static int[] RunTest() {
    Console.WriteLine("\nTesting SubArrays with array: [3,4,1,6,2]");
    var arr = new int[] {3,4,1,6,2};
    var result = countSubarrays(arr);
    return result;
  }
  
  private static int[] countSubarrays(int[] arr) {
    int n = arr.Length;
    int[] result = new int[n];
    Stack<int> stack = new Stack<int>();
    
    // Process left to right - find next greater element
    Console.WriteLine("\nProcessing left to right:");
    for (int i = 0; i < n; i++) {
        Console.WriteLine($"\nProcessing element arr[{i}] = {arr[i]}");
        Console.Write("Stack before: ");
        if (stack.Count == 0) Console.WriteLine("empty");
        else {
            foreach (var idx in stack) {
                Console.Write($"[{idx}]={arr[idx]} ");
            }
            Console.WriteLine();
        }

        // Pop elements smaller than current
        while (stack.Count > 0 && arr[stack.Peek()] <= arr[i]) {
            int idx = stack.Pop();
            result[idx] += (i - idx - 1);
            Console.WriteLine($"  Popped position {idx} (value={arr[idx]}) because {arr[i]} is greater/equal");
            Console.WriteLine($"  Position {idx}: Adding {i - idx - 1} elements to right");
        }
        stack.Push(i);
        
        Console.Write("Stack after: ");
        foreach (var idx in stack) {
            Console.Write($"[{idx}]={arr[idx]} ");
        }
        Console.WriteLine();
    }
    
    // Process remaining elements in stack
    while (stack.Count > 0) {
        int idx = stack.Pop();
        result[idx] += (n - idx - 1);
        Console.WriteLine($"  Position {idx}: Adding {n - idx - 1} remaining elements to right");
    }
    
    stack.Clear();
    
    // Process right to left - find next greater element
    Console.WriteLine("\nProcessing right to left:");
    for (int i = n - 1; i >= 0; i--) {
        // Pop elements smaller than current
        while (stack.Count > 0 && arr[stack.Peek()] < arr[i]) {
            int idx = stack.Pop();
            result[idx] += (idx - i - 1);
            Console.WriteLine($"  Position {idx}: Adding {idx - i - 1} elements to left");
        }
        stack.Push(i);
    }
    
    // Process remaining elements in stack
    while (stack.Count > 0) {
        int idx = stack.Pop();
        result[idx] += idx;
        Console.WriteLine($"  Position {idx}: Adding {idx} remaining elements to left");
    }
    
    // Add 1 for the element itself
    for (int i = 0; i < n; i++) {
        result[i]++;
    }
    
    Console.WriteLine("\nFinal results:");
    foreach(var res in result) {
        Console.Write($"{res} ");
    }
    Console.WriteLine();
    
    return result;
  }
}