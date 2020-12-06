using System;
using System.IO;
using AdventOfCode.Common;

namespace AdventOfCode.Day7
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
        }

        public static void Part2(string[] data)
        {
        }
    }
}
