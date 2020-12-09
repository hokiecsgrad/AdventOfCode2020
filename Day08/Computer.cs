using System;

namespace AdventOfCode.Day8
{
    public class Computer
    {
        public string[] Program { get; private set; }
        public int Accumulator { get; private set; } = 0;
        public bool IsInfiniteLoop { get; private set; } = false;

        public Computer(string[] program)
        {
            Program = program;
        }

        public void Run()
        {
            bool[] hasBeenVisited = new bool[Program.Length];
            int programPosition = 0;
            while (programPosition < Program.Length)
            {
                hasBeenVisited[programPosition] = true;
                InstructionParser parser = new InstructionParser(Program[programPosition]);
                switch (parser.Command)
                {
                    case "acc":
                        Accumulator += parser.Value;
                        programPosition++;
                        break;
                    case "jmp":
                        programPosition += parser.Value;
                        break;
                    default:
                        programPosition++;
                        break;
                }
                if (programPosition >= Program.Length)
                    break;
                else if (hasBeenVisited[programPosition])
                {
                    IsInfiniteLoop = true;
                    break;
                }
            }
        }
    }
}