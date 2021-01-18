using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day20
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
            List<Tile> tiles = new();
            for (int i = 0; i < data.Length; i += 12)
            {
                string[] tileData = data[new Range(i, i+11)];
                tiles.Add( new Tile(tileData) );
            }

            Image pic = new Image(tiles);
            List<int> cornerIds = pic.GetCorners();
            
            long total = 1;
            foreach (int value in cornerIds)
                total *= value;

            Console.WriteLine($"The product of all the corners is: {total}.");
        }

        public static void Part2(string[] data)
        {
        }
    }
}
