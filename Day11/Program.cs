using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day11
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
            char[,] seatMap = ConvertStringArrayToMultiDimensionalCharArray(data);
            RuleSet rules = new RuleSet();
            rules.GetOccupiedThreshold = rules.GetPart1OccupiedThreshold;
            rules.GetNumOccupiedSeats = rules.CountAdjacentOccupiedSeats;

            GameOfChairs chairs = new GameOfChairs(seatMap, rules);
            char[,] lastMap = new char[seatMap.GetLength(0), seatMap.GetLength(1)];
            do
            {
                Array.Copy(chairs.CurrentMap, 0, lastMap, 0, chairs.CurrentMap.Length);
                chairs.RunRound();
            } while (!AreArraysTheSame(lastMap, chairs.CurrentMap));

            int total = chairs.CountAllOccupiedSeats();
            Console.WriteLine($"After stabilization, total occupied chairs are: {total}.");
        }

        public static void Part2(string[] data)
        {
            char[,] seatMap = ConvertStringArrayToMultiDimensionalCharArray(data);
            RuleSet rules = new RuleSet();
            rules.GetOccupiedThreshold = rules.GetPart2OccupiedThreshold;
            rules.GetNumOccupiedSeats = rules.CountLineOfSightOccupiedSeats;

            GameOfChairs chairs = new GameOfChairs(seatMap, rules);
            char[,] lastMap = new char[seatMap.GetLength(0), seatMap.GetLength(1)];
            do
            {
                Array.Copy(chairs.CurrentMap, 0, lastMap, 0, chairs.CurrentMap.Length);
                chairs.RunRound();
            } while (!AreArraysTheSame(lastMap, chairs.CurrentMap));

            int total = chairs.CountAllOccupiedSeats();
            Console.WriteLine($"After stabilization, total occupied chairs are: {total}.");
        }

        private static char[,] ConvertStringArrayToMultiDimensionalCharArray(string[] data)
        {
            char[,] newArray = new char[data.Length, data[0].Length];
            for (int i = 0; i < data.Length; i++)
                for (int j = 0; j < data[0].Length; j++)
                    newArray[i, j] = data[i][j];
            return newArray;
        }

        private static bool AreArraysTheSame(char[,] source, char[,] dest)
            => source.Rank == dest.Rank &&
                Enumerable.Range(0, source.Rank).All(dimension => source.GetLength(dimension) == dest.GetLength(dimension)) &&
                source.Cast<char>().SequenceEqual(dest.Cast<char>());

    }
}
