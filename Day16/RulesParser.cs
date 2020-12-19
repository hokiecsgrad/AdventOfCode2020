using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    public class Rule
    {
        public string Name { get; init; } = string.Empty;
        public (int Min, int Max) Lower { get; init; }
        public (int Min, int Max) Upper { get; init; }
    }

    public class RulesParser
    {
        public List<Rule> Rules { get; private set; } = new();

        public void AddRule(string rule)
        {
            Regex rulePattern = new Regex("^([\\w ]+): ([\\d]+)-([\\d]+) or ([\\d]+)-([\\d]+)$");
            Match match = rulePattern.Match(rule);
            if (match.Success)
            {
                Rule newRule = new Rule
                {
                    Name = match.Groups[1].ToString(),
                    Lower = (int.Parse(match.Groups[2].ToString()), int.Parse(match.Groups[3].ToString())),
                    Upper = (int.Parse(match.Groups[4].ToString()), int.Parse(match.Groups[5].ToString()))
                };
                Rules.Add(newRule);
            }
        }
    }
}