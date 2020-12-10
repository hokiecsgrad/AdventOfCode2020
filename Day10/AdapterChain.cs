using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class AdapterChain
    {
        public List<int> Adapters { get; private set; } = new List<int>();

        public AdapterChain(List<int> adapters)
        {
            Adapters = adapters;
        }

        public (int, int) GetJoltageDiffs()
        {
            Adapters.Sort();
            int adapterIndex = 1;
            int countOf1Diffs = 0;
            int countOf3Diffs = 0;
            int joltageDiff = Adapters[adapterIndex] - Adapters[adapterIndex-1];

            while (joltageDiff <= 3)
            {
                _ = joltageDiff switch
                {
                    1 => countOf1Diffs++,
                    3 => countOf3Diffs++,
                    _ => 0,
                };

                adapterIndex++;
                if (adapterIndex >= Adapters.Count) break;
                joltageDiff = Adapters[adapterIndex] - Adapters[adapterIndex-1];
            }

            return (countOf1Diffs, countOf3Diffs);
        }
    }
}