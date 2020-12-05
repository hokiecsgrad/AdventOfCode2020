using System.Text.RegularExpressions;

namespace AdventOfCode.Day4.Validators
{
    public static class ValidatorExtensions
    {
        public static IntValidator IsInt(this Validate validator)
        {
            return new IntValidator(validator.Value);
        }

        public static IntValidator IsAtLeast(this IntValidator validator, int min)
        {
            validator.Min = min;
            return validator;
        }

        public static IntValidator IsNoMoreThan(this IntValidator validator, int max)
        {
            validator.Max = max;
            return validator;
        }

        public static StringValidator IsString(this Validate validator)
        {
            return new StringValidator(validator.Value);
        }

        public static StringValidator LengthIsExactly(this StringValidator validator, int length)
        {
            validator.ExactLength = length;
            return validator;
        }

        public static StringValidator StartsWith(this StringValidator validator, char start)
        {
            validator.Begining = start;
            return validator;
        }

        public static StringValidator Matches(this StringValidator validator, Regex pattern)
        {
            validator.RegexPattern = pattern;
            return validator;
        }

        public static StringValidator IsOneOf(this StringValidator validator, string[] possibles)
        {
            validator.Possibles = possibles;
            return validator;
        }
    }
}