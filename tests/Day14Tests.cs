using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day14;

namespace tests
{
    public class Day14Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn165()
        {
            string sampleInput = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
                mem[8] = 11
                mem[7] = 101
                mem[8] = 0";
            string[] program = sampleInput.Split(Environment.NewLine,
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        );
            Dictionary<long, long> memory = new Dictionary<long, long>();
            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            for (int i = 0; i < program.Length; i++)
            {
                if (program[i].Substring(0, 4) == "mask")
                    mask = program[i].Split('=', StringSplitOptions.TrimEntries)[1];
                else
                {
                    long memSlot = long.Parse(new Regex("^mem\\[([\\d]+)\\] ").Match(program[i]).Groups[1].ToString());
                    long value = long.Parse(program[i].Split('=', StringSplitOptions.TrimEntries)[1]);
                    BinaryNum num = new BinaryNum(value);
                    long result = num.Mask(mask);
                    memory[memSlot] = result;
                }
            }

            long total = 0;
            foreach (long key in memory.Keys)
                total += memory[key];

            Assert.Equal(165, total);
        }

        [Fact]
        public void BinaryNumberMask_WithSampleInput_ShouldReturn73()
        {
            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X";
            BinaryNum num = new BinaryNum(int.Parse("11"));
            long result = num.Mask(mask);

            Assert.Equal(73, result);
        }
    }
}
