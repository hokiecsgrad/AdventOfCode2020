using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public class Trip
    {
        public List<string> Map { get; private set; }
        public Vector Speed { get; private set; }

        public Trip(List<string> map)
        {
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
                    currentPosition = new Point(
                        currentPosition.X - Map[currentPosition.Y].Length,
                        currentPosition.Y);

                if (Map[currentPosition.Y][currentPosition.X] == '#')
                    totalTrees++;

                currentPosition = currentPosition + speed;
            }

            return totalTrees;
        }
    }
}