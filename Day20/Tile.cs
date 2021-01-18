using System;
using System.Linq;

namespace AdventOfCode.Day20
{
    public class Tile
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
    }
}