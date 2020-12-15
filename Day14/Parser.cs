using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day14
{
    public static class Parser
    {
        public static string GetMask(string data)
            => data.Split('=', StringSplitOptions.TrimEntries)[1];

        public static (long, long) GetMem(string data)
        {
            long memSlot = long.Parse(new Regex("^mem\\[([\\d]+)\\] ").Match(data).Groups[1].ToString());
            long value = long.Parse(data.Split('=', StringSplitOptions.TrimEntries)[1]);
            return (memSlot, value);
        }
    }
}