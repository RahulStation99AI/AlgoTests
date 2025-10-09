using System;
using System.Collections.Generic;

// Find if the given string is a planidrom or not.
// Example: "madam" is a planidrom, "hello" is not a planidrom.
public class FindPlanidrom
{
    public static void RunTest()
    {
        string test1 = "madam";
        Console.WriteLine($"\nTest 1: Is '{test1}' a planidrom? {IsPlanidrom(test1)}");

        string test2 = "hello";
        Console.WriteLine($"\nTest 2: Is '{test2}' a planidrom? {IsPlanidrom(test2)}");

    }

    private static bool IsPlanidrom(string str)
    {
        int left = 0, right = str.Length - 1;
        while (left < right)
        {
            if (str[left] != str[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    public List<string> FindAllPlanidroms(string str)
    {
        var planidroms = new List<string>();
        int n = str.Length;

        // Check it to start from Center and expand.
        for (int i = 0; i < n; i++)
        {
            // Odd length planidroms
            ExpandAroundCenter(str, i, i, planidroms);
            // Even length planidroms
            ExpandAroundCenter(str, i, i + 1, planidroms);
        }

        return planidroms;
    }

    private void ExpandAroundCenter(string str, int left, int right, List<string> planidroms)
    {
        while (left >= 0 && right < str.Length && str[left] == str[right])
        {
            var planidrom = str.Substring(left, right - left + 1);
            if (planidrom?.Length >= 3 && new HashSet<char>(planidrom).Count > 1) // Avoid duplicates and length < 3
            {
                planidroms.Add(planidrom);
            }

            left--;
            right++;
        }
    }
}