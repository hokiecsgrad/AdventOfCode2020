using System;
using System.Collections.Generic;
using Xunit;
using AdventOfCode.Day7;

namespace tests
{
    public class Day07Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn4()
        {
            string sampleInput = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
                dark orange bags contain 3 bright white bags, 4 muted yellow bags.
                bright white bags contain 1 shiny gold bag.
                muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
                shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                dark olive bags contain 3 faded blue bags, 4 dotted black bags.
                vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
                faded blue bags contain no other bags.
                dotted black bags contain no other bags.
                ";
            string[] rulesData = new List<string>(
                sampleInput.Split(Environment.NewLine, 
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();

            int totalBags = 0;
            Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
            for (int i = 0; i < rulesData.Length; i++)
            {
                Rule rule = new RuleParser(rulesData[i]).CreateRule();
                rules.Add(rule.Bag, rule.Contains);
            }

            foreach (string bag in rules.Keys)
            {
                bool bagContainsShinyGold = DoesBagContainShinyGold(rules, bag);
                if (bagContainsShinyGold) totalBags++;
            }

            Assert.Equal(4, totalBags);
        }

        private bool DoesBagContainShinyGold(Dictionary<string, List<string>> rules, string currentBag)
        {
            bool containsShinyGold = false;
            if (rules[currentBag].Contains("shiny gold"))
                return true;
            else
            {
                foreach (string bag in rules[currentBag])
                    return containsShinyGold || DoesBagContainShinyGold(rules, bag);
            }
            return false;
        }

        [Fact]
        public void ParseSingleRule_WithNoContainingBags_ShouldReturnRuleWithEmptyList()
        {
            string input = "dotted black bags contain no other bags.";
            RuleParser parser = new RuleParser(input);

            Rule rule = parser.CreateRule();

            Assert.Equal("dotted black", rule.Bag);
            Assert.Equal(0, rule.Contains.Count);
        }

        [Fact]
        public void ParseSingleRule_WithTwoContainingBags_ShouldReturnRuleWith2Bags()
        {
            string input = "light red bags contain 1 bright white bag, 2 muted yellow bags.";
            RuleParser parser = new RuleParser(input);

            Rule rule = parser.CreateRule();

            Assert.Equal("light red", rule.Bag);
            Assert.Equal(2, rule.Contains.Count);
            Assert.Equal("bright white", rule.Contains[0]);
            Assert.Equal("muted yellow", rule.Contains[1]);
        }

        private bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);
    }
}