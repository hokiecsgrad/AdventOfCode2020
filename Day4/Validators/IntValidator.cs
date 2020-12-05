using System;

namespace AdventOfCode.Day4.Validators
{
    public class IntValidator
    {
        public string Value { get; set; } = string.Empty;
        public int Min { get; set; } = int.MinValue;
        public int Max { get; set; } = int.MaxValue;

        public IntValidator(string value)
        {
            Value = value;
        }

        public bool Run()
        {
            bool isValid = true;
            int intValue = 0;

            try
            {
                intValue = int.Parse(Value);
                isValid = true;
            }
            catch
            {
                isValid = false;
            }

            isValid &= intValue >= Min;
            isValid &= intValue <= Max;

            return isValid;
        }

    }
}