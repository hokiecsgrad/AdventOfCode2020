using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public class Trip
    {
        public string[] Pattern { get; private set; }
        public List<string> Map { get; private set; }
        public Vector Speed { get; private set; }

        public Trip(string[] pattern, List<string> map)
        {
            Pattern = pattern;
            Map = map;
        }

        public int GetNumberOfTreesWithSpeed(Vector speed)
        {
            Speed = speed;
            int totalTrees = 0;
            Point currentPosition = new Point(0, 0);
            while (currentPosition.Y < Map.Count)
            {
                if (currentPosition.X >= Map[currentPosition.Y].Length)
                    while (Map[currentPosition.Y].Length <= currentPosition.X)
                        Map[currentPosition.Y] += Pattern[currentPosition.Y];

                if (Map[currentPosition.Y][currentPosition.X] == '#')
                    totalTrees++;

                currentPosition = currentPosition + speed;
            }

            return totalTrees;
        }
    }
}