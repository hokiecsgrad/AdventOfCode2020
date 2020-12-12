using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day11;

namespace tests
{
    public class Day11Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn()
        {
            string sampleInput = @"
                L.LL.LL.LL
                LLLLLLL.LL
                L.L.L..L..
                LLLL.LL.LL
                L.LL.LL.LL
                L.LLLLL.LL
                ..L.L.....
                LLLLLLLLLL
                L.LLLLLL.L
                L.LLLLL.LL";
            string[] seats = sampleInput.Split(Environment.NewLine,
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );
            char[,] seatMap = new char[seats.Length, seats[0].Length];
            for (int i = 0; i < seats.Length; i++)
                for (int j = 0; j < seats[0].Length; j++)
                    seatMap[i, j] = seats[i][j];

            GameOfChairs chairs = new GameOfChairs(seatMap);
            chairs.RunRound(chairs.CountAdjacentOccupiedSeats);

            Assert.Equal(
                new char[10, 10] {
                    { '#','.','#','#','.','#','#','.','#','#' },
                    { '#','#','#','#','#','#','#','.','#','#' },
                    { '#','.','#','.','#','.','.','#','.','.' },
                    { '#','#','#','#','.','#','#','.','#','#' },
                    { '#','.','#','#','.','#','#','.','#','#' },
                    { '#','.','#','#','#','#','#','.','#','#' },
                    { '.','.','#','.','#','.','.','.','.','.' },
                    { '#','#','#','#','#','#','#','#','#','#' },
                    { '#','.','#','#','#','#','#','#','.','#' },
                    { '#','.','#','#','#','#','#','.','#','#' }},
                chairs.CurrentMap
                );

            chairs.RunRound(chairs.CountAdjacentOccupiedSeats);

            Assert.Equal(
                new char[10, 10] {
                    { '#','.','L','L','.','L','#','.','#','#' },
                    { '#','L','L','L','L','L','L','.','L','#' },
                    { 'L','.','L','.','L','.','.','L','.','.' },
                    { '#','L','L','L','.','L','L','.','L','#' },
                    { '#','.','L','L','.','L','L','.','L','L' },
                    { '#','.','L','L','L','L','#','.','#','#' },
                    { '.','.','L','.','L','.','.','.','.','.' },
                    { '#','L','L','L','L','L','L','L','L','#' },
                    { '#','.','L','L','L','L','L','L','.','L' },
                    { '#','.','#','L','L','L','L','.','#','#' }},
                chairs.CurrentMap
                );

            chairs.RunRound(chairs.CountAdjacentOccupiedSeats);

            Assert.Equal(
                new char[10, 10] {
                    { '#','.','#','#','.','L','#','.','#','#' },
                    { '#','L','#','#','#','L','L','.','L','#' },
                    { 'L','.','#','.','#','.','.','#','.','.' },
                    { '#','L','#','#','.','#','#','.','L','#' },
                    { '#','.','#','#','.','L','L','.','L','L' },
                    { '#','.','#','#','#','L','#','.','#','#' },
                    { '.','.','#','.','#','.','.','.','.','.' },
                    { '#','L','#','#','#','#','#','#','L','#' },
                    { '#','.','L','L','#','#','#','L','.','L' },
                    { '#','.','#','L','#','#','#','.','#','#' }
                },
                chairs.CurrentMap
                );

            chairs.RunRound(chairs.CountAdjacentOccupiedSeats);

            Assert.Equal(
                new char[10, 10] {
                    { '#','.','#','L','.','L','#','.','#','#' },
                    { '#','L','L','L','#','L','L','.','L','#' },
                    { 'L','.','L','.','L','.','.','#','.','.' },
                    { '#','L','L','L','.','#','#','.','L','#' },
                    { '#','.','L','L','.','L','L','.','L','L' },
                    { '#','.','L','L','#','L','#','.','#','#' },
                    { '.','.','L','.','L','.','.','.','.','.' },
                    { '#','L','#','L','L','L','L','#','L','#' },
                    { '#','.','L','L','L','L','L','L','.','L' },
                    { '#','.','#','L','#','L','#','.','#','#' }
                },
                chairs.CurrentMap
                );

            chairs.RunRound(chairs.CountAdjacentOccupiedSeats);

            Assert.Equal(
                new char[10, 10] {
                    { '#','.','#','L','.','L','#','.','#','#' },
                    { '#','L','L','L','#','L','L','.','L','#' },
                    { 'L','.','#','.','L','.','.','#','.','.' },
                    { '#','L','#','#','.','#','#','.','L','#' },
                    { '#','.','#','L','.','L','L','.','L','L' },
                    { '#','.','#','L','#','L','#','.','#','#' },
                    { '.','.','L','.','L','.','.','.','.','.' },
                    { '#','L','#','L','#','#','L','#','L','#' },
                    { '#','.','L','L','L','L','L','L','.','L' },
                    { '#','.','#','L','#','L','#','.','#','#' }
                },
                chairs.CurrentMap
                );

            Assert.Equal(37, chairs.CountAllOccupiedSeats());
        }

        [Fact]
        public void TestPart1_WithSampleInput_ShouldStabilizeAt37()
        {
            string sampleInput = @"
                L.LL.LL.LL
                LLLLLLL.LL
                L.L.L..L..
                LLLL.LL.LL
                L.LL.LL.LL
                L.LLLLL.LL
                ..L.L.....
                LLLLLLLLLL
                L.LLLLLL.L
                L.LLLLL.LL";
            string[] seats = sampleInput.Split(Environment.NewLine,
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );
            char[,] seatMap = new char[seats.Length, seats[0].Length];
            for (int i = 0; i < seats.Length; i++)
                for (int j = 0; j < seats[0].Length; j++)
                    seatMap[i, j] = seats[i][j];

            GameOfChairs chairs = new GameOfChairs(seatMap);
            char[,] lastMap = new char[seatMap.GetLength(0), seatMap.GetLength(1)];
            bool equal = false;
            do
            {
                Array.Copy(chairs.CurrentMap, 0, lastMap, 0, chairs.CurrentMap.Length);
                chairs.RunRound(chairs.CountAdjacentOccupiedSeats);
                equal =
                    chairs.CurrentMap.Rank == lastMap.Rank &&
                    Enumerable.Range(0, chairs.CurrentMap.Rank).All(dimension => chairs.CurrentMap.GetLength(dimension) == lastMap.GetLength(dimension)) &&
                    chairs.CurrentMap.Cast<char>().SequenceEqual(lastMap.Cast<char>());
            } while (!equal);

            Assert.Equal(37, chairs.CountAllOccupiedSeats());
        }
    }
}