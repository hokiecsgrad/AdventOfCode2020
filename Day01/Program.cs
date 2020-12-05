using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            long totalTime = 0;
            long timeToLoadInput = 0;
            long timeToSolvePart1 = 0;
            long timeToSolvePart2 = 0;
            
            watch.Start();
            InputGetter inputter = new InputGetter("input.txt");
            int[] input = inputter.GetIntsFromInput();
            NumbersArray numbers = new NumbersArray(input);
            watch.Stop();
            timeToLoadInput = watch.ElapsedMilliseconds;
            Console.WriteLine($"Input loaded in {timeToLoadInput} ms");

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int product = 0;
            
            // Part one asks for the 2 numbers that sum to 2020
            watch.Start();
            (num1, num2) = numbers.GetTwoNumbersThatSumTo2020();
            product = num1 * num2;
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The two numbers that sum to 2020 are: {num1} and {num2}");
            Console.WriteLine($"The product of these numbers is: {product}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");


            // Part two asks for the 3 numbers that sum to 2020
            watch.Start();
            (num1, num2, num3) = numbers.GetThreeNumbersThatSumTo2020();
            product = num1 * num2 * num3;
            watch.Stop();
            timeToSolvePart2 = watch.ElapsedMilliseconds - timeToSolvePart1 - timeToLoadInput;

            Console.WriteLine($"The three numbers that sum to 2020 are: {num1}, {num2}, and {num3}");
            Console.WriteLine($"The product of these numbers is: {product}");
            Console.WriteLine($"Solved in {timeToSolvePart2} ms");

            totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time: {totalTime} ms");
        }
    }
}
