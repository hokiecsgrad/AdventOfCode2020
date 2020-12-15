using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Day14
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
            Dictionary<long, long> memory = new Dictionary<long, long>();

            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Substring(0, 4) == "mask")
                    mask = Parser.GetMask(data[i]);
                else
                {
                    (long memSlot, long value) = Parser.GetMem(data[i]);
                    BinaryNum num = new BinaryNum(value);
                    long result = num.Mask(mask);
                    memory[memSlot] = result;
                }
            }

            long total = 0;
            foreach (long key in memory.Keys)
                total += memory[key];

            Console.WriteLine($"The total of the memory slots is: {total}.");
        }

        public static void Part2(string[] data)
        {
        }
    }
}
