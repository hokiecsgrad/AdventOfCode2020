using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode.Day3
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
            string[] pattern = inputter.GetStringsFromInput();
            watch.Stop();
            timeToLoadInput = watch.ElapsedMilliseconds;
            Console.WriteLine($"Input loaded in {timeToLoadInput} ms");

            watch.Start();
            List<string> map = new List<string>(pattern);
            Point currentPosition = new Point(0, 0);
            Vector speed = new Vector(3, 1);
            int totalTrees = 0;
            while (currentPosition.Y < map.Count)
            {
                if (currentPosition.X >= map[currentPosition.Y].Length)
                    while (map[currentPosition.Y].Length <= currentPosition.X)
                        map[currentPosition.Y] += pattern[currentPosition.Y];

                if (map[currentPosition.Y][currentPosition.X] == '#')
                    totalTrees++;

                currentPosition = currentPosition + speed;
            }
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The number of trees on the path is: {totalTrees}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");

        }
    }
}
