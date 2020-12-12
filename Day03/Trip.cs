using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode.Day3
{
    public class Trip
    {
        public List<string> Map { get; private set; }

        public Trip(List<string> map)
        {
            Map = map;
        }

        public int GetNumberOfTreesWithSpeed(Vector speed)
        {
            int totalTrees = 0;
            Point currentPosition = new Point(0, 0);
            while (currentPosition.Y < Map.Count)
            {
                if (IsPositionOffEdgeOfMap(currentPosition))
                    currentPosition = new Point(
                        currentPosition.X - Map[currentPosition.Y].Length,
                        currentPosition.Y);

                if (IsPositionOnTree(currentPosition))
                    totalTrees++;

                currentPosition = currentPosition + speed;
            }

            return totalTrees;
        }

        private bool IsPositionOffEdgeOfMap(Point pos)
            => pos.X >= Map[pos.Y].Length;

        private bool IsPositionOnTree(Point pos)
            => Map[pos.Y][pos.X] == '#';
    }
}