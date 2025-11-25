namespace Alogs
{
    using System;
    using System.Collections.Generic;

    // We don’t provide test cases in this language yet, but have outlined the signature for you.
    // Please write your code below, and don’t forget to test edge cases!
    public class FindTargetInRotateArray
    {
        public static void Test()
        {
            // Call numberOfWays() with test cases here
            var arr = new int[] { 6, 5, 0, 1, 3, 4 };
            int k = 6;
            int result = searchRotatedTimestamps(arr.ToList(), k);
            Console.WriteLine(result);

            k = 0;
            result = searchRotatedTimestamps(arr.ToList(), k);
            Console.WriteLine(result);
        }

        public static int searchRotatedTimestamps(List<int> nums, int target)
        {
            if (nums == null || nums.Count == 0)
                return -1;

            int left = 0;
            int right = nums.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                // Check which half is sorted
                if (nums[left] <= nums[mid])
                {
                    // Left half is sorted
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1; // Target is in left half
                    else
                        left = mid + 1;  // Target is in right half
                }
                else
                {
                    // Right half is sorted
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;  // Target is in right half
                    else
                        right = mid - 1; // Target is in left half
                }
            }

            return -1; // Target not found
        }

    }
}