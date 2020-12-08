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
            Dictionary<string, Dictionary<string, int>> rules = ParseRules(rulesData);

            foreach (string bag in rules.Keys)
            {
                bool bagContainsShinyGold = DoesBagContainShinyGold(rules, bag);
                if (bagContainsShinyGold) totalBags++;
            }

            Assert.Equal(4, totalBags);
        }

        private bool DoesBagContainShinyGold(Dictionary<string, Dictionary<string, int>> rules, string currentBag)
        {
            bool containsShinyGold = false;
            if (rules[currentBag].ContainsKey("shiny gold"))
                return true;
            else
            {
                foreach (string bag in rules[currentBag].Keys)
                    containsShinyGold |= DoesBagContainShinyGold(rules, bag);
            }
            return containsShinyGold;
        }

        private Dictionary<string, Dictionary<string, int>> ParseRules(string[] rulesData)
        {
            Dictionary<string, Dictionary<string, int>> rules = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < rulesData.Length; i++)
            {
                Rule rule = new RuleParser(rulesData[i]).CreateRule();
                rules.Add(rule.Bag, rule.Contains);
            }
            return rules;
        }

        [Fact]
        public void Part2_WithOriginalSampleInput_ShouldReturn32()
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
            Dictionary<string, Dictionary<string, int>> rules = ParseRules(rulesData);

            totalBags = CountNumBags(rules, "shiny gold");

            Assert.Equal(32, totalBags);
        }

        [Fact]
        public void Part2_WithNewSampleInput_ShouldReturn126()
        {
            string sampleInput = @"shiny gold bags contain 2 dark red bags.
                dark red bags contain 2 dark orange bags.
                dark orange bags contain 2 dark yellow bags.
                dark yellow bags contain 2 dark green bags.
                dark green bags contain 2 dark blue bags.
                dark blue bags contain 2 dark violet bags.
                dark violet bags contain no other bags.
                ";
            string[] rulesData = new List<string>(
                sampleInput.Split(Environment.NewLine,
                                    StringSplitOptions.TrimEntries |
                                    StringSplitOptions.RemoveEmptyEntries
                                    )
                )
                .ToArray();

            int totalBags = 0;
            Dictionary<string, Dictionary<string, int>> rules = ParseRules(rulesData);

            totalBags = CountNumBags(rules, "shiny gold");

            Assert.Equal(126, totalBags);
        }

        private int CountNumBags(Dictionary<string, Dictionary<string, int>> rules, string currentBag)
        {
            int totalBags = 0;

            if (rules[currentBag].Keys.Count == 0)
                return 0;

            foreach (string bag in rules[currentBag].Keys)
            {
                totalBags += rules[currentBag][bag] + (rules[currentBag][bag] * CountNumBags(rules, bag));
            }
            return totalBags;
        }

        [Fact]
        public void ParseSingleRule_WithNoContainingBags_ShouldReturnRuleWithEmptyList()
        {
            string input = "dotted black bags contain no other bags.";
            RuleParser parser = new RuleParser(input);

            Rule rule = parser.CreateRule();

            Assert.Equal("dotted black", rule.Bag);
            Assert.Empty(rule.Contains);
        }

        [Fact]
        public void ParseSingleRule_WithTwoContainingBags_ShouldReturnRuleWith2Bags()
        {
            string input = "light red bags contain 1 bright white bag, 2 muted yellow bags.";
            RuleParser parser = new RuleParser(input);

            Rule rule = parser.CreateRule();

            Assert.Equal("light red", rule.Bag);
            Assert.Equal(2, rule.Contains.Count);
            Assert.True(rule.Contains.ContainsKey("bright white"));
            Assert.True(rule.Contains.ContainsKey("muted yellow"));
        }

        [Fact]
        public void ParseSingleRule_WithTwoContainingBags_ShouldCaptureNumberOfBags()
        {
            string input = "light red bags contain 1 bright white bag, 2 muted yellow bags.";
            RuleParser parser = new RuleParser(input);

            Rule rule = parser.CreateRule();

            Assert.Equal(1, rule.GetNumBags("bright white"));
        }

        private bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);
    }
}