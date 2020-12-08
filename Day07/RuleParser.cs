using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day7
{
    public class RuleParser
    {
        public string Rule { get; private set; } = string.Empty;

        public RuleParser(string rule)
        {
            Rule = rule;
        }

        public Rule CreateRule()
        {
            string bagColor = GetFirstTwoWords(Rule);
            Dictionary<string, int> contains = GetContainingBagColors(Rule);
            return new Day7.Rule(bagColor, contains);
        }

        private string GetFirstTwoWords(string input)
        {
            Regex pattern = new Regex("^(\\w+ \\w+) ");
            return pattern.Match(input).Groups[1].ToString();
        }

        private Dictionary<string, int> GetContainingBagColors(string input)
        {
            if (input.Contains("no other bags"))
                return new Dictionary<string, int>();

            Dictionary<string, int> bags = new Dictionary<string, int>();
            Regex pattern = new Regex("([\\d]) (\\w+ \\w+) bag[s]?");

            foreach (Match bag in pattern.Matches(input))
            {
                Dictionary<string, int> data = new Dictionary<string, int>();
                bags.Add(bag.Groups[2].ToString(), int.Parse(bag.Groups[1].ToString()));
            }

            return bags;
        }
    }
}