using System;
using AdventOfCode.Common;

namespace AdventOfCode.Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter("input.txt");

            ProgramFramework framework = new ProgramFramework();
            framework.InputHandler = input.GetStringsFromInput;
            framework.Part1Handler = Part1;
            framework.Part2Handler = Part2;
            framework.RunProgram();
        }

        public static void Part1(string[] data)
        {
            Computer computer = new Computer(data);
            computer.Run();

            Console.WriteLine($"The value of the accumulator is: {computer.Accumulator}.");
        }

        public static void Part2(string[] data)
        {
            Computer computer = new Computer(new string[0]);

            for (int i = 0; i < data.Length; i++)
            {
                string[] alteredProgram = new string[data.Length];
                Array.Copy(data, alteredProgram, data.Length);

                string newInstruction = string.Empty;
                InstructionParser parser = new InstructionParser(alteredProgram[i]);

                if (parser.Command == "nop")
                    newInstruction = "jmp " + parser.Value.ToString("+#;-#;+0");
                else if (parser.Command == "jmp")
                    newInstruction = "nop " + parser.Value.ToString("+#;-#;+0");
                else
                    continue;

                alteredProgram[i] = newInstruction;
                computer = new Computer(alteredProgram);
                computer.Run();

                if (!computer.IsInfiniteLoop)
                    break;
            }

            Console.WriteLine($"The value of the accumulator is: {computer.Accumulator}.");
        }
    }
}
