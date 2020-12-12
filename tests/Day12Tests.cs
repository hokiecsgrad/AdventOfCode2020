using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day12;

namespace tests
{
    public class Day12Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn25()
        {
            Ship ship = new Ship();

            ship.Move('F', 10);
            ship.Move('N', 3);
            ship.Move('F', 7);
            ship.Turn('R', 90);
            ship.Move('F', 11);

            int manhattanDist = Math.Abs(ship.Location.X) + Math.Abs(ship.Location.Y);

            Assert.Equal(25, manhattanDist);
        }

        [Fact]
        public void Heading_WhenTurningLeft_ShouldWrapCorrectly()
        {
            Ship ship = new Ship();
            ship.Turn('L', 180);
            Assert.Equal(270, ship.Heading);
        }
    }
}
