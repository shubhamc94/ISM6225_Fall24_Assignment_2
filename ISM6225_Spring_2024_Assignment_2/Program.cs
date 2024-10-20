using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1: Find Missing Numbers in Array");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine("The missing numbers in the array are: " + string.Join(",", missingNumbers));
            Console.WriteLine();

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2: Sort Array by Parity");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine("Array after sorting by parity (even first, then odd): " + string.Join(",", sortedArray));
            Console.WriteLine();

            // Question 3: Two Sum
            Console.WriteLine("Question 3: Two Sum");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine("Indices of the two numbers that add up to " + target + " are: " + string.Join(",", indices));
            Console.WriteLine();

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4: Find Maximum Product of Three Numbers");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine("The maximum product of three numbers is: " + maxProduct);
            Console.WriteLine();

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5: Decimal to Binary Conversion");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine("The binary equivalent of " + decimalNumber + " is: " + binary);
            Console.WriteLine();

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6: Find Minimum in Rotated Sorted Array");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine("The minimum element in the rotated sorted array is: " + minElement);
            Console.WriteLine();

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7: Palindrome Number");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine("Is " + palindromeNumber + " a palindrome? " + (isPalindrome ? "Yes, it is a palindrome." : "No, it is not a palindrome."));
            Console.WriteLine();

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8: Fibonacci Number");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine("The " + n + "th Fibonacci number is: " + fibonacciNumber);
            Console.WriteLine();
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            List<int> missingNumbers = new List<int>();
            HashSet<int> numSet = new HashSet<int>(nums);
            for (int i = 1; i <= nums.Length; i++)
            {
                if (!numSet.Contains(i))
                {
                    missingNumbers.Add(i);
                }
            }
            return missingNumbers;
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] % 2 > nums[right] % 2)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                }
                if (nums[left] % 2 == 0) left++;
                if (nums[right] % 2 == 1) right--;
            }
            return nums;
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            return null;
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";
            string binary = "";
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary;
                decimalNumber /= 2;
            }
            return binary;
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right]) left = mid + 1;
                else right = mid;
            }
            return nums[left];
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int original = x, reversed = 0;
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }
            return original == reversed;
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0 || n > 30)
                    throw new ArgumentException("n should be between 0 and 30");

                if (n == 0) return 0;
                if (n == 1) return 1;

                int prev1 = 0, prev2 = 1, current = 0;
                for (int i = 2; i <= n; i++)
                {
                    current = prev1 + prev2;
                    prev1 = prev2;
                    prev2 = current;
                }
                return current;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1; // Return -1 in case of an error
            }
        }

    }
}
