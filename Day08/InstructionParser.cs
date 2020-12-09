namespace AdventOfCode.Day8
{
    public class InstructionParser
    {
        public string Command { get; private set; } = string.Empty;
        public int Value { get; private set; } = 0;

        public InstructionParser(string instruction)
        {
            Command = instruction.Substring(0, 3);
            Value = int.Parse(instruction.Split(" ")[1]);
        }
    }
}