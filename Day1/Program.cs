/* Advent of Code # 1059068-20201201-e3937a39 */

using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter inputter = new InputGetter("input.txt");
            int[] input = inputter.GetIntsFromInput();
            // int[] input = new int[] {1721, 979, 366, 299, 675, 1456};
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int product = 0;
            
            (num1, num2) = FindTwoNumbersThatSumTo2020(input);
            product = num1 * num2;

            Console.WriteLine($"The two numbers that sum to 2020 are: {num1} and {num2}");
            Console.WriteLine($"The product of these numbers is: {product}");

            (num1, num2, num3) = FindThreeNumbersThatSumTo2020(input);
            product = num1 * num2 * num3;

            Console.WriteLine($"The three numbers that sum to 2020 are: {num1}, {num2}, and {num3}");
            Console.WriteLine($"The product of these numbers is: {product}");
        }

        public static (int, int) FindTwoNumbersThatSumTo2020(int[] numbers)
        {
            for (int outerIndex = 0; outerIndex < numbers.Length; outerIndex++)
                for (int innerIndex = outerIndex; innerIndex < numbers.Length; innerIndex++)
                    if ( numbers[outerIndex] + numbers[innerIndex] == 2020 )
                        return (numbers[outerIndex], numbers[innerIndex]);

            return (0,0);
        }

        public static (int, int, int) FindThreeNumbersThatSumTo2020(int[] numbers)
        {
            for (int outerIndex = 0; outerIndex < numbers.Length; outerIndex++)
                for (int innerIndex = outerIndex; innerIndex < numbers.Length; innerIndex++)
                    for (int innerestIndex = innerIndex; innerestIndex < numbers.Length; innerestIndex++)
                        if ( numbers[outerIndex] + numbers[innerIndex] + numbers[innerestIndex] == 2020 )
                            return (numbers[outerIndex], numbers[innerIndex], numbers[innerestIndex]);

            return (0,0,0);
        }
    }
}
