using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day12
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
            Ship ship = new Ship();
            for (int i = 0; i < data.Length; i++)
            {
                char instruction = data[i][0];
                int value = int.Parse(data[i].Substring(1, data[i].Length - 1));
                if (instruction == 'R' || instruction == 'L')
                    ship.Turn(instruction, value);
                else
                    ship.Move(instruction, value);
            }
            int manhattanDist = Math.Abs(ship.Location.X) + Math.Abs(ship.Location.Y);
            Console.WriteLine($"The Manhattan Distance for the ship is: {manhattanDist}.");
        }

        public static void Part2(string[] data)
        {
            Ship ship = new Ship();

            for (int i = 0; i < data.Length; i++)
            {
                char instruction = data[i][0];
                int value = int.Parse(data[i].Substring(1, data[i].Length - 1));
                if (instruction == 'F')
                    ship.MoveTowardsWaypoint(value);
                else if (instruction == 'R' || instruction == 'L')
                    ship.RotateWaypoint(instruction, value);
                else
                    ship.MoveWaypoint(instruction, value);
            }

            int manhattanDist = Math.Abs(ship.Location.X) + Math.Abs(ship.Location.Y);
            Console.WriteLine($"The Manhattan Distance for the ship is: {manhattanDist}.");
        }
    }
}
