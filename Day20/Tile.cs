using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day20
{
    public enum Side
    {
        Top,
        Left,
        Right,
        Bottom
    }

    public enum Orientation
    {
        Given,
        Flipped,
        Rotated,
        FlippedAndRotated
    }

    public class Tile : IEquatable<Tile>
    {
        public int Id { get; set; } = 0;
        public string[] Pattern { get; set; } = new string[10];

        public Tile(string[] tile)
        {
            Id = int.Parse(tile[0].Substring(5, 4));
            for(int i = 1; i < 11; i++)
                Pattern[i - 1] = tile[i];
        }

        public Tile Flip()
        {
            string[] tileData = new string[11];
            tileData[0] = "Tile " + Id.ToString() + ":";
            for (int i = 0; i < Pattern.Length; i++)
            {
                char[] charArray = Pattern[i].ToCharArray();
                Array.Reverse(charArray);
                string reversed = new string(charArray);
                tileData[i+1] = reversed;
            }
            return new Tile(tileData);
        }

        public Tile Rotate()
        {
            string[] tileData = new string[11];
            tileData[0] = "Tile " + Id.ToString() + ":";
            for (int i = 0; i < 10; i++)
            {
                int mirrorRow = (10 - 1) - i;
                string rotated = string.Empty;
                for (int j = 9; j >= 0; j--)
                    rotated += Pattern[mirrorRow][j];
                tileData[i+1] = rotated;
            }
            return new Tile(tileData);
        }

        public bool NeighborOf(Tile tile)
        {
            return Id != tile.Id && SharedEdges(tile).Any();
        }

        private HashSet<string> SharedEdges(Tile tile)
        {
            return GetAllEdges().Intersect(tile.GetAllEdges()).ToHashSet();
        }

        public HashSet<string> GetAllEdges()
        {
            HashSet<string> edges = new();
            foreach (Side s in (Side[])Enum.GetValues(typeof(Side)))
            {
                string side = GetSide(s);
                char[] charArray = side.ToCharArray();
                Array.Reverse(charArray);
                string reversed = new string(charArray);

                edges.Add(side);
                edges.Add(reversed);
            }
            return edges;
        }

        public string GetSide(Side side)
        {
            string value = side switch 
            {
                Side.Top    => Pattern[0],
                Side.Bottom => Pattern[Pattern.Length - 1],
                Side.Left   => string.Join("", Pattern.Select(s => s[0]).ToArray()),
                Side.Right  => string.Join("", Pattern.Select(s => s[s.Length - 1]).ToArray()),
                _           => throw new ArgumentException("Invalid side requested!")
            };
            return value;
        }

        public bool Equals(Tile other)
        {
            return Id == other.Id;
        }
    }
}