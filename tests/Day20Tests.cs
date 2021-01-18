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
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn()
        {
	    }

        [Fact]
        public void CreateTile_WithFirstRowOfSampleInput_ShouldCreateSingleTile()
        {
            string sampleInput = @"Tile 2311:
                ..##.#..#.
                ##..#.....
                #...##..#.
                ####.#...#
                ##.##.###.
                ##...#.###
                .#.#.#..##
                ..#....#..
                ###...#.#.
                ..###..###";
            string[] tileData = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );
            Tile tile = new Tile(tileData);

            string[] expectedTile = new string[] {
                "..##.#..#.", "##..#.....", "#...##..#.", "####.#...#", "##.##.###.", "##...#.###", ".#.#.#..##", "..#....#..", "###...#.#.", "..###..###"
            };

            Assert.Equal(2311, tile.Id);
            Assert.Equal(expectedTile, tile.Pattern);
        }

        [Fact]
        public void TileFlip_WithFirstRowOfSampleInput_ShouldFlipTile()
        {
            string sampleInput = @"Tile 2311:
                ..##.#..#.
                ##..#.....
                #...##..#.
                ####.#...#
                ##.##.###.
                ##...#.###
                .#.#.#..##
                ..#....#..
                ###...#.#.
                ..###..###";
            string[] tileData = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );
            Tile tile = new Tile(tileData);
            Tile flipped = tile.Flip();

            string[] expectedTile = new string[] {
                ".#..#.##..", ".....#..##", ".#..##...#", "#...#.####", ".###.##.##", "###.#...##", "##..#.#.#.", "..#....#..", ".#.#...###", "###..###.."
            };

            Assert.Equal(2311, flipped.Id);
            Assert.Equal(expectedTile, flipped.Pattern);
        }

        [Fact]
        public void TileRotate_WithFirstRowOfSampleData_ShouldRotateTile()
        {
            string sampleInput = @"Tile 2311:
                ..##.#..#.
                ##..#.....
                #...##..#.
                ####.#...#
                ##.##.###.
                ##...#.###
                .#.#.#..##
                ..#....#..
                ###...#.#.
                ..###..###";
            string[] tileData = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );
            Tile tile = new Tile(tileData);
            Tile rotated = tile.Rotate();

            string[] expectedTile = new string[] {
                "###..###..", ".#.#...###", "..#....#..", "##..#.#.#.", "###.#...##", ".###.##.##", "#...#.####", ".#..##...#", ".....#..##", ".#..#.##.."
            };

            Assert.Equal(2311, rotated.Id);
            Assert.Equal(expectedTile, rotated.Pattern);
        }

        [Fact]
        public void TileFilpAndRotate_WithSampleInput_ShouldFlipAndRotate()
        {
            string sampleInput = @"Tile 2311:
                ..##.#..#.
                ##..#.....
                #...##..#.
                ####.#...#
                ##.##.###.
                ##...#.###
                .#.#.#..##
                ..#....#..
                ###...#.#.
                ..###..###";
            string[] tileData = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );
            Tile tile = new Tile(tileData);
            Tile flipped = tile.Flip();
            Tile rotated = flipped.Rotate();

            string[] expectedTile = new string[] {
                "..###..###", "###...#.#.", "..#....#..", ".#.#.#..##", "##...#.###", "##.##.###.", "####.#...#", "#...##..#.", "##..#.....", "..##.#..#."
            };

            Assert.Equal(2311, rotated.Id);
            Assert.Equal(expectedTile, rotated.Pattern);
        }


        public List<Tile> Tiles = new();
    }
}
