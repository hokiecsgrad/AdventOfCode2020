using System;
using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class Rule
    {
        public string Bag { get; private set; } = string.Empty;
        public List<string> Contains { get; private set; } = new List<string>();

        public Rule(string bag, List<string> contains)
        {
            Bag = bag;
            Contains = contains;
        }

        public bool CanHoldSpecificBag(string bag)
        {
            if (Contains.Contains(bag))
                return true;
            else 
                return false;
        }
    }
}