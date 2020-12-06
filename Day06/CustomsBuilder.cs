using System;
using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class CustomsBuilder
    {
        public List<HashSet<char>> CustomsData { get; private set; } = new List<HashSet<char>>();

        public void AddAnswersToGroup(string data)
        {
            HashSet<char> passengerAnswers = new HashSet<char>(data.ToCharArray());
            CustomsData.Add(passengerAnswers);
        }

        public CustomsForm CreateForm()
        {
            return new CustomsForm(CustomsData);
        }
    }
}