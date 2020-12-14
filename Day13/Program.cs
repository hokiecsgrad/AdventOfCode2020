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

            long minWaitId = -1;
            long minWaitTime = int.MaxValue;
            for (int i = 0; i < schedules.Length; i++)
            {
                Schedule schedule = new Schedule(schedules[i]);
                long busArrivalTime = schedule.GetNearestDepartureTimeTo(earliestTime);

                long waitTime = busArrivalTime - earliestTime;
                if (waitTime < minWaitTime)
                {
                    minWaitTime = waitTime;
                    minWaitId = schedules[i];
                }
            }

            long total = minWaitId * minWaitTime;
            Console.WriteLine($"The {minWaitId} bus has shortest wait at {minWaitTime} minutes for a total of {total}.");
        }

        // Day 13 Part 2 is the first problem that I couldn't figure out on my own.  Couldn't even
        // figure out what to Google to help point me in the right direction.  I took this code
        // directly from one of the C# solutions in the subreddit.
        public static void Part2(string[] data)
        {
            int[] schedules = data[1].Split(',').ToList()
                                .Select(s => s == "x" ? 0 : int.Parse(s))
                                .ToArray();

            Schedule schedule = new Schedule(0, schedules[0]);
            for (int bi = 1; bi < schedules.Length; bi++)
            {
                if (schedules[bi] == 0) continue;
                schedule = schedule.CombineTwoBussesIntoOne(schedule, new Schedule(bi, schedules[bi]));
            }

            long time = schedule.Offset * -1;

            Console.WriteLine($"The earliest time when all bus departures match their ID is: {time}.");
        }
    }
}
