using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            long totalTime = 0;
            long timeToLoadInput = 0;
            long timeToSolvePart1 = 0;
            long timeToSolvePart2 = 0;

            watch.Start();
            InputGetter inputter = new InputGetter("input.txt");
            string[] boardingPasses = inputter.GetStringsFromInput();
            watch.Stop();
            timeToLoadInput = watch.ElapsedMilliseconds;

            Console.WriteLine($"Input loaded in {timeToLoadInput} ms");

            // Process Part 1
            watch.Start();

            BoardingPassParser maxSeatCalc = new BoardingPassParser("BBBBBBBRRR");
            int maxPossibleSeatId = maxSeatCalc.GetId();
            int[] seats = new int[maxPossibleSeatId];

            int maxSeatId = 0;
            int minSeatId = maxPossibleSeatId;
            for (int i = 0; i < boardingPasses.Length; i++)
            {
                BoardingPassParser seatCalc = new BoardingPassParser(boardingPasses[i]);
                int row = seatCalc.GetRow();
                int col = seatCalc.GetCol();
                int id = seatCalc.GetId();
                seats[id] = 1;
                if (id > maxSeatId) maxSeatId = id;
                if (id < minSeatId) minSeatId = id;
            }
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The max seat id is: {maxSeatId}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");

            // Process Part 2
            watch.Start();
            int mySeatId = 0;
            for (int i = minSeatId; i < maxSeatId; i++)
                if (seats[i] == 0)
                    mySeatId = i;
            watch.Stop();
            timeToSolvePart2 = watch.ElapsedMilliseconds - timeToSolvePart1 - timeToLoadInput;

            Console.WriteLine($"My seat id is: {mySeatId}");
            Console.WriteLine($"Solved in {timeToSolvePart2} ms");

            totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time: {totalTime} ms");
        }
    }
}
