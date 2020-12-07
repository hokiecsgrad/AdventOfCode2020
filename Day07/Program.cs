using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode.Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter("input.txt");

            ProgramFramework framework = new ProgramFramework();
            framework.InputHandler = input.GetStringsFromInput;
            framework.Part1Handler = Part1;
            framework.Part2Handler = Part2;
            framework.RunProgram();
        }

        public static void Part1(string[] data)
        {
            int totalBags = 0;
            Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();

            for (int i = 0; i < data.Length; i++)
            {
                Rule rule = new RuleParser(data[i]).CreateRule();
                rules.Add(rule.Bag, rule.Contains);
            }

            foreach (string bag in rules.Keys)
            {
                bool bagContainsShinyGold = DoesBagContainShinyGold(rules, bag);
                if (bagContainsShinyGold) totalBags++;
            }

            Console.WriteLine($"The number of bags that can contain a shiny gold bag are: {totalBags}.");
        }

        private static bool DoesBagContainShinyGold(Dictionary<string, List<string>> rules, string currentBag)
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

        public static void Part2(string[] data)
        {
        }
    }
}
