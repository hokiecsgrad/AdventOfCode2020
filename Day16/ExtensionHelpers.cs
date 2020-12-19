using System;

namespace AdventOfCode.Day16
{
    public static class ExtensionHelpers
    {
        public static bool IsWithin<T>(this T value, T minimum, T maximum) where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0)
                return false;
            if (value.CompareTo(maximum) > 0)
                return false;
            return true;
        }
    }
}