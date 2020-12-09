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

        [Fact]
        public void Part2_WithSampleInput_ShouldReturn8()
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

            Computer computer = new Computer(new string[0]);

            for (int i = 0; i < programData.Length; i++)
            {
                programData = new List<string>(
                    sampleInput.Split(Environment.NewLine,
                                        StringSplitOptions.TrimEntries |
                                        StringSplitOptions.RemoveEmptyEntries
                                        )
                    )
                    .ToArray();
                InstructionParser parser = new InstructionParser(programData[i]);
                string newInstruction = string.Empty;

                if (parser.Command == "nop")
                    newInstruction = "jmp " + parser.Value.ToString("+#;-#;+0");
                else if (parser.Command == "jmp")
                    newInstruction = "nop " + parser.Value.ToString("+#;-#;+0");
                else
                    continue;

                programData[i] = newInstruction;
                computer = new Computer(programData);
                computer.Run();

                if (!computer.IsInfiniteLoop)
                    break;
            }

            Assert.Equal(8, computer.Accumulator);
        }
    }
}