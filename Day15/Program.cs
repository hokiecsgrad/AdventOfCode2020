using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day15
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
            List<long> numbers = data.Select(long.Parse).ToList();
            MemoryGame game = new MemoryGame(numbers);
            long total = game.Play(2020);

            Console.WriteLine($"The 2020th number is: {total}.");
        }

        public static void Part2(string[] data)
        {
            List<long> numbers = data.Select(long.Parse).ToList();
            MemoryGame game = new MemoryGame(numbers);
            long total = game.Play(30_000_000);

            Console.WriteLine($"The 30,000,000th number is: {total}.");
        }
    }
}
