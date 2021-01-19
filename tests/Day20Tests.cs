using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day20;

namespace tests
{
    public class Day20Tests
    {
        public List<Tile> Tiles = new();

        public Day20Tests()
        {
            string[] tilesData = Input.Split(Environment.NewLine + Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );
            for (int i = 0; i < tilesData.Length; i++)
            {
                string[] tileData = tilesData[i].Split(Environment.NewLine,
                                StringSplitOptions.TrimEntries |
                                StringSplitOptions.RemoveEmptyEntries
                                );
                Tiles.Add( new Tile(tileData) );
            }
        }

        [Fact]
        public void Part1_WithSampleInput_ShouldReturn20899048083289()
        {
            Image pic = new Image(Tiles);
            List<int> cornerIds = pic.GetCorners();
            long total = 1;
            foreach (int value in cornerIds)
                total *= value;

            Assert.Equal(20899048083289, total);
	    }

        [Fact(Skip="Nowhere near ready to run this yet.")]
        public void Part2_WithSampleInput_ShouldReturn273()
        {
        }

        [Fact]
        public void TileCreate_WithFirstRowOfSampleInput_ShouldCreateSingleTile()
        {
            Tile tile = Tiles[0];

            string[] expectedTile = new string[] {
                "..##.#..#.", "##..#.....", "#...##..#.", "####.#...#", "##.##.###.", "##...#.###", ".#.#.#..##", "..#....#..", "###...#.#.", "..###..###"
            };

            Assert.Equal(2311, tile.Id);
            Assert.Equal(expectedTile, tile.Pattern);
        }

        [Theory]
        [InlineData(Side.Top, "..##.#..#.")]
        [InlineData(Side.Bottom, "..###..###")]
        [InlineData(Side.Left, ".#####..#.")]
        [InlineData(Side.Right, "...#.##..#")]
        public void TileGetSide_WithFirstRowOfSampleInput_ShouldReturn(Side side, string expected)
        {
            Assert.Equal(expected, Tiles[0].GetSide(side));
        }

        [Fact]
        public void TileGetAllSides_With2311FromSampleInput_ShouldReturn8Rows()
        {
            HashSet<string> allEdges = Tiles[0].GetAllEdges();
            Assert.Equal(8, allEdges.Count);
            Assert.Contains("..##.#..#.", allEdges);
            Assert.Contains(".#..#.##..", allEdges);
            Assert.Contains(".#####..#.", allEdges);
            Assert.Contains(".#..#####.", allEdges);
            Assert.Contains("...#.##..#", allEdges);
            Assert.Contains("#..##.#...", allEdges);
            Assert.Contains("..###..###", allEdges);
            Assert.Contains("###..###..", allEdges);
        }

        [Fact]
        public void TileNeighborOf_With1951And2311FromSampleInput_ShouldReturnTrue()
        {
            Tile t1951 = Tiles.First(t => t.Id == 1951);
            Tile t2311 = Tiles.First(t => t.Id == 2311);
            Assert.True(t1951.NeighborOf(t2311));
        }

        [Fact]
        public void TileNeighborOf_With1951And1171FromSampleInput_ShouldReturnFalse()
        {
            Tile t1951 = Tiles.First(t => t.Id == 1951);
            Tile t1171 = Tiles.First(t => t.Id == 1171);
            Assert.False(t1951.NeighborOf(t1171));
        }

        [Fact]
        public void TileFlip_WithFirstRowOfSampleInput_ShouldFlipTile()
        {
            Tile tile = Tiles[0];
            Tile flipped = tile.Flip();

            string[] expectedTile = new string[] {
                ".#..#.##..", ".....#..##", ".#..##...#", "#...#.####", ".###.##.##", "###.#...##", "##..#.#.#.", "..#....#..", ".#.#...###", "###..###.."
            };

            Assert.Equal(2311, flipped.Id);
            Assert.Equal(expectedTile, flipped.Pattern);
        }

        [Fact]
        public void ImageGetCorners_WithSampleData_ShouldReturn1951And3079And2971And1171()
        {
            Image pic = new Image(Tiles);
            List<int> cornerIds = pic.GetCorners();

            Assert.Equal(4, cornerIds.Count);
            Assert.Contains(1951, cornerIds);
            Assert.Contains(3079, cornerIds);
            Assert.Contains(2971, cornerIds);
            Assert.Contains(1171, cornerIds);
        }

        public string Input = @"Tile 2311:
            ..##.#..#.
            ##..#.....
            #...##..#.
            ####.#...#
            ##.##.###.
            ##...#.###
            .#.#.#..##
            ..#....#..
            ###...#.#.
            ..###..###

            Tile 1951:
            #.##...##.
            #.####...#
            .....#..##
            #...######
            .##.#....#
            .###.#####
            ###.##.##.
            .###....#.
            ..#.#..#.#
            #...##.#..

            Tile 1171:
            ####...##.
            #..##.#..#
            ##.#..#.#.
            .###.####.
            ..###.####
            .##....##.
            .#...####.
            #.##.####.
            ####..#...
            .....##...

            Tile 1427:
            ###.##.#..
            .#..#.##..
            .#.##.#..#
            #.#.#.##.#
            ....#...##
            ...##..##.
            ...#.#####
            .#.####.#.
            ..#..###.#
            ..##.#..#.

            Tile 1489:
            ##.#.#....
            ..##...#..
            .##..##...
            ..#...#...
            #####...#.
            #..#.#.#.#
            ...#.#.#..
            ##.#...##.
            ..##.##.##
            ###.##.#..

            Tile 2473:
            #....####.
            #..#.##...
            #.##..#...
            ######.#.#
            .#...#.#.#
            .#########
            .###.#..#.
            ########.#
            ##...##.#.
            ..###.#.#.

            Tile 2971:
            ..#.#....#
            #...###...
            #.#.###...
            ##.##..#..
            .#####..##
            .#..####.#
            #..#.#..#.
            ..####.###
            ..#.#.###.
            ...#.#.#.#

            Tile 2729:
            ...#.#.#.#
            ####.#....
            ..#.#.....
            ....#..#.#
            .##..##.#.
            .#.####...
            ####.#.#..
            ##.####...
            ##..#.##..
            #.##...##.

            Tile 3079:
            #.#.#####.
            .#..######
            ..#.......
            ######....
            ####.#..#.
            .#...#.##.
            #.#####.##
            ..#.###...
            ..#.......
            ..#.###...";
    }
}
