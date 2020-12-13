using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
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
        public void Part2_WithSampleInput_ShouldReturn286()
        {
            Ship ship = new Ship();

            ship.MoveTowardsWaypoint(10);
            ship.MoveWaypoint('N', 3);
            ship.MoveTowardsWaypoint(7);
            ship.RotateWaypoint('R', 90);
            ship.MoveTowardsWaypoint(11);

            int manhattanDist = Math.Abs(ship.Location.X) + Math.Abs(ship.Location.Y);

            Assert.Equal(286, manhattanDist);
        }

        [Fact]
        public void MovingWaypoint_North_ShouldMoveWaypointNorth()
        {
            Ship ship = new Ship();
            ship.MoveWaypoint('N', 5);
            Assert.Equal(6, ship.Waypoint.Y);
            Assert.Equal(10, ship.Waypoint.X);
        }

        [Fact]
        public void Heading_WhenTurningLeft_ShouldWrapCorrectly()
        {
            Ship ship = new Ship();
            ship.Turn('L', 180);
            Assert.Equal(270, ship.Heading);
        }

        [Fact]
        public void Rotate_WhenTurningLeft_ShouldMoveWaypoint()
        {
            Ship ship = new Ship();
            ship.RotateWaypoint('L', 90);
            Assert.Equal(-1, ship.Waypoint.X);
            Assert.Equal(10, ship.Waypoint.Y);
        }

        [Fact]
        public void Rotate_WhenTurningLeft_ShouldWrapWaypoint()
        {
            Ship ship = new Ship();
            ship.RotateWaypoint('L', 180);
            Assert.Equal(-10, ship.Waypoint.X);
            Assert.Equal(-1, ship.Waypoint.Y);
        }

        [Fact]
        public void MovingToWaypoint_ForVerySimpleCase_ShouldWork()
        {
            Ship ship = new Ship();
            ship.Waypoint = new Point(10, 0);
            ship.MoveTowardsWaypoint(1);

            Assert.Equal(10, ship.Location.X);
            Assert.Equal(0, ship.Location.Y);
        }

        [Fact]
        public void MovingToWaypoint_ForSlightlyMoreComplexCase_ShouldWork()
        {
            Ship ship = new Ship();
            ship.Waypoint = new Point(5, 5);
            ship.MoveTowardsWaypoint(10);

            Assert.Equal(50, ship.Location.X);
            Assert.Equal(50, ship.Location.Y);
        }
    }
}
