using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day12
{
    public class Ship
    {
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
    }
}