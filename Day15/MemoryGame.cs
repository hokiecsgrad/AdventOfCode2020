using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day15
{
    public class MemoryGame
    {
        public List<long> StartingNumbers { get; private set; } = new List<long>();
        public Dictionary<long, int> NumbersLastSpoken { get; private set; } = new Dictionary<long, int>();

        public MemoryGame(List<long> startingNumbers)
        {
            StartingNumbers = startingNumbers;
        }

        public long Play(int numTurns)
        {
            for (int i = 0; i < StartingNumbers.Count - 1; i++)
                NumbersLastSpoken[StartingNumbers[i]] = i + 1;

            int turn = StartingNumbers.Count + 1;
            long lastNumber = StartingNumbers[StartingNumbers.Count - 1];
            long currNumber = 0;
            while (turn <= numTurns)
            {
                if (!NumbersLastSpoken.Keys.Contains(lastNumber))
                {
                    NumbersLastSpoken[lastNumber] = turn - 1;
                    currNumber = 0;
                }
                else
                {
                    int turnLastSpoken = NumbersLastSpoken[lastNumber];
                    currNumber = turn - 1 - turnLastSpoken;
                    NumbersLastSpoken[lastNumber] = turn - 1;
                }
                lastNumber = currNumber;
                turn++;
            }

            return currNumber;
        }
    }
}