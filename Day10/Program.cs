using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day10
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
            List<int> joltageData = new List<int>(Array.ConvertAll(data, s => int.Parse(s)));
            joltageData.Add(0);
            joltageData.Add( joltageData.Max() + 3 );

            AdapterChain adapters = new AdapterChain(joltageData);
            (int countOf1Diffs, int countOf3Diffs) = adapters.GetJoltageDiffs();
            int product = countOf1Diffs * countOf3Diffs;

            Console.WriteLine($"There were {countOf1Diffs} 1s and {countOf3Diffs} 3s.");
            Console.WriteLine($"The product of the number of 1 offs and the number of 3 offs is: {countOf1Diffs * countOf3Diffs}.");
        }

        public static void Part2(string[] data)
        {
        }
    }
}
