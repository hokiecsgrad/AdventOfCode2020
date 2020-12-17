using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day15;

namespace tests
{
    public class Day15Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn436()
        {
            string sampleInput = @"0,3,6";
            string[] input = sampleInput.Split(',',
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );
            List<long> numbers = input.Select(long.Parse).ToList();
            MemoryGame game = new MemoryGame(numbers);
            long total = game.Play(2020);
            Assert.Equal(436, total);
        }

        [Theory]
        [InlineData("1,3,2", 1)]
        [InlineData("2,1,3", 10)]
        [InlineData("1,2,3", 27)]
        [InlineData("2,3,1", 78)]
        [InlineData("3,2,1", 438)]
        [InlineData("3,1,2", 1836)]
        public void Part1_WithOtherSamples_ShouldReturnExpected(string sampleInput, long expected)
        {
            string[] input = sampleInput.Split(',',
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );
            List<long> numbers = input.Select(long.Parse).ToList();
            MemoryGame game = new MemoryGame(numbers);
            long total = game.Play(2020);
            Assert.Equal(expected, total);
        }

        [Theory]
        [InlineData("0,3,6", 175594)]
        [InlineData("1,3,2", 2578)]
        [InlineData("2,1,3", 3544142)]
        [InlineData("1,2,3", 261214)]
        [InlineData("2,3,1", 6895259)]
        [InlineData("3,2,1", 18)]
        [InlineData("3,1,2", 362)]
        public void Part2_WithOtherSamples_ShouldReturnExpected(string sampleInput, long expected)
        {
            string[] input = sampleInput.Split(',',
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );
            List<long> numbers = input.Select(long.Parse).ToList();
            MemoryGame game = new MemoryGame(numbers);
            long total = game.Play(30000000);
            Assert.Equal(expected, total);
        }
    }
}
