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
            NumbersArray numbers = new NumbersArray(input);

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int product = 0;
            
            // Part one asks for the 2 numbers that sum to 2020
            (num1, num2) = numbers.GetTwoNumbersThatSumTo2020();
            product = num1 * num2;

            Console.WriteLine($"The two numbers that sum to 2020 are: {num1} and {num2}");
            Console.WriteLine($"The product of these numbers is: {product}");


            // Part two asks for the 3 numbers that sum to 2020
            (num1, num2, num3) = numbers.GetThreeNumbersThatSumTo2020();
            product = num1 * num2 * num3;

            Console.WriteLine($"The three numbers that sum to 2020 are: {num1}, {num2}, and {num3}");
            Console.WriteLine($"The product of these numbers is: {product}");
        }

    }
}
