using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day12
{
    public class Ship
    {
        public Point Waypoint { get; set; } = new Point(10, 1);
        public int Heading { get; private set; } = 90;
        public Point Location { get; set; } = new Point(0, 0);

        public void Move(char direction, int distance)
        {
            int bearing = direction switch
            {
                'N' => 0,
                'E' => 90,
                'S' => 180,
                'W' => 270,
                'F' => Heading,
                _ => 0,
            };

            double bearingInRads = bearing * Math.PI / 180;
            Vector velocity = new Vector(
                    (int)Math.Sin(bearingInRads) * distance,
                    (int)Math.Cos(bearingInRads) * distance
                    );

            Location += velocity;
        }

        public void Turn(char direction, int amount)
        {
            int modifier = direction == 'R' ? 1 : -1;
            Heading += amount * modifier;
            if (Heading >= 360) Heading = Heading - 360;
            if (Heading < 0) Heading = 360 + Heading;
        }

        public void MoveTowardsWaypoint(int amount)
        {
            Location = new Point(Location.X + (Waypoint.X * amount), Location.Y + (Waypoint.Y * amount));
        }

        public void MoveWaypoint(char direction, int amount)
        {
            Vector move = direction switch
            {
                'N' => new Vector(0, amount),
                'E' => new Vector(amount, 0),
                'S' => new Vector(0, -amount),
                'W' => new Vector(-amount, 0),
                _ => new Vector(0, 0),
            };
            Waypoint += move;
        }

        public void RotateWaypoint(char direction, int degrees)
        {
            int modifier = direction == 'R' ? 1 : -1;
            double radians = (degrees * modifier) * Math.PI / 180;
            int x = (Waypoint.X * (int)Math.Cos(radians)) + (Waypoint.Y * (int)Math.Sin(radians));
            int y = (-Waypoint.X * (int)Math.Sin(radians)) + (Waypoint.Y * (int)Math.Cos(radians));
            Point newDirection = new Point(x, y);
            Waypoint = newDirection;
        }
    }
}