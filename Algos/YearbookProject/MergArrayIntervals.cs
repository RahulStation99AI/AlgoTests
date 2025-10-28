namespace Alogs
{
    using System;
    using System.Collections.Generic;

  /*

Array – Merge Intervals (Sorting + Greedy)
using System; using System.Collections.Generic; class IntervalMerger { public static int[][] Merge(int[][] intervals) { if (intervals.Length == 0) return intervals; Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0])); List merged = new List(); int[] current = intervals[0]; foreach (var interval in intervals) { if (interval[0] <= current[1]) // Overlap { current[1] = Math.Max(current[1], interval[1]); } else { merged.Add(current); current = interval; } } merged.Add(current); return merged.ToArray(); } static void Main() { int[][] intervals = new int[][] { new int[]{1,3}, new int[]{2,6}, new int[]{8,10}, new int[]{15,18} }; var result = Merge(intervals); foreach (var interval in result) { Console.WriteLine($"[{interval[0]}, {interval[1]}]"); } // Output: [1,6], [8,10], [15,18] } } 
✅ These four cover DP, Data Structures, String Manipulation, and Arrays—a solid spread for interviews.
Rahul, do you want me to also add xUnit/NUnit test cases for each of these so you can demonstrate engineering rigor in an interview setting? That’s often a differentiator at senior levels.

*/
    public static class IntervalMerger
    {
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0) return intervals;

            // Sort the Array by 1st element
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> merged = new List<int[]>();
            int[] current = intervals[0]; // Assign the first starting with shortest start index

            foreach (var interval in intervals)
            {
                if (interval[0] <= current[1]) // Overlap
                {
                    current[1] = Math.Max(current[1], interval[1]);
                }
                else
                {
                    merged.Add(current);
                    current = interval;
                }
            }

            merged.Add(current);
            return merged.ToArray();
        }

        public static void Test()
        {
            int[][] intervals = new int[][]
            {
            new int[]{1,3},
            new int[]{2,6},
            new int[]{2,8},
            new int[]{8,10},
            new int[]{15,18}
            };

            foreach (var interval in intervals)
            {
                Console.WriteLine($"Input: [{interval[0]}, {interval[1]}]");
            }
            
            var result = Merge(intervals);
            foreach (var interval in result)
            {
                Console.WriteLine($"Result: [{interval[0]}, {interval[1]}]");
            }
            
        }
    }

}