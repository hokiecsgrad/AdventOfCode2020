using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day19
{
    public static class RuleParser
    {
        public static Rule Parse(string rule)
        {
            Rule newRule = new();
            Regex nestedPattern = new Regex(@"^([\d]+):[ ]?([\d]+)[ ]*([\d]*)[ ]?[|]?[ ]?([\d]*)[ ]?([\d]*)$");
            Regex charOnly = new Regex(@"^([\d]+): ""[ab]{1}""$");
            Match match = nestedPattern.Match(rule);
            if (match.Success)
            {
                StringSplitOptions opts = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
                int ruleNumber = int.Parse(rule.Split(':', opts)[0]);
                string numbers = rule.Split(':', opts)[1];
                string[] numsArray = numbers.Split('|', opts);
                string primary = numsArray[0];
                string secondary = (numsArray.Length > 1) ? numsArray[1] : "";
                List<int> primaryList = primary.Split(' ', opts).Select(Int32.Parse).ToList();
                List<int> secondaryList = secondary.Split(' ', opts).Select(Int32.Parse).ToList();
                newRule = new Rule
                {
                    Number = ruleNumber,
                    Primary = primaryList,
                    Secondary = secondaryList
                };
            }

            return newRule;
        }

        public static string BuildStringFromRules(Rule[] rules, int currentRule, string currentStr, List<string> possibilities)
        {
            if (rules[currentRule].Character != '\0')
                return rules[currentRule].Character.ToString();

            string primaryStr = currentStr;
            foreach (var rule in rules[currentRule].Primary)
                primaryStr += BuildStringFromRules(rules, rule, primaryStr, possibilities);
            if (currentRule == 0)
                possibilities.Add(primaryStr);

            string secondaryStr = currentStr;
            foreach (var rule in rules[currentRule].Secondary)
                secondaryStr += BuildStringFromRules(rules, rule, secondaryStr, possibilities);
            if (currentRule == 0)
                possibilities.Add(secondaryStr);

            return "";
        }
    }
}