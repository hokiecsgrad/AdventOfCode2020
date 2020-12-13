using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day13
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
            int earliestTime = int.Parse(data[0]);
            int[] schedules = data[1].Split(',').ToList()
                                .Where(s => s != "x")
                                .Select(s => int.Parse(s))
                                .OrderBy(s => s)
                                .ToArray();

            int minWaitId = -1;
            int minWaitTime = int.MaxValue;
            for (int i = 0; i < schedules.Length; i++)
            {
                int busArrivalTime = 0;
                while (busArrivalTime < earliestTime)
                    busArrivalTime += schedules[i];
                int waitTime = busArrivalTime - earliestTime;
                if (waitTime < minWaitTime)
                {
                    minWaitTime = waitTime;
                    minWaitId = schedules[i];
                }
            }

            int total = minWaitId * minWaitTime;
            Console.WriteLine($"The {minWaitId} bus has shortest wait at {minWaitTime} minutes for a total of {total}.");
        }

        public static void Part2(string[] data)
        {
        }
    }
}
