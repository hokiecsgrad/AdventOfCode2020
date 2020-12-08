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
            Dictionary<string, Dictionary<string, int>> rules = new Dictionary<string, Dictionary<string, int>>();

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

        private static bool DoesBagContainShinyGold(Dictionary<string, Dictionary<string, int>> rules, string currentBag)
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

        public static void Part2(string[] data)
        {
            int totalBags = 0;
            Dictionary<string, Dictionary<string, int>> rules = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < data.Length; i++)
            {
                Rule rule = new RuleParser(data[i]).CreateRule();
                rules.Add(rule.Bag, rule.Contains);
            }

            totalBags = CountNumBags(rules, "shiny gold");

            Console.WriteLine($"The number of bags contained within a Shiny Gold bag is: {totalBags}.");
        }

        private static int CountNumBags(Dictionary<string, Dictionary<string, int>> rules, string currentBag)
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

    }
}
