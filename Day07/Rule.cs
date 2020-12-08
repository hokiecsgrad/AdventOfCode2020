using System;
using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class Rule
    {
        public string Bag { get; private set; } = string.Empty;
        public Dictionary<string, int> Contains { get; private set; } = new Dictionary<string, int>();

        public Rule(string bag, Dictionary<string, int> contains)
        {
            Bag = bag;
            Contains = contains;
        }

        public bool CanHoldSpecificBag(string bag)
        {
            if (Contains.ContainsKey(bag))
                return true;
            else
                return false;
        }

        public int GetNumBags(string bag)
        {
            if (Contains.ContainsKey(bag))
                return Contains[bag];
            return 0;
        }
    }
}