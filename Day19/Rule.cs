using System.Collections.Generic;

namespace AdventOfCode.Day19
{
    public class Rule
    {
        public int Number { get; init; }
        public char Character { get; init; }
        public List<int> Primary { get; init; } = new();
        public List<int> Secondary { get; init; } = new();
    }
}