namespace Alogs
{
    using System;

    public class PassingYearbooks
    {
        public static int[] RunTest()
        {
            Console.WriteLine("\nTesting PassingYearbooks with array: [5,2,1,3,4]");
            var arr = new int[] { 5, 2, 1, 3, 4 };
            return findSignatureCounts(arr);
        }

        private static int[] findSignatureCounts(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            bool[] visited = new bool[n];

            Console.WriteLine("\nProcessing yearbook cycles:");
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Console.WriteLine($"\nStarting with student {i + 1}'s yearbook:");

                    // Find the cycle starting from i
                    int curr = i;
                    int count = 0;
                    Console.Write($"Cycle path: {curr + 1}");
                    do
                    {
                        curr = arr[curr] - 1;
                        count++;
                        Console.Write($" -> {curr + 1}");
                    } while (curr != i);
                    Console.WriteLine($"\nCycle length: {count}");

                    // Assign the cycle length to all students in the cycle
                    curr = i;
                    Console.Write($"Assigning {count} signatures to students: ");
                    do
                    {
                        result[curr] = count;
                        visited[curr] = true;
                        Console.Write($"{curr + 1} ");
                        curr = arr[curr] - 1;
                    } while (curr != i);
                    Console.WriteLine();
                }
            }

            // Print results for debugging
            Console.Write("\nFinal results: ");
            foreach (var res in result)
            {
                Console.Write($"{res} ");
            }
            Console.WriteLine();

            return result;
        }
    }
}