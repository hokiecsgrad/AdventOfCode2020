using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day3;


namespace tests
{
    public class Day03Tests
    {
        [Fact]
        public void FindNumTrees_WithDefaultInput_ShouldReturn7()
        {
            string testInput = @"
                ..##.......
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
            string[] pattern = new List<string>(
                    testInput.Split(
                        Environment.NewLine,
                        StringSplitOptions.RemoveEmptyEntries
                        )
                )
                .Select(s => s.Trim()).ToArray();
            List<string> map = new List<string>(pattern);
            Trip trip = new Trip(map);

            int totalTrees = trip.GetNumberOfTreesWithSpeed(new Vector(3, 1));

            Assert.Equal(7, totalTrees);
        }

        [Fact]
        public void FindProductOfTrips_WithDefaultInput_ShouldReturn336()
        {
            string testInput = @"
                ..##.......
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
            string[] pattern = new List<string>(
                    testInput.Split(
                        Environment.NewLine,
                        StringSplitOptions.RemoveEmptyEntries
                        )
                )
                .Select(s => s.Trim()).ToArray();
            List<string> map = new List<string>(pattern);
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

            Assert.Equal(336, totalProduct);
        }
    }
}
