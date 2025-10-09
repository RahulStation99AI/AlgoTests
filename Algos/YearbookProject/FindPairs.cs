namespace Alogs
{
  using System;
  using System.Collections.Generic;

  // We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
  public class PairSums
  {
    public static void Test()
    {
      // Call numberOfWays() with test cases here
      var arr = new int[] { 1, 3, 3, 4, 5 };
      int k = 6;
      int result = numberOfWays(arr, k);
      Console.WriteLine(result);
    }

    private static int numberOfWays(int[] arr, int k)
    {
      // Write your code here
      var pairs = new List<(int, int)>(); // the  found pairs.
      var numFreq = new Dictionary<int, int>(); // keep track of nums found

      foreach (int num in arr)
      {
        int complement = k - num;
        if (complement <= 0) // single num or greater number skip it
        {
          continue;
        }

        int ItemCount = 0;
        if (numFreq.TryGetValue(complement, out ItemCount) && ItemCount > 0) // found complement
                                                                             // add as many pairs as the complement count
        {
          for (int i = 0; i < ItemCount; i++)
          {
            pairs.Add((num, complement));
          }
        }

        int count = -1;
        if (numFreq.TryGetValue(num, out count) && count > 0) // the dictionary throw expection, if not found, so use method which doesn't throw exception.
        {
          numFreq[num]++;
        }
        else
        {
          numFreq[num] = 1;
        }
      }

      foreach (var pair in pairs)
      {
        Console.WriteLine($"{pair.Item1}, {pair.Item2}");
      }

      return pairs.Count;
    }
  }
}