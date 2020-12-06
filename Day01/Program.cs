using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter("input.txt");

            ProgramFramework framework = new ProgramFramework();
            framework.InputHandler = input.GetStringsFromInput;
            framework.Part1Handler = Part1;
            framework.Part2Handler = Part2;
            framework.RunProgram();
        }

        public static void Part1(string[] data)
        {
            int num1 = 0;
            int num2 = 0;
            int[] input = Array.ConvertAll(data, s => int.Parse(s));
            NumbersArray numbers = new NumbersArray(input);
            (num1, num2) = numbers.GetTwoNumbersThatSumTo2020();
            int product = num1 * num2;
            Console.WriteLine($"The two numbers that sum to 2020 are: {num1} and {num2}");
            Console.WriteLine($"The product of these numbers is: {product}");
        }

        public static void Part2(string[] data)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int[] input = Array.ConvertAll(data, s => int.Parse(s));
            NumbersArray numbers = new NumbersArray(input);
            (num1, num2, num3) = numbers.GetThreeNumbersThatSumTo2020();
            int product = num1 * num2 * num3;
            Console.WriteLine($"The three numbers that sum to 2020 are: {num1}, {num2}, and {num3}");
            Console.WriteLine($"The product of these numbers is: {product}");
        }
    }
}
