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
            string initialPattern = @"
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
            List<string> patternRows = new List<string>(initialPattern.Split(Environment.NewLine)).Select(s => s.Trim()).ToList();

            Assert.True(false);
        }
    }
}
