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
            Vector speed = new Vector(3, 1);
            Trip trip = new Trip(pattern, map);
            int totalTrees = trip.GetNumberOfTreesWithSpeed(speed);
            watch.Stop();
            timeToSolvePart1 = watch.ElapsedMilliseconds - timeToLoadInput;

            Console.WriteLine($"The number of trees on the path is: {totalTrees}");
            Console.WriteLine($"Solved in {timeToSolvePart1} ms");

            watch.Start();
            map = new List<string>(pattern);
            List<Vector> speeds = new List<Vector> {
                new Vector(1, 1),
                new Vector(3, 1),
                new Vector(5, 1),
                new Vector(7, 1),
                new Vector(1, 2)
                };
            long totalProduct = 1;
            foreach (Vector currentSpeed in speeds)
            {
                totalTrees = trip.GetNumberOfTreesWithSpeed(currentSpeed);
                totalProduct *= totalTrees;
            }
            watch.Stop();
            timeToSolvePart2 = watch.ElapsedMilliseconds - timeToSolvePart1 - timeToLoadInput;

            Console.WriteLine($"The product of trees in each path: {totalProduct}");
            Console.WriteLine($"Solved in {timeToSolvePart2} ms");

            totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time: {totalTime} ms");
        }
    }
}
