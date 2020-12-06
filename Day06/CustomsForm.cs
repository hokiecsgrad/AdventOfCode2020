using System;
using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class CustomsForm
    {
        public List<HashSet<char>> CustomsData { get; private set; }

        public CustomsForm(List<HashSet<char>> data)
        {
            CustomsData = data;
        }

        public int GetAllAnswersInGroup()
        {
            HashSet<char> uniqueAnswers = new HashSet<char>();
            foreach (var passengerAnswers in CustomsData)
                uniqueAnswers.UnionWith(passengerAnswers);
            return uniqueAnswers.Count;
        }

        public int GetUniqueAnswersInGroup()
        {
            HashSet<char> uniqueAnswers = CustomsData[0];
            for (int i = 1; i < CustomsData.Count; i++)
                uniqueAnswers.IntersectWith(CustomsData[i]);
            return uniqueAnswers.Count;
        }
    }
}