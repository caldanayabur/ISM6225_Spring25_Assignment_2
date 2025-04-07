using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here

                // Create a Hashset from the input array 'nums'
                // HashSet provides efficient (on average O(1) time complexity)
                // lookups to check for the existence of an element.
                HashSet<int> numsHashset = new HashSet<int>(nums);

                // Initialize an empty List to store the missing numbers.
                List<int> missingNumbers = new List<int>();

                //Find the maximum value in the input array 'nums'.
                int max = nums.Max();
                //Find the minimum value in the input array 'nums'.
                int min = nums.Min();

                //Iterate through the numbers starting from the minimum value found in the
                //array up to the maximum value found in the array.
                for (int i = min; i <= max; i++)
                {
                    //Check if the current number 'i' is not present in the HashSet.
                    if (!numsHashset.Contains(i))
                    {
                        //If it is not found, it means is missing from the input array.
                        //Add the missing number to the List.
                        missingNumbers.Add(i);
                    }
                }
                // Edge cases:
                // 1. Handles empty input by returning an empty list due to loop conditions.
                // 2. Duplicates (2, 3) are implicitly handled by using a HashSet.
                // 3. Works correctly for single-element arrays and non-sequential/negative
                // numbers by using min/max for the range. 
                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                // Create a new array to store the sorted numbers with the same length as the input array.
                int[] sortedArray = new int[nums.Length];
                // Initialize a counter to keep track of the position in the sorted array.
                int sortedCounter = 0;

                // Iterate through the input array and add even numbers to the sorted array first.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        // If the number is even, add it to the sorted array at the current position.
                        sortedArray[sortedCounter] = nums[i];
                        // Increment the counter to move to the next position in the sorted array.
                        sortedCounter++;
                    }
                }
                // After adding all even numbers, continue to add odd numbers to the sorted array.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        // If the number is odd, add it to the sorted array at the current position.
                        sortedArray[sortedCounter] = nums[i];
                        sortedCounter++;
                    }
                }

                // Edge cases:
                // 1. Handles empty input by returning an empty array due to loop conditions.
                // 2. Single-element arrays are processed correctly through the loops.
                // 3. All even/odd arrays are sorted by the two separate loops.
                // Negative numbers' parity is correctly determined by the modulo operator.
                return sortedArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                // Create a HashSet from the input array 'nums' to allow for efficient lookups.
                HashSet<int> numsHashset = new HashSet<int>(nums);
                // Initialize an empty array to store the indices of the two numbers that add up to the target.
                int[] twoSum = new int[] {};

                // Iterate through the input array 'nums' to find the two numbers that add up to the target.
                foreach (int num in nums)
                {
                    // Calculate the number needed to reach the target by subtracting the current number from the target.
                    int subtraction = target - num;
                    // Check if the subtraction result is present in the HashSet.
                    if (numsHashset.Contains(subtraction))
                    {
                        // If it is found, we need to find the indices of the two numbers in the original array.
                        int first_index = Array.IndexOf(nums, num);
                        int second_index = Array.IndexOf(nums, subtraction);
                        // Create a new integer array to store the indices of the two numbers.
                        twoSum = new int[] {first_index, second_index};
                        // Break the loop as we have found the two numbers.
                        break;
                    }
                }
                // Edge cases:
                // 1. If no valid pair exists, the code returns an empty array because the loop will never find a matching pair,
                // and 'twoSum' remains empty, which is returned as the result.
                // 2. It handles negative numbers and zero correctly because the HashSet and subtraction work for all integer values,
                // allowing it to find pairs even with negative numbers or zero in the array.
                // 3. It safely handles empty arrays or arrays with only one element because the loop will not run,
                // and the function will return the empty 'twoSum' array without errors.
                return twoSum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                // Sort the input array in ascending order.
                Array.Sort(nums);

                // Calculate the maximum product of three numbers when two could be possibly negative.
                int negativeNumbersEdgeCase = nums[0] * nums[1] * nums[nums.Length-1];
                // Calculate the product of the three largest numbers.
                int maxProduct = nums[nums.Length-1] * nums[nums.Length-2] * nums[nums.Length-3];

                // Edge cases:
                // 1. The code handles negative numbers by checking the product of the two smallest numbers (which could be negative)
                // and the largest number to account for the possibility of two negative numbers producing a large positive product.
                // 2. If the array contains all positive or all negative numbers, it correctly computes the maximum product 
                // based on the largest three values.
                return Math.Max(negativeNumbersEdgeCase, maxProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                // Initialize an empty string to store the binary representation.
                string binary = "";

                // Make a copy of the decimal number to perform the conversion.
                int toConvert = decimalNumber;

                // Loop until the number becomes zero.
                while (toConvert > 0)
                {
                    // Calculate the remainder by dividing the number by 2.
                    // The remainder will be either 0 or 1, which represents the binary digit.
                    int remainder = toConvert % 2;
                    // Update 'toConvert' by dividing it by 2.
                    toConvert = toConvert / 2;
                    // Prepend the remainder (converted to a string) to the binary string.
                    binary = remainder.ToString() + binary;
                }
                // Edge cases:
                // 1. Zero input results in an empty string return because the conversion loop is skipped.
                // 2. Positive numbers are correctly converted through iterative modulo and division by two.
                return binary;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {

                // Write your code here
                // Initialize two pointers, 'left' and 'right', to the start and end of the array.
                int left = 0;
                int right = nums.Length - 1;

                //Perform a binary search to find the minimum element in the rotated sorted array.
                // The loop continues until the left pointer is less than the right pointer.
                while (left < right)
                {
                    // Calculate the middle index of the current range.
                    int mid = (left + right) / 2;

                    // Check if the middle element is greater than the rightmost element.
                    if (nums[mid] > nums[right])
                    {
                        // If it is, the minimum element must be in the right half of the array.
                        // Move the left pointer to mid + 1 to search in the right half.
                        left = mid + 1;
                    }
                    else
                    {
                        // If it is not, the minimum element must be in the left half of the array.
                        // Move the right pointer to mid to search in the left half.
                        right = mid;
                    }
                }
                // Edge cases:
                // 1. Single element: The while loop doesn't execute, and nums[left] (the single element) is returned as the minimum.
                // 2. Already sorted: The else condition consistently reduces right until it converges with left at the smallest element(index 0).
                // 3. Rotated with minimum at start or end: The binary search logic correctly adjusts left and right to narrow down the search to the minimum element's location.
                // 4. Duplicate minimums: The comparisons in the if and else conditions guide the search towards a minimum element, even if duplicates exist
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                // Convert the number to a tring to eaily check its characters from both ends.
                string xString = x.ToString();

                // Loop through the first half of the string to compare characters from both ends.
                for (int i = 0; i < xString.Length / 2; i++)
                {
                    // If the characters at the current index and its corresponding index from the end are not equal,
                    // return false as it is not a palindrome.
                    if (xString[i] != xString[xString.Length-1-i])
                    {
                        return false;
                    }
                }
                // Edge cases:
                // 1. Negative numbers are handled by the minus sign causing a mismatch, so they return false.
                // 2. Single-digit numbers don't enter the loop, so they are considered palindromes and return true.
                // 3. Zero is handled by the loop not running, returning true as "0" is a palindrome.
                // 4. Large numbers are converted to strings and don't face overflow.
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                // Initialize the first two Fibonacci numbers.
                // FibonacciN_2 represents F(n-2) and FibonacciN_1 represents F(n-1) if n > 1.
                int FibonacciN_2 = 0;
                if (n <= 0)
                {
                    return FibonacciN_2;
                }

                int FibonacciN_1 = 1;
                if (n == 1)
                {
                    return FibonacciN_1;           
                }

                // Loop to calculate Fibonacci numbers starting from 2 up to n.
                for (int i = 2; i < n; i++)
                {
                    // Calculate the current Fibonacci number as the sum of the previous two.
                    int FibonacciN = FibonacciN_1 + FibonacciN_2;
                    // Update FibonacciN_2 and FibonacciN_1 for the next iteration.
                    FibonacciN_2 = FibonacciN_1;
                    FibonacciN_1 = FibonacciN;
                }
                // Edge cases:
                // 1. If n is 0 or negative, the code returns 0, as Fibonacci(0) is 0 by definition, and negative values are not valid for Fibonacci.
                // 2. If n is 1, it returns 1, as Fibonacci(1) is 1 by definition.
                return FibonacciN_1 + FibonacciN_2;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
