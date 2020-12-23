using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day18
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
            long total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                ExpressionParser expression = new ExpressionParser(data[i]);
                expression.Parse();
                total += expression.Evaluate();
            }
            Console.WriteLine($"The total of all the expressions is: {total}.");
        }

        public static void Part2(string[] data)
        {
            long total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                ExpressionParser expression = new ExpressionParser(data[i]);
                expression.ParseDifferentPrecedence();
                total += expression.Evaluate();
            }
            Console.WriteLine($"The total of all the expressions is: {total}.");
        }
    }
}
