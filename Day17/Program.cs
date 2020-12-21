using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day17
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
            string input = string.Join("", data);
            Cube board = new Cube(input);
            for (int i = 0; i < 6; i++)
                board.Tick();
            Console.WriteLine($"After six cylce, the number of active cells is: {board.CountAllActive()}.");
        }

        public static void Part2(string[] data)
        {
            string input = string.Join("", data);
            HyperCube board = new HyperCube(input);
            for (int i = 0; i < 6; i++)
                board.Tick();
            Console.WriteLine($"After six cylce, the number of active cells is: {board.CountAllActive()}.");
        }
    }
}
