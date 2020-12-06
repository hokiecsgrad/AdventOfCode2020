using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day5
{
    class Program
    {
        public static int[] seats;
        public static int minSeatId;
        public static int maxSeatId;

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
            BoardingPassParser maxSeatCalc = new BoardingPassParser("BBBBBBBRRR");
            int maxPossibleSeatId = maxSeatCalc.GetId();
            seats = new int[maxPossibleSeatId];

            maxSeatId = 0;
            minSeatId = maxPossibleSeatId;
            for (int i = 0; i < data.Length; i++)
            {
                BoardingPassParser seatCalc = new BoardingPassParser(data[i]);
                int row = seatCalc.GetRow();
                int col = seatCalc.GetCol();
                int id = seatCalc.GetId();
                seats[id] = 1;
                if (id > maxSeatId) maxSeatId = id;
                if (id < minSeatId) minSeatId = id;
            }
            Console.WriteLine($"The max seat id is: {maxSeatId}");
        }

        public static void Part2(string[] data)
        {
            int mySeatId = 0;

            for (int i = minSeatId; i < maxSeatId; i++)
                if (seats[i] == 0)
                    mySeatId = i;

            Console.WriteLine($"My seat id is: {mySeatId}");
        }
    }
}
