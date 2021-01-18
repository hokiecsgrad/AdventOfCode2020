using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day20
{
    public class Image
    {
        public HashSet<Tile> Tiles { get; set; } = new();

        public Image(List<Tile> tiles)
        {
            foreach (Tile tile in tiles)
            {
                Tiles.Add(tile);
            }
        }

        public List<int> GetCorners()
            => GetNeighbors().Where(t => t.Value.Count == 2).ToDictionary( x => x.Key, x => x.Value ).Select( t => t.Key.Id ).ToList();

        public Dictionary<Tile, List<Tile>> GetNeighbors()
            => Tiles.ToDictionary(t => t, t => NeighborsOf(t));

        private List<Tile> NeighborsOf(Tile tile)
            => Tiles.Where(t => tile.NeighborOf(t)).ToList();
    }
}