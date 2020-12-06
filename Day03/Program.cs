using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode.Day3
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
            List<string> map = new List<string>(data);
            Trip trip = new Trip(map);
            Vector speed = new Vector(3, 1);

            int totalTrees = trip.GetNumberOfTreesWithSpeed(speed);

            Console.WriteLine($"The number of trees on the path is: {totalTrees}");
        }

        public static void Part2(string[] data)
        {
            List<string> map = new List<string>(data);
            Trip trip = new Trip(map);
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
                int totalTrees = trip.GetNumberOfTreesWithSpeed(currentSpeed);
                totalProduct *= totalTrees;
            }

            Console.WriteLine($"The product of trees in each path: {totalProduct}");
        }
    }
}
