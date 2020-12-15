using System;

namespace AdventOfCode.Day14
{
    public class BinaryNum
    {
        public string Number { get; private set; } = string.Empty;

        public BinaryNum(long number)
        {
            Number = Convert.ToString(number, 2).PadLeft(36, '0');
        }

        public long Mask(string mask)
        {
            string result = string.Empty;
            for (int i = 0; i < 36; i++)
                result += mask[i] == 'X' ? Number[i] : mask[i];

            return Convert.ToInt64(result, 2);
        }
    }
}