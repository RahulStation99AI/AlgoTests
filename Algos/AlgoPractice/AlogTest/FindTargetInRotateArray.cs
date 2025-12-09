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
            result = SearchRotatedTimestampsWithRotationPoint(arr.ToList(), k);
            Console.WriteLine(result);
            k = 0;
            result = searchRotatedTimestamps(arr.ToList(), k);
            Console.WriteLine(result);
            result = SearchRotatedTimestampsWithRotationPoint(arr.ToList(), k);
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

        // Alternate Solution
        public static int SearchRotatedTimestampsWithRotationPoint(List<int> nums, int target)
        {
            if (nums == null || nums.Count == 0)
                return -1;

            // First find the rotation point (index of minimum element)
            int left = 0;
            int right = nums.Count - 1;
            int rotationPoint = 0;

            // Find the rotation point
            while (left < right)
            {
                int mid = left + (right - left) / 2; 
                if (nums[mid] > nums[right]) 
                    left = mid + 1;
                else
                    right = mid;
                rotationPoint = left; // After the loop, left will be at the minimum element
            }

            // Now determine which half to search
            int start, end;
            if (target >= nums[0] && rotationPoint > 0 &&  nums[rotationPoint - 1] <= target)
            {
                // Target is in the first half
                start = 0;
                end = rotationPoint - 1;
            }
            else
            {
                // Target is in the second half
                start = rotationPoint;
                end = nums.Count - 1;
            }

            // Perform standard binary search
            while (start <= end)
            {
                int mid = start + (end - start) / 2; 
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }

            return -1; // Not found
        }
    }
}