using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day17;

namespace tests
{
    public class Day17Tests
    {
        public const char ON = '#';
        public const char OFF = '.';

        [Fact]
        public void Part1_WithSampleInput_ShouldReturn()
        {
            string sampleInput = ".#...####";
            Cube board = new Cube(sampleInput);
            board.Tick();
            char[,,] step1 = new char[3, 5, 5] {
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,ON,OFF,OFF,OFF},
                  {OFF,OFF,OFF,ON,OFF},
                  {OFF,OFF,ON,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,ON,OFF,ON,OFF},
                  {OFF,OFF,ON,ON,OFF},
                  {OFF,OFF,ON,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,ON,OFF,OFF,OFF},
                  {OFF,OFF,OFF,ON,OFF},
                  {OFF,OFF,ON,OFF,OFF}
                }
            };
            Assert.Equal(step1, board.BoardState);

            board.Tick();
            char[,,] step2 = new char[5, 7, 5] {
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,ON,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,ON,OFF,OFF},
                  {OFF,ON,OFF,OFF,ON},
                  {OFF,OFF,OFF,OFF,ON},
                  {OFF,ON,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {ON,ON,OFF,OFF,OFF},
                  {ON,ON,OFF,OFF,OFF},
                  {ON,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,ON},
                  {OFF,ON,ON,ON,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,ON,OFF,OFF},
                  {OFF,ON,OFF,OFF,ON},
                  {OFF,OFF,OFF,OFF,ON},
                  {OFF,ON,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,ON,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                }
            };
            Assert.Equal(step2, board.BoardState);

            board.Tick();
            board.Tick();
            board.Tick();
            board.Tick();

            Assert.Equal(112, board.CountAllActive());
        }

        [Fact]
        public void BoardCtor_WithSampleInput_ShouldReturn3by3CharArray()
        {
            string strBoard = ".#...####";
            Cube board = new Cube(strBoard);
            char[,,] expected = new char[1, 3, 3] { { { '.', '#', '.' }, { '.', '.', '#' }, { '#', '#', '#' } } };
            Assert.Equal(expected, board.BoardState);
        }

        [Fact]
        public void CountNeighbors_WithSampleInput_ShoulReturn3()
        {
            string strBoard = ".#...####";
            Cube board = new Cube(strBoard);
            int neighbors = board.GetActiveNeighborCount(0, 2, 1);
            Assert.Equal(3, neighbors);
        }

        [Fact]
        public void GrowBoardTest_WithSimpleInput_ShouldReturnTrueFalseFalse()
        {
            string strBoard = "....#....";
            Cube board = new Cube(strBoard);
            Assert.Equal((true, false, false), board.ShouldGrowBoard());
        }

        [Fact]
        public void GrowBoardTest_WithDefaultInput_ShouldReturnTrueForAll()
        {
            string strBoard = ".#...####";
            Cube board = new Cube(strBoard);
            Assert.Equal((true, true, true), board.ShouldGrowBoard());
        }

        [Fact]
        public void GrowBoard_WithDefaultInput_ShouldReturnLargerBoardInXAndYAndZ()
        {
            string strBoard = ".#...####";
            Cube board = new Cube(strBoard);
            board.GrowBoard();

            char[,,] expected = new char[3, 5, 5] {
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,ON,OFF,OFF},
                  {OFF,OFF,OFF,ON,OFF},
                  {OFF,ON,ON,ON,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                },
                { {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF},
                  {OFF,OFF,OFF,OFF,OFF}
                }
            };
            Assert.Equal(expected, board.BoardState);
        }
    }
}
