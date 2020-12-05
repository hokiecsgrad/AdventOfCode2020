using System;

namespace AdventOfCode.Day5
{
    public class BinaryTreeParser
    {
        private string Input { get; set; } = string.Empty;
        private char Lower { get; set; } = '\0';
        private char Upper { get; set; } = '\0';
        private int Size { get; set; } = 0;

        public BinaryTreeParser(string input, char lowerHalf, char upperHalf)
        {
            Input = input;
            Lower = lowerHalf;
            Upper = upperHalf;
            Size = (int)Math.Pow(2, Input.Length) - 1;
        }

        public int GetValue()
        {
            int currLower = 0;
            int currUpper = Size;
            for (int i = 0; i < Input.Length; i++)
            {
                if (Input[i] == Lower)
                    currUpper = currUpper - ((currUpper - currLower) / 2) - 1;
                else if (Input[i] == Upper)
                    currLower = currUpper - ((currUpper - currLower) / 2);
            }
            return currUpper;
        }
    }
}