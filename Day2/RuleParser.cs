using System;

namespace AdventOfCode.Day2
{
    public class RuleParser
    {
        public int Min { get; private set; } = 0;
        public int Max { get; private set; } = 0;
        public char Pattern { get; private set; } = ' ';

        public void ParseRules(string rawRules)
        {
            // raw: "1-3 a"
            string[] rules = rawRules.Split(' ');
            if (rules.Length == 0)
                throw new ArgumentException("Invalid input format, contains no spaces ( )");

            string[] minMax = rules[0].Split('-');
            if (minMax.Length == 0)
                throw new ArgumentException("Invalid input format, contains no hyphen (-)");
            
            try 
            {
                Min = int.Parse(minMax[0]);
                Max = int.Parse(minMax[1]);
                Pattern = (char)rules[1][0];
            }
            catch
            {
                throw new ArgumentException("Invalid input format, invalid numbers found for min/max");
            }
        }
    }
}