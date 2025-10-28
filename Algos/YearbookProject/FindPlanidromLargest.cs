namespace Alogs
{

    using System;
    using System.Collections.Generic;

    // Find if the given string Largest planidrom.
    // Example: "madam" is a planidrom, "hello" is not a planidrom.


public static class LongestPalindromeFinder
{
    public static string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";

        int start = 0, maxLength = 1;

      
        for (int i = 0; i < s.Length; i++)
        {
            // Odd length palindrome
            ExpandAroundCenter(s, i, i, ref start, ref maxLength);

            // Even length palindrome
            ExpandAroundCenter(s, i, i + 1, ref start, ref maxLength);
        }

        return s.Substring(start, maxLength);
    }

    private static void ExpandAroundCenter(string s, int left, int right, ref int start, ref int maxLength)
        {
         Console.WriteLine($"Start planidrom: {left}, {right}");
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            int currentLength = right - left + 1;
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                start = left;
            }
            left--;
            right++;
            
            Console.WriteLine($"Found planidrom: {start}, {right}");
        }
    }

    public static void Test()
    {
        string input = "babad";
        Console.WriteLine("Input: " + input);
        Console.WriteLine("Longest Palindrome: " + LongestPalindrome(input));

        input = "efacdbbdcafl";
        Console.WriteLine("Input: " + input);
        Console.WriteLine("Longest Palindrome: " + LongestPalindrome(input));
    }
}

    }
