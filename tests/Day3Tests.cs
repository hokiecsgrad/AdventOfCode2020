using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day3;


namespace tests
{
    public class Day3Tests
    {
        [Fact]
        public void FindNumTrees_WithDefaultInput_ShouldReturn7()
        {
            string testInput = @"..##.......
                #...#...#..
                .#....#..#.
                ..#.#...#.#
                .#...##..#.
                ..#.##.....
                .#.#.#....#
                .#........#
                #.##...#...
                #...##....#
                .#..#...#.#";

            List<string> pattern = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim()).ToList();

            List<string> map = new List<string>(pattern);

            int totalTrees = 0;
            Vector speed = new Vector(3, 1);
            Point currentPosition = new Point(0, 0);
            while (currentPosition.Y < map.Count())
            {
                if (currentPosition.X > map[currentPosition.Y].Length)
                    while (map[currentPosition.Y].Length < currentPosition.X)
                        map[currentPosition.Y] += pattern[currentPosition.Y];

                if (map[currentPosition.Y][currentPosition.X] == '#')
                    totalTrees++;

                currentPosition = currentPosition + speed;
            }

            Assert.Equal(7, totalTrees);
        }
    }
}
