using System;
using System.Collections.Generic;
using Xunit;
using AdventOfCode.Day8;

namespace tests
{
    public class Day08Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn5()
        {
            string sampleInput = @"nop +0
                acc +1
                jmp +4
                acc +3
                jmp -3
                acc -99
                acc +1
                jmp -4
                acc +6";
            string[] programData = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();

            Computer computer = new Computer(programData);
            computer.Run();

            Assert.Equal(5, computer.Accumulator);
        }
    }
}