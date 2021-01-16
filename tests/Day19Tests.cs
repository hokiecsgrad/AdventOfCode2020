using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day19;

namespace tests
{
    public class Day19Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn2()
        {
            string sampleInput = @"0: 4 1 5
                1: 2 3 | 3 2
                2: 4 4 | 5 5
                3: 4 5 | 5 4
                4: 'a'
                5: 'b'

                ababbb
                bababa
                abbbab
                aaabbb
                aaaabbb";
            string[] data = sampleInput.Split(
                                Environment.NewLine,
                                StringSplitOptions.TrimEntries
                                );
            int i = 0;
            List<Rule> rules = new();
            while (!string.IsNullOrEmpty(data[i]))
            {
                Rule rule = RuleParser.Parse(data[i]);
                rules.Add(rule);
            }
        }

        [Fact]
        public void RuleParser_WhenGivenStandardRuleText_ShouldReturnFullyFormedRule()
        {
            Rule rule = RuleParser.Parse("124: 77 91 | 77 77");
            Assert.Equal(124, rule.Number);
            Assert.Equal(new List<int> { 77, 91 }, rule.Primary);
            Assert.Equal(new List<int> { 77, 77 }, rule.Secondary);
        }

        [Fact]
        public void RuleParser_WhenGivenOneRuleText_ShouldReturnRuleWithOnlyPrimary()
        {
            Rule rule = RuleParser.Parse("8: 42");
            Assert.Equal(8, rule.Number);
            Assert.Equal(new List<int> { 42 }, rule.Primary);
            Assert.Equal(new List<int>(), rule.Secondary);
        }

        [Fact]
        public void Possibilities_WithSampleInput_ShouldReturn8PossibleStrings()
        {
            Rule[] rules = new Rule[6];
            rules[0] = new Rule { Number = 0, Primary = new List<int> { 4, 1, 5 } };
            rules[1] = new Rule { Number = 1, Primary = new List<int> { 2, 3 }, Secondary = new List<int> { 3, 2 } };
            rules[2] = new Rule { Number = 2, Primary = new List<int> { 4, 4 }, Secondary = new List<int> { 5, 5 } };
            rules[3] = new Rule { Number = 3, Primary = new List<int> { 4, 5 }, Secondary = new List<int> { 5, 4 } };
            rules[4] = new Rule { Number = 4, Character = 'a' };
            rules[5] = new Rule { Number = 5, Character = 'b' };
            List<string> possibilities = new();
            RuleParser.BuildStringFromRules(rules, 0, "", possibilities);
            Assert.Equal(8, possibilities.Count);
        }
    }
}
