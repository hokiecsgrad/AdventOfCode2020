using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day9;

namespace tests
{
    public class Day09Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn127()
        {
            string sampleInput = @"35
                20
                15
                25
                47
                40
                62
                55
                65
                95
                102
                117
                150
                182
                127
                219
                299
                277
                309
                576";
            string[] input = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();
            long[] serialData = Array.ConvertAll(input, s => long.Parse(s));

            int frameWindowSize = 5;
            Stream stream = new Stream(serialData, frameWindowSize);
            stream.Run();

            Assert.Equal(127, stream.InvalidOperation);
        }

        [Fact]
        public void Part2_WithSampleInput_ShouldReturn62()
        {
            string sampleInput = @"35
                20
                15
                25
                47
                40
                62
                55
                65
                95
                102
                117
                150
                182
                127
                219
                299
                277
                309
                576";
            string[] input = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();
            long[] serialData = Array.ConvertAll(input, s => long.Parse(s));

            int frameWindowSize = 5;
            Stream stream = new Stream(serialData, frameWindowSize);
            (int lower, int upper) = stream.FindContiguousRange(127);

            Assert.Equal(2, lower);
            Assert.Equal(5, upper);

            List<long> contiguousNumbers = new List<long>(serialData[lower..(upper + 1)]);
            long min = contiguousNumbers.Min();
            long max = contiguousNumbers.Max();

            Assert.Equal(62, min + max);
        }
    }
}