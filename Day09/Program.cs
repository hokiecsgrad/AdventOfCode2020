using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day9
{
    class Program
    {
        public static long InvalidOperation { get; private set; } = 0;

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
            long[] serialData = Array.ConvertAll(data, s => long.Parse(s));
            Stream stream = new Stream(serialData);
            stream.Run();
            InvalidOperation = stream.InvalidOperation;

            Console.WriteLine($"The invalid number in the stream is: {stream.InvalidOperation}.");
        }

        public static void Part2(string[] data)
        {
            long[] serialData = Array.ConvertAll(data, s => long.Parse(s));

            Stream stream = new Stream(serialData);
            (int lower, int upper) = stream.FindContiguousRange(InvalidOperation);

            List<long> contiguousNumbers = new List<long>(serialData[lower..(upper + 1)]);
            long min = contiguousNumbers.Min();
            long max = contiguousNumbers.Max();

            Console.WriteLine($"The encryption weakness number is: {min + max}.");
        }
    }
}
