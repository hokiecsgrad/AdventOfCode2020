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
            List<string> contains = GetContainingBagColors(Rule);
            return new Day7.Rule(bagColor, contains);
        }

        private string GetFirstTwoWords(string input)
        {
            Regex pattern = new Regex("^(\\w+ \\w+) ");
            return pattern.Match(input).Groups[1].ToString();
        }

        private List<string> GetContainingBagColors(string input)
        {
            if (input.Contains("no other bags"))
                return new List<string>();

            List<string> bags = new List<string>();
            Regex pattern = new Regex("[\\d] (\\w+ \\w+) bag[s]?");

            foreach (Match bag in pattern.Matches(input))
                bags.Add(bag.Groups[1].ToString());

            return bags;
        }
    }
}